namespace BuildTool.Forms
{
    public partial class BuildToolForm : Form
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public BuildToolForm ()
        {
            InitializeComponent ();
        }

        /// <summary>
        /// ツール起動時実行イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildToolForm_Load ( object sender , EventArgs e )
        {
            const int GROUPBOX_WIDTH = 100;
            const int GROUPBOX_HEIGHT = 60;
            const int TEXTBOX_WIDTH = 80;
            const int TEXTBOX_HEIGHT = 27;
            const int BUTTON_WIDTH = 80;
            const int BUTTON_HEIGHT = 30;

            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            #region バージョン変更タブ
            #region GroupBoxとTextBoxサイズ変更
            MajorVersionGroupBox.Width = GROUPBOX_WIDTH;
            MajorVersionGroupBox.Height = GROUPBOX_HEIGHT;
            MajorVersionTextBox.Width = TEXTBOX_WIDTH;
            MajorVersionTextBox.Height = TEXTBOX_HEIGHT;

            MinorVersionGroupBox.Width = GROUPBOX_WIDTH;
            MinorVersionGroupBox.Height = GROUPBOX_HEIGHT;
            MinorVersionTextBox.Width = TEXTBOX_WIDTH;
            MinorVersionTextBox.Height = TEXTBOX_HEIGHT;

            PatchVersionGroupBox.Width = GROUPBOX_WIDTH;
            PatchVersionGroupBox.Height = GROUPBOX_HEIGHT;
            PatchVersionTextBox.Width = TEXTBOX_WIDTH;
            PatchVersionTextBox.Height = TEXTBOX_HEIGHT;

            BuildVersionGroupBox.Width = GROUPBOX_WIDTH;
            BuildVersionGroupBox.Height = GROUPBOX_HEIGHT;
            BuildVersionTextBox.Width = TEXTBOX_WIDTH;
            BuildVersionTextBox.Height = TEXTBOX_HEIGHT;
            #endregion

            #region GroupBox配置位置変更
            const int GROUPBOX_PADDING = 10;
            MajorVersionGroupBox.Location = new Point ( GROUPBOX_PADDING , GROUPBOX_PADDING );
            MinorVersionGroupBox.Location = new Point ( MajorVersionGroupBox.Right + GROUPBOX_PADDING , GROUPBOX_PADDING );
            PatchVersionGroupBox.Location = new Point ( MinorVersionGroupBox.Right + GROUPBOX_PADDING , GROUPBOX_PADDING );
            BuildVersionGroupBox.Location = new Point ( PatchVersionGroupBox.Right + GROUPBOX_PADDING , GROUPBOX_PADDING );
            ClientSize = new Size ( BuildVersionGroupBox.Right + 10 + GROUPBOX_PADDING , 300 );
            #endregion

            #region TextBox配置位置変更
            const int TEXTBOX_PADDING = 10;
            int positionY = ( GROUPBOX_HEIGHT - TEXTBOX_HEIGHT ) / 2 + TEXTBOX_PADDING;
            MajorVersionTextBox.Location = new Point ( TEXTBOX_PADDING , positionY );
            MinorVersionTextBox.Location = new Point ( TEXTBOX_PADDING , positionY );
            PatchVersionTextBox.Location = new Point ( TEXTBOX_PADDING , positionY );
            BuildVersionTextBox.Location = new Point ( TEXTBOX_PADDING , positionY );
            #endregion

            #region TextBox文字標準位置変更
            MajorVersionTextBox.TextAlign = HorizontalAlignment.Center;
            MinorVersionTextBox.TextAlign = HorizontalAlignment.Center;
            PatchVersionTextBox.TextAlign = HorizontalAlignment.Center;
            BuildVersionTextBox.TextAlign = HorizontalAlignment.Center;
            #endregion

            ChengeBtn.Size = new Size ( BUTTON_WIDTH , BUTTON_HEIGHT );
            ReturnBtn.Size = new Size ( BUTTON_WIDTH , BUTTON_HEIGHT );
            ChengeBtn.Location = new Point ( BuildVersionGroupBox.Right - BUTTON_WIDTH , BuildVersionGroupBox.Bottom + 30 );
            ReturnBtn.Location = new Point ( ChengeBtn.Left - BUTTON_WIDTH - 10 , BuildVersionGroupBox.Bottom + 30 );
            #endregion
        }

        private void ChengeBtn_Click ( object sender , EventArgs e )
        {

        }

        private void ReturnBtn_Click ( object sender , EventArgs e )
        {

        }
    }
}
