using System;

namespace WinAPI.Wininet.Enums
{
    [Flags]
    public enum InternetFlags
    {
        /// <summary>
        /// Local system has a valid connection to the Internet, but it might or might not be currently connected.
        /// </summary>
        Configured = 0x40,

        /// <summary>
        /// Local system uses a local area network to connect to the Internet.
        /// </summary>
        LAN = 0x02,

        /// <summary>
        /// Local system uses a modem to connect to the Internet.
        /// </summary>
        Modem = 0x01,

        /// <summary>
        /// No longer used.
        /// </summary>
        ModemBusy = 0x08,

        /// <summary>
        /// Local system is in offline mode.
        /// </summary>
        Offline = 0x20,

        /// <summary>
        /// Local system uses a proxy server to connect to the Internet.
        /// </summary>
        Proxy = 0x04,

        /// <summary>
        /// Local system has RAS installed.
        /// </summary>
        RasInstalled = 0x10
    }
}
