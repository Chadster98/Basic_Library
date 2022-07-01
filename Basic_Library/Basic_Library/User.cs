using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Library
{
    public class User
    {
       public static List<Book> borrowedBooks = new List<Book>();

        public string Name { get; set; }
        public int Password { get; set; }

        public User(string name, int password)
        {
            Name = name;
            Password = password;
        }

        public void showBorrowedBooks()
        {
            foreach (Book i in borrowedBooks)
            {
                Console.WriteLine(i.Title);
            }
            Console.ReadLine();
        }
    }
}
