using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using LocalGit.ViewModel;

namespace LocalGit.Entities
{
    public class DirectoryEntity :BaseViewModel, IFile
    {
        public BitmapSource Icon { get; set; }

        public InfoType Info
        {
            get
            {
                return InfoType.Folder;
            }
        }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}
