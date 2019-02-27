using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using LocalGit.Pages;
using MenuItem = LocalGit.Entities.MenuItem;

namespace LocalGit.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainViewModel()
        {
            SelectedInnerView = new FilesPage();
            ContainerMenu.Add(new MenuItem { Name = "abc" });
            ContainerMenu.Add(new MenuItem { Name = "xxx" });
        }
        private List<MenuItem> _containerMenu = new List<MenuItem>();
        public List<MenuItem> ContainerMenu
        {
            get { return _containerMenu; }
            set { _containerMenu = value;
                NotifyPropertyChanged(nameof(ContainerMenu));
            }
        }

        private UserControl _selectedInnerView;

        public UserControl SelectedInnerView
        {
            get { return _selectedInnerView; }
            set
            {
                _selectedInnerView = value;
                NotifyPropertyChanged(nameof(SelectedInnerView));
            }
        }





    }
}
