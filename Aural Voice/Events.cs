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
    ///  These events are called via user input.
    ///  Events are associated with "keys", where they call their respective "note".
    /// </summary>

    #region PictureBox keys - MouseEnter events
    private void keyA0_MouseEnter(object sender, EventArgs e)  { piano.GetNote("A0").KeyInput(Piano.KeyAction.ENTER); }
    private void keyBb0_MouseEnter(object sender, EventArgs e) { piano.GetNote("Bb0").KeyInput(Piano.KeyAction.ENTER); }
    // ...
    #endregion

    #region PictureBox keys - MouseLeave events
    private void keyA0_MouseLeave(object sender, EventArgs e)  { piano.GetNote("A0").KeyInput(Piano.KeyAction.LEAVE); }
    private void keyBb0_MouseLeave(object sender, EventArgs e) { piano.GetNote("Bb0").KeyInput(Piano.KeyAction.LEAVE); }
    // ...
    #endregion

    #region PictureBox keys - MouseDown events
    private void keyA0_MouseDown(object sender, MouseEventArgs e)  { piano.GetNote("A0").KeyInput(Piano.KeyAction.DOWN); }
    private void keyBb0_MouseDown(object sender, MouseEventArgs e) { piano.GetNote("Bb0").KeyInput(Piano.KeyAction.DOWN); }
    // ...
    #endregion

    #region PictureBox keys - MouseUp events
    private void keyA0_MouseUp(object sender, MouseEventArgs e)  { piano.GetNote("A0").KeyInput(Piano.KeyAction.UP); }
    private void keyBb0_MouseUp(object sender, MouseEventArgs e) { piano.GetNote("Bb0").KeyInput(Piano.KeyAction.UP); }
    // ...
    #endregion
}
