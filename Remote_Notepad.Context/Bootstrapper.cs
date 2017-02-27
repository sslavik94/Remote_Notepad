// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Remote_Notepad.Context
{
    using System;
    using System.Configuration;
    using System.Reflection;

    using Remote_Notepad.Context.Configuration;
    using Remote_Notepad.Utility.GeneralPurpose;

    /// <summary>
    /// The boot initializer.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// The bootstrapper.
        /// </summary>
        protected static Bootstrapper bootstrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
        /// </summary>
        protected Bootstrapper()
        {
            this.GetFromConfigFile();
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="Bootstrapper"/>.
        /// </returns>
        public static Bootstrapper GetInstance()
        {
            if (bootstrapper == null)
            {
                bootstrapper = new Bootstrapper();
            }

            return bootstrapper;
        }

        /// <summary>
        /// The get from config file.
        /// </summary>
        protected virtual void GetFromConfigFile()
        {
            BootstrapperConfigurationSection section = (BootstrapperConfigurationSection)ConfigurationManager.GetSection("bootstrapper");

            if (section != null)
            {
                ControlCollection controlCollection = section.ControlItems;

                ServiceCollection serviceCollection = section.ServiceItems;

                this.InitControlCollection(controlCollection);

                this.InitServiceCollection(serviceCollection);
            }
        }

        /// <summary>
        /// The initialization control collection.
        /// </summary>
        /// <param name="controlCollection">
        /// The control collection.
        /// </param>
        protected virtual void InitControlCollection(ControlCollection controlCollection)
        {
            foreach (ControlElement controlElement in controlCollection)
            {
                string name = controlElement.Name;
                string path = controlElement.Element;

                string[] pathArray = path.Split(',');

                string className = pathArray[0];
                string assemblyName = pathArray[1];

                Type type = ReflectionHelper.GetType(assemblyName, className);
                ControlManager.GetInstance().Add(name, type);
            }
        }

        /// <summary>
        /// The initialization service collection.
        /// </summary>
        /// <param name="serviceCollection">
        /// The service collection.
        /// </param>
        protected virtual void InitServiceCollection(ServiceCollection serviceCollection)
        {
            foreach (ServiceElement serviceElement in serviceCollection)
            {
                string name = serviceElement.Name;
                string path = serviceElement.Element;

                string[] pathArray = path.Split(',');

                string className = pathArray[0].Trim();
                string assemblyName = pathArray[1].Trim();

                //Type managerType = ReflectionHelper.GetType(assemblyName, className);
                //object manager = ReflectionHelper.CallGenericMethod(TypeController.Instance, "GetObjectOfType", managerType, null);

                Assembly assembly = Assembly.LoadFrom(assemblyName + ".dll");

                object manager = assembly.CreateInstance(className);

                ServiceManager.GetInstance().AddManager(name, manager);
            }
        }

        /// <summary>
        /// The init.
        /// </summary>
        public void Init()
        {
            this.InitControls();
            this.InitManagers();
        }

        /// <summary>
        /// The initialize controls.
        /// </summary>
        public virtual void InitControls()
        {
            // ControlManager.GetInstance().Add("MainWindow", typeof(MainWindow));
            // ControlManager.GetInstance().Add("HomeControl", typeof(HomeControl));
            // ControlManager.GetInstance().Add("DashboardControl", typeof(DashboardControl));
        }

        /// <summary>
        /// The initialize managers.
        /// </summary>
        public virtual void InitManagers()
        {
            // ServiceManager.GetInstance().AddManager("UserManager", TypeController.Instance.GetObjectOfType<IUserManager>());
        }
    }
}
