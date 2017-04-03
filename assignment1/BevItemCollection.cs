//Author: David Gipe
//CIS 237
//Assignment 1
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class BevItemCollection
    {
        BeverageDGipeEntities bevItems = new BeverageDGipeEntities();
        
        public override string ToString()
        {
            string returnString = "";

            foreach (Beverage bev in bevItems.Beverages)
            {
                if (bev != null)
                    returnString += Environment.NewLine + "ID: " + bev.id + Environment.NewLine +
                        "Item Name: " + bev.name +
                        "Item pack: " + bev.pack + Environment.NewLine +
                        "Item cost: " + bev.price.ToString("C")+ Environment.NewLine + 
                        "Active?: " + bev.active + Environment.NewLine;
            }

            return returnString;            
        }

        public Beverage searchItem(string input)
        {
            Beverage ToFind = bevItems.Beverages.Where(beverage => beverage.id == input).First();

            return ToFind;
            
        }

        public void addItem(string id, string[] namePack, decimal price, bool active)
        {
            //Placeholder for new item
            Beverage newBev = new Beverage();

            //Assign the properties
            newBev.id = id;
            newBev.name = namePack[0];
            newBev.pack = namePack[1];
            newBev.price = price;
            newBev.active = active;

            //Move to database
            bevItems.Beverages.Add(newBev);
            bevItems.SaveChanges();
        }

        public void deleteItem(Beverage input)
        {
            bevItems.Beverages.Remove(input);
            bevItems.SaveChanges();
        }

        public void updateItem(Beverage updateItem, string name, string pack, decimal price, bool active)
        {
            //Push to database
            updateItem.name = name;
            updateItem.pack = pack;
            updateItem.price = price;
            updateItem.active = active;
            
            bevItems.SaveChanges();
        }
    }

}