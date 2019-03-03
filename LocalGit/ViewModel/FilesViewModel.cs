using LocalGit.Entities;

using System.Collections.ObjectModel;

using System.IO;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Lind.Core.ViewModel;

namespace LocalGit.ViewModel
{
    public class FilesViewModel:BaseViewModel
    {
        public ObservableCollection<IFile> Items { get; set; } 
        public async Task<long> DirSize(DirectoryInfo d)
        {
            return await Task.Run(async () => {
                long size = 0;
                // Add file sizes.
                try
                {
                    FileInfo[] fis = d.GetFiles();
                    foreach (FileInfo fi in fis)
                    {
                        size += fi.Length;
                    }

                    // Add subdirectory sizes.
                    DirectoryInfo[] dis = d.GetDirectories();
                    foreach (DirectoryInfo di in dis)
                    {
                        size += await DirSize(di);
                    }
                }
                catch (System.UnauthorizedAccessException ex)
                {

                }
                return size;
            }).ConfigureAwait(false);

        }

        public FilesViewModel()
        {
            ItemsLocation = new DirectoryInfo("D:\\");
            Populate();
        }

        public DirectoryInfo ItemsLocation
        {
            get;
            set;
        }

        private async void Populate()
        {
            if (Items == null)
            {
                Items = new ObservableCollection<IFile>();
            }
            if(Items.Count>0)
            Items.Clear();
            try
            {
                foreach (var dirinfo in ItemsLocation.GetDirectories())
                {
                    DirectoryEntity de = new DirectoryEntity();
                    de.Size = await DirSize(dirinfo);
                    de.Name = dirinfo.Name;
                    var ico = GetFolderIcon.FromPath(dirinfo.FullName);
                    de.Icon = Imaging.CreateBitmapSourceFromHIcon(ico.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Items.Add(de);
                }
                foreach (var fileinfo in ItemsLocation.GetFiles())
                {
                    FileEntity fe = new FileEntity();
                    fe.Name = Path.GetFileNameWithoutExtension(fileinfo.Name);
                    fe.Size = fileinfo.Length;
                    fe.Type = Path.GetExtension(fileinfo.Name).Substring(1);
                    var ico = System.Drawing.Icon.ExtractAssociatedIcon(fileinfo.FullName);
                    fe.Icon = Imaging.CreateBitmapSourceFromHIcon(ico.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Items.Add(fe);
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {

            }
            Items.Add(new NullEntity());
        }



    }
}
