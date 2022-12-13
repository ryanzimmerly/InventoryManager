using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace InventoryManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountManagement : ContentPage
    {
        public AccountManagement()
        {
            InitializeComponent();
        }
        private void btnMainPage_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
        private void CreateAccount_Clicked(object sender, EventArgs e)
        {
            if (Name.Text == string.Empty && Email.Text == string.Empty && Password.Text == string.Empty && Phone.Text == string.Empty)
            {
                lblOutput.Text = "Error: Please fill out all entries";
            }
            else
            {
                User user = new User();
                user.Name = Name.Text;
                user.Email = Email.Text;
                user.Password = Password.Text;
                user.Phone = Phone.Text;

                DAL dal = new DAL();
                dal.AddUser(user);
                lblOutput.Text = "Account Created!";
            }
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Name.Text = string.Empty;
            Email.Text = string.Empty;
            Password.Text = string.Empty;
            Phone.Text = string.Empty;
        }
    }
}