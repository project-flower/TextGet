using System;
using System.Windows.Forms;

namespace TextGet
{
    public static partial class ExtensionMethods
    {
        #region Public Methods

        public static void ShowErrorMessage(this Form form, Exception exception)
        {
            ShowMessage(form, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowMessage(this Form form, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(form, text, form.Text, buttons, icon);
        }

        #endregion
    }
}
