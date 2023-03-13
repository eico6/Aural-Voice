using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;
using Windows.Devices.Midi;
using Windows.UI.Notifications;
using Windows.UI.WindowManagement;

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
///                      Each note has a a key reference to keep track of its associated key.
///                      The notes are stored within a hash table inside the 'Piano' class.
/// </summary>

public partial class AppWindow : MaterialForm
{
    private Piano? piano;
    private Gamemaster? gamemaster;
    private MaterialSkinManager? materialSkinManager;

    public AppWindow()
    {
        InitializeComponent();
        InitializePiano();
        InitializeGamemaster();
        InitializeMaterialSkin();
    }
}