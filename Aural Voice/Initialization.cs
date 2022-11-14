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
        // Octave 0
        internal const String A0  = "A0";
        internal const String Bb0 = "Bb0";
        internal const String B0  = "B0";

        // Octave 1
        internal const String C1  = "C1";
        internal const String Db1 = "Db1";
        internal const String D1  = "D1";
        internal const String Eb1 = "Eb1";
        internal const String E1  = "E1";
        internal const String F1  = "F1";
        internal const String Gb1 = "Gb1";
        internal const String G1  = "G1";
        internal const String Ab1 = "Ab1";
        internal const String A1  = "A1";
        internal const String Bb1 = "Bb1";
        internal const String B1  = "B1";

        // Octave 2
        internal const String C2  = "C2";
        internal const String Db2 = "Db2";
        internal const String D2  = "D2";
        internal const String Eb2 = "Eb2";
        internal const String E2  = "E2";
        internal const String F2  = "F2";
        internal const String Gb2 = "Gb2";
        internal const String G2  = "G2";
        internal const String Ab2 = "Ab2";
        internal const String A2  = "A2";
        internal const String Bb2 = "Bb2";
        internal const String B2  = "B2";

        // Octave 3
        internal const String C3  = "C3";
        internal const String Db3 = "Db3";
        internal const String D3  = "D3";
        internal const String Eb3 = "Eb3";
        internal const String E3  = "E3";
        internal const String F3  = "F3";
        internal const String Gb3 = "Gb3";
        internal const String G3  = "G3";
        internal const String Ab3 = "Ab3";
        internal const String A3  = "A3";
        internal const String Bb3 = "Bb3";
        internal const String B3  = "B3";

        // Octave 4
        internal const String C4  = "C4";
        internal const String Db4 = "Db4";
        internal const String D4  = "D4";
        internal const String Eb4 = "Eb4";
        internal const String E4  = "E4";
        internal const String F4  = "F4";
        internal const String Gb4 = "Gb4";
        internal const String G4  = "G4";
        internal const String Ab4 = "Ab4";
        internal const String A4  = "A4";
        internal const String Bb4 = "Bb4";
        internal const String B4  = "B4";

        // Octave 5
        internal const String C5  = "C5";
        internal const String Db5 = "Db5";
        internal const String D5  = "D5";
        internal const String Eb5 = "Eb5";
        internal const String E5  = "E5";
        internal const String F5  = "F5";
        internal const String Gb5 = "Gb5";
        internal const String G5  = "G5";
        internal const String Ab5 = "Ab5";
        internal const String A5  = "A5";
        internal const String Bb5 = "Bb5";
        internal const String B5  = "B5";

        // Octave 6
        internal const String C6  = "C6";
        internal const String Db6 = "Db6";
        internal const String D6  = "D6";
        internal const String Eb6 = "Eb6";
        internal const String E6  = "E6";
        internal const String F6  = "F6";
        internal const String Gb6 = "Gb6";
        internal const String G6  = "G6";
        internal const String Ab6 = "Ab6";
        internal const String A6  = "A6";
        internal const String Bb6 = "Bb6";
        internal const String B6  = "B6";

        // Octave 7
        internal const String C7  = "C7";
        internal const String Db7 = "Db7";
        internal const String D7  = "D7";
        internal const String Eb7 = "Eb7";
        internal const String E7  = "E7";
        internal const String F7  = "F7";
        internal const String Gb7 = "Gb7";
        internal const String G7  = "G7";
        internal const String Ab7 = "Ab7";
        internal const String A7  = "A7";
        internal const String Bb7 = "Bb7";
        internal const String B7  = "B7";

        // Octave 8
        internal const String C8  = "C8";
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
