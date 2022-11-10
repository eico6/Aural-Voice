using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;
using AuralVoice.Audio;
using Windows.Devices.Midi;

namespace AuralVoice;

/// <summary>
///  There are two sets of "piano keys" (88 instances each).
///  This is due to the limitations of the Microsoft Windows Forms auto-generated code.
///  Notice the difference in naming when reffering between the two; "key(s)" and "note(s)".
/// 
///      ImageBox keys - The visual representation of keys that the user interacts with.
///                      The keys are associated with the EventHandler. They consist of auto-
///                      generated code, which is why they are not stored in a collection.
///      Note notes    - This is where the functionality of each key is handled.
///                      Each note has a a '_keyReference' to keep track of its associated key.
///                      The notes are stored within a hash table inside the 'Piano' class.
/// </summary>

public partial class AppWindow : MaterialForm
{
    private Piano? piano;
    private MaterialSkinManager? materialSkinManager;

    public AppWindow()
    {
        // TODO: show splashscreen while initializing variables. Use another winfows form
        // and show "Loading {components, material, piano} ...", whichever one is being
        // initialized. Then show "Complete!" and start a 1 sec fixed timer which ends with
        // app being fully displayed. GitHub link and author can also be displayed.

        InitializeComponent();
        InitializePiano();
        InitializeMaterialSkin();
    }
}