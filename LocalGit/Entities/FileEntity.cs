﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Lind.Core.ViewModel;
using LocalGit.ViewModel;

namespace LocalGit.Entities
{
    public class FileEntity: BaseViewModel,IFile
    {
        public BitmapSource Icon { get; set; }

        public string Name { get; set; }

        public InfoType Info
        {
            get
            {
                return InfoType.File;
            }
        }

        public long Size { get; set; }

        public string Type { get; set; }
    }
}
