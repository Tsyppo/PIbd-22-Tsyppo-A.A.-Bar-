using System;
using System.Windows.Forms;
using AbstractBarBusinessLogic.BusinessLogics;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.StoragesContracts;
using AbstractBarFileImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace AbstractBarView
{
    static class Program
    {
        private static IUnityContainer container = null;

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage,
            ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICocktailStorage, CocktailStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseStorage, WarehouseStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICocktailLogic, CocktailLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWarehouseLogic, WarehouseLogic>(new
               HierarchicalLifetimeManager());
            return currentContainer;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }
    }
}