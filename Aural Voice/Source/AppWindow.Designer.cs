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
            this.pianoCard = new MaterialSkin.Controls.MaterialCard();
            this.keyBb0 = new System.Windows.Forms.PictureBox();
            this.keyA0 = new System.Windows.Forms.PictureBox();
            this.keysLayout = new System.Windows.Forms.PictureBox();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabController.SuspendLayout();
            this.pianoTab.SuspendLayout();
            this.pianoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyBb0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyA0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysLayout)).BeginInit();
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
            this.tabController.Size = new System.Drawing.Size(874, 383);
            this.tabController.TabIndex = 0;
            // 
            // pianoTab
            // 
            this.pianoTab.Controls.Add(this.pianoCard);
            this.pianoTab.Location = new System.Drawing.Point(4, 4);
            this.pianoTab.Margin = new System.Windows.Forms.Padding(0);
            this.pianoTab.Name = "pianoTab";
            this.pianoTab.Size = new System.Drawing.Size(865, 375);
            this.pianoTab.TabIndex = 0;
            this.pianoTab.Text = "Piano";
            this.pianoTab.UseVisualStyleBackColor = true;
            // 
            // pianoCard
            // 
            this.pianoCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pianoCard.Controls.Add(this.keyBb0);
            this.pianoCard.Controls.Add(this.keyA0);
            this.pianoCard.Controls.Add(this.keysLayout);
            this.pianoCard.Depth = 0;
            this.pianoCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pianoCard.Location = new System.Drawing.Point(35, 246);
            this.pianoCard.Margin = new System.Windows.Forms.Padding(14);
            this.pianoCard.MouseState = MaterialSkin.MouseState.HOVER;
            this.pianoCard.Name = "pianoCard";
            this.pianoCard.Padding = new System.Windows.Forms.Padding(14);
            this.pianoCard.Size = new System.Drawing.Size(805, 115);
            this.pianoCard.TabIndex = 0;
            // 
            // keyBb0
            // 
            this.keyBb0.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyBb0.Location = new System.Drawing.Point(23, 18);
            this.keyBb0.Margin = new System.Windows.Forms.Padding(0);
            this.keyBb0.Name = "keyBb0";
            this.keyBb0.Size = new System.Drawing.Size(10, 47);
            this.keyBb0.TabIndex = 1;
            this.keyBb0.TabStop = false;
            this.keyBb0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyBb0_MouseDown);
            this.keyBb0.MouseEnter += new System.EventHandler(this.keyBb0_MouseEnter);
            this.keyBb0.MouseLeave += new System.EventHandler(this.keyBb0_MouseLeave);
            this.keyBb0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyBb0_MouseUp);
            // 
            // keyA0
            // 
            this.keyA0.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyA0.Location = new System.Drawing.Point(13, 18);
            this.keyA0.Margin = new System.Windows.Forms.Padding(0);
            this.keyA0.Name = "keyA0";
            this.keyA0.Size = new System.Drawing.Size(15, 75);
            this.keyA0.TabIndex = 0;
            this.keyA0.TabStop = false;
            this.keyA0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyA0_MouseDown);
            this.keyA0.MouseEnter += new System.EventHandler(this.keyA0_MouseEnter);
            this.keyA0.MouseLeave += new System.EventHandler(this.keyA0_MouseLeave);
            this.keyA0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyA0_MouseUp);
            // 
            // keysLayout
            // 
            this.keysLayout.Image = global::AuralVoice.ProjectResources.keys_layout;
            this.keysLayout.Location = new System.Drawing.Point(13, 18);
            this.keysLayout.Margin = new System.Windows.Forms.Padding(0);
            this.keysLayout.Name = "keysLayout";
            this.keysLayout.Size = new System.Drawing.Size(780, 75);
            this.keysLayout.TabIndex = 0;
            this.keysLayout.TabStop = false;
            this.keysLayout.Visible = false;
            // 
            // optionsTab
            // 
            this.optionsTab.Location = new System.Drawing.Point(4, 4);
            this.optionsTab.Margin = new System.Windows.Forms.Padding(0);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Size = new System.Drawing.Size(865, 375);
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
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.tabController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(880, 450);
            this.MinimumSize = new System.Drawing.Size(880, 450);
            this.Name = "AppWindow";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aural Voice";
            this.tabController.ResumeLayout(false);
            this.pianoTab.ResumeLayout(false);
            this.pianoCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keyBb0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyA0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysLayout)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private MaterialSkin.Controls.MaterialTabControl tabController;
    private TabPage pianoTab;
    private TabPage optionsTab;
    private MaterialSkin.Controls.MaterialTabSelector tabSelector;
    private MaterialSkin.Controls.MaterialCard pianoCard;
    private PictureBox keyA0;
    private PictureBox keysLayout;
    private PictureBox keyBb0;
}
