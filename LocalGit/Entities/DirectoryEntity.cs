
using System.Windows.Media.Imaging;
using Lind.Core.ViewModel;
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
