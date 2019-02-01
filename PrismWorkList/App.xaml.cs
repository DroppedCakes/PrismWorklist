using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWorkList.Infrastructure;
using PrismWorkList.Login;
using PrismWorkList.Login.Views;
using PrismWorkList.Service;
using PrismWorkList.SettingsMenu;
using PrismWorkList.Views;
using PrismWorkList.WorkSpace;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace PrismWorkList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var region_manager = CommonServiceLocator.ServiceLocator.Current.GetInstance<IRegionManager>();
            region_manager.RequestNavigate("ContentRegion", nameof(Login.Views.Login));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            TransactionContext.SetOpenConnection(OpenConnection);
            containerRegistry.RegisterInstance(CreateTransactionContext());
            containerRegistry.RegisterInstance<IStudiesService>(CreateIStudyService());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoginModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<WorkSpaceModule>();
            moduleCatalog.AddModule<SettingsModule>();
        }

        /// <summary>
        /// App.configから
        /// DBへのConnectionを作成する
        /// </summary>
        /// <returns></returns>
        private static IDbConnection OpenConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["PGTraining"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;

            return connection;
        }

        private static ITransactionContext _transactionContext;
        private static ITransactionContext CreateTransactionContext()
        {
            if (_transactionContext ==null)
            {
                _transactionContext = new TransactionContext();
            }
            return _transactionContext;
        }

        private static IStudiesService CreateIStudyService()
        {
            return new StudiesService(CreateTransactionContext(),new OrderPatientViewDao(),new PatientDao());
        }
    }
}
