//Author: David Barnes
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
        
        public BevItemCollection()
        {

        }

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
                        "Active?:" + bev.active + Environment.NewLine;
            }

            return returnString;
            
        }
    }

}