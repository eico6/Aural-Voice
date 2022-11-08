using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;
using AuralVoice.Audio;
using Windows.Devices.Midi;

namespace AuralVoice;


public partial class AppWindow : MaterialForm
{
    private Piano? piano;
    private MidiSynthesizer? midiSynth;
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
        // TODO: show splashscreen for a minimum of 2 sec while piano is getting initialized.

        InitializePiano();
        InitializeMidiSynth();
    }
}