using NativeApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TextGet
{
    internal static class WindowManager
    {
        #region Public Properties

        public static bool UseWindowMessageGetText { get; set; } = false;

        #endregion

        #region Public Methods

        public static WindowStatus[] CollectWindows(out Bitmap bitmap, out Rectangle totalScreenSize)
        {
            var result = new List<WindowStatus>();
            var handles = new List<IntPtr>();
            GCHandle allocated = GCHandle.Alloc(handles);

            try
            {
                var wndEnumProc = new WNDENUMPROC(EnumWindowsProc);
                User32.EnumWindows(wndEnumProc, GCHandle.ToIntPtr(allocated));
            }
            finally
            {
                if (allocated.IsAllocated)
                {
                    allocated.Free();
                }
            }

            foreach (IntPtr handle in handles)
            {
                if (DwmApi.DwmGetWindowAttribute(handle, DWMWINDOWATTRIBUTE.DWMWA_EXTENDED_FRAME_BOUNDS, out RECT rect, Marshal.SizeOf(typeof(RECT))) == 0)
                {
                    int top = rect.Top;
                    int left = rect.Left;
                    result.Add(new WindowStatus(handle, new Rectangle(left, top, Math.Abs(rect.Right - left), Math.Abs(rect.Bottom - top))));
                }
            }

            totalScreenSize = GetTotalScreenSize();
            bitmap = CaptureScreen(totalScreenSize);
            return result.ToArray();
        }

        public static string GetWindowTexts(IntPtr handle, out string[] texts, bool useWindowMessageGetText)
        {
            UseWindowMessageGetText = useWindowMessageGetText;
            string result;

            try
            {
                result = GetWindowText(handle, 256, false, true);
            }
            catch
            {
                throw;
            }

            var texts_ = new List<string>();
            GCHandle allocated = GCHandle.Alloc(texts_);

            try
            {
                var wndEnumProc = new WNDENUMPROC(EnumChildProc);
                User32.EnumChildWindows(handle, wndEnumProc, GCHandle.ToIntPtr(allocated));
            }
            finally
            {
                if (allocated.IsAllocated)
                {
                    allocated.Free();
                }
            }

            texts = texts_.ToArray();
            return result;
        }

        #endregion

        #region Private Methods

        private static Bitmap CaptureScreen(Rectangle rectangle)
        {
            Bitmap result = new Bitmap(rectangle.Width, rectangle.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                IntPtr hdc = graphics.GetHdc();

                try
                {
                    IntPtr dc = User32.GetDC(IntPtr.Zero);

                    try
                    {
                        int left = rectangle.Left;
                        int top = rectangle.Top;
                        Gdi32.BitBlt(hdc, 0, 0, result.Width, result.Height, dc, left, top, WinGdi.SRCCOPY);
                    }
                    finally
                    {
                        User32.ReleaseDC(IntPtr.Zero, dc);
                    }
                }
                finally
                {
                    graphics.ReleaseHdc(hdc);
                }
            }

            return result;
        }

        private static bool EnumChildProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(lParam);
            List<string> texts;

            try
            {
                texts = (List<string>)gcHandle.Target;
            }
            catch
            {
                throw;
            }

            string text = GetWindowText(hWnd, 256, UseWindowMessageGetText);

            if (!string.IsNullOrEmpty(text))
            {
                texts.Add(text);
            }

            return true;
        }

        private static bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam)
        {
            GCHandle gcHandle = GCHandle.FromIntPtr(lParam);
            List<IntPtr> handles;

            try
            {
                handles = (List<IntPtr>)gcHandle.Target;
            }
            catch
            {
                throw;
            }

            if (!User32.IsWindowVisible(hWnd))
            {
                return true;
            }

            if (string.IsNullOrEmpty(GetWindowText(hWnd, 256, false)))
            {
                return true;
            }

            handles.Add(hWnd);
            return true;
        }

        private static Rectangle GetTotalScreenSize()
        {
            var result = new Rectangle();

            foreach (Screen screen in Screen.AllScreens)
            {
                Rectangle bounds = screen.Bounds;
                Rectangle prevResult = result;

                if (bounds.X < result.X)
                {
                    result.X = bounds.X;
                    result.Width += (prevResult.Right - result.Right);
                }

                if (bounds.Y < result.Y)
                {
                    result.Y = bounds.Y;
                    result.Height += (prevResult.Bottom - result.Bottom);
                }

                if (bounds.Right > result.Right)
                {
                    result.Width += (bounds.Right - result.Right);
                }

                if (bounds.Bottom > result.Bottom)
                {
                    result.Height += (bounds.Bottom - result.Bottom);
                }
            }

            return result;
        }

        private static string GetWindowText(IntPtr handle, int bufferSize, bool useWindowMessageGetText, bool getError = false)
        {
            var builder = new StringBuilder(bufferSize);
            int length = User32.GetWindowText(handle, builder, builder.Capacity);

            if ((length < 1) && useWindowMessageGetText)
            {
                length = (int)User32.SendMessage(handle, WM.GETTEXT, new IntPtr(bufferSize - 1), builder);
            }

            if (length > 0)
            {
                try
                {
                    return builder.ToString();
                }
                catch
                {
                }
            }
            else if (getError)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return string.Empty;
        }

        #endregion
    }
}
