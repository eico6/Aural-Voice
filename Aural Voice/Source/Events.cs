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
            if (e.KeyCode == Keys.C) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.E) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.F) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.G) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.A) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.B) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.DOWN, Piano.ActionCaller.KEYBOARD); }
        }
        #endregion

        #region KeyUp(...)
        private void AppWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.E) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.F) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.G) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.A) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.B) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.UP, Piano.ActionCaller.KEYBOARD); }
        }
        #endregion

    #endregion


    #region Mouse Events

        #region MouseEnter(...)

        // Octave 0
        private void keyA0_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.ENTER); }
        private void keyBb0_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.ENTER); }
        private void keyB0_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.B0).ActionInput(Piano.KeyAction.ENTER); }

        // Octave 1
        private void keyC1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyDb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyD1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyEb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyE1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyF1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyGb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyG1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyAb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyA1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyBb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Piano.KeyAction.ENTER); }
        private void keyB1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.ENTER); }

        // ...
        #endregion

        #region MouseLeave(...)

        // Octave 0
        private void keyA0_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyBb0_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyB0_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.B0).ActionInput(Piano.KeyAction.LEAVE); }

        // Octave 1
        private void keyC1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyDb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyD1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyEb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyE1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyF1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyGb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyG1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyAb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyA1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyBb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Piano.KeyAction.LEAVE); }
        private void keyB1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.LEAVE); }

        // ...
        #endregion

        #region MouseDown(...)

        // Octave 0
        private void keyA0_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.DOWN); }
        private void keyBb0_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.DOWN); }
        private void keyB0_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.B0).ActionInput(Piano.KeyAction.DOWN); }

        // Octave 1
        private void keyC1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyDb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyD1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyEb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyE1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyF1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyGb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyG1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyAb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyA1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyBb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Piano.KeyAction.DOWN); }
        private void keyB1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.DOWN); }

        // ...
        #endregion

        #region MouseUp(...)

        // Octave 0
        private void keyA0_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Piano.KeyAction.UP); }
        private void keyBb0_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Piano.KeyAction.UP); }
        private void keyB0_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.B0).ActionInput(Piano.KeyAction.UP); }

        // Octave 1
        private void keyC1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.C1).ActionInput(Piano.KeyAction.UP); }
        private void keyDb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Piano.KeyAction.UP); }
        private void keyD1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.D1).ActionInput(Piano.KeyAction.UP); }
        private void keyEb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Piano.KeyAction.UP); }
        private void keyE1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.E1).ActionInput(Piano.KeyAction.UP); }
        private void keyF1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.F1).ActionInput(Piano.KeyAction.UP); }
        private void keyGb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Piano.KeyAction.UP); }
        private void keyG1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.G1).ActionInput(Piano.KeyAction.UP); }
        private void keyAb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Piano.KeyAction.UP); }
        private void keyA1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.A1).ActionInput(Piano.KeyAction.UP); }
        private void keyBb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Piano.KeyAction.UP); }
        private void keyB1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.B1).ActionInput(Piano.KeyAction.UP); }


        // ...
        #endregion

    #endregion
}
