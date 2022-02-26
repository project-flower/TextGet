namespace TextGet
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonGet = new System.Windows.Forms.Button();
            this.buttonOneMore = new System.Windows.Forms.Button();
            this.labelDelay = new System.Windows.Forms.Label();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.labelSec = new System.Windows.Forms.Label();
            this.checkBoxUseWindowMessageGetText = new System.Windows.Forms.CheckBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonCopyTitle = new System.Windows.Forms.Button();
            this.labelTexts = new System.Windows.Forms.Label();
            this.textBoxTexts = new System.Windows.Forms.TextBox();
            this.buttonCopyTexts = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGet
            // 
            this.buttonGet.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonGet.Location = new System.Drawing.Point(12, 12);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(150, 46);
            this.buttonGet.TabIndex = 0;
            this.buttonGet.Text = "&Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // buttonOneMore
            // 
            this.buttonOneMore.Location = new System.Drawing.Point(168, 12);
            this.buttonOneMore.Name = "buttonOneMore";
            this.buttonOneMore.Size = new System.Drawing.Size(75, 23);
            this.buttonOneMore.TabIndex = 1;
            this.buttonOneMore.Text = "&One More";
            this.buttonOneMore.UseVisualStyleBackColor = true;
            this.buttonOneMore.Click += new System.EventHandler(this.buttonOneMore_Click);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(249, 14);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(36, 12);
            this.labelDelay.TabIndex = 2;
            this.labelDelay.Text = "&Delay:";
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Location = new System.Drawing.Point(291, 12);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(60, 19);
            this.numericUpDownDelay.TabIndex = 3;
            this.numericUpDownDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSec
            // 
            this.labelSec.AutoSize = true;
            this.labelSec.Location = new System.Drawing.Point(357, 14);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(26, 12);
            this.labelSec.TabIndex = 4;
            this.labelSec.Text = "Sec,";
            // 
            // checkBoxUseWindowMessageGetText
            // 
            this.checkBoxUseWindowMessageGetText.AutoSize = true;
            this.checkBoxUseWindowMessageGetText.Checked = global::TextGet.Properties.Settings.Default.UseWindowMessageGetText;
            this.checkBoxUseWindowMessageGetText.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TextGet.Properties.Settings.Default, "UseWindowMessageGetText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxUseWindowMessageGetText.Location = new System.Drawing.Point(251, 37);
            this.checkBoxUseWindowMessageGetText.Name = "checkBoxUseWindowMessageGetText";
            this.checkBoxUseWindowMessageGetText.Size = new System.Drawing.Size(211, 16);
            this.checkBoxUseWindowMessageGetText.TabIndex = 5;
            this.checkBoxUseWindowMessageGetText.Text = "Use Window Message &WM_GETTEXT";
            this.checkBoxUseWindowMessageGetText.UseVisualStyleBackColor = true;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(10, 61);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 12);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "&Title:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxTitle.Location = new System.Drawing.Point(12, 76);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(695, 19);
            this.textBoxTitle.TabIndex = 7;
            // 
            // buttonCopyTitle
            // 
            this.buttonCopyTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyTitle.Location = new System.Drawing.Point(713, 74);
            this.buttonCopyTitle.Name = "buttonCopyTitle";
            this.buttonCopyTitle.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyTitle.TabIndex = 8;
            this.buttonCopyTitle.Text = "Copy";
            this.buttonCopyTitle.UseVisualStyleBackColor = true;
            this.buttonCopyTitle.Click += new System.EventHandler(this.buttonCopyTitle_Click);
            // 
            // labelTexts
            // 
            this.labelTexts.AutoSize = true;
            this.labelTexts.Location = new System.Drawing.Point(12, 98);
            this.labelTexts.Name = "labelTexts";
            this.labelTexts.Size = new System.Drawing.Size(36, 12);
            this.labelTexts.TabIndex = 9;
            this.labelTexts.Text = "Te&xts:";
            // 
            // textBoxTexts
            // 
            this.textBoxTexts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTexts.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxTexts.Location = new System.Drawing.Point(12, 113);
            this.textBoxTexts.Multiline = true;
            this.textBoxTexts.Name = "textBoxTexts";
            this.textBoxTexts.ReadOnly = true;
            this.textBoxTexts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTexts.Size = new System.Drawing.Size(695, 325);
            this.textBoxTexts.TabIndex = 10;
            this.textBoxTexts.WordWrap = false;
            // 
            // buttonCopyTexts
            // 
            this.buttonCopyTexts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyTexts.Location = new System.Drawing.Point(713, 111);
            this.buttonCopyTexts.Name = "buttonCopyTexts";
            this.buttonCopyTexts.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyTexts.TabIndex = 11;
            this.buttonCopyTexts.Text = "Copy";
            this.buttonCopyTexts.UseVisualStyleBackColor = true;
            this.buttonCopyTexts.Click += new System.EventHandler(this.buttonCopyTexts_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCopyTexts);
            this.Controls.Add(this.textBoxTexts);
            this.Controls.Add(this.labelTexts);
            this.Controls.Add(this.buttonCopyTitle);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.checkBoxUseWindowMessageGetText);
            this.Controls.Add(this.labelSec);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.buttonOneMore);
            this.Controls.Add(this.buttonGet);
            this.Name = "FormMain";
            this.Text = "TextGet";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Button buttonOneMore;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.CheckBox checkBoxUseWindowMessageGetText;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonCopyTitle;
        private System.Windows.Forms.Label labelTexts;
        private System.Windows.Forms.TextBox textBoxTexts;
        private System.Windows.Forms.Button buttonCopyTexts;
        private System.Windows.Forms.Timer timer;
    }
}

