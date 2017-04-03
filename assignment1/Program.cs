﻿//Author: David Gipe
//CIS 237
//Assignment 1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            BeverageDGipeEntities bevItems = new BeverageDGipeEntities();


            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        //Add A New Item 
                        string IDnew = userInterface.IDadd();
                        try
                        {
                            //attempt to find ID
                            Beverage ToFind = bevItems.Beverages.Where(beverage => beverage.id == IDnew).First();

                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        catch
                        {
                            //nothing found
                            string[] newItemInformation = userInterface.GetNewItemInformation();
                            decimal price = userInterface.PriceAdd();
                            bool active = userInterface.ActiveAdd();

                            //Placeholder for new item
                            Beverage newBev = new Beverage();

                            //Assign the properties
                            newBev.id = IDnew;
                            newBev.name = newItemInformation[0];
                            newBev.pack = newItemInformation[1];
                            newBev.price = price;
                            newBev.active = active;
                            
                            //Move to database
                            bevItems.Beverages.Add(newBev);
                            bevItems.SaveChanges();

                            userInterface.DisplayAddWineItemSuccess();
                        }
                        break;
                    case 2:
                        //Search For An Item 
                        //Get input
                        string searchResponse = userInterface.GetSearchQuery();
                        //Try and find 
                        try
                        {
                            //attempt to find ID
                            Beverage ToFind = bevItems.Beverages.Where(beverage => beverage.id == searchResponse).First();

                            userInterface.DisplayItemFound();
                            
                            userInterface.DisplayItemInfo(ToFind);
                        }
                        catch
                        {
                            //nothing found
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                    case 3:
                        //Update an existing item   
                        string updateID = userInterface.getUpdateID();
                        //Try and find 
                        try
                        {
                            //attempt to find ID
                            Beverage ToUpdate = bevItems.Beverages.Where(beverage => beverage.id == updateID).First();

                            userInterface.DisplayItemFound();
                            userInterface.DisplayItemInfo(ToUpdate);
                            //Get update info
                            string name = userInterface.updateName(ToUpdate.name);
                            //Get pack info
                            string pack = userInterface.updatePack(ToUpdate.pack);
                            //Get price info
                            decimal price = userInterface.updatePrice(ToUpdate.price);
                            //Get price info
                            bool active = userInterface.updateActive(ToUpdate.active);

                            //Push to database
                            ToUpdate.name = name;
                            ToUpdate.pack = pack;
                            ToUpdate.price = price;
                            ToUpdate.active = active;

                            bevItems.SaveChanges();
                            userInterface.updateSucess();
                            userInterface.DisplayItemInfo(ToUpdate);

                        }
                        catch
                        {
                            //nothing found
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                    case 4:
                        //Delete an Item from Database
                        string deleteID = userInterface.getDeleteID();
                        //Try and find 
                        try
                        {
                            //attempt to find ID
                            Beverage ToDelete = bevItems.Beverages.Where(beverage => beverage.id == deleteID).First();

                            userInterface.DisplayItemFound();
                            userInterface.DisplayItemInfo(ToDelete);

                            bool input = userInterface.acceptDelete();

                            if (input == true)
                            {

                                //Delete Item and save
                                bevItems.Beverages.Remove(ToDelete);
                                bevItems.SaveChanges();

                                userInterface.confirmDelete();
                            }
                            else
                            {
                                userInterface.canceldelete();
                                break;
                            }
                        }
                        catch
                        {
                            //nothing found
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                    case 5:
                        //Print Database
                        userInterface.DisplayAllItems();
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
