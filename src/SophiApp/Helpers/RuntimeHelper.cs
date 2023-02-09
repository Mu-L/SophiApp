namespace SophiApp.Helpers
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Runtime helper.
    /// </summary>
    public class RuntimeHelper
    {
        /// <summary>
        /// Gets a value indicating whether is MSIX.
        /// </summary>
        public static bool IsMSIX
        {
            get
            {
                var length = 0;

                return GetCurrentPackageFullName(ref length, null) != 15700L;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetCurrentPackageFullName(ref int packageFullNameLength, StringBuilder? packageFullName);
    }
}