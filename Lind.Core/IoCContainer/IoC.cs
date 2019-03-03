using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lind.Core.ViewModel;
using Ninject;

namespace Lind.Core.IoCContainer
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all 
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            // bind to a single instanse of application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
