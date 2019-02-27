using LocalGit.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace LocalGit.ViewModel
{
    class FilesViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<IFile> _items = new ObservableCollection<IFile>();
        public ObservableCollection<IFile> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyPropertyChanged(nameof(Items));
            }
        }
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
            Populate();
        }
        private DirectoryInfo _itemsLocation = new DirectoryInfo("D:\\");
        public DirectoryInfo ItemsLocation
        {
            get
            {
                return _itemsLocation;
            }
            set
            {
                _itemsLocation = value;
                NotifyPropertyChanged(nameof(ItemsLocation));
            }
        }
        private async void Populate()
        {
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
