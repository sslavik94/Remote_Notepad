using System.Windows;
using System.Runtime.Remoting;
using System.ComponentModel;
using System.Collections.Generic;

namespace Remote_Notepad.ViewModel
{
    public abstract class ViewModelBase : DependencyObject
    {
        public bool IsValid
        {
            get
            {
                foreach (string property in this.ValidatedProperties)
                    if (this.GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        public List<string> ValidatedProperties = new List<string>();

        /// <summary>
        /// The get validation error. Validation controller.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected virtual string GetValidationError(string propertyName)
        {
            string error = null;

            return error;
        }
    }
}
