namespace Remote_Notepad.Context.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The bootstrapper configuration section.
    /// </summary>
    public class BootstrapperConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the control items.
        /// </summary>
        [ConfigurationProperty("Controls")]
        public ControlCollection ControlItems
        {
            get { return ((ControlCollection)(base["Controls"])); }
        }

        [ConfigurationProperty("Services")]
        public ServiceCollection ServiceItems
        {
            get { return ((ServiceCollection)(base["Services"])); }
        }
    }
}
