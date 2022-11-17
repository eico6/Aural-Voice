using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Preview.Notes;
using Windows.Devices.Midi;

namespace AuralVoice;

#nullable disable
partial class AppWindow
{
    /// <summary>
    ///  All events are called via user input.
    ///  Events are associated with "keys", where they call their respective "note".
    /// </summary>


    #region Hotkey Events

        #region KeyDown(...)
        private void AppWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            // ...
        }
        #endregion

        #region KeyUp(...)
        private void AppWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            // ...
        }
        #endregion

    #endregion


    #region Mouse Events

        #region MouseEnter(...)
        private void keyA0_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.ENTER); }
        private void keyBb0_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.ENTER); }
        // ...
        #endregion

        #region MouseLeave(...)
        private void keyA0_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyBb0_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.LEAVE); }
        // ...
        #endregion

        #region MouseDown(...)
        private void keyA0_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.DOWN); }
        private void keyBb0_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.DOWN); }
        // ...
        #endregion

        #region MouseUp(...)
        private void keyA0_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.UP); }
        private void keyBb0_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.UP); }
        // ...
        #endregion

    #endregion
}
