using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LocalGit.Entities
{
    public class FileEntity:IFile
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private BitmapSource _icon;

        public BitmapSource Icon
        {
            get
            {
                return _icon;
                
            }

            set
            {
                _icon = value;
                NotifyPropertyChanged(nameof(Icon));
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }



        public InfoType Info
        {
            get
            {
                return InfoType.File;
            }
        }
        private long _size;
        public long Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                NotifyPropertyChanged(nameof(Size));
            }
        }
        private string _type;
        public string Type { get { return _type; } set { _type = value; NotifyPropertyChanged(nameof(Type)); } }
    }
}
