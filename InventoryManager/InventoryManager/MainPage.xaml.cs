using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace InventoryManager
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            DAL dal = new DAL();

        }
        private string _dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "InventoryDb.db");
        private async void ButtonLoginClicked(object sender, EventArgs e)
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))

                foreach (User u in db.Table<User>())
                {
                    if (u.Email == EmailInput.Text && PasswordInput.Text == u.Password)
                    {
                        lblOutput.Text = "Login Successful";
                        await Navigation.PushAsync(new InventoryManager());
                    }
                    else
                    {
                        lblOutput.Text = "Login Failed " +
                            EmailInput.Text;
                    }
                }
        }
        private async void ButtonCreateClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountManagement());
        }
    }
}

