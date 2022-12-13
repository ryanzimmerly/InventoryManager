using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using InventoryManager;

namespace InventoryManager
{

    public class DAL
    {
        private string _dbPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "InventoryDb.db");
        public DAL()
        {
            //check to see if DB exists - if not, create it
            if (!File.Exists(_dbPath))
            {
                SQLiteDb db = new SQLiteDb(_dbPath);
                db.Create();
            }
        }
        public partial class Items
        {
            public string Name { get { return ItemID + " - " + ItemName; } }
            public string ItemDesc
            {
                get { return string.Format(ItemDescription); }

            }
            //Method to save a user to the db
            public void AddUser(User userToAdd)
        {
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                bool exists = false;

                //error checking to prevent adding same Email twice
                foreach (User u in db.Table<User>())
                {
                    if (u.Email == userToAdd.Email)
                    {
                        exists = true;
                        break;
                    }
                }

                //if user doesnt exist in the DB, add them
                if (!exists)
                {
                    db.Insert(userToAdd);
                }
            }
        }
        //method to get a list of all users in the database
        public List<User> GetAllUsers()
        {
            List<User> People = new List<User>();

            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                People = db.Table<User>().ToList();
            }

            return People;
        }
            //Method to save a item to the db
            public void AddItems(Items itemToAdd)
            {
                using (SQLiteConnection db = new SQLiteConnection(_dbPath))
                {
                    bool exists = false;

                    //error checking to prevent adding same item twice
                    foreach (Items i in db.Table<Items>())
                    {
                        if (i.ItemID == itemToAdd.ItemID
                            && i.ItemName == itemToAdd.ItemName
                            && i.ItemDescription == itemToAdd.ItemDescription)
                        {
                            exists = true;
                            break;
                        }
                    }

                    //if item doesnt exist in the DB, add them
                    if (!exists)
                    {
                        db.Insert(itemToAdd);
                    }
                }
            }
            //method to get a list of all items in the database
            public List<Items> GetAllItems()
            {
                List<Items> Item = new List<Items>();

                using (SQLiteConnection db = new SQLiteConnection(_dbPath))
                {
                    Item = db.Table<Items>().ToList();
                }

                return Item;
            }
        }
    }
}
