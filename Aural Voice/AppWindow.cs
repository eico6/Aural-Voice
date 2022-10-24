using System.Media;

namespace AuralVoice;


public partial class AppWindow : Form
{
    // Use multi-threading for more responsive feedback
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

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
        // Notice that we need more threads to play these simultaneously
        SoundPlayer soundPlayer = new SoundPlayer(resources.PianoAudio.test);
        SoundPlayer soundPlayer2 = new SoundPlayer(resources.PianoAudio.C5);
        soundPlayer2.Play();
        soundPlayer.Play();


        // gjør da inni ein thorw cath, eller exception kanskje

    }
}