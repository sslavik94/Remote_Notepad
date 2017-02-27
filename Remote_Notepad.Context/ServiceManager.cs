using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote_Notepad.Context
{
    /// <summary>
    /// The service manager.
    /// </summary>
    public class ServiceManager
    {
        /// <summary>
        /// The service manager.
        /// </summary>
        protected static ServiceManager serviceManager;

        /// <summary>
        /// The cache dictionary. Used to store static information such as dictionaries etc. 
        /// </summary>
        private readonly Dictionary<string, object> cacheDictionary = new Dictionary<string, object>();

        /// <summary>
        /// The manager dictionary. Plays a role of central storage for managers.
        /// </summary>
        private readonly Dictionary<string, object> managerDictionary = new Dictionary<string, object>();

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="ServiceManager"/>.
        /// </returns>
        public static ServiceManager GetInstance()
        {
            if (serviceManager == null)
            {
                serviceManager = new ServiceManager();
            }

            return serviceManager;
        }

        /// <summary>
        /// The add to cache.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="elementType">
        /// The element type.
        /// </param>
        /// <example>
        /// <code>
        /// <![CDATA[ServiceManager.GetInstance().AddToCache("StateCollection", new List<State>);]]>
        ///  </code>
        /// </example>
        public void AddToCache(string key, object elementType)
        {
            this.cacheDictionary.Add(key, elementType);
        }

        /// <summary>
        /// The get from cache.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The object from cache <see cref="object"/>.
        /// </returns>
        public object GetFromCache(string key)
        {
            return this.cacheDictionary[key];
        }

        /// <summary>
        /// The add manager.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="manager">
        /// The element type.
        /// </param>
        public void AddManager(string key, object manager)
        {
            this.managerDictionary.Add(key, manager);
        }

        /// <summary>
        /// The get manager.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The manager object <see cref="object"/>.
        /// </returns>
        public object GetManager(string key)
        {
            return this.managerDictionary[key];
        }
    }
}