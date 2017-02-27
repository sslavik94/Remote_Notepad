using Remote_Notepad.Context;
using Remote_Notepad.Domain;
using Remote_Notepad.Service.Client.Contract;
using Remote_Notepad.Service.Client.Stub;
using Remote_Notepad.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Remote_Notepad.ViewModel
{
    public class ViewProfileViewModel : ViewModelBase
    {
        private IFrontServiceClient frontServiceClient;

        #region Profile
        public string Profile
        {
            get { return (string)GetValue(ProfileProperty); }
            set { SetValue(ProfileProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Profile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProfileProperty =
            DependencyProperty.Register("Profile", typeof(string), typeof(ViewProfileViewModel), new PropertyMetadata(null));



        #endregion

        public ViewProfileViewModel()
        {
            //try
            //{
                frontServiceClient = ServiceManager.GetInstance().GetManager("FrontServiceClient") as IFrontServiceClient;
                this.Transform(this.frontServiceClient);
                //this.ValidatedProperties.Add("Profile");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        /// <summary>
        /// The Transform.
        /// </summary>
        public void Transform(IFrontServiceClient frontServiceClient)
        {
            this.Profile = "Hello, " + frontServiceClient.GetMember().Login + "!" + "\n" + "You have " + frontServiceClient.GetProfile() + " message(s).";
        }

        /// <summary>
        /// The Extract.
        /// </summary>
        //public MemberInfo Extract()
        //{
        //    this.member.Login = this.Login;
        //    this.member.Password = this.Password;
        //    this.member.NickName = this.NickName;
        //    this.member.DateOfBirth = this.DateOfBirth;
        //    this.member.Photo = this.Photo;

        //    return this.member;
        //}



    }
}
