//Author: David Gipe
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        const int maxMenuChoice = 6;

        BevItemCollection BevList = new BevItemCollection();
        
        //---------------------------------------------------
        //Public Methods
        //---------------------------------------------------

        //Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the program");
        }

        //Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.displayPrompt();

            //Get the selection they enter
            selection = this.getSelection();

            //While the response is not valid
            while (!this.verifySelectionIsValid(selection))
            {
                //display error message
                this.displayErrorMessage();

                //display the prompt again
                this.displayPrompt();

                //get the selection again
                selection = this.getSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        //Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //***************************
        //UPpdate item
        //***************************
        public string getUpdateID()
        {
            Console.WriteLine();
            Console.WriteLine("What is the ID of the item to be updated?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get new description
        public string updateName(String description)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like the Name to be?");
            Console.WriteLine("Current is: " + description);
            Console.Write("> ");

            return Console.ReadLine();
        }

        //Get new pack info
        public string updatePack(String description)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like the pack to be?");
            Console.WriteLine("Current is: " + description);
            Console.Write("> ");

            return Console.ReadLine();
        }

        //Get new price
        public decimal updatePrice(decimal price)
        {
            Console.WriteLine("What is the items new Price?");
            Console.WriteLine("Current is: " + price);
            Console.Write("> ");
            //Attempt to parse  input
            try
            {
                price = decimal.Parse(this.getSelection());
            }
            //Display error if input is bad
            catch
            {
                Console.WriteLine();
                Console.WriteLine("That is not a valid price, please try again");
                Console.WriteLine();
                PriceAdd();
            }
            return price;
        }

        //Get new active status
        public bool updateActive(bool active)
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to switch the active status? (Y/N)" );
            Console.WriteLine("Current is: " + active);
            Console.Write("> ");
            string input = Console.ReadLine();
            //While te imput is not valid re-get the input
            while (input != "Y" && input != "N")
            {
                //Print Error message
                this.displayErrorMessage();
                this.updateActive(active);
            }

            if (input == "Y")
            {
                if (active == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return active;
            }
                     
        }

        public void updateSucess()
        {
            Console.WriteLine();
            Console.WriteLine("Update Sucess!");
        }

        //*****(*************
        //Add Item
        //*******************
        //Get new item ID from user
        public string IDadd()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {

            Console.WriteLine("What is the new items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            return new string[] { description, pack };
        }
        public decimal PriceAdd()
        {
            decimal price = 0;
            Console.WriteLine("What is the new items Price?");
            Console.Write("> ");
            //Attempt to parse  input
            try
            {
                price = decimal.Parse(this.getSelection());
            }
            //Display error if input is bad
            catch
            {
                Console.WriteLine();
                Console.WriteLine("That is not a valid price, please try again");
                Console.WriteLine();
                PriceAdd();
            }
            return price;
        }

        public bool ActiveAdd()
        {
            Console.WriteLine("");
            Console.WriteLine("Is the new item active? Y/N");
            Console.Write(">");
            string input = Console.ReadLine();
            //While te imput is not valid re-get the input
            while (input != "Y" && input != "N")
            {
                //Print Error message
                this.displayErrorMessage();
                this.ActiveAdd();
            }

            if (input == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //********************
        //Delete Item
        //****************

        public string getDeleteID()
        {
            Console.WriteLine();
            Console.WriteLine("What is the ID of the item you wish to delete?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        public bool acceptDelete()
        {
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to delete the above Item? Y/N");
            Console.Write("> ");
            string input = Console.ReadLine();
            //While te imput is not valid re-get the input
            while (input != "Y" && input != "N")
            {
                //Print Error message
                this.displayErrorMessage();
                this.ActiveAdd();
            }

            if (input == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void canceldelete()
        {
            Console.WriteLine();
            Console.WriteLine("Delete opperation has been cancled");
            Console.WriteLine();
        }

        public void confirmDelete()
        {
            Console.WriteLine();
            Console.WriteLine("Delete Sucesfull");
            Console.WriteLine();
        }

        //**************************

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine List Has Been Imported Successfully");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error importing the CSV");
        }

        //Display All Items
        public void DisplayAllItems()
        {
            Console.WriteLine(BevList.ToString());
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
        public void DisplayItemFound()
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine();
        }

        //Display Item Info
        public void DisplayItemInfo(Beverage itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + itemInformation.id);
            Console.WriteLine("Item Name: " + itemInformation.name.Trim());
            Console.WriteLine("Item Pack: " + itemInformation.pack);
            Console.WriteLine("Item Cost: " + itemInformation.price.ToString("C"));
            Console.WriteLine("Active?: " + itemInformation.active);
            
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }


        //---------------------------------------------------
        //Private Methods
        //---------------------------------------------------

        //Display the Menu
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Add New Item To The Database");
            Console.WriteLine("2. Search For An Item using the item ID");
            Console.WriteLine("3. Update an exsiting Item");
            Console.WriteLine("4. Delete an Item from the Database");
            Console.WriteLine("5. Print the list of items");
            Console.WriteLine("6. Exit Program");
        }
        
        //Display the Prompt
        private void displayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        //Display the Error Message
        private void displayErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        //Get the selection from the user
        private string getSelection()
        {
            return Console.ReadLine();
        }

        //Verify that a selection from the main menu is valid
        private bool verifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }
    }
}
