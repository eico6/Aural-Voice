﻿namespace AuralVoice;


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
            this.noteA0 = new System.Windows.Forms.PictureBox();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabController.SuspendLayout();
            this.pianoTab.SuspendLayout();
            this.pianoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteA0)).BeginInit();
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
            this.pianoCard.Controls.Add(this.noteA0);
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
            // noteA0
            // 
            this.noteA0.Location = new System.Drawing.Point(208, 17);
            this.noteA0.Name = "noteA0";
            this.noteA0.Size = new System.Drawing.Size(37, 81);
            this.noteA0.TabIndex = 0;
            this.noteA0.TabStop = false;
            this.noteA0.Click += new System.EventHandler(this.noteA0_Click);
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
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.tabController.ResumeLayout(false);
            this.pianoTab.ResumeLayout(false);
            this.pianoCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noteA0)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private MaterialSkin.Controls.MaterialTabControl tabController;
    private TabPage pianoTab;
    private TabPage optionsTab;
    private MaterialSkin.Controls.MaterialTabSelector tabSelector;
    private MaterialSkin.Controls.MaterialCard pianoCard;
    protected PictureBox noteA0;
}
