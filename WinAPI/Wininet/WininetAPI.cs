using System.Runtime.InteropServices;
using WinAPI.Wininet.Enums;

namespace WinAPI.Wininet
{
    public static class WininetAPI
    {
        public const string DllName = "Wininet";

        /// <summary>
        /// Retrieves the connected state of the local system.
        /// </summary>
        /// <param name="lpdwFlags">Variable that receives the connection description. This parameter may return a valid flag even when the function returns FALSE.</param>
        /// <param name="dwReserved">This parameter is reserved and must be 0.</param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool InternetGetConnectedState(out InternetFlags lpdwFlags, int dwReserved = 0);
    }
}
