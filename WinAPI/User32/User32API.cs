using System;
using System.Runtime.InteropServices;
using System.Text;
using WinAPI.User32.Enums.MessageBox;

namespace WinAPI.User32
{
    public static class User32API
    {
        public const string DllName = "User32";

        /// <summary>
        /// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="x">The new position of the left side of the window.</param>
        /// <param name="y">The new position of the top of the window.</param>
        /// <param name="nWidth">The new width of the window.</param>
        /// <param name="nHeight">The new height of the window.</param>
        /// <param name="bRepaint">Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of moving a child window.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName)]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="lpClassName">If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);

        /// <summary>
        /// Minimizes (but does not destroy) the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be minimized.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool CloseWindow(IntPtr hWnd);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). If the specified window is a control, the function retrieves the length of the text within the control. However, GetWindowTextLength cannot retrieve the length of the text of an edit control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="nMaxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Reverses or restores the meaning of the left and right mouse buttons.
        /// </summary>
        /// <param name="fSwap">If this parameter is TRUE, the left button generates right-button messages and the right button generates left-button messages. If this parameter is FALSE, the buttons are restored to their original meanings.</param>
        /// <returns></returns>
        [DllImport(DllName)]
        public static extern bool SwapMouseButton(bool fSwap);

        /// <summary>
        /// Locks the workstation's display. Locking a workstation protects it from unauthorized use.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool LockWorkStation();

        /// <summary>
        /// Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message, such as status or error information. The message box returns an integer value that indicates which button the user clicked.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName)]
        static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, int uType);

        /// <summary>
        /// Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message, such as status or error information. The message box returns an integer value that indicates which button the user clicked.
        /// </summary>
        /// <param name="text">The message to be displayed. If the string consists of more than one line, you can separate the lines using a carriage return and/or linefeed character between each line.</param>
        /// <param name="title">The dialog box title. If this parameter is NULL, the default title is Error.</param>
        /// <param name="buttons">The buttons displayed in the message box.</param>
        /// <param name="icon">Icon in the message box.</param>
        /// <returns></returns>
        public static DialogResult ShowMessageBox(string text,
                                                  string title,
                                                  MessageBoxButtons buttons = MessageBoxButtons.Ok,
                                                  MessageBoxIcon icon = MessageBoxIcon.None,
                                                  MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1,
                                                  MessageBoxModality modality = MessageBoxModality.AppModal,
                                                  MessageBoxOption option = 0)
        {
            return (DialogResult)MessageBox(IntPtr.Zero, text, title, (int)buttons | (int)icon | (int)defaultButton | (int)modality | (int)option);
        }
    }
}
