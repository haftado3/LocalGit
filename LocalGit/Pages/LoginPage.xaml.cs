using System.Security;
using Lind.Core.ViewModel;
using LocalGit.ViewModel;


namespace LocalGit.Pages
{
    /// <summary>
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>,IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
