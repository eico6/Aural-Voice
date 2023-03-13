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
using static AuralVoice.Piano.Note;

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
        private String? _name;
        public String? name
        {
            get { return _name; }
            private set { _name = value; }
        }

        /// <summary>
        ///  Determines whether this note recieves input or not.
        /// </summary>
        private bool _isNoteActive = true;
        private bool isNoteActive
        {
            get { return _isNoteActive; }
            set { _isNoteActive = value; }
        }

        /// <summary>
        ///  Incremented by 1 for each new note.
        ///  Keeps track of how many notes there are.
        /// </summary>
        private static int _indexCounter = 0;
        private static int indexCounter
        {
            get { return _indexCounter; }
            set { _indexCounter = value; }
        }

        /// <summary>
        ///  Index position of this note related to the order
        ///  notes were added into the 'Piano.Notes' dictionary.
        /// </summary>
        private readonly int _noteIndex;
        private int noteIndex
        {
            get { return _noteIndex; }
        }

        /// <summary>
        ///  Reference to the visual representation of the note.
        /// </summary>
        private PictureBox? _associatedKey;
        private PictureBox? associatedKey
        {
            get { return _associatedKey; }
            set { _associatedKey = value; }
        }

        /// <summary>
        ///  Midi message note index
        /// </summary>
        private byte _midiIndex;
        private byte midiIndex
        {
            set { _midiIndex = value; }
            get { return _midiIndex; }
        }

        /// <summary>
        ///  Determines whether this note is a black key.
        /// </summary>
        private bool _isBlack;
        private bool isBlack
        {
            get { return _isBlack; }
            set { _isBlack = value; }
        }

        /// <summary>
        ///  Contains data for messages sent to the midi device.
        /// </summary>
        private IMidiMessage? _midiMessage;
        private IMidiMessage? midiMessage
        {
            get { return _midiMessage; }
            set { _midiMessage = value; }
        }
        
        /// <summary>
        ///  Determines the status of this note's corresponding key.
        /// </summary>
        private KeyStatus? _keyStatus;
        private KeyStatus? keyStatus
        {
            get { return _keyStatus; }
            set { _keyStatus = value; }
        }

        /// <summary>
        ///  Determines whether this note as been answered as a question.
        ///  - Default: STANDBY
        ///  - Wrong:   RED
        ///  - Correct: GREEN
        /// </summary>
        private QuestionStatus _questionStatus = QuestionStatus.STANDBY;
        private QuestionStatus questionStatus
        {
            get { return _questionStatus; }
            set { _questionStatus = value; }
        }

        /// <summary>
        ///  Handles user input logic for overlapping calls.
        /// </summary>
        private bool _isPlayingNote = false;
        private bool isPlayingNote
        {
            get { return _isPlayingNote; }
            set { _isPlayingNote = value; }
        }

        /// <summary>
        ///  Keeps that of previous ActionCaller.
        ///  Used to prevent overlapping inputs.
        /// </summary>
        private ActionCaller? _prevCaller;
        private ActionCaller? prevCaller
        {
            get { return _prevCaller; }
            set { _prevCaller = value; }
        }

        internal Note(in String nameIn, ref PictureBox keyIn)
        {
            name          = nameIn;
            associatedKey = keyIn;
            midiIndex     = GetMidiIndex();
            isBlack       = name.Contains('b') ? true : false;

            // Sets this note's index, corresponding to its 'Piano.notes' placement.
            _noteIndex = Note.indexCounter;
            Note.indexCounter++;
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
        ///  Determines which one of the six possible key images should be displayed. 
        /// </summary>
        private enum KeyStatus : Byte
        {
            IDLE = 0,
            HOVER = 1,
            PRESS = 2,
            WRONG = 3,
            CORRECT = 4,
            DISABLED = 5
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
        ///  Send a midi message to start playing this note.
        /// </summary>
        internal void PlayNote(bool isGameMaster = false)
        {
            // if (this note is active)
            if (isNoteActive)
            {
                _gamemasterRef.UpdateNoteDisplay(name);

                // if (the user is not being asked questions ||
                //     the call was made by the game master)
                if (!Gamemaster.isPlayMode || isGameMaster)
                {
                    // if (this note is not already being
                    //     played && the piano is active)
                    if (!isPlayingNote && Piano.isActive)
                    {
                        if (Piano.midiDevice == null) throw new NullReferenceException($"{this}.midiDevice = null.");

                        // Send "note on" midi message with note data.
                        midiMessage = new MidiNoteOnMessage(Piano.defaultChannel, midiIndex, Piano.volume);
                        Piano.midiDevice.SendMessage(midiMessage);
                        isPlayingNote = true;
                    }
                } 
                // else if (the user is being asked questions)
                else if (Gamemaster.isPlayMode)
                {
                    // if (this note has not been answered yet this round)
                    if (questionStatus == QuestionStatus.STANDBY)
                    {
                        bool isCorrectAnswer;

                        // Determines whether the note was correct or wrong.
                        isCorrectAnswer = gamemasterRef.TryAnswer(noteIndex);
                        keyStatus = (isCorrectAnswer) ? KeyStatus.CORRECT : KeyStatus.WRONG;
                        UpdateKeyImage();
                    }
                }
            }
        }

        /// <summary>
        ///  Send a midi message to stop playing this note.
        /// </summary>
        internal void StopNote(bool isGameMaster = false)
        {
            // if (the user is not being asked questions ||
            //     the call was made by the game master)
            if (!Gamemaster.isPlayMode || isGameMaster)
            {
                // if (this note is currently being played)
                if (isPlayingNote)
                {
                    if (Piano.midiDevice == null) throw new NullReferenceException($"{this}.midiDevice = null");

                    // Send "note off" midi message with note data.
                    midiMessage = new MidiNoteOffMessage(Piano.defaultChannel, midiIndex, Piano.volume);
                    Piano.midiDevice.SendMessage(midiMessage);
                    isPlayingNote = false;
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
                // If in play mode, let all input be registered, regardless of ActionCaller.
                if (Gamemaster.isPlayMode)
                {
                    if (actionCaller == ActionCaller.MOUSE) MouseInput(keyAction);
                    if (actionCaller == ActionCaller.KEYBOARD) KeyboardInput(keyAction);
                }
                else
                {
                    // If input was made via mouse.
                    if (actionCaller == ActionCaller.MOUSE)
                    {
                        // Don't run if the note is already playing and if that call
                        // was made via keyboard. This is to prevent overlapping notes.
                        if (!(isPlayingNote && prevCaller == ActionCaller.KEYBOARD))
                        {
                            MouseInput(keyAction);
                            prevCaller = ActionCaller.MOUSE;
                        }
                    }

                    // If input was made via keyboard.
                    if (actionCaller == ActionCaller.KEYBOARD)
                    {
                        // Don't run if the note is already playing and if that call
                        // was made via mouse. This is to prevent overlapping notes.
                        if (!(isPlayingNote && prevCaller == ActionCaller.MOUSE))
                        {
                            KeyboardInput(keyAction);
                            prevCaller = ActionCaller.KEYBOARD;
                        }  
                    }
                }
            }
        }

        /// <summary>
        ///  Handles user input made via mouse events.
        /// </summary>
        private void MouseInput(in KeyAction keyAction)
        {
            switch (keyAction)
            {
                case KeyAction.ENTER:
                    keyStatus = KeyStatus.HOVER;
                    _gamemasterRef.UpdateNoteDisplay(name);
                    break;
                case KeyAction.LEAVE:
                    keyStatus = KeyStatus.IDLE;
                    _gamemasterRef.UpdateNoteDisplay();
                    break;
                case KeyAction.DOWN:
                    keyStatus = KeyStatus.PRESS;
                    PlayNote();
                    break;
                case KeyAction.UP:
                    keyStatus = KeyStatus.HOVER;
                    StopNote();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
            }

            UpdateKeyImage();
        }

        /// <summary>
        ///  Handles user input made via hotkey events.
        /// </summary>
        private void KeyboardInput(in KeyAction keyAction)
        {
            switch (keyAction)
            {
                case KeyAction.DOWN:
                    keyStatus = KeyStatus.PRESS;
                    PlayNote();
                    break;
                case KeyAction.UP:
                    _gamemasterRef.UpdateNoteDisplay();
                    keyStatus = KeyStatus.IDLE;
                    StopNote();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
            }

            UpdateKeyImage();
        }

        /// <summary>
        ///  Updates the displayed image of the associated key based on its 'keyStatus'.
        /// </summary>
        private void UpdateKeyImage()
        {
            if (isNoteActive)
            {
                // if (note has note been answered as a question)
                if (questionStatus == QuestionStatus.STANDBY)
                {
                    switch (keyStatus)
                    {
                        case KeyStatus.IDLE:
                            associatedKey.Image = isBlack ? Piano.keyImages["idle_black"] : Piano.keyImages["idle_white"];
                            break;
                        case KeyStatus.HOVER:
                            associatedKey.Image = isBlack ? Piano.keyImages["hover_black"] : Piano.keyImages["hover_white"];
                            break;
                        case KeyStatus.PRESS:
                            associatedKey.Image = isBlack ? Piano.keyImages["press_black"] : Piano.keyImages["press_white"];
                            break;
                        case KeyStatus.WRONG:
                            associatedKey.Image = isBlack ? Piano.keyImages["red_black"] : Piano.keyImages["red_white"];
                            questionStatus = QuestionStatus.RED;
                            break;
                        case KeyStatus.CORRECT:
                            associatedKey.Image = isBlack ? Piano.keyImages["green_black"] : Piano.keyImages["green_white"];
                            questionStatus = QuestionStatus.GREEN;
                            break;
                        case KeyStatus.DISABLED:
                            associatedKey.Image = isBlack ? Piano.keyImages["disabled_black"] : Piano.keyImages["disabled_white"];
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"Enum KeyStatus '{keyStatus}' is not accounted for.");
                    }
                }
            }
        }

        /// <summary>
        ///  Enables this note and reset
        ///  it to its default values
        /// </summary>
        public void EnableNote()
        {
            isNoteActive = true;

            ResetStatus();
            UpdateKeyImage();
            StopNote(true);
        }

        /// <summary>
        ///  Disables this note and
        ///  make it uninteractable.
        /// </summary>
        public void DisableNote()
        {
            keyStatus = KeyStatus.DISABLED;

            UpdateKeyImage();
            StopNote(true);
            isNoteActive = false;
        }

        /// <summary>
        ///  Reset this note's 'questionStatus'
        ///  and 'keyStatus' to default values.
        /// </summary>
        private void ResetStatus()
        {
            questionStatus = QuestionStatus.STANDBY;
            keyStatus = KeyStatus.IDLE;
        }

        /// <summary>
        ///  Calculates and returns a midi message note index based on 'Note.name'.
        /// </summary>
        private byte GetMidiIndex()
        {
            /// <Summary>
            /// Midi message note index:
            /// - Index range  (0 - 127)
            /// - Lowest note  (21 = A0)
            /// - Highest note (108 = C8)
            /// 
            ///  Return: 12 + (sum of each char in 'this.name'), where their values are the following:
            ///  '0' = 0     'C' = 0    
            ///  '1' = 12    'D' = 2    
            ///  '2' = 24    'E' = 4    
            ///  '3' = 36    'F' = 5    
            ///  '4' = 48    'G' = 7    
            ///  '5' = 60    'A' = 9
            ///  '6' = 72    'B' = 11   
            ///  '7' = 84    'b' = -1
            ///  '8' = 96
            ///  Example: name = "Eb4" would be equal to (12 + 4 + (-1) + 48) = 63
            /// </Summary>

            if (name == null) throw new NullReferenceException($"{this}.name = null");

            byte calculatedIndex = 12;

            for (int i = 0; i < name.Length; i++)
            {
                switch (name[i])
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
                        throw new ArgumentOutOfRangeException($"Char '{name[i]}' is not accounted for.");
                }
            }

            return calculatedIndex;
        }
    }
}
