using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;

namespace AuralVoice;


public partial class AppWindow : MaterialForm
{
    // Use multi-threading for more responsive feedback
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

    private MaterialSkinManager? materialSkinManager;

    internal AppWindow()
    {
        InitializeComponent();

        materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
    }

    // Load
    // TODO: show splashscreen for 2 sec

    // Button
    //// 'SoundPlayer' class does not support playing multiple sounds simultaneously.
    //SoundPlayer soundPlayer = new SoundPlayer(resources.PianoAudio.test);
    //SoundPlayer soundPlayer2 = new SoundPlayer(resources.PianoAudio.C5);
    //soundPlayer2.Play();
    //soundPlayer.Play();
}