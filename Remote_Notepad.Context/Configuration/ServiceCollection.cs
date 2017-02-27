// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollection.cs" company="">
//   
// </copyright>
// <summary>
//   The service collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Remote_Notepad.Context.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The service collection.
    /// </summary>
    [ConfigurationCollection(typeof(ServiceElement), AddItemName = "Service")]
    public class ServiceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceElement();
        }

        /// <summary>
        /// The get element key.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceElement)(element)).Name;
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="idx">
        /// The idx.
        /// </param>
        /// <returns>
        /// The <see cref="ServiceElement"/>.
        /// </returns>
        public ServiceElement this[int idx]
        {
            get { return (ServiceElement)this.BaseGet(idx); }
        }
    }
}
