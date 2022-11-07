using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;
using AuralVoice.Audio;

namespace AuralVoice;


public partial class AppWindow : MaterialForm
{
    // Use multi-threading for more responsive feedback
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

    private Piano? piano;
    private MaterialSkinManager? materialSkinManager;

    public AppWindow()
    {
        InitializeComponent();

        materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        // TODO: show splashscreen for min 2 sec while piano is getting initialized.

        // - Initialize 'piano' with correct values and references.
        InitializePiano();
    }
}