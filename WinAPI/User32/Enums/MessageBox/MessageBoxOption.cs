namespace WinAPI.User32.Enums.MessageBox
{
    public enum MessageBoxOption
    {
        /// <summary>
        /// Same as desktop of the interactive window station. If the current input desktop is not the default desktop, MessageBox does not return until the user switches to the default desktop.
        /// </summary>
        MB_DEFAULT_DESKTOP_ONLY = 0x00020000,

        /// <summary>
        /// The text is right-justified.
        /// </summary>
        MB_RIGHT = 0x00080000,

        /// <summary>
        /// Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.
        /// </summary>
        MB_RTLREADING = 0x00100000,

        /// <summary>
        /// The message box becomes the foreground window. Internally, the system calls the SetForegroundWindow function for the message box.
        /// </summary>
        MB_SETFOREGROUND = 0x00010000,

        /// <summary>
        /// The message box is created with the WS_EX_TOPMOST window style.
        /// </summary>
        MB_TOPMOST = 0x00040000,

        /// <summary>
        /// The caller is a service notifying the user of an event. The function displays a message box on the current active desktop, even if there is no user logged on to the computer. Terminal Services: If the calling thread has an impersonation token, the function directs the message box to the session specified in the impersonation token. If this flag is set, the hWnd parameter must be NULL. This is so that the message box can appear on a desktop other than the desktop corresponding to the hWnd.
        /// </summary>
        MB_SERVICE_NOTIFICATION = 0x00200000
    }
}
