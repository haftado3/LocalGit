using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Lind.Core.DataModel;
using Lind.Core.ViewModel;
using LocalGit.ViewModel;

namespace LocalGit.Entities
{
    public class MenuItem : BaseViewModel
    {

        public string Name { get; set; }

        public ApplicationPage View { get; set; }
    }
}
