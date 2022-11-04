using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice;


partial class AppWindow
{
    // PianoEvents
    // - These events are called via user input.
    // - Events are associated with keys, where keys call their respective note.
    
    #region PictureBox keys - Click events
    private void keyA0_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Play the note A0");
    }
    #endregion

    #region PictureBox keys - MouseEnter events
    private void keyA0_MouseEnter(object sender, EventArgs e)
    {
        // ...
    }
    #endregion

    #region PictureBox keys - MouseLeave events
    private void keyA0_MouseLeave(object sender, EventArgs e)
    {
        // ...
    }
    #endregion






}
