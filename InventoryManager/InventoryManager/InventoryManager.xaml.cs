using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace InventoryManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryManager : ContentPage
    {
        public InventoryManager()
        {
            InitializeComponent();
            DAL dal = new DAL();
            lvItems.ItemsSource = dal.GetAllItems();
        }
        private void btnSave_Clicked(object sender, EventArgs e)
        {
            Items items = new Items();
            items.ItemID = txtItemID.Text;
            items.ItemName = txtItemName.Text;
            items.ItemDescription = txtItemDescription.Text;

            DAL dal = new DAL();
            dal.AddItems(items);
            lvItems.ItemsSource = dal.GetAllItems();
        }
    }
}
