using System;

namespace TextGet
{
    public class WindowTextsCollectedEventArgs : EventArgs
    {
        #region Public Fields

        public readonly string[] Texts;
        public readonly string Title;

        #endregion

        #region Public Methods

        public WindowTextsCollectedEventArgs(string title, string[] texts)
        {
            Texts = texts;
            Title = title;
        }

        #endregion
    }

    public delegate void WindowTextsCollectedEventHandler(object sender, WindowTextsCollectedEventArgs e);
}
