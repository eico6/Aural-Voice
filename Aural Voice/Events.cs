using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Midi;

namespace AuralVoice;

#nullable disable
partial class AppWindow
{
    /// <summary>
    /// - These events are called via user input.
    /// - Events are associated with "keys", where they call their respective "note".
    /// </summary>

    #region PictureBox keys - MouseEnter events
    private void keyA0_MouseEnter(object sender, EventArgs e)  { piano.notes["A0"].MouseEnter(); }
    private void keyBb0_MouseEnter(object sender, EventArgs e) { piano.notes["Bb0"].MouseEnter(); }
    // ...
    #endregion

    #region PictureBox keys - MouseLeave events
    private void keyA0_MouseLeave(object sender, EventArgs e)  { piano.notes["A0"].MouseLeave(); }
    private void keyBb0_MouseLeave(object sender, EventArgs e) { piano.notes["Bb0"].MouseLeave(); }
    // ...
    #endregion

    #region PictureBox keys - MouseDown events
    private void keyA0_MouseDown(object sender, MouseEventArgs e)  { piano.notes["A0"].MouseDown(); }
    private void keyBb0_MouseDown(object sender, MouseEventArgs e) { piano.notes["Bb0"].MouseDown(); }
    // ...
    #endregion

    #region PictureBox keys - MouseUp events
    private void keyA0_MouseUp(object sender, MouseEventArgs e)  { piano.notes["A0"].MouseUp(); }
    private void keyBb0_MouseUp(object sender, MouseEventArgs e) { piano.notes["Bb0"].MouseUp(); }
    // ...
    #endregion
}
