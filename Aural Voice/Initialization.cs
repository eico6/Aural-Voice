using AuralVoice.Audio;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Preview.Notes;
using Windows.Devices.Midi;

namespace AuralVoice;

partial class AppWindow
{
    /// <summary>
    ///  Adds 88 notes to the piano, and assigns a unique reference 
    ///  between each "note" and its corresponding "key".
    /// </summary> 
    private void InitializePiano()
    {
        piano = new Piano();
        
        if (piano.notes != null)
        {
            piano.AddNote("A0", keyA0);
            piano.AddNote("Bb0", keyBb0);
            // ...
        }
    }

    /// <summary>
    ///  WinForms theme: MaterialSkin 2, by leocb.
    /// </summary> 
    private void InitializeMaterialSkin()
    {
        materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.BlueGrey500, 
                                                          Accent.LightBlue200, TextShade.WHITE);
    }
}
