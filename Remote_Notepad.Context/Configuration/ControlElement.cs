// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlElement.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The control element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Remote_Notepad.Context.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The control element.
    /// </summary>
    public class ControlElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("Name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["Name"]; }
            set { base["Name"] = value; }
        }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        [ConfigurationProperty("Element", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Element
        {
            get { return (string)base["Element"]; }
            set { base["Element"] = value; }
        }
    }
}
