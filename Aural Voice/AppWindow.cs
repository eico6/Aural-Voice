using System.Media;
using System.Reflection;
using System.Resources;

namespace AuralVoice;


public partial class AppWindow : Form
{
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
        // Use multi-threading for more responsive feedback
        // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
        // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Visual Studio Projects\Aural-Voice\Aural Voice\resources\audio\C5.wav");
        soundPlayer.Play();


        //if (_soundPlayer != null && _audioPath != null)
        //{
        //    _soundPlayer.Play();
        //    MessageBox.Show($"You hit the note C5. \n\nNow playing audio from: {_audioPath}");
        //}

        
    }
}