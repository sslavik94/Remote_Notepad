namespace Remote_Notepad.Context.Configuration
{
    using System.Configuration;

    [ConfigurationCollection(typeof(ControlElement), AddItemName = "Control")]
    public class ControlCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ControlElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ControlElement)(element)).Name;
        }

        public ControlElement this[int idx]
        {
            get { return (ControlElement)this.BaseGet(idx); }
        }
    }
}
