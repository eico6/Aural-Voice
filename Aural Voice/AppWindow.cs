using MaterialSkin;
using MaterialSkin.Controls;
using System.Media;

namespace AuralVoice;


public partial class AppWindow : MaterialForm
{
    // Use multi-threading for more responsive feedback
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/multithreading-in-windows-forms-controls?view=netframeworkdesktop-4.8
    // - https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form?view=netframeworkdesktop-4.8

    private Piano? piano;
    private MaterialSkinManager? materialSkinManager;

    internal AppWindow()
    {
        InitializeComponent();

        piano = new Piano();

        materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
    }

    private void AppWindow_Load(object sender, EventArgs e)
    {
        // TODO: show splashscreen for 2 sec

        // Connect PictureBox.notes to the appropriate Piano.tangents
        // - Cast all 'ImageBox' notes into 'ImageBox.Tangent' tangents.
        // - Then add them to the 'Piano.Tangents' list as references.
    }

    // There are two sets of tangents:
    //     Visual Tangents
    //     - Class: Forms.PictureBox
    //     - The visual representation of tangents in the application.
    //     - Mostly managed by Windows Forms through the designer.
    //
    //     Tangents
    //     - Class: Forms.PictureBox.Tangent
    //     - The 
    //
    // (Edit: hmmmm maybe not needed to have two sets of tangets, noticed that I
    // can set visual tangent's access modifier to protected in the designer)


    // - If downcasting becomes a problem, then you could also just fill up
    //   the dictionary with 88 tangents with proper string key and note audio
    //   in its constructor. Then just let these events call the respective dictionary element. 
    // - Make PictureBox notes private instead of protected, and run a void
    //   function in AppWindow() that simply references each tangent with a note (maybe
    //   do the dictionary "filling up" here instead of in the constructor so that everything
    //   that has to do with "all elements operations" is located at the same place.
    // - This is possiblty a cleaner solution as well. 
    // - Will look something like this:
    // private void noteA0_Click(object sender, EventArgs e)
    // {
    //     piano.tangents["A0"].Play()
    // }
    #region PictureBox notes - Click events
    private void noteA0_Click(object sender, EventArgs e)
    {
        // ...
    }
    #endregion

    #region PictureBox notes - MouseEnter events
    // private void noteA0_MouseEnter(...)
    // ...
    #endregion

    #region PictureBox notes - MouseLeave events
    // private void noteA0_MouseLeave(...)
    // ...
    #endregion

}