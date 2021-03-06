﻿using PrismWorkList.Views;
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
using PrismWorkList.Domain;

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
            containerRegistry.RegisterInstance(OpenConnection());
            containerRegistry.RegisterInstance(new OrderPatientViewDao(OpenConnection()));
            containerRegistry.RegisterInstance<IStudiesService>(new StudiesService(Container.Resolve<OrderPatientViewDao>()));
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoginModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<WorkSpaceModule>();
        }

        private static IDbConnection OpenConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["PGTraining"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;

            return connection;
        }
    }
}
