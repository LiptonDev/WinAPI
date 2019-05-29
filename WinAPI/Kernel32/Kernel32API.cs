using System.Runtime.InteropServices;
using System.Text;

namespace WinAPI.Kernel32
{
    public static class Kernel32API
    {
        public const string DllName = "Kernel32";

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true)]
        public static extern bool FreeConsole();

        /// <summary>
        /// Gets last error.
        /// </summary>
        /// <returns></returns>
        [DllImport(DllName)]
        public static extern uint GetLastError();

        /// <summary>
        /// Class for reading and writing data in to .ini files.
        /// </summary>
        public class IniReader
        {
            [DllImport(DllName, SetLastError = true)]
            static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

            [DllImport(DllName, SetLastError = true)]
            static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

            /// <summary>
            /// Path to .ini file.
            /// </summary>
            public string PathToFile { get; }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="pathToFile">Path to .ini file.</param>
            public IniReader(string pathToFile)
            {
                PathToFile = pathToFile;
            }

            /// <summary>
            /// Read value by section and key.
            /// </summary>
            /// <param name="section">Section.</param>
            /// <param name="key">Key.</param>
            /// <param name="defaultValue">Default value if key isn't exists.</param>
            /// <returns></returns>
            public string ReadValue(string section, string key, string defaultValue = "")
            {
                StringBuilder sb = new StringBuilder();
                GetPrivateProfileString(section, key, defaultValue, sb, sb.MaxCapacity, PathToFile);

                return sb.ToString();
            }

            /// <summary>
            /// Write value by section and key.
            /// </summary>
            /// <param name="section">Section.</param>
            /// <param name="key">Key.</param>
            /// <param name="value">Value.</param>
            /// <returns></returns>
            public bool WriteValue(string section, string key, string value)
            {
                return WritePrivateProfileString(section, key, value, PathToFile);
            }
        }
    }
}
