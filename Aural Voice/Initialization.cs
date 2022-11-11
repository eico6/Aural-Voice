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
    ///  Used as an alias to keep note names consistent and fail-safe.
    /// </summary>
    internal static class NoteName
    {
        internal const String A0 = "A0";
        internal const String Bb0 = "Bb0";
        // ...
    }

    /// <summary>
    ///  Adds 88 notes to the piano, and assigns a unique reference 
    ///  between each "note" and its corresponding "key".
    /// </summary> 
    private void InitializePiano()
    {
        piano = new Piano();
        
        piano.AddNote(NoteName.A0, keyA0);
        piano.AddNote(NoteName.Bb0, keyBb0);
        // ...

        // TODO: at the end, throw exception unless '_notes.count()' == 88
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
