
using System.ComponentModel;

using PropertyChanged;

namespace LocalGit.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (e, sender) =>
        {

        };
        /// <summary>
        /// Call this to fire property changed event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this,new PropertyChangedEventArgs(name));
        }
    }
}
