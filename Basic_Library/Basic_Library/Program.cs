using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.InitiateBooks();
            UserHandler users = new UserHandler();
            users.InitiateAdmins();
            Menu meny = new Menu();
            meny.LoginMenu();
        }
    }
}
