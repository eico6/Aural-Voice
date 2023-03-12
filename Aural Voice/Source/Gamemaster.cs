using System;
using System.Collections.Generic;
using System.Drawing.Design;
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
        private bool _roundOver = false;
        public bool roundOver
        {
            get { return _roundOver; }
            private set { _roundOver = value; }
        }

        /// <summary>
        ///  Current question's note index. 
        ///  Retrieves note element in 'Piano.notes' dictionary.
        /// </summary>
        private int _questionIndex;
        private int questionIndex
        {
            get { return _questionIndex; }
            set { _questionIndex = value; }
        }

        private int pianoLowerBound = 0;
        private int pianoUpperBound = 88;

        /// <summary>
        ///  References to controls for UI and game management.
        /// </summary>
        private readonly Piano? _piano;
        private readonly MaterialForm? _appWindow;
        private readonly MaterialButton? _buttonGame;
        private readonly MaterialButton? _buttonQuestion;
        private readonly MaterialCard? _noteDisplay;
        private readonly MaterialLabel? _noteDisplayText;
        private readonly MaterialLabel? _scoreAnswersLabel;
        private readonly MaterialLabel? _scoreCorrectLabel;
        private readonly MaterialLabel? _scoreCorrect;
        private readonly MaterialLabel? _scoreWrongLabel;
        private readonly MaterialLabel? _scoreWrong;
        private readonly MaterialLabel? _scoreTotalLabel;
        private readonly MaterialLabel? _scoreTotal;
        private readonly MaterialLabel? _scoreAccuracyLabel;
        private readonly MaterialLabel? _scoreAccuracy;
        private readonly MaterialLabel? _auralVoiceLabel;
        private readonly MaterialSlider? _noteSlider;
        private readonly MaterialLabel? _noteSliderValue;

        internal Gamemaster(ref Piano pianoIn, MaterialForm appWindowIn, ref MaterialButton buttonGameIn, ref MaterialButton buttonQuestionIn,
                            ref MaterialCard noteDisplayIn, ref MaterialLabel noteDisplayTextIn, ref MaterialLabel scoreAnswersLabelIn,
                            ref MaterialLabel scoreCorrectLabelIn, ref MaterialLabel scoreCorrectIn, ref MaterialLabel scoreWrongLabelIn,
                            ref MaterialLabel scoreWrongIn, ref MaterialLabel scoreTotalLabelIn, ref MaterialLabel scoreTotalIn,
                            ref MaterialLabel scoreAccuracyLabelIn, ref MaterialLabel scoreAccuracyIn, ref MaterialLabel auralVoiceLabelIn,
                            ref MaterialSlider noteSliderIn, ref MaterialLabel noteSliderValueIn)
        {
            // Assign UI control references.
            _piano              = pianoIn;
            _appWindow          = appWindowIn;
            _buttonGame         = buttonGameIn;
            _buttonQuestion     = buttonQuestionIn;
            _noteDisplay        = noteDisplayIn;
            _noteDisplayText    = noteDisplayTextIn;
            _scoreAnswersLabel  = scoreAnswersLabelIn;
            _scoreCorrectLabel  = scoreCorrectLabelIn;
            _scoreCorrect       = scoreCorrectIn;
            _scoreWrongLabel    = scoreWrongLabelIn;
            _scoreWrong         = scoreWrongIn;
            _scoreTotalLabel    = scoreTotalLabelIn;
            _scoreTotal         = scoreTotalIn;
            _scoreAccuracyLabel = scoreAccuracyLabelIn;
            _scoreAccuracy      = scoreAccuracyIn;
            _auralVoiceLabel    = auralVoiceLabelIn;
            _noteSlider         = noteSliderIn;
            _noteSliderValue    = noteSliderValueIn;
        }

        /// <summary>
        ///  Gamemaster version of the control 'buttonGame' click event.
        /// </summary>
        public void GM_buttonGame_Click()
        {
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
            if (isPlayMode)
            {
                if (_buttonQuestion != null)
                {
                    if (roundOver)
                    {
                        StartRound();
                    }
                    else if (!roundOver)
                    {
                        PlayQuestion();
                    }
                    ClearFocus();
                }
                else
                {
                    throw new NullReferenceException($"{this}._buttonQuestion = null");
                }
            }
        }

        /// <summary>
        ///  Try a note as an answer to the round's question.
        /// </summary>
        public bool TryAnswer(int noteIndex)
        {
            if (noteIndex == questionIndex)
            {
                CorrectAnswer();
                return true;
            }
            else
            {
                WrongAnswer();
                return false;
            }
        }

        /// <summary>
        ///  Plays the question related to the current round.
        /// </summary>
        private void PlayQuestion()
        {
            _piano.notes.ElementAt(questionIndex).Value.StopNote(true);
            _piano.notes.ElementAt(questionIndex).Value.PlayNote(true);
        }

        private void StartGame()
        {
            isPlayMode = true;

            ResetScore();
            UpdateUI();
            SetupPiano();
            StartRound();
        }

        private void EndGame()
        {
            isPlayMode = false;
            roundOver = false;

            SetupPiano();
            UpdateUI();
        }

        private void StartRound()
        {
            roundOver = false;
            RefreshPiano();
            questionIndex = new Random().Next(pianoLowerBound, pianoUpperBound);

            // Update UI func
            string? questionmark = "  ?  ";
            _buttonQuestion.Text = "REPLAY QUESTION";
            _buttonQuestion.UseAccentColor = false;
            SetNoteDisplayText(questionmark);
            GM_buttonQuestion_Click();
        }

        public void SetupPiano()
        {
            CalculateBounds();
            DisableNotes();
            RefreshPiano();
        }

        private void CalculateBounds()
        {
            int intValue;
            decimal decValue;
            int lowerDiff;
            int upperDiff;
            int middleNoteIndex;

            intValue = _noteSlider.Value;

            // Clamp the value to minimum 2.
            intValue = (intValue < 2) ? 2 : intValue;
            decValue = Convert.ToDecimal(intValue);

            lowerDiff = Convert.ToInt32(Math.Floor(decValue / 2));
            upperDiff = Convert.ToInt32(Math.Ceiling(decValue / 2));

            // Special case for 87 keys and above.
            middleNoteIndex = (intValue >= 87) ? 44 : 45;

            pianoLowerBound = middleNoteIndex - lowerDiff;
            pianoUpperBound = middleNoteIndex + upperDiff;

            var newValue = new StringBuilder();
            newValue.Append(Convert.ToString(intValue));
            newValue.Append(" Notes");
            _noteSliderValue.Text = Convert.ToString(newValue);
        }

        private void DisableNotes()
        {
            // Disable lower bound notes.
            for (int i = 0; i < pianoLowerBound; i++)
            {
                _piano.notes.ElementAt(i).Value.DisableNote();
            }

            // Disable upper bound notes.
            for (int i = pianoUpperBound; i < 88; i++)
            {
                _piano.notes.ElementAt(i).Value.DisableNote();
            }
        }

        private void RefreshPiano()
        {
            _piano.UpdateIsPianoActive();

            // Enable active notes.
            for (int i = pianoLowerBound; i < pianoUpperBound; i++)
            {
                _piano.notes.ElementAt(i).Value.EnableNote();
            }
        }

        private void EndRound()
        {
            roundOver = true;
            _piano.UpdateIsPianoActive();

            // Update UI func
            string? questionName = _piano.notes.ElementAt(questionIndex).Value.name;
            _buttonQuestion.Text = "NEXT QUESTION";
            _buttonQuestion.UseAccentColor = true;
            SetNoteDisplayText(questionName);
        }

        /// <summary>
        ///  Question answered correctly.
        /// </summary>
        private void CorrectAnswer()
        {
            // Stop playing the question note.
            _piano.notes.ElementAt(questionIndex).Value.StopNote(true);

            // Update amount of correct answers.
            int newScore = Convert.ToInt32(_scoreCorrect.Text) + 1;
            _scoreCorrect.Text = Convert.ToString(newScore);

            UpdateScoreboard();
            EndRound();
        }

        /// <summary>
        ///  Question answered wrong.
        /// </summary>
        private void WrongAnswer()
        {
            // Update amount of wrong answers.
            int newScore = Convert.ToInt32(_scoreWrong.Text) + 1;
            _scoreWrong.Text = Convert.ToString(newScore);

            UpdateScoreboard();
        }

        /// <summary>
        ///  Calculates and updates the scoreboard with new values.
        /// </summary>
        private void UpdateScoreboard()
        {
            int scoreCorrect;
            int scoreWrong;
            int newTotal;
            double newAccuracy;

            // Retrieve score data in the form of integers.
            scoreCorrect = Convert.ToInt32(_scoreCorrect.Text);
            scoreWrong = Convert.ToInt32(_scoreWrong.Text);

            // Calculate the new total and accuracy.
            newTotal = scoreCorrect + scoreWrong;
            newAccuracy = (Convert.ToDouble(scoreCorrect) / Convert.ToDouble(newTotal)) * 100d;
            newAccuracy = Math.Round(newAccuracy, 2);

            // UI Update
            _scoreTotal.Text = Convert.ToString(newTotal);
            _scoreAccuracy.Text = Convert.ToString(newAccuracy) + '%';
        }

        /// <summary>
        ///  Set '_noteDisplayText' to a new string.
        /// </summary>
        public void SetNoteDisplayText(string newText)
        {
            _noteDisplayText.Text = newText;
        }

        /// <summary>
        ///  Resets the scoreboard do default values.
        /// </summary>
        private void ResetScore()
        {
            _scoreCorrect.Text  = "0";
            _scoreWrong.Text    = "0";
            _scoreTotal.Text    = "0";
            _scoreAccuracy.Text = "0%";
        }

        /// <summary>
        ///  Hide/unhide UI elements according to 'isPlayMode'.
        /// </summary>
        private void UpdateUI()
        {
            if (_buttonGame == null) { throw new NullReferenceException($"{this}._buttonGame = null"); }
            if (_noteDisplay == null) { throw new NullReferenceException($"{this}._noteDisplay = null"); }
            if (_noteDisplayText == null) { throw new NullReferenceException($"{this}._noteDisplayText = null"); }
            if (_buttonQuestion == null) { throw new NullReferenceException($"{this}._buttonQuestion = null"); }

            if (isPlayMode)
            {
                _buttonGame.Text = "STOP";
                _buttonGame.UseAccentColor = false;

                _buttonQuestion.Visible = true;
                
                _auralVoiceLabel.Visible = false;
                _noteSlider.Visible      = false;
                _noteSliderValue.Visible = false;

                SetScoreVisibility(true);
            }
            else if (!isPlayMode)
            {
                _buttonGame.Text = "START";
                _buttonGame.UseAccentColor = true;
                SetNoteDisplayText("");

                _buttonQuestion.Visible = false;

                _auralVoiceLabel.Visible = true;
                _noteSlider.Visible      = true;
                _noteSliderValue.Visible = true;

                SetScoreVisibility(false);
            }
        }

        private void SetScoreVisibility(bool visibility)
        {
            _scoreAnswersLabel.Visible  = visibility;
            _scoreCorrectLabel.Visible  = visibility;
            _scoreCorrect.Visible       = visibility;
            _scoreWrongLabel.Visible    = visibility;
            _scoreWrong.Visible         = visibility;
            _scoreTotalLabel.Visible    = visibility;
            _scoreTotal.Visible         = visibility;
            _scoreAccuracyLabel.Visible = visibility;
            _scoreAccuracy.Visible      = visibility;
        }

        /// <summary>
        ///  Sets the focus to '_noteDisplayText'.
        ///  - Focus is whenever a control is highlighted and recieves keyboard inputs.
        ///  - This focus is, by default, set to the latest control clicked by the user.
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
