namespace Remote_Notepad.Context.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The service element.
    /// </summary>
    public class ServiceElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("Name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return ((string)(base["Name"])); }
            set { base["Name"] = value; }
        }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        [ConfigurationProperty("Element", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Element
        {
            get { return ((string)(base["Element"])); }
            set { base["Element"] = value; }
        }
    }
}
