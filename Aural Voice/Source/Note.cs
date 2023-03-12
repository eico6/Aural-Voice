using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Midi;
using Windows.UI.Notifications;

namespace AuralVoice;

internal partial class Piano
{
    /// <summary>
    ///  Contained in Piano and recieves input from the associated key.
    /// </summary>
    internal class Note
    {
        /// <summary>
        ///  Holds the note's name. E.g. "Ab4".
        /// </summary>
        private readonly String? _name;
        public String? name
        {
            get => _name;
        }

        private static int _indexCounter = 0;
        private readonly int _noteIndex;
        private readonly PictureBox _associatedKey;
        private readonly byte _midiIndex;
        private readonly bool _isBlack;
        private IMidiMessage? _midiMessage;
        private KeyStatus? _keyStatus;

        private QuestionStatus _questionStatus = QuestionStatus.STANDBY;
        public QuestionStatus questionStatus
        {
            get => _questionStatus;
            set => _questionStatus = value;
        }

        /// <summary>
        ///  Handles user input logic for overlapping calls.
        /// </summary>
        private bool _isPlayingNote = false;
        private ActionCaller? _prevCaller;

        internal Note(in String noteName, ref PictureBox keyRef)
        {
            _name = noteName;
            _associatedKey = keyRef;
            _midiIndex = GetMidiIndex();
            _isBlack = _name.Contains('b') ? true : false;

            // Sets this note's index, corresponding to its 'Piano.notes' placement.
            _noteIndex = _indexCounter;
            _indexCounter++;
        }

        /// <summary>
        ///  Specifies the caller of a KeyAction to prevent overlapping inputs.
        /// </summary>
        internal enum ActionCaller : Byte
        {
            MOUSE = 0,
            KEYBOARD = 1
        }

        /// <summary>
        ///  All user input related to the keys, either via mouse events, or the use of hotkeys.
        /// </summary>
        internal enum KeyAction : Byte
        {
            ENTER = 0,
            LEAVE = 1,
            DOWN = 2,
            UP = 3
        }

        /// <summary>
        ///  Determines which one of the three possible key images should be displayed. 
        /// </summary>
        private enum KeyStatus : Byte
        {
            IDLE = 0,
            HOVER = 1,
            PRESS = 2
        }

        /// <summary>
        ///  Three possible note conditions during questioning.
        ///  - STANDBY = Can be used as an answer to the round's question.
        ///  - RED     = Was previously used as a wrong answer to a question.
        ///  - GREEN   = Was previously used as a correct answer to a question.
        /// </summary>
        public enum QuestionStatus : Byte
        {
            STANDBY = 0,
            RED = 1,
            GREEN = 2
        }

        /// <summary>
        ///  Send a midi signal to start playing this note.
        /// </summary>
        internal void PlayNote(bool isGameMaster = false)
        {
            // if (the user is not being asked questions || the call was made by the game master)
            if (!Gamemaster.isPlayMode || isGameMaster)
            {
                // if (this note is not already being played && the piano is active)
                if (!_isPlayingNote && Piano.isActive)
                {
                    if (s_midiDevice != null)
                    {
                        _midiMessage = new MidiNoteOnMessage(Piano.defaultChannel, _midiIndex, Piano.volume);
                        s_midiDevice.SendMessage(_midiMessage);
                        _isPlayingNote = true;
                    } else { throw new NullReferenceException($"{this}.midiDevice = null."); }
                }
            } 
            else if (Gamemaster.isPlayMode)
            {
                // if (this note has not been answered yet this round)
                if (questionStatus == QuestionStatus.STANDBY)
                {
                    gamemasterRef.TryAnswer(_noteIndex);
                }
            }
        }

        /// <summary>
        ///  Send a midi signal to stop playing this note.
        /// </summary>
        internal void StopNote(bool isGameMaster = false)
        {
            // if (the user is not being asked questions || the call was made by the game master)
            if (!Gamemaster.isPlayMode || isGameMaster)
            {
                // if (this note is currently being played)
                if (_isPlayingNote)
                {
                    if (s_midiDevice != null)
                    {
                        _midiMessage = new MidiNoteOffMessage(Piano.defaultChannel, _midiIndex, Piano.volume);
                        s_midiDevice.SendMessage(_midiMessage);
                        _isPlayingNote = false;
                    } else { throw new NullReferenceException($"{this}.midiDevice = null"); }
                }
            }
        }

        /// <summary>
        ///  Handles output of key/note based on <paramref name="keyAction"/> and <paramref name="actionCaller"/>.
        /// </summary>
        internal void ActionInput(in KeyAction keyAction, in ActionCaller actionCaller = ActionCaller.MOUSE)
        {
            if (Piano.isActive)
            {
                // If input was made via mouse.
                if (actionCaller == ActionCaller.MOUSE)
                {
                    // Don't run if the note is already playing and if that call was made via keyboard.
                    if (!(_isPlayingNote && _prevCaller == ActionCaller.KEYBOARD))
                    {
                        MouseInput(keyAction);
                        _prevCaller = ActionCaller.MOUSE;
                    }
                }

                // If input was made via keyboard.
                if (actionCaller == ActionCaller.KEYBOARD)
                {
                    // Don't run if the note is already playing and if that call was made via mouse.
                    if (!(_isPlayingNote && _prevCaller == ActionCaller.MOUSE))
                    {
                        KeyboardInput(keyAction);
                        _prevCaller = ActionCaller.KEYBOARD;
                    }
                }
            }

        }

