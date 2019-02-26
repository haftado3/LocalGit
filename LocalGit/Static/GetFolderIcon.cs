using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalGit.Entities
{
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public int dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }
    public class GetFolderIcon
    {
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_DISPLAYNAME = 0x200;
        private const int SHGFI_TYPENAME = 0x400;
        private const int SHGFI_PIDL = 0x8;
        private const int FILE_ATTRIBUTE_NORMAL = 0x80;
        private const int FILE_ATTRIBUTE_DIRECTORY = 0x10;
        [System.Runtime.InteropServices.DllImport("shell32.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [System.Runtime.InteropServices.DllImport("shell32.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        private static extern IntPtr SHGetFileInfo(IntPtr pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        public static extern int SHGetSpecialFolderLocation(int hwndOwner, int nFolder, ref int pidl);

        public static Icon FromPath(string _path)
        {
            SHFILEINFO fi = new SHFILEINFO();
            //SHGFI_ICON + SHGFI_SMALLICON + SHGFI_DISPLAYNAME + SHGFI_TYPENAME              <- changed
            SHGetFileInfo(_path, FILE_ATTRIBUTE_DIRECTORY, ref fi, Marshal.SizeOf(fi), SHGFI_ICON );
            return Icon.FromHandle(fi.hIcon);
        }
    }

}
