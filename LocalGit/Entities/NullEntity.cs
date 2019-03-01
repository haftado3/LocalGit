using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using LocalGit.ViewModel;

namespace LocalGit.Entities
{
    public class NullEntity : BaseViewModel,IFile
    {
        public BitmapSource Icon
        {
            get;

            set;
        }

        public InfoType Info
        {
            get;
        }

        public string Name
        {
            get;

            set;
        }

    }
}
