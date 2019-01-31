using PrismWorkList.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismWorkList.ViewModels;
using PrismWorkList.Login;
using Prism.Regions;
using PrismWorkList.Login.Views;
using PrismWorkList.WorkSpace;
using PrismWorkList.Infrastructure.Models;
using PrismWorkList.Infrastructure;
using System.Data;
using System.Configuration;
using System.Data.Common;
using PrismWorkList.Service;
using System;

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
            region_manager.RequestNavigate("ContentRegion", nameof(LoginView));
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
            return new StudiesService(CreateTransactionContext(),new OrderPatientViewDao());
        }
    }
}
