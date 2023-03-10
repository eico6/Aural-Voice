using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Preview.Notes;
using Windows.Devices.Midi;
using static AuralVoice.Piano;

namespace AuralVoice;

#nullable disable
partial class AppWindow
{
    /// <summary>
    ///  All events are called via user input.
    ///  Events are associated with "keys", where they call their respective "note".
    /// </summary>

    #region Control Events
    
        // Tab Controller
        private void tabController_Selected(object sender, TabControlEventArgs e) { piano.UpdateIsActive(); }

        // Volume Slider
        private void volumeSlider_onValueChanged(object sender, int newValue) { piano.SetVolume(newValue); }

        // Program Selector
        private void programSelector_SelectedValueChanged(object sender, EventArgs e) { piano.UpdateProgram(); }


    #endregion

    #region Hotkey Events

        #region KeyDown(...)
        private void AppWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D2) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.W) { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D3) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.E) { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.R) { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D5) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.T) { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D6) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.Y) { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D7) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.U) { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.I) { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.DOWN, Note.ActionCaller.KEYBOARD); }
        }
        #endregion

        #region KeyUp(...)
        private void AppWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D2) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.W) { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D3) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.E) { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.R) { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D5) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.T) { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D6) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.Y) { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.D7) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.U) { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
            if (e.KeyCode == Keys.I) { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.UP, Note.ActionCaller.KEYBOARD); }
        }
        #endregion

    #endregion

    #region Mouse Events

        #region MouseEnter(...)
        // Octave 0
        private void keyA0_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb0_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Note.KeyAction.ENTER); }
        private void keyB0_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B0).ActionInput(Note.KeyAction.ENTER); }

        // Octave 1
        private void keyC1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C1).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Note.KeyAction.ENTER); }
        private void keyD1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D1).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Note.KeyAction.ENTER); }
        private void keyE1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E1).ActionInput(Note.KeyAction.ENTER); }
        private void keyF1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F1).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Note.KeyAction.ENTER); }
        private void keyG1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G1).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Note.KeyAction.ENTER); }
        private void keyA1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A1).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb1_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Note.KeyAction.ENTER); }
        private void keyB1_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B1).ActionInput(Note.KeyAction.ENTER); }

        // Octave 2
        private void keyC2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C2).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb2_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db2).ActionInput(Note.KeyAction.ENTER); }
        private void keyD2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D2).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb2_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb2).ActionInput(Note.KeyAction.ENTER); }
        private void keyE2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E2).ActionInput(Note.KeyAction.ENTER); }
        private void keyF2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F2).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb2_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb2).ActionInput(Note.KeyAction.ENTER); }
        private void keyG2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G2).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb2_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab2).ActionInput(Note.KeyAction.ENTER); }
        private void keyA2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A2).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb2_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb2).ActionInput(Note.KeyAction.ENTER); }
        private void keyB2_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B2).ActionInput(Note.KeyAction.ENTER); }

        // Octave 3
        private void keyC3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C3).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb3_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db3).ActionInput(Note.KeyAction.ENTER); }
        private void keyD3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D3).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb3_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb3).ActionInput(Note.KeyAction.ENTER); }
        private void keyE3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E3).ActionInput(Note.KeyAction.ENTER); }
        private void keyF3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F3).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb3_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb3).ActionInput(Note.KeyAction.ENTER); }
        private void keyG3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G3).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb3_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab3).ActionInput(Note.KeyAction.ENTER); }
        private void keyA3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A3).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb3_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb3).ActionInput(Note.KeyAction.ENTER); }
        private void keyB3_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B3).ActionInput(Note.KeyAction.ENTER); }

        // Octave 4
        private void keyC4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb4_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.ENTER); }
        private void keyD4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb4_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.ENTER); }
        private void keyE4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.ENTER); }
        private void keyF4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb4_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.ENTER); }
        private void keyG4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb4_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.ENTER); }
        private void keyA4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb4_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.ENTER); }
        private void keyB4_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.ENTER); }

        // Octave 5
        private void keyC5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb5_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db5).ActionInput(Note.KeyAction.ENTER); }
        private void keyD5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D5).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb5_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb5).ActionInput(Note.KeyAction.ENTER); }
        private void keyE5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E5).ActionInput(Note.KeyAction.ENTER); }
        private void keyF5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F5).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb5_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb5).ActionInput(Note.KeyAction.ENTER); }
        private void keyG5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G5).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb5_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab5).ActionInput(Note.KeyAction.ENTER); }
        private void keyA5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A5).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb5_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb5).ActionInput(Note.KeyAction.ENTER); }
        private void keyB5_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B5).ActionInput(Note.KeyAction.ENTER); }

        // Octave 6
        private void keyC6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C6).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb6_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db6).ActionInput(Note.KeyAction.ENTER); }
        private void keyD6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D6).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb6_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb6).ActionInput(Note.KeyAction.ENTER); }
        private void keyE6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E6).ActionInput(Note.KeyAction.ENTER); }
        private void keyF6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F6).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb6_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb6).ActionInput(Note.KeyAction.ENTER); }
        private void keyG6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G6).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb6_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab6).ActionInput(Note.KeyAction.ENTER); }
        private void keyA6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A6).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb6_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb6).ActionInput(Note.KeyAction.ENTER); }
        private void keyB6_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B6).ActionInput(Note.KeyAction.ENTER); }

        // Octave 7
        private void keyC7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C7).ActionInput(Note.KeyAction.ENTER); }
        private void keyDb7_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Db7).ActionInput(Note.KeyAction.ENTER); }
        private void keyD7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.D7).ActionInput(Note.KeyAction.ENTER); }
        private void keyEb7_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Eb7).ActionInput(Note.KeyAction.ENTER); }
        private void keyE7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.E7).ActionInput(Note.KeyAction.ENTER); }
        private void keyF7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.F7).ActionInput(Note.KeyAction.ENTER); }
        private void keyGb7_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Gb7).ActionInput(Note.KeyAction.ENTER); }
        private void keyG7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.G7).ActionInput(Note.KeyAction.ENTER); }
        private void keyAb7_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Ab7).ActionInput(Note.KeyAction.ENTER); }
        private void keyA7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.A7).ActionInput(Note.KeyAction.ENTER); }
        private void keyBb7_MouseEnter(object sender, EventArgs e) { piano.GetNote(NoteName.Bb7).ActionInput(Note.KeyAction.ENTER); }
        private void keyB7_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.B7).ActionInput(Note.KeyAction.ENTER); }

        // Octave 8
        private void keyC8_MouseEnter(object sender, EventArgs e)  { piano.GetNote(NoteName.C8).ActionInput(Note.KeyAction.ENTER); }
        #endregion

        #region MouseLeave(...)
        // Octave 0
        private void keyA0_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb0_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB0_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B0).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 1
        private void keyC1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb1_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB1_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B1).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 2
        private void keyC2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb2_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb2_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb2_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb2_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb2_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb2).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB2_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B2).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 3
        private void keyC3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb3_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb3_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb3_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb3_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb3_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb3).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB3_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B3).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 4
        private void keyC4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb4_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb4_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb4_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb4_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb4_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB4_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 5
        private void keyC5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb5_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb5_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb5_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb5_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb5_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb5).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB5_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B5).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 6
        private void keyC6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb6_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb6_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb6_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb6_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb6_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb6).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB6_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B6).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 7
        private void keyC7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyDb7_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Db7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyD7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.D7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyEb7_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Eb7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyE7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.E7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyF7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.F7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyGb7_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Gb7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyG7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.G7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyAb7_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Ab7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyA7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.A7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyBb7_MouseLeave(object sender, EventArgs e) { piano.GetNote(NoteName.Bb7).ActionInput(Note.KeyAction.LEAVE); }
        private void keyB7_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.B7).ActionInput(Note.KeyAction.LEAVE); }

        // Octave 8
        private void keyC8_MouseLeave(object sender, EventArgs e)  { piano.GetNote(NoteName.C8).ActionInput(Note.KeyAction.LEAVE); }
        #endregion

        #region MouseDown(...)
        // Octave 0
        private void keyA0_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb0_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Note.KeyAction.DOWN); }
        private void keyB0_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B0).ActionInput(Note.KeyAction.DOWN); }

        // Octave 1
        private void keyC1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C1).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Note.KeyAction.DOWN); }
        private void keyD1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D1).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Note.KeyAction.DOWN); }
        private void keyE1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E1).ActionInput(Note.KeyAction.DOWN); }
        private void keyF1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F1).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Note.KeyAction.DOWN); }
        private void keyG1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G1).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Note.KeyAction.DOWN); }
        private void keyA1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A1).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb1_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Note.KeyAction.DOWN); }
        private void keyB1_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B1).ActionInput(Note.KeyAction.DOWN); }

        // Octave 2
        private void keyC2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C2).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb2_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db2).ActionInput(Note.KeyAction.DOWN); }
        private void keyD2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D2).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb2_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb2).ActionInput(Note.KeyAction.DOWN); }
        private void keyE2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E2).ActionInput(Note.KeyAction.DOWN); }
        private void keyF2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F2).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb2_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb2).ActionInput(Note.KeyAction.DOWN); }
        private void keyG2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G2).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb2_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab2).ActionInput(Note.KeyAction.DOWN); }
        private void keyA2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A2).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb2_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb2).ActionInput(Note.KeyAction.DOWN); }
        private void keyB2_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B2).ActionInput(Note.KeyAction.DOWN); }

        // Octave 3
        private void keyC3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C3).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb3_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db3).ActionInput(Note.KeyAction.DOWN); }
        private void keyD3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D3).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb3_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb3).ActionInput(Note.KeyAction.DOWN); }
        private void keyE3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E3).ActionInput(Note.KeyAction.DOWN); }
        private void keyF3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F3).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb3_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb3).ActionInput(Note.KeyAction.DOWN); }
        private void keyG3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G3).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb3_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab3).ActionInput(Note.KeyAction.DOWN); }
        private void keyA3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A3).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb3_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb3).ActionInput(Note.KeyAction.DOWN); }
        private void keyB3_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B3).ActionInput(Note.KeyAction.DOWN); }

        // Octave 4
        private void keyC4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb4_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.DOWN); }
        private void keyD4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb4_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.DOWN); }
        private void keyE4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.DOWN); }
        private void keyF4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb4_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.DOWN); }
        private void keyG4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb4_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.DOWN); }
        private void keyA4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb4_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.DOWN); }
        private void keyB4_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.DOWN); }

        // Octave 5
        private void keyC5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb5_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db5).ActionInput(Note.KeyAction.DOWN); }
        private void keyD5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D5).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb5_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb5).ActionInput(Note.KeyAction.DOWN); }
        private void keyE5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E5).ActionInput(Note.KeyAction.DOWN); }
        private void keyF5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F5).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb5_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb5).ActionInput(Note.KeyAction.DOWN); }
        private void keyG5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G5).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb5_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab5).ActionInput(Note.KeyAction.DOWN); }
        private void keyA5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A5).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb5_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb5).ActionInput(Note.KeyAction.DOWN); }
        private void keyB5_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B5).ActionInput(Note.KeyAction.DOWN); }

        // Octave 6
        private void keyC6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C6).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb6_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db6).ActionInput(Note.KeyAction.DOWN); }
        private void keyD6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D6).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb6_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb6).ActionInput(Note.KeyAction.DOWN); }
        private void keyE6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E6).ActionInput(Note.KeyAction.DOWN); }
        private void keyF6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F6).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb6_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb6).ActionInput(Note.KeyAction.DOWN); }
        private void keyG6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G6).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb6_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab6).ActionInput(Note.KeyAction.DOWN); }
        private void keyA6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A6).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb6_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb6).ActionInput(Note.KeyAction.DOWN); }
        private void keyB6_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B6).ActionInput(Note.KeyAction.DOWN); }

        // Octave 7
        private void keyC7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C7).ActionInput(Note.KeyAction.DOWN); }
        private void keyDb7_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db7).ActionInput(Note.KeyAction.DOWN); }
        private void keyD7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D7).ActionInput(Note.KeyAction.DOWN); }
        private void keyEb7_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb7).ActionInput(Note.KeyAction.DOWN); }
        private void keyE7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E7).ActionInput(Note.KeyAction.DOWN); }
        private void keyF7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F7).ActionInput(Note.KeyAction.DOWN); }
        private void keyGb7_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb7).ActionInput(Note.KeyAction.DOWN); }
        private void keyG7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G7).ActionInput(Note.KeyAction.DOWN); }
        private void keyAb7_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab7).ActionInput(Note.KeyAction.DOWN); }
        private void keyA7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A7).ActionInput(Note.KeyAction.DOWN); }
        private void keyBb7_MouseDown(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb7).ActionInput(Note.KeyAction.DOWN); }
        private void keyB7_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B7).ActionInput(Note.KeyAction.DOWN); }

        // Octave 8
        private void keyC8_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C8).ActionInput(Note.KeyAction.DOWN); }
        #endregion

        #region MouseUp(...)
        // Octave 0
        private void keyA0_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A0).ActionInput(Note.KeyAction.UP); }
        private void keyBb0_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb0).ActionInput(Note.KeyAction.UP); }
        private void keyB0_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B0).ActionInput(Note.KeyAction.UP); }

        // Octave 1
        private void keyC1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C1).ActionInput(Note.KeyAction.UP); }
        private void keyDb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db1).ActionInput(Note.KeyAction.UP); }
        private void keyD1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D1).ActionInput(Note.KeyAction.UP); }
        private void keyEb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb1).ActionInput(Note.KeyAction.UP); }
        private void keyE1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E1).ActionInput(Note.KeyAction.UP); }
        private void keyF1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F1).ActionInput(Note.KeyAction.UP); }
        private void keyGb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb1).ActionInput(Note.KeyAction.UP); }
        private void keyG1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G1).ActionInput(Note.KeyAction.UP); }
        private void keyAb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab1).ActionInput(Note.KeyAction.UP); }
        private void keyA1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A1).ActionInput(Note.KeyAction.UP); }
        private void keyBb1_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb1).ActionInput(Note.KeyAction.UP); }
        private void keyB1_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B1).ActionInput(Note.KeyAction.UP); }

        // Octave 2
        private void keyC2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C2).ActionInput(Note.KeyAction.UP); }
        private void keyDb2_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db2).ActionInput(Note.KeyAction.UP); }
        private void keyD2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D2).ActionInput(Note.KeyAction.UP); }
        private void keyEb2_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb2).ActionInput(Note.KeyAction.UP); }
        private void keyE2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E2).ActionInput(Note.KeyAction.UP); }
        private void keyF2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F2).ActionInput(Note.KeyAction.UP); }
        private void keyGb2_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb2).ActionInput(Note.KeyAction.UP); }
        private void keyG2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G2).ActionInput(Note.KeyAction.UP); }
        private void keyAb2_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab2).ActionInput(Note.KeyAction.UP); }
        private void keyA2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A2).ActionInput(Note.KeyAction.UP); }
        private void keyBb2_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb2).ActionInput(Note.KeyAction.UP); }
        private void keyB2_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B2).ActionInput(Note.KeyAction.UP); }

        // Octave 3
        private void keyC3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C3).ActionInput(Note.KeyAction.UP); }
        private void keyDb3_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db3).ActionInput(Note.KeyAction.UP); }
        private void keyD3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D3).ActionInput(Note.KeyAction.UP); }
        private void keyEb3_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb3).ActionInput(Note.KeyAction.UP); }
        private void keyE3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E3).ActionInput(Note.KeyAction.UP); }
        private void keyF3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F3).ActionInput(Note.KeyAction.UP); }
        private void keyGb3_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb3).ActionInput(Note.KeyAction.UP); }
        private void keyG3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G3).ActionInput(Note.KeyAction.UP); }
        private void keyAb3_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab3).ActionInput(Note.KeyAction.UP); }
        private void keyA3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A3).ActionInput(Note.KeyAction.UP); }
        private void keyBb3_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb3).ActionInput(Note.KeyAction.UP); }
        private void keyB3_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B3).ActionInput(Note.KeyAction.UP); }

        // Octave 4
        private void keyC4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C4).ActionInput(Note.KeyAction.UP); }
        private void keyDb4_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db4).ActionInput(Note.KeyAction.UP); }
        private void keyD4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D4).ActionInput(Note.KeyAction.UP); }
        private void keyEb4_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb4).ActionInput(Note.KeyAction.UP); }
        private void keyE4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E4).ActionInput(Note.KeyAction.UP); }
        private void keyF4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F4).ActionInput(Note.KeyAction.UP); }
        private void keyGb4_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb4).ActionInput(Note.KeyAction.UP); }
        private void keyG4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G4).ActionInput(Note.KeyAction.UP); }
        private void keyAb4_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab4).ActionInput(Note.KeyAction.UP); }
        private void keyA4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A4).ActionInput(Note.KeyAction.UP); }
        private void keyBb4_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb4).ActionInput(Note.KeyAction.UP); }
        private void keyB4_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B4).ActionInput(Note.KeyAction.UP); }

        // Octave 5
        private void keyC5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C5).ActionInput(Note.KeyAction.UP); }
        private void keyDb5_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db5).ActionInput(Note.KeyAction.UP); }
        private void keyD5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D5).ActionInput(Note.KeyAction.UP); }
        private void keyEb5_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb5).ActionInput(Note.KeyAction.UP); }
        private void keyE5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E5).ActionInput(Note.KeyAction.UP); }
        private void keyF5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F5).ActionInput(Note.KeyAction.UP); }
        private void keyGb5_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb5).ActionInput(Note.KeyAction.UP); }
        private void keyG5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G5).ActionInput(Note.KeyAction.UP); }
        private void keyAb5_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab5).ActionInput(Note.KeyAction.UP); }
        private void keyA5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A5).ActionInput(Note.KeyAction.UP); }
        private void keyBb5_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb5).ActionInput(Note.KeyAction.UP); }
        private void keyB5_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B5).ActionInput(Note.KeyAction.UP); }

        // Octave 6
        private void keyC6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C6).ActionInput(Note.KeyAction.UP); }
        private void keyDb6_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db6).ActionInput(Note.KeyAction.UP); }
        private void keyD6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D6).ActionInput(Note.KeyAction.UP); }
        private void keyEb6_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb6).ActionInput(Note.KeyAction.UP); }
        private void keyE6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E6).ActionInput(Note.KeyAction.UP); }
        private void keyF6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F6).ActionInput(Note.KeyAction.UP); }
        private void keyGb6_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb6).ActionInput(Note.KeyAction.UP); }
        private void keyG6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G6).ActionInput(Note.KeyAction.UP); }
        private void keyAb6_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab6).ActionInput(Note.KeyAction.UP); }
        private void keyA6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A6).ActionInput(Note.KeyAction.UP); }
        private void keyBb6_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb6).ActionInput(Note.KeyAction.UP); }
        private void keyB6_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B6).ActionInput(Note.KeyAction.UP); }

        // Octave 7
        private void keyC7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C7).ActionInput(Note.KeyAction.UP); }
        private void keyDb7_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Db7).ActionInput(Note.KeyAction.UP); }
        private void keyD7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.D7).ActionInput(Note.KeyAction.UP); }
        private void keyEb7_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Eb7).ActionInput(Note.KeyAction.UP); }
        private void keyE7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.E7).ActionInput(Note.KeyAction.UP); }
        private void keyF7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.F7).ActionInput(Note.KeyAction.UP); }
        private void keyGb7_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Gb7).ActionInput(Note.KeyAction.UP); }
        private void keyG7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.G7).ActionInput(Note.KeyAction.UP); }
        private void keyAb7_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Ab7).ActionInput(Note.KeyAction.UP); }
        private void keyA7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.A7).ActionInput(Note.KeyAction.UP); }
        private void keyBb7_MouseUp(object sender, MouseEventArgs e) { piano.GetNote(NoteName.Bb7).ActionInput(Note.KeyAction.UP); }
        private void keyB7_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.B7).ActionInput(Note.KeyAction.UP); }

        // Octave 8
        private void keyC8_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote(NoteName.C8).ActionInput(Note.KeyAction.UP); }
        #endregion

    #endregion
}
