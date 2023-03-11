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
    ///  Essentially promotes the use of l-values instead of r-values.
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
        piano = new Piano(ref programSelector, ref tabController);
        
        // Octave 0
        piano.AddNote(NoteName.A0, keyA0);
        piano.AddNote(NoteName.Bb0, keyBb0);
        piano.AddNote(NoteName.B0, keyB0);

        // Octave 1
        piano.AddNote(NoteName.C1, keyC1);
        piano.AddNote(NoteName.Db1, keyDb1);
        piano.AddNote(NoteName.D1, keyD1);
        piano.AddNote(NoteName.Eb1, keyEb1);
        piano.AddNote(NoteName.E1, keyE1);
        piano.AddNote(NoteName.F1, keyF1);
        piano.AddNote(NoteName.Gb1, keyGb1);
        piano.AddNote(NoteName.G1, keyG1);
        piano.AddNote(NoteName.Ab1, keyAb1);
        piano.AddNote(NoteName.A1, keyA1);
        piano.AddNote(NoteName.Bb1, keyBb1);
        piano.AddNote(NoteName.B1, keyB1);

        // Octave 2
        piano.AddNote(NoteName.C2, keyC2);
        piano.AddNote(NoteName.Db2, keyDb2);
        piano.AddNote(NoteName.D2, keyD2);
        piano.AddNote(NoteName.Eb2, keyEb2);
        piano.AddNote(NoteName.E2, keyE2);
        piano.AddNote(NoteName.F2, keyF2);
        piano.AddNote(NoteName.Gb2, keyGb2);
        piano.AddNote(NoteName.G2, keyG2);
        piano.AddNote(NoteName.Ab2, keyAb2);
        piano.AddNote(NoteName.A2, keyA2);
        piano.AddNote(NoteName.Bb2, keyBb2);
        piano.AddNote(NoteName.B2, keyB2);

        // Octave 3
        piano.AddNote(NoteName.C3, keyC3);
        piano.AddNote(NoteName.Db3, keyDb3);
        piano.AddNote(NoteName.D3, keyD3);
        piano.AddNote(NoteName.Eb3, keyEb3);
        piano.AddNote(NoteName.E3, keyE3);
        piano.AddNote(NoteName.F3, keyF3);
        piano.AddNote(NoteName.Gb3, keyGb3);
        piano.AddNote(NoteName.G3, keyG3);
        piano.AddNote(NoteName.Ab3, keyAb3);
        piano.AddNote(NoteName.A3, keyA3);
        piano.AddNote(NoteName.Bb3, keyBb3);
        piano.AddNote(NoteName.B3, keyB3);

        // Octave 4
        piano.AddNote(NoteName.C4, keyC4);
        piano.AddNote(NoteName.Db4, keyDb4);
        piano.AddNote(NoteName.D4, keyD4);
        piano.AddNote(NoteName.Eb4, keyEb4);
        piano.AddNote(NoteName.E4, keyE4);
        piano.AddNote(NoteName.F4, keyF4);
        piano.AddNote(NoteName.Gb4, keyGb4);
        piano.AddNote(NoteName.G4, keyG4);
        piano.AddNote(NoteName.Ab4, keyAb4);
        piano.AddNote(NoteName.A4, keyA4);
        piano.AddNote(NoteName.Bb4, keyBb4);
        piano.AddNote(NoteName.B4, keyB4);

        // Octave 5
        piano.AddNote(NoteName.C5, keyC5);
        piano.AddNote(NoteName.Db5, keyDb5);
        piano.AddNote(NoteName.D5, keyD5);
        piano.AddNote(NoteName.Eb5, keyEb5);
        piano.AddNote(NoteName.E5, keyE5);
        piano.AddNote(NoteName.F5, keyF5);
        piano.AddNote(NoteName.Gb5, keyGb5);
        piano.AddNote(NoteName.G5, keyG5);
        piano.AddNote(NoteName.Ab5, keyAb5);
        piano.AddNote(NoteName.A5, keyA5);
        piano.AddNote(NoteName.Bb5, keyBb5);
        piano.AddNote(NoteName.B5, keyB5);

        // Octave 6
        piano.AddNote(NoteName.C6, keyC6);
        piano.AddNote(NoteName.Db6, keyDb6);
        piano.AddNote(NoteName.D6, keyD6);
        piano.AddNote(NoteName.Eb6, keyEb6);
        piano.AddNote(NoteName.E6, keyE6);
        piano.AddNote(NoteName.F6, keyF6);
        piano.AddNote(NoteName.Gb6, keyGb6);
        piano.AddNote(NoteName.G6, keyG6);
        piano.AddNote(NoteName.Ab6, keyAb6);
        piano.AddNote(NoteName.A6, keyA6);
        piano.AddNote(NoteName.Bb6, keyBb6);
        piano.AddNote(NoteName.B6, keyB6);

        // Octave 7
        piano.AddNote(NoteName.C7, keyC7);
        piano.AddNote(NoteName.Db7, keyDb7);
        piano.AddNote(NoteName.D7, keyD7);
        piano.AddNote(NoteName.Eb7, keyEb7);
        piano.AddNote(NoteName.E7, keyE7);
        piano.AddNote(NoteName.F7, keyF7);
        piano.AddNote(NoteName.Gb7, keyGb7);
        piano.AddNote(NoteName.G7, keyG7);
        piano.AddNote(NoteName.Ab7, keyAb7);
        piano.AddNote(NoteName.A7, keyA7);
        piano.AddNote(NoteName.Bb7, keyBb7);
        piano.AddNote(NoteName.B7, keyB7);

        // Octave 8
        piano.AddNote(NoteName.C8, keyC8);
    }

    /// <summary>
    ///  Sets required control references for communication with the UI.
    /// </summary>
    private void InitializeGamemaster()
    {
        gamemaster = new Gamemaster(this, ref buttonGame, ref buttonQuestion, ref noteDisplay, ref noteDisplayText);
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
                                                          Accent.Blue400, TextShade.WHITE); // Prev accent: LightBlue200
    }
}
