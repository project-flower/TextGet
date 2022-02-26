using System;
using System.Windows.Forms;
using TextGet.Properties;

namespace TextGet
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private readonly FormPreview formPreview = new FormPreview();

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            MinimumSize = Size;
            Settings settings = Settings.Default;
            formPreview.Initialize(settings.PreviewShadowColor, settings.PreviewShadowAlpha, settings.PreviewFrameColor);
            formPreview.VisibleChanged += formPreview_VisibleChanged;
            formPreview.WindowTextsCollected += formPreview_WindowTextsCollected;
        }

        #endregion

        #region Private Methods

        private void formPreview_VisibleChanged(object sender, EventArgs e)
        {
            if (formPreview.IsDisposed)
            {
                return;
            }

            if (!formPreview.Visible && !Visible)
            {
                Show();
            }
        }

        private void formPreview_WindowTextsCollected(object sender, WindowTextsCollectedEventArgs e)
        {
            textBoxTitle.Text = e.Title;
            textBoxTexts.Lines = e.Texts;
        }

        private void SetTextToClipboard(TextBox textBox)
        {
            try
            {
                Clipboard.SetText(textBox.Text);
                this.ShowMessage("クリップボードにテキストをコピーしました。", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception);
            }
        }

        private void StartCollect()
        {
            int interval;
            decimal value = numericUpDownDelay.Value;

            if (value == 0)
            {
                interval = 1;
            }
            else
            {
                interval = (int)(value * 1000);
            }

            Hide();
            timer.Interval = interval;
            timer.Start();
        }

        #endregion

        // Designer's Methods

        private void buttonCopyTexts_Click(object sender, EventArgs e)
        {
            SetTextToClipboard(textBoxTexts);
        }

        private void buttonCopyTitle_Click(object sender, EventArgs e)
        {
            SetTextToClipboard(textBoxTitle);
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            StartCollect();
        }

        private void buttonOneMore_Click(object sender, EventArgs e)
        {
            try
            {
                formPreview.DoCollect(checkBoxUseWindowMessageGetText.Checked);
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            formPreview.ShowPreview(checkBoxUseWindowMessageGetText.Checked);
        }
    }
}
