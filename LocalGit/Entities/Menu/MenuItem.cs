using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LocalGit.Entities.Menu
{
    public class MenuItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private List<MenuItem> _children;
        List<MenuItem> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                NotifyPropertyChanged(nameof(Children));
            }
        }
        private string _header;
        public string Header
        {
            get
            {
                return _header;

            }
            set
            {
                _header = value;
                NotifyPropertyChanged(nameof(Header));
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
        private string _action;
        public string Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
                NotifyPropertyChanged(nameof(Action));
            }
        }
    }
}
