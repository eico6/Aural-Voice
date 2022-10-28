namespace AuralVoice;


partial class AppWindow
{
    ///  Required designer variable.
    private System.ComponentModel.IContainer components = null;

    ///  Clean up any resources being used.
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.tabController = new MaterialSkin.Controls.MaterialTabControl();
            this.pianoTab = new System.Windows.Forms.TabPage();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabController.Controls.Add(this.pianoTab);
            this.tabController.Controls.Add(this.optionsTab);
            this.tabController.Depth = 0;
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabController.ItemSize = new System.Drawing.Size(19, 1);
            this.tabController.Location = new System.Drawing.Point(3, 64);
            this.tabController.Margin = new System.Windows.Forms.Padding(0);
            this.tabController.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabController.Multiline = true;
            this.tabController.Name = "tabController";
            this.tabController.Padding = new System.Drawing.Point(0, 0);
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(834, 383);
            this.tabController.TabIndex = 0;
            // 
            // pianoTab
            // 
            this.pianoTab.Location = new System.Drawing.Point(4, 4);
            this.pianoTab.Margin = new System.Windows.Forms.Padding(0);
            this.pianoTab.Name = "pianoTab";
            this.pianoTab.Size = new System.Drawing.Size(825, 375);
            this.pianoTab.TabIndex = 0;
            this.pianoTab.Text = "Piano";
            this.pianoTab.UseVisualStyleBackColor = true;
            // 
            // optionsTab
            // 
            this.optionsTab.Location = new System.Drawing.Point(4, 4);
            this.optionsTab.Margin = new System.Windows.Forms.Padding(0);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(825, 375);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // tabSelector
            // 
            this.tabSelector.BaseTabControl = this.tabController;
            this.tabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.tabSelector.Depth = 0;
            this.tabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelector.Location = new System.Drawing.Point(125, 24);
            this.tabSelector.Margin = new System.Windows.Forms.Padding(0);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(480, 40);
            this.tabSelector.TabIndex = 0;
            this.tabSelector.Text = "tabSelector";
            // 
            // AppWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(840, 450);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.tabController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 450);
            this.MinimumSize = new System.Drawing.Size(840, 450);
            this.Name = "AppWindow";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aural Voice";
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.tabController.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private MaterialSkin.Controls.MaterialTabControl tabController;
    private TabPage pianoTab;
    private TabPage optionsTab;
    private MaterialSkin.Controls.MaterialTabSelector tabSelector;
}
