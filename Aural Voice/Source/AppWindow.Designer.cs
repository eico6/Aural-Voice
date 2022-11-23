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
            this.pianoCard = new MaterialSkin.Controls.MaterialCard();
            this.pianoTab = new System.Windows.Forms.TabPage();
            this.keyBb1 = new System.Windows.Forms.PictureBox();
            this.keyB1 = new System.Windows.Forms.PictureBox();
            this.keyAb1 = new System.Windows.Forms.PictureBox();
            this.keyA1 = new System.Windows.Forms.PictureBox();
            this.keyGb1 = new System.Windows.Forms.PictureBox();
            this.keyG1 = new System.Windows.Forms.PictureBox();
            this.keyF1 = new System.Windows.Forms.PictureBox();
            this.keyEb1 = new System.Windows.Forms.PictureBox();
            this.keyE1 = new System.Windows.Forms.PictureBox();
            this.keyDb1 = new System.Windows.Forms.PictureBox();
            this.keyD1 = new System.Windows.Forms.PictureBox();
            this.keyC1 = new System.Windows.Forms.PictureBox();
            this.keyBb0 = new System.Windows.Forms.PictureBox();
            this.keyB0 = new System.Windows.Forms.PictureBox();
            this.keyA0 = new System.Windows.Forms.PictureBox();
            this.keysLayout = new System.Windows.Forms.PictureBox();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabController.SuspendLayout();
            this.pianoTab.SuspendLayout();
            this.pianoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyBb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyAb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyA1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyGb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyEb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyE1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyDb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBb0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB0)).BeginInit();
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
            this.pianoCard.Controls.Add(this.keyBb1);
            this.pianoCard.Controls.Add(this.keyB1);
            this.pianoCard.Controls.Add(this.keyAb1);
            this.pianoCard.Controls.Add(this.keyA1);
            this.pianoCard.Controls.Add(this.keyGb1);
            this.pianoCard.Controls.Add(this.keyG1);
            this.pianoCard.Controls.Add(this.keyF1);
            this.pianoCard.Controls.Add(this.keyEb1);
            this.pianoCard.Controls.Add(this.keyE1);
            this.pianoCard.Controls.Add(this.keyDb1);
            this.pianoCard.Controls.Add(this.keyD1);
            this.pianoCard.Controls.Add(this.keyC1);
            this.pianoCard.Controls.Add(this.keyBb0);
            this.pianoCard.Controls.Add(this.keyB0);
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
            // keyBb1
            // 
            this.keyBb1.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyBb1.Location = new System.Drawing.Point(128, 18);
            this.keyBb1.Margin = new System.Windows.Forms.Padding(0);
            this.keyBb1.Name = "keyBb1";
            this.keyBb1.Size = new System.Drawing.Size(10, 47);
            this.keyBb1.TabIndex = 11;
            this.keyBb1.TabStop = false;
            this.keyBb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyBb1_MouseDown);
            this.keyBb1.MouseEnter += new System.EventHandler(this.keyBb1_MouseEnter);
            this.keyBb1.MouseLeave += new System.EventHandler(this.keyBb1_MouseLeave);
            this.keyBb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyBb1_MouseUp);
            // 
            // keyB1
            // 
            this.keyB1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyB1.Location = new System.Drawing.Point(133, 18);
            this.keyB1.Margin = new System.Windows.Forms.Padding(0);
            this.keyB1.Name = "keyB1";
            this.keyB1.Size = new System.Drawing.Size(15, 75);
            this.keyB1.TabIndex = 14;
            this.keyB1.TabStop = false;
            this.keyB1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyB1_MouseDown);
            this.keyB1.MouseEnter += new System.EventHandler(this.keyB1_MouseEnter);
            this.keyB1.MouseLeave += new System.EventHandler(this.keyB1_MouseLeave);
            this.keyB1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyB1_MouseUp);
            // 
            // keyAb1
            // 
            this.keyAb1.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyAb1.Location = new System.Drawing.Point(113, 18);
            this.keyAb1.Margin = new System.Windows.Forms.Padding(0);
            this.keyAb1.Name = "keyAb1";
            this.keyAb1.Size = new System.Drawing.Size(10, 47);
            this.keyAb1.TabIndex = 10;
            this.keyAb1.TabStop = false;
            this.keyAb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyAb1_MouseDown);
            this.keyAb1.MouseEnter += new System.EventHandler(this.keyAb1_MouseEnter);
            this.keyAb1.MouseLeave += new System.EventHandler(this.keyAb1_MouseLeave);
            this.keyAb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyAb1_MouseUp);
            // 
            // keyA1
            // 
            this.keyA1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyA1.Location = new System.Drawing.Point(118, 18);
            this.keyA1.Margin = new System.Windows.Forms.Padding(0);
            this.keyA1.Name = "keyA1";
            this.keyA1.Size = new System.Drawing.Size(15, 75);
            this.keyA1.TabIndex = 13;
            this.keyA1.TabStop = false;
            this.keyA1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyA1_MouseDown);
            this.keyA1.MouseEnter += new System.EventHandler(this.keyA1_MouseEnter);
            this.keyA1.MouseLeave += new System.EventHandler(this.keyA1_MouseLeave);
            this.keyA1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyA1_MouseUp);
            // 
            // keyGb1
            // 
            this.keyGb1.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyGb1.Location = new System.Drawing.Point(98, 18);
            this.keyGb1.Margin = new System.Windows.Forms.Padding(0);
            this.keyGb1.Name = "keyGb1";
            this.keyGb1.Size = new System.Drawing.Size(10, 47);
            this.keyGb1.TabIndex = 6;
            this.keyGb1.TabStop = false;
            this.keyGb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyGb1_MouseDown);
            this.keyGb1.MouseEnter += new System.EventHandler(this.keyGb1_MouseEnter);
            this.keyGb1.MouseLeave += new System.EventHandler(this.keyGb1_MouseLeave);
            this.keyGb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyGb1_MouseUp);
            // 
            // keyG1
            // 
            this.keyG1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyG1.Location = new System.Drawing.Point(103, 18);
            this.keyG1.Margin = new System.Windows.Forms.Padding(0);
            this.keyG1.Name = "keyG1";
            this.keyG1.Size = new System.Drawing.Size(15, 75);
            this.keyG1.TabIndex = 12;
            this.keyG1.TabStop = false;
            this.keyG1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyG1_MouseDown);
            this.keyG1.MouseEnter += new System.EventHandler(this.keyG1_MouseEnter);
            this.keyG1.MouseLeave += new System.EventHandler(this.keyG1_MouseLeave);
            this.keyG1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyG1_MouseUp);
            // 
            // keyF1
            // 
            this.keyF1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyF1.Location = new System.Drawing.Point(88, 18);
            this.keyF1.Margin = new System.Windows.Forms.Padding(0);
            this.keyF1.Name = "keyF1";
            this.keyF1.Size = new System.Drawing.Size(15, 75);
            this.keyF1.TabIndex = 9;
            this.keyF1.TabStop = false;
            this.keyF1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyF1_MouseDown);
            this.keyF1.MouseEnter += new System.EventHandler(this.keyF1_MouseEnter);
            this.keyF1.MouseLeave += new System.EventHandler(this.keyF1_MouseLeave);
            this.keyF1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyF1_MouseUp);
            // 
            // keyEb1
            // 
            this.keyEb1.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyEb1.Location = new System.Drawing.Point(68, 18);
            this.keyEb1.Margin = new System.Windows.Forms.Padding(0);
            this.keyEb1.Name = "keyEb1";
            this.keyEb1.Size = new System.Drawing.Size(10, 47);
            this.keyEb1.TabIndex = 5;
            this.keyEb1.TabStop = false;
            this.keyEb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyEb1_MouseDown);
            this.keyEb1.MouseEnter += new System.EventHandler(this.keyEb1_MouseEnter);
            this.keyEb1.MouseLeave += new System.EventHandler(this.keyEb1_MouseLeave);
            this.keyEb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyEb1_MouseUp);
            // 
            // keyE1
            // 
            this.keyE1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyE1.Location = new System.Drawing.Point(73, 18);
            this.keyE1.Margin = new System.Windows.Forms.Padding(0);
            this.keyE1.Name = "keyE1";
            this.keyE1.Size = new System.Drawing.Size(15, 75);
            this.keyE1.TabIndex = 8;
            this.keyE1.TabStop = false;
            this.keyE1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyE1_MouseDown);
            this.keyE1.MouseEnter += new System.EventHandler(this.keyE1_MouseEnter);
            this.keyE1.MouseLeave += new System.EventHandler(this.keyE1_MouseLeave);
            this.keyE1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyE1_MouseUp);
            // 
            // keyDb1
            // 
            this.keyDb1.Image = global::AuralVoice.ProjectResources.key_black_idle;
            this.keyDb1.Location = new System.Drawing.Point(53, 18);
            this.keyDb1.Margin = new System.Windows.Forms.Padding(0);
            this.keyDb1.Name = "keyDb1";
            this.keyDb1.Size = new System.Drawing.Size(10, 47);
            this.keyDb1.TabIndex = 4;
            this.keyDb1.TabStop = false;
            this.keyDb1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyDb1_MouseDown);
            this.keyDb1.MouseEnter += new System.EventHandler(this.keyDb1_MouseEnter);
            this.keyDb1.MouseLeave += new System.EventHandler(this.keyDb1_MouseLeave);
            this.keyDb1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyDb1_MouseUp);
            // 
            // keyD1
            // 
            this.keyD1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyD1.Location = new System.Drawing.Point(58, 18);
            this.keyD1.Margin = new System.Windows.Forms.Padding(0);
            this.keyD1.Name = "keyD1";
            this.keyD1.Size = new System.Drawing.Size(15, 75);
            this.keyD1.TabIndex = 7;
            this.keyD1.TabStop = false;
            this.keyD1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyD1_MouseDown);
            this.keyD1.MouseEnter += new System.EventHandler(this.keyD1_MouseEnter);
            this.keyD1.MouseLeave += new System.EventHandler(this.keyD1_MouseLeave);
            this.keyD1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyD1_MouseUp);
            // 
            // keyC1
            // 
            this.keyC1.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyC1.Location = new System.Drawing.Point(43, 18);
            this.keyC1.Margin = new System.Windows.Forms.Padding(0);
            this.keyC1.Name = "keyC1";
            this.keyC1.Size = new System.Drawing.Size(15, 75);
            this.keyC1.TabIndex = 3;
            this.keyC1.TabStop = false;
            this.keyC1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyC1_MouseDown);
            this.keyC1.MouseEnter += new System.EventHandler(this.keyC1_MouseEnter);
            this.keyC1.MouseLeave += new System.EventHandler(this.keyC1_MouseLeave);
            this.keyC1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyC1_MouseUp);
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
            // keyB0
            // 
            this.keyB0.Image = global::AuralVoice.ProjectResources.key_white_idle;
            this.keyB0.Location = new System.Drawing.Point(28, 18);
            this.keyB0.Margin = new System.Windows.Forms.Padding(0);
            this.keyB0.Name = "keyB0";
            this.keyB0.Size = new System.Drawing.Size(15, 75);
            this.keyB0.TabIndex = 2;
            this.keyB0.TabStop = false;
            this.keyB0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.keyB0_MouseDown);
            this.keyB0.MouseEnter += new System.EventHandler(this.keyB0_MouseEnter);
            this.keyB0.MouseLeave += new System.EventHandler(this.keyB0_MouseLeave);
            this.keyB0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.keyB0_MouseUp);
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
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(880, 450);
            this.MinimumSize = new System.Drawing.Size(880, 450);
            this.Name = "AppWindow";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aural Voice";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AppWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AppWindow_KeyUp);
            this.tabController.ResumeLayout(false);
            this.pianoTab.ResumeLayout(false);
            this.pianoCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keyBb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyAb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyA1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyGb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyEb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyE1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyDb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBb0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyB0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyA0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keysLayout)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private MaterialSkin.Controls.MaterialTabControl tabController;
    private MaterialSkin.Controls.MaterialTabSelector tabSelector;
    private MaterialSkin.Controls.MaterialCard pianoCard;
    private TabPage pianoTab;
    private TabPage optionsTab;
    private PictureBox keysLayout;
    private PictureBox keyA0;
    private PictureBox keyBb0;
    private PictureBox keyB0;
    private PictureBox keyC1;
    private PictureBox keyDb1;
    private PictureBox keyD1;
    private PictureBox keyEb1;
    private PictureBox keyE1;
    private PictureBox keyF1;
    private PictureBox keyGb1;
    private PictureBox keyG1;
    private PictureBox keyAb1;
    private PictureBox keyA1;
    private PictureBox keyBb1;
    private PictureBox keyB1;
}
