using System;
using System.Drawing;

namespace TextGet
{
    public class WindowStatus
    {
        #region Public Fields

        public readonly Rectangle Bounds;
        public readonly IntPtr Handle;

        #endregion

        #region Public Methods

        public WindowStatus(IntPtr handle, Rectangle bounds)
        {
            Bounds = bounds;
            Handle = handle;
        }

        #endregion
    }
}