        /// <summary>
        ///  Performs audiovisual output of key/note, from mouse input. 
        /// </summary>
        private void MouseInput(in KeyAction keyAction)
        {
            switch (keyAction)
            {
                case KeyAction.ENTER:
                    _keyStatus = KeyStatus.HOVER;
                    break;
                case KeyAction.LEAVE:
                    _keyStatus = KeyStatus.IDLE;
                    break;
                case KeyAction.DOWN:
                    _keyStatus = KeyStatus.PRESS;
                    PlayNote();
                    break;
                case KeyAction.UP:
                    _keyStatus = KeyStatus.HOVER;
                    StopNote();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
            }

            UpdateKeyImage();
        }

        /// <summary>
        ///  Performs audiovisual output of key/note, from keyboard input. 
        /// </summary>
        private void KeyboardInput(in KeyAction keyAction)
        {
            switch (keyAction)
            {
                case KeyAction.DOWN:
                    _keyStatus = KeyStatus.PRESS;
                    PlayNote();
                    break;
                case KeyAction.UP:
                    _keyStatus = KeyStatus.IDLE;
                    StopNote();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
            }

            UpdateKeyImage();
        }

        /// <summary>
        ///  Updates the displayed image of the associated key based on its '_keyStatus'.
        /// </summary>
        private void UpdateKeyImage()
        {
            switch (_keyStatus)
            {
                case KeyStatus.IDLE:
                    _associatedKey.Image = _isBlack ? s_keyImages["idle_black"] : s_keyImages["idle_white"];
                    break;
                case KeyStatus.HOVER:
                    _associatedKey.Image = _isBlack ? s_keyImages["hover_black"] : s_keyImages["hover_white"];
                    break;
                case KeyStatus.PRESS:
                    _associatedKey.Image = _isBlack ? s_keyImages["press_black"] : s_keyImages["press_white"];
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Enum KeyStatus '{_keyStatus}' is not accounted for.");
            }
        }

        /// <summary>
        ///  Sets the displayed image of the associated key to its idle 's_keyImages'.
        /// </summary>
        public void ResetKeyImage()
        {
            if (gamemasterRef.roundOver)
            {
                if (_keyStatus == KeyStatus.HOVER || _keyStatus == KeyStatus.PRESS)
                {
                    _associatedKey.Image = _isBlack ? s_keyImages["idle_black"] : s_keyImages["idle_white"];
                }
            } 
            else if (!gamemasterRef.roundOver)
            {
                _associatedKey.Image = _isBlack ? s_keyImages["idle_black"] : s_keyImages["idle_white"];
            }
        }

        /// <summary>
        ///  Calculates and returns a midi message note index based on 'Note._name'.
        /// </summary>
        private byte GetMidiIndex()
        {
            /// <Summary>
            /// Midi message note index:
            /// - Index range  (0 - 127)
            /// - Lowest note  (21 = A0)
            /// - Highest note (108 = C8)
            /// 
            ///  Return: 12 + (sum of each char in 'this._name'), where their values are the following:
            ///  '0' = 0     'C' = 0    
            ///  '1' = 12    'D' = 2    
            ///  '2' = 24    'E' = 4    
            ///  '3' = 36    'F' = 5    
            ///  '4' = 48    'G' = 7    
            ///  '5' = 60    'A' = 9
            ///  '6' = 72    'B' = 11   
            ///  '7' = 84    'b' = -1
            ///  '8' = 96
            ///  Example: _name = "Eb4" would be equal to (12 + 4 + (-1) + 48) = 63
            /// </Summary>

            if (_name != null)
            {
                byte calculatedIndex = 12;

                for (int i = 0; i < _name.Length; i++)
                {
                    switch (_name[i])
                    {
                        case 'C':
                            calculatedIndex += 0;
                            break;
                        case 'D':
                            calculatedIndex += 2;
                            break;
                        case 'E':
                            calculatedIndex += 4;
                            break;
                        case 'F':
                            calculatedIndex += 5;
                            break;
                        case 'G':
                            calculatedIndex += 7;
                            break;
                        case 'A':
                            calculatedIndex += 9;
                            break;
                        case 'B':
                            calculatedIndex += 11;
                            break;
                        case 'b':
                            calculatedIndex -= 1;
                            break;
                        case '0':
                            calculatedIndex += 0;
                            break;
                        case '1':
                            calculatedIndex += 12;
                            break;
                        case '2':
                            calculatedIndex += 24;
                            break;
                        case '3':
                            calculatedIndex += 36;
                            break;
                        case '4':
                            calculatedIndex += 48;
                            break;
                        case '5':
                            calculatedIndex += 60;
                            break;
                        case '6':
                            calculatedIndex += 72;
                            break;
                        case '7':
                            calculatedIndex += 84;
                            break;
                        case '8':
                            calculatedIndex += 96;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"Char '{_name[i]}' is not accounted for.");
                    }
                }

                return calculatedIndex;
            } 
            else
            {
                throw new NullReferenceException($"{this}._name = null");
            }
        }
    }

}
