using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LocalGit.Static
{
    public enum InfoType{
        File,Folder
    }
    public interface IFile :INotifyPropertyChanged
    {
        InfoType Info { get;  }
        string Name { get; set; }
        BitmapSource Icon { get; set; }
    }
}
