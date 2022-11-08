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
    // - Events are associated with "keys", where they call their respective "note".

    private readonly Dictionary<String, Bitmap> _keyImages = new Dictionary<String, Bitmap>()
    {
        { "idle_white", ProjectResources.key_white_idle },
        { "idle_black", ProjectResources.key_black_idle },
        { "hover_white", ProjectResources.key_white_hover },
        { "hover_black", ProjectResources.key_black_hover },
        { "press_white", ProjectResources.key_white_press },
        { "press_black", ProjectResources.key_black_press }
    };

    private void setToIdle(PictureBox key)
    {
        // TODO: Maybe abstract condition with macro(?)
        // Sets the displayed image of the key to its "idle" state.
        key.Image = (!key.Name.Contains("b")) ? _keyImages["idle_white"] : _keyImages["idle_black"];
    }

    // TODO: keybinds and lookup windows midi library 
    #region PictureBox keys - MouseEnter events
    private void keyA0_MouseEnter(object sender, EventArgs e)
    {
        keyA0.Image = ProjectResources.key_white_hover;
    }

    private void keyBb0_MouseEnter(object sender, EventArgs e)
    {
        keyBb0.Image = ProjectResources.key_black_hover;
    }
    #endregion

    #region PictureBox keys - MouseLeave events
    private void keyA0_MouseLeave(object sender, EventArgs e)
    {
        setToIdle(keyA0);
    }

    private void keyBb0_MouseLeave(object sender, EventArgs e)
    {
        setToIdle(keyBb0);
    }
    #endregion

    #region PictureBox keys - MouseDown events
    private void keyA0_MouseDown(object sender, MouseEventArgs e)
    {
        keyA0.Image = ProjectResources.key_white_press;
    }

    private void keyBb0_MouseDown(object sender, MouseEventArgs e)
    {
        keyBb0.Image = ProjectResources.key_black_press;
    }
    #endregion

    #region PictureBox keys - MouseUp events
    private void keyA0_MouseUp(object sender, MouseEventArgs e)
    {
        keyA0.Image = ProjectResources.key_white_hover;
    }

    private void keyBb0_MouseUp(object sender, MouseEventArgs e)
    {
        keyBb0.Image = ProjectResources.key_black_hover;
    }
    #endregion
}
