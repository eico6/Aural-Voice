using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MaterialSkin.Controls;
using static AuralVoice.AppWindow;

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
        ///  When active, the user can procceed to next the question.
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

        /// <summary>
        ///  Determines the lower bound of active keys.
        /// </summary>
        private int _pianoLowerBound = 0;
        private int pianoLowerBound
        {
            get { return _pianoLowerBound; }
            set { _pianoLowerBound = value; }
        }

        /// <summary>
        ///  Determines the upper bound of active keys.
        /// </summary>
        private int _pianoUpperBound = 88;
        private int pianoUpperBound
        {
            get { return _pianoUpperBound; }
            set { _pianoUpperBound = value; }
        }

        /// <summary>
        ///  Determines the amount of questions answered correctly.
        /// </summary>
        private int _correctAnswers = 0;
        private int correctAnswers
        {
            get { return _correctAnswers; }
            set { _correctAnswers = value; }
        }

        /// <summary>
        ///  Determines the aomunt of questions answered wrongly.
        /// </summary>
        private int _wrongAnswers = 0;
        private int wrongAnswers
        {
            get { return _wrongAnswers; }
            set { _wrongAnswers = value; }
        }

        /// <summary>
        ///  References to controls for UI and game management.
        /// </summary>
        private readonly Piano? piano;
        private readonly MaterialForm? appWindow;
        private readonly MaterialButton? buttonGame;
        private readonly MaterialButton? buttonQuestion;
        private readonly MaterialCard? noteDisplay;
        private readonly MaterialLabel? noteDisplayText;
        private readonly MaterialLabel? scoreAnswersLabel;
        private readonly MaterialLabel? scoreCorrectLabel;
        private readonly MaterialLabel? scoreCorrect;
        private readonly MaterialLabel? scoreWrongLabel;
        private readonly MaterialLabel? scoreWrong;
        private readonly MaterialLabel? scoreTotalLabel;
        private readonly MaterialLabel? scoreTotal;
        private readonly MaterialLabel? scoreAccuracyLabel;
        private readonly MaterialLabel? scoreAccuracy;
        private readonly MaterialLabel? auralVoiceLabel;
        private readonly MaterialSlider? noteSlider;
        private readonly MaterialLabel? noteSliderValue;

        internal Gamemaster(ref Piano pianoIn, MaterialForm appWindowIn, ref MaterialButton buttonGameIn, ref MaterialButton buttonQuestionIn,
                            ref MaterialCard noteDisplayIn, ref MaterialLabel noteDisplayTextIn, ref MaterialLabel scoreAnswersLabelIn,
                            ref MaterialLabel scoreCorrectLabelIn, ref MaterialLabel scoreCorrectIn, ref MaterialLabel scoreWrongLabelIn,
                            ref MaterialLabel scoreWrongIn, ref MaterialLabel scoreTotalLabelIn, ref MaterialLabel scoreTotalIn,
                            ref MaterialLabel scoreAccuracyLabelIn, ref MaterialLabel scoreAccuracyIn, ref MaterialLabel auralVoiceLabelIn,
                            ref MaterialSlider noteSliderIn, ref MaterialLabel noteSliderValueIn)
        {
            // Assign UI control references.
            piano              = pianoIn;
            appWindow          = appWindowIn;
            buttonGame         = buttonGameIn;
            buttonQuestion     = buttonQuestionIn;
            noteDisplay        = noteDisplayIn;
            noteDisplayText    = noteDisplayTextIn;
            scoreAnswersLabel  = scoreAnswersLabelIn;
            scoreCorrectLabel  = scoreCorrectLabelIn;
            scoreCorrect       = scoreCorrectIn;
            scoreWrongLabel    = scoreWrongLabelIn;
            scoreWrong         = scoreWrongIn;
            scoreTotalLabel    = scoreTotalLabelIn;
            scoreTotal         = scoreTotalIn;
            scoreAccuracyLabel = scoreAccuracyLabelIn;
            scoreAccuracy      = scoreAccuracyIn;
            auralVoiceLabel    = auralVoiceLabelIn;
            noteSlider         = noteSliderIn;
            noteSliderValue    = noteSliderValueIn;
        }

        /// <summary>
        ///  Gamemaster version of the control 'buttonGame' click event.
        /// </summary>
        public void GM_buttonGame_Click()
        {
            if (buttonGame == null) throw new NullReferenceException($"{this}.buttonGame = null");

            if (isPlayMode)
            {
                EndGame();
            }
            else
            {
                StartGame();
            }

            ClearFocus();
        }

        /// <summary>
        ///  Gamemaster version of the control 'buttonQuestion' click event.
        /// </summary>
        public void GM_buttonQuestion_Click()
        {
            if (buttonQuestion == null) throw new NullReferenceException($"{this}.buttonQuestion = null"); 

            if (roundOver)
            {
                StartRound();
            }
            else
            {
                PlayQuestion();
            }

            ClearFocus();
        }

        /// <summary>
        ///  Try a <paramref name="answerIndex"/> as an answer to the round's question.
        /// </summary>
        public bool TryAnswer(int answerIndex)
        {
            // if (answered note == question's answer)
            if (answerIndex == questionIndex)
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
            if (piano == null)       throw new NullReferenceException($"{this}.piano = null");
            if (piano.notes == null) throw new NullReferenceException($"{this}.piano.notes = null");

            // Play question note, but stop it first if it was already playing.
            piano.notes.ElementAt(questionIndex).Value.StopNote(true);
            piano.notes.ElementAt(questionIndex).Value.PlayNote(true);
        }

        /// <summary>
        ///  Starts the game.
        /// </summary>
        private void StartGame()
        {
            isPlayMode = true;

            ResetScore();
            UpdateUI();
            SetupPiano();
            StartRound();
        }

        /// <summary>
        ///  Ends the game.
        /// </summary>
        private void EndGame()
        {
            isPlayMode = false;
            roundOver = false;

            SetupPiano();
            UpdateUI();
        }

        /// <summary>
        ///  Starts a round.
        /// </summary>
        private void StartRound()
        {
            if (buttonQuestion == null) throw new NullReferenceException($"{this}.buttonQuestion = null");

            // Starts the round and resets previous inputs.
            roundOver = false;
            RefreshPiano();

            // Sets up a new random question within the piano bounds.
            questionIndex = new Random().Next(pianoLowerBound, pianoUpperBound);

            // Update question button UI
            buttonQuestion.Text = "REPLAY QUESTION";
            buttonQuestion.UseAccentColor = false;

            // Update displayed note, and plays the question.
            UpdateNoteDisplay();
            GM_buttonQuestion_Click();
        }

        /// <summary>
        ///  Ends a round.
        /// </summary>
        private void EndRound()
        {
            if (buttonQuestion == null) throw new NullReferenceException($"{this}.buttonQuestion = null");

            // Ends the round and disable piano input.
            roundOver = true;
            piano.UpdateIsPianoActive();

            // Update question button UI
            buttonQuestion.Text = "NEXT QUESTION";
            buttonQuestion.UseAccentColor = true;

            // Update displayed note to show the answer.
            string? questionName = piano.notes.ElementAt(questionIndex).Value.name;
            UpdateNoteDisplay(questionName);
        }

        /// <summary>
        ///  Gets the piano ready for input.
        /// </summary>
        public void SetupPiano()
        {
            CalculateBounds();
            DisableNotes();
            RefreshPiano();
        }

        /// <summary>
        ///  Calculates 'pianoLowerBound' and 'pianoUpperBound'.
        /// </summary>
        private void CalculateBounds()
        {
            if (noteSlider == null)      throw new NullReferenceException($"{this}.noteSlider = null");
            if (noteSliderValue == null) throw new NullReferenceException($"{this}.noteSliderValue = null");

            int intValue;
            int lowerDiff;
            int upperDiff;
            int middleNoteIndex;
            decimal decValue;

            // Retrieve value of the UI slider.
            intValue = noteSlider.Value;

            // Clamp intValue to minimum 2.
            intValue = (intValue < 2) ? 2 : intValue;

            // Calculate differences.
            decValue = Convert.ToDecimal(intValue);
            lowerDiff = Convert.ToInt32(Math.Floor(decValue / 2));
            upperDiff = Convert.ToInt32(Math.Ceiling(decValue / 2));

            // Sets the middleNoteIndex.
            // Special case for 87 keys and above.
            middleNoteIndex = (intValue >= 87) ? 44 : 45;

            // Calculate lower/upper bounds.
            pianoLowerBound = middleNoteIndex - lowerDiff;
            pianoUpperBound = middleNoteIndex + upperDiff;

            // Update slider UI with new value.
            var newValue = new StringBuilder();
            newValue.Append(Convert.ToString(intValue));
            newValue.Append(" Notes");
            noteSliderValue.Text = Convert.ToString(newValue);
        }

        /// <summary>
        ///  Disable notes outside of piano bounds.
        /// </summary>
        private void DisableNotes()
        {
            if (piano == null)       throw new NullReferenceException($"{this}.piano = null");
            if (piano.notes == null) throw new NullReferenceException($"{this}.piano.notes = null");

            // Disable lower bound notes.
            for (int i = 0; i < pianoLowerBound; i++)
            {
                piano.notes.ElementAt(i).Value.DisableNote();
            }

            // Disable upper bound notes.
            for (int i = pianoUpperBound; i < 88; i++)
            {
                piano.notes.ElementAt(i).Value.DisableNote();
            }
        }

        /// <summary>
        ///  Refreshes the piano based on app state.
        ///  - Disable/activate piano.
        ///  - Enables all notes for new input.
        /// </summary>
        private void RefreshPiano()
        {
            if (piano == null)       throw new NullReferenceException($"{this}.piano = null");
            if (piano.notes == null) throw new NullReferenceException($"{this}.piano.notes = null");

            // Piano activation logic.
            piano.UpdateIsPianoActive();

            // Enable active notes.
            for (int i = pianoLowerBound; i < pianoUpperBound; i++)
            {
                piano.notes.ElementAt(i).Value.EnableNote();
            }
        }

        /// <summary>
        ///  Question answered correctly.
        /// </summary>
        private void CorrectAnswer()
        {
            if (piano == null)       throw new NullReferenceException($"{this}.piano = null");
            if (piano.notes == null) throw new NullReferenceException($"{this}.piano.notes = null");

            // Stop playing the question note.
            piano.notes.ElementAt(questionIndex).Value.StopNote(true);

            // Increment correctAnswers, update the scoreboard, and end round.
            correctAnswers++;
            UpdateScoreboard();
            EndRound();
        }

        /// <summary>
        ///  Question answered wrongly.
        /// </summary>
        private void WrongAnswer()
        {
            // Increment wrongAnswers, and update the scoreboard.
            wrongAnswers++;
            UpdateScoreboard();
        }

        /// <summary>
        ///  Calculates and updates the scoreboard with new values.
        /// </summary>
        private void UpdateScoreboard()
        {
            if (scoreCorrect == null)  throw new NullReferenceException($"{this}.scoreCorrect = null");
            if (scoreWrong == null)    throw new NullReferenceException($"{this}.scoreWrong = null");
            if (scoreTotal == null)    throw new NullReferenceException($"{this}.scoreTotal = null");
            if (scoreAccuracy == null) throw new NullReferenceException($"{this}.scoreAccuracy = null");

            int total = 0;
            double accuracy = 0;

            // Calculate the total
            total = correctAnswers + wrongAnswers;

            // Calculate the accuracy
            if (total > 0)
            {
                accuracy = (Convert.ToDouble(correctAnswers) / Convert.ToDouble(total)) * 100d;
                accuracy = Math.Round(accuracy, 2);
            }

            // Update scoreboard UI elements with new values
            scoreCorrect.Text  = Convert.ToString(correctAnswers);
            scoreWrong.Text    = Convert.ToString(wrongAnswers);
            scoreTotal.Text    = Convert.ToString(total);
            scoreAccuracy.Text = Convert.ToString(accuracy) + '%';
        }

        /// <summary>
        ///  Handles note text logic, and displays result in 'noteDisplayText',
        /// </summary>
        /// <param name="noteName">Name of the note to display.</param>
        public void UpdateNoteDisplay(string noteName = "")
        {
            if (isPlayMode)
            {
                string newInput;
                newInput = (roundOver) ? noteName : "  ?  ";
                SetNoteDisplayText(newInput);
            }
            else
            {
                SetNoteDisplayText(noteName);
            }
        }

        /// <summary>
        ///  Set the displayed note to <paramref name="newText"/>.
        /// </summary>
        public void SetNoteDisplayText(string newText)
        {
            if (noteDisplayText == null) throw new NullReferenceException($"{this}.noteDisplayText = null");

            // Add an extra space at the start of the text if
            // the text is the name of a white key. This is to
            // visually align the text to the center.
            if (!(newText.Contains('b') || newText.Contains('?')))
            {
                var whiteKey = new StringBuilder();

                whiteKey.Append(" ");
                whiteKey.Append(newText);

                newText = Convert.ToString(whiteKey);
            }

            // Update display text UI with new value.
            noteDisplayText.Text = newText;
        }

        /// <summary>
        ///  Resets the scoreboard do default values.
        /// </summary>
        private void ResetScore()
        {
            correctAnswers = 0;
            wrongAnswers = 0;
            UpdateScoreboard();
        }

        /// <summary>
        ///  Hide/unhide and alter UI elements based on app state.
        /// </summary>
        private void UpdateUI()
        {
            if (buttonGame == null)      throw new NullReferenceException($"{this}.buttonGame = null");
            if (buttonQuestion == null)  throw new NullReferenceException($"{this}.buttonQuestion = null");
            if (auralVoiceLabel == null) throw new NullReferenceException($"{this}.auralVoiceLabel = null");
            if (noteSlider == null)      throw new NullReferenceException($"{this}.noteSlider = null");
            if (noteSliderValue == null) throw new NullReferenceException($"{this}.noteSliderValue = null");

            if (isPlayMode)
            {
                buttonGame.Text = "STOP";
                buttonGame.UseAccentColor = false;
                buttonQuestion.Visible = true;
                auralVoiceLabel.Visible = false;
                noteSlider.Visible      = false;
                noteSliderValue.Visible = false;

                SetScoreVisibility(true);
            }
            else if (!isPlayMode)
            {
                buttonGame.Text = "START";
                buttonGame.UseAccentColor = true;
                buttonQuestion.Visible = false;
                auralVoiceLabel.Visible = true;
                noteSlider.Visible      = true;
                noteSliderValue.Visible = true;

                UpdateNoteDisplay();
                SetScoreVisibility(false);
            }
        }

        /// <summary>
        ///  Set the visibility of all score UI elements, based on <paramref name="visibility"/>.
        /// </summary>
        private void SetScoreVisibility(bool visibility)
        {
            scoreAnswersLabel.Visible  = visibility;
            scoreCorrectLabel.Visible  = visibility;
            scoreCorrect.Visible       = visibility;
            scoreWrongLabel.Visible    = visibility;
            scoreWrong.Visible         = visibility;
            scoreTotalLabel.Visible    = visibility;
            scoreTotal.Visible         = visibility;
            scoreAccuracyLabel.Visible = visibility;
            scoreAccuracy.Visible      = visibility;
        }

        /// <summary>
        ///  Sets the focus to 'noteDisplayText'.
        ///  - Focus is whenever a control is highlighted and recieves keyboard inputs.
        ///  - This focus is, by default, set to the latest control clicked by the user.
        ///  - This function's goal is to "override" this functionality by clearing that 
        ///    focus to an "uninteractive" control, which happens to be a 'MaterialLabel' class.
        /// </summary>
        private void ClearFocus()
        {
            if (appWindow == null)       throw new NullReferenceException($"{this}.appWindow = null");
            if (noteDisplayText == null) throw new NullReferenceException($"{this}.noteDisplayText = null");

            appWindow.ActiveControl = noteDisplayText;
        }
    }
}
