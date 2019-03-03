
using Lind.Core.DataModel;

namespace Lind.Core.ViewModel
{
    public class ApplicationViewModel: BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    }
}
