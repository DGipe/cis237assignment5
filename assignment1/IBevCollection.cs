using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    interface IBevCollection
    {
        void AddNewItem(string id, string description, string pack);

        string[] GetPrintStringsForAllItems();

        string FindById(string id);
    }
}
