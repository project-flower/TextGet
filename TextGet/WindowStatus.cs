using System;
using System.Drawing;

namespace TextGet
{
    public class WindowStatus
    {
        #region Public Fields

        public readonly Rectangle Bounds;
        public readonly IntPtr Handle;
        public readonly int ZOrder;

        #endregion

        #region Public Methods

        public WindowStatus(IntPtr handle, Rectangle bounds, int zOrder)
        {
            Bounds = bounds;
            Handle = handle;
            ZOrder = zOrder;
        }

        #endregion
    }
}
