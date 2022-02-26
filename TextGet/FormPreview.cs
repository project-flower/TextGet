using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextGet
{
    public partial class FormPreview : Form
    {
        #region Private Fields

        private Image baseImage = null;
        private Color previewFrameColor;
        private Color previewShadowColor;
        private int prevX = int.MinValue;
        private int prevY = int.MinValue;
        private int windowIndex = -1;
        private WindowStatus[] windows = new WindowStatus[0];

        #endregion

        #region Public Properties

        public event WindowTextsCollectedEventHandler WindowTextsCollected = delegate { };

        #endregion

        #region Private Fields

        private bool useWindowMessageGetText = false;

        #endregion

        #region Public Methods

        public FormPreview()
        {
            InitializeComponent();

#if DEBUG
            TopMost = false;
#endif
        }

        public void DoCollect(bool useWindowMessageGetText)
        {
            if (windowIndex < 0)
            {
                return;
            }

            IntPtr handle = windows[windowIndex].Handle;

            try
            {
                string title = WindowManager.GetWindowTexts(handle, out string[] texts, useWindowMessageGetText);
                WindowTextsCollected(this, new WindowTextsCollectedEventArgs(title, texts));
            }
            catch
            {
                throw;
            }
        }

        public void Initialize(Color previewShadowColor, byte previewShadowAlpha, Color previewFrameColor)
        {
            this.previewFrameColor = previewFrameColor;
            this.previewShadowColor = Color.FromArgb(previewShadowAlpha, previewShadowColor);
        }

        public void ShowPreview(bool useWindowMessageGetText)
        {
            windows = WindowManager.CollectWindows(out Bitmap bitmap, out Rectangle totalScreenSize);
            windowIndex = -1;

            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }

            pictureBox.Image = bitmap;
            baseImage = bitmap.Clone() as Image;

            if (!Visible)
            {
                this.useWindowMessageGetText = useWindowMessageGetText;
                Show();
            }

            Left = totalScreenSize.Left;
            Top = totalScreenSize.Top;
            Width = totalScreenSize.Width;
            Height = totalScreenSize.Height;
        }

        #endregion

        #region Private Methods

        private void EmphasizeRectangle(Rectangle rectangle)
        {
            if (baseImage == null)
            {
                return;
            }

            pictureBox.Image.Dispose();
            Bitmap bitmap = baseImage.Clone() as Bitmap;

            if (!rectangle.IsEmpty)
            {
                DrawingEngine.FillHollowRectangle(bitmap, rectangle, previewShadowColor, previewFrameColor);
            }

            pictureBox.Image = bitmap;
        }

        private Rectangle PointToClient(Rectangle rectangle)
        {
            return new Rectangle(pictureBox.PointToClient(rectangle.Location), rectangle.Size);
        }

        private bool SmallerThan(Rectangle rectangle1, Rectangle rectangle2)
        {
            return (rectangle1.Width * rectangle1.Height) < (rectangle2.Width * rectangle2.Height);
        }

        #endregion

        // Designer's Methods

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                DoCollect(useWindowMessageGetText);
            }
            catch (Exception exception)
            {
                this.ShowErrorMessage(exception);
            }

            Close();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X == prevX) && (e.Y == prevY))
            {
                return;
            }

            prevX = e.X;
            prevY = e.Y;
            int candidate = -1;

            for (int i = 0; i < windows.Length; ++i)
            {
                Rectangle window = windows[i].Bounds;
                Point point = pictureBox.PointToScreen(e.Location);
                int x = point.X;
                int y = point.Y;

                if (x < window.Left) continue;
                if (y < window.Top) continue;
                if (x > window.Right) continue;
                if (y > window.Bottom) continue;

                if (candidate >= 0 && !SmallerThan(window, windows[candidate].Bounds))
                {
                    continue;
                }

                candidate = i;
            }

            if ((candidate == -1) && (windowIndex != -1))
            {
                EmphasizeRectangle(Rectangle.Empty);
                windowIndex = -1;
            }
            else if ((candidate != -1) && (candidate != windowIndex))
            {
                EmphasizeRectangle(PointToClient(windows[candidate].Bounds));
                windowIndex = candidate;
            }
        }
    }
}
