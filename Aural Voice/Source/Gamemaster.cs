using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;

namespace AuralVoice
{
    internal class Gamemaster
    {
        /// <summary>
        ///  When play mode is active, then the game loop is ongoing.
        ///  Questions are asked, and user can answer.
        /// </summary>
        private static bool _isPlayMode = false;
        public static bool isPlayMode
        {
            get { return _isPlayMode; }
            private set { _isPlayMode = value; }
        }

        /// <summary>
        ///  When round over is active, the user can procceed to next question.
        ///  One question is equal to one round.
        /// </summary>
        private static bool _roundOver = false;
        public static bool roundOver
        {
            get { return _roundOver; }
            private set { _roundOver = value; }
        }

        /// <summary>
        ///  References to controls for UI and game management.
        /// </summary>
        private readonly MaterialForm? _appWindow;
        private readonly MaterialButton? _buttonGame;
        private readonly MaterialButton? _buttonQuestion;
        private readonly MaterialCard? _noteDisplay;
        private readonly MaterialLabel? _noteDisplayText;

        internal Gamemaster(MaterialForm appWindowIn, ref MaterialButton buttonGameIn, ref MaterialButton buttonQuestionIn,
                            ref MaterialCard noteDisplayIn, ref MaterialLabel noteDisplayTextIn)
        {
            // Assign control references.
            _appWindow = appWindowIn;
            _buttonGame = buttonGameIn;
            _buttonQuestion = buttonQuestionIn;
            _noteDisplay = noteDisplayIn;
            _noteDisplayText = noteDisplayTextIn;
        }

        /// <summary>
        ///  Gamemaster version of the control 'buttonGame' click event.
        /// </summary>
        public void GM_buttonGame_Click()
        {
            // Insert function to do all exception testing in one go here.

            if (_buttonGame != null)
            {
                if (isPlayMode)
                {
                    EndGame();
                }
                else if (!isPlayMode)
                {
                    StartGame();
                }
                ClearFocus();
            }
            else
            {
                throw new NullReferenceException($"{this}._buttonGame = null");
            }
        }

        /// <summary>
        ///  Gamemaster version of the control 'buttonQuestion' click event.
        /// </summary>
        public void GM_buttonQuestion_Click()
        {
            if (_buttonQuestion != null)
            {
                if (roundOver)
                {
                    StartRound();
                }
                else if (!roundOver)
                {
                    MessageBox.Show("Played note ...");
                }
                ClearFocus();
            }
            else
            {
                throw new NullReferenceException($"{this}._buttonQuestion = null");
            }
        }

        public void StartGame()
        {
            isPlayMode = true;
            // ResetScore();
            AlterUI();
            StartRound();
        }

        public void EndGame()
        {
            isPlayMode = false;
            AlterUI();
        }

        public void StartRound()
        {
            roundOver = false;
            _buttonQuestion.Text = "REPLAY QUESTION";
            _buttonQuestion.UseAccentColor = false;
            _noteDisplayText.Text = "  ?  ";
        }

        public void EndRound()
        {
            roundOver = true;
            _buttonQuestion.Text = "NEXT QUESTION";
            _buttonQuestion.UseAccentColor = true;
            _noteDisplayText.Text = "Ab4"; // Correct note
        }

        /// <summary>
        ///  Hide/unhide and translate UI elements according to 'isPlayMode'.
        /// </summary>
        private void AlterUI()
        {
            if (_buttonGame == null) { throw new NullReferenceException($"{this}._buttonGame = null"); }
            if (_noteDisplay == null) { throw new NullReferenceException($"{this}._noteDisplay = null"); }
            if (_noteDisplayText == null) { throw new NullReferenceException($"{this}._noteDisplayText = null"); }
            if (_buttonQuestion == null) { throw new NullReferenceException($"{this}._buttonQuestion = null"); }

            if (isPlayMode)
            {
                _buttonGame.Text = "STOP";
                //_buttonGame.Location = new Point(383, 186);
                _buttonGame.UseAccentColor = false;
                _noteDisplay.Visible = true;
                _buttonQuestion.Visible = true;
            }
            else if (!isPlayMode)
            {
                _buttonGame.Text = "START";
                //_buttonGame.Location = new Point(383, 120);
                _buttonGame.UseAccentColor = true;
                _noteDisplayText.Text = "";
                _noteDisplay.Visible = false;
                _buttonQuestion.Visible = false;
            }
        }

        /// <summary>
        ///  Sets the focus to '_noteDisplayText'.
        ///  - Focus is whenever a control is highlighted and recieves keyboard inputs.
        ///  - This focus is by default set to the latest control clicked by the user.
        ///  - This function's goal is therefore to clear/reset that focus to an 
        ///    "uninteractive" control, which happens to be a 'MaterialLabel' class.
        /// </summary>
        private void ClearFocus()
        {
            if (_appWindow == null) { throw new NullReferenceException($"{this}._appWindow = null"); }
            if (_noteDisplayText == null) { throw new NullReferenceException($"{this}._noteDisplayText = null"); }

            _appWindow.ActiveControl = _noteDisplayText;
        }
    }
}
