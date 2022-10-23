using System.Media;
using System.Reflection;

namespace AuralVoice;


internal partial class AppWindow : Form
{
    // Notes:
    // - AppWindow size should be (840, 390)

    private SoundPlayer? _soundPlayer;
    private String? _audioPath;

    internal AppWindow()
    {
        InitializeComponent();

    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        // TODO: show splashscreen for 2 sec
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Best practice for building paths:
        // - https://stackoverflow.com/questions/10704579/best-practice-for-building-file-paths-in-c-sharp

        // Use multi-threading for more responsive feedback
        // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

        // TODO: figure out how to properly get the audio path so that it works at release version through a shortcut.
        _audioPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 

        // Hardcode the path until '_audioPath' is figured out.
        _soundPlayer = new SoundPlayer(@"C:\Visual Studio Projects\Aural-Voice\Aural Voice\resources\audio\C5.wav");

        if (_soundPlayer != null && _audioPath != null)
        {
            _soundPlayer.Play();
            MessageBox.Show($"You hit the note C5. \n\nREWARD: {_audioPath}");
        }

    }
}