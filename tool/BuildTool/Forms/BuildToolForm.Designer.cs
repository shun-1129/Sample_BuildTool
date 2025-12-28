namespace BuildTool.Forms
{
    partial class BuildToolForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            BuildToolFormTabControl = new TabControl ();
            ProjectFileUpdateTabPage = new TabPage ();
            ReturnBtn = new Button ();
            ChengeBtn = new Button ();
            BuildVersionGroupBox = new GroupBox ();
            BuildVersionTextBox = new TextBox ();
            PatchVersionGroupBox = new GroupBox ();
            PatchVersionTextBox = new TextBox ();
            MinorVersionGroupBox = new GroupBox ();
            MinorVersionTextBox = new TextBox ();
            MajorVersionGroupBox = new GroupBox ();
            MajorVersionTextBox = new TextBox ();
            BulidTabPage = new TabPage ();
            BuildToolFormTabControl.SuspendLayout ();
            ProjectFileUpdateTabPage.SuspendLayout ();
            BuildVersionGroupBox.SuspendLayout ();
            PatchVersionGroupBox.SuspendLayout ();
            MinorVersionGroupBox.SuspendLayout ();
            MajorVersionGroupBox.SuspendLayout ();
            SuspendLayout ();
            // 
            // BuildToolFormTabControl
            // 
            BuildToolFormTabControl.Controls.Add ( ProjectFileUpdateTabPage );
            BuildToolFormTabControl.Controls.Add ( BulidTabPage );
            BuildToolFormTabControl.Dock = DockStyle.Fill;
            BuildToolFormTabControl.Location = new Point ( 0 , 0 );
            BuildToolFormTabControl.Name = "BuildToolFormTabControl";
            BuildToolFormTabControl.SelectedIndex = 0;
            BuildToolFormTabControl.Size = new Size ( 511 , 212 );
            BuildToolFormTabControl.TabIndex = 0;
            // 
            // ProjectFileUpdateTabPage
            // 
            ProjectFileUpdateTabPage.Controls.Add ( ReturnBtn );
            ProjectFileUpdateTabPage.Controls.Add ( ChengeBtn );
            ProjectFileUpdateTabPage.Controls.Add ( BuildVersionGroupBox );
            ProjectFileUpdateTabPage.Controls.Add ( PatchVersionGroupBox );
            ProjectFileUpdateTabPage.Controls.Add ( MinorVersionGroupBox );
            ProjectFileUpdateTabPage.Controls.Add ( MajorVersionGroupBox );
            ProjectFileUpdateTabPage.Location = new Point ( 4 , 24 );
            ProjectFileUpdateTabPage.Name = "ProjectFileUpdateTabPage";
            ProjectFileUpdateTabPage.Padding = new Padding ( 3 );
            ProjectFileUpdateTabPage.Size = new Size ( 503 , 184 );
            ProjectFileUpdateTabPage.TabIndex = 0;
            ProjectFileUpdateTabPage.Text = "プロジェクトファイル更新";
            ProjectFileUpdateTabPage.UseVisualStyleBackColor = true;
            // 
            // ReturnBtn
            // 
            ReturnBtn.Location = new Point ( 339 , 81 );
            ReturnBtn.Name = "ReturnBtn";
            ReturnBtn.Size = new Size ( 75 , 23 );
            ReturnBtn.TabIndex = 6;
            ReturnBtn.Text = "戻す";
            ReturnBtn.UseVisualStyleBackColor = true;
            ReturnBtn.Click += ReturnBtn_Click;
            // 
            // ChengeBtn
            // 
            ChengeBtn.Location = new Point ( 420 , 81 );
            ChengeBtn.Name = "ChengeBtn";
            ChengeBtn.Size = new Size ( 75 , 23 );
            ChengeBtn.TabIndex = 5;
            ChengeBtn.Text = "変更";
            ChengeBtn.UseVisualStyleBackColor = true;
            ChengeBtn.Click += ChengeBtn_Click;
            // 
            // BuildVersionGroupBox
            // 
            BuildVersionGroupBox.Controls.Add ( BuildVersionTextBox );
            BuildVersionGroupBox.Location = new Point ( 371 , 6 );
            BuildVersionGroupBox.Name = "BuildVersionGroupBox";
            BuildVersionGroupBox.Size = new Size ( 115 , 55 );
            BuildVersionGroupBox.TabIndex = 4;
            BuildVersionGroupBox.TabStop = false;
            BuildVersionGroupBox.Text = "ビルド";
            // 
            // BuildVersionTextBox
            // 
            BuildVersionTextBox.Location = new Point ( 6 , 22 );
            BuildVersionTextBox.Name = "BuildVersionTextBox";
            BuildVersionTextBox.Size = new Size ( 100 , 23 );
            BuildVersionTextBox.TabIndex = 1;
            BuildVersionTextBox.Text = "0";
            // 
            // PatchVersionGroupBox
            // 
            PatchVersionGroupBox.Controls.Add ( PatchVersionTextBox );
            PatchVersionGroupBox.Location = new Point ( 250 , 6 );
            PatchVersionGroupBox.Name = "PatchVersionGroupBox";
            PatchVersionGroupBox.Size = new Size ( 115 , 55 );
            PatchVersionGroupBox.TabIndex = 3;
            PatchVersionGroupBox.TabStop = false;
            PatchVersionGroupBox.Text = "パッチ";
            // 
            // PatchVersionTextBox
            // 
            PatchVersionTextBox.Location = new Point ( 6 , 22 );
            PatchVersionTextBox.Name = "PatchVersionTextBox";
            PatchVersionTextBox.Size = new Size ( 100 , 23 );
            PatchVersionTextBox.TabIndex = 1;
            PatchVersionTextBox.Text = "0";
            // 
            // MinorVersionGroupBox
            // 
            MinorVersionGroupBox.Controls.Add ( MinorVersionTextBox );
            MinorVersionGroupBox.Location = new Point ( 129 , 6 );
            MinorVersionGroupBox.Name = "MinorVersionGroupBox";
            MinorVersionGroupBox.Size = new Size ( 115 , 55 );
            MinorVersionGroupBox.TabIndex = 2;
            MinorVersionGroupBox.TabStop = false;
            MinorVersionGroupBox.Text = "マイナー";
            // 
            // MinorVersionTextBox
            // 
            MinorVersionTextBox.Location = new Point ( 6 , 22 );
            MinorVersionTextBox.Name = "MinorVersionTextBox";
            MinorVersionTextBox.Size = new Size ( 100 , 23 );
            MinorVersionTextBox.TabIndex = 1;
            MinorVersionTextBox.Text = "0";
            // 
            // MajorVersionGroupBox
            // 
            MajorVersionGroupBox.Controls.Add ( MajorVersionTextBox );
            MajorVersionGroupBox.Location = new Point ( 8 , 6 );
            MajorVersionGroupBox.Name = "MajorVersionGroupBox";
            MajorVersionGroupBox.Size = new Size ( 115 , 55 );
            MajorVersionGroupBox.TabIndex = 0;
            MajorVersionGroupBox.TabStop = false;
            MajorVersionGroupBox.Text = "メジャー";
            // 
            // MajorVersionTextBox
            // 
            MajorVersionTextBox.Location = new Point ( 6 , 22 );
            MajorVersionTextBox.Name = "MajorVersionTextBox";
            MajorVersionTextBox.Size = new Size ( 100 , 23 );
            MajorVersionTextBox.TabIndex = 1;
            MajorVersionTextBox.Text = "1";
            // 
            // BulidTabPage
            // 
            BulidTabPage.Location = new Point ( 4 , 24 );
            BulidTabPage.Name = "BulidTabPage";
            BulidTabPage.Padding = new Padding ( 3 );
            BulidTabPage.Size = new Size ( 503 , 184 );
            BulidTabPage.TabIndex = 1;
            BulidTabPage.Text = "ビルド";
            BulidTabPage.UseVisualStyleBackColor = true;
            // 
            // BuildToolForm
            // 
            AutoScaleDimensions = new SizeF ( 7F , 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size ( 511 , 212 );
            Controls.Add ( BuildToolFormTabControl );
            Name = "BuildToolForm";
            Text = "BuildToolForm";
            Load += BuildToolForm_Load;
            BuildToolFormTabControl.ResumeLayout ( false );
            ProjectFileUpdateTabPage.ResumeLayout ( false );
            BuildVersionGroupBox.ResumeLayout ( false );
            BuildVersionGroupBox.PerformLayout ();
            PatchVersionGroupBox.ResumeLayout ( false );
            PatchVersionGroupBox.PerformLayout ();
            MinorVersionGroupBox.ResumeLayout ( false );
            MinorVersionGroupBox.PerformLayout ();
            MajorVersionGroupBox.ResumeLayout ( false );
            MajorVersionGroupBox.PerformLayout ();
            ResumeLayout ( false );
        }

        #endregion

        private TabControl BuildToolFormTabControl;
        private TabPage ProjectFileUpdateTabPage;
        private TabPage BulidTabPage;
        private GroupBox MajorVersionGroupBox;
        private TextBox MajorVersionTextBox;
        private GroupBox BuildVersionGroupBox;
        private TextBox BuildVersionTextBox;
        private GroupBox PatchVersionGroupBox;
        private TextBox PatchVersionTextBox;
        private GroupBox MinorVersionGroupBox;
        private TextBox MinorVersionTextBox;
        private Button ReturnBtn;
        private Button ChengeBtn;
    }
}
