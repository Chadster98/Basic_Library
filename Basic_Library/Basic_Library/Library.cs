using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Library
{
    class Library
    {
        public static List<Book> availableBooks = new List<Book>();
        public User user = new User("",0);
        public Library()
        {

        }
        public void ReturnToLibrary()
        {
            Console.WriteLine("Whats the book title?");
            string newTitle = Console.ReadLine();
            Book returnBook = User.borrowedBooks.Find(x => x.Title == newTitle);
            
            if(returnBook != null)
            {
                User.borrowedBooks.Remove(returnBook);
                availableBooks.Add(new Book(newTitle));
                Console.WriteLine("The book " + newTitle + " has now been returned to library. Press enter to proceed");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The book you entered does not exist.");
                Console.ReadLine();
            }
        }
        public void RemoveBookFromLibraryAdmin()
        {
            foreach(Book book in availableBooks)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("What book would you like to remove?");
            string removeBook = Console.ReadLine();
            Book bookTmp = availableBooks.Find(x => x.Title == removeBook);
            if (bookTmp != null)
            {
                Console.WriteLine("The book has been removed");
                availableBooks.Remove(bookTmp);
                Console.WriteLine("The new booklist has been updated");
                foreach (Book newBookList in availableBooks)
                {
                    Console.WriteLine(newBookList.Title);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The book does not exist..");
                Console.ReadLine();
            }
        }
        public void ShowAllAvailableBooksInLibrary()
        {
            foreach (Book i in availableBooks)
            {
                Console.WriteLine(i.Title);
            }
            Console.ReadLine();
        }
        public void InitiateBooks()
        {
            availableBooks.Add(new Book("Harry Potter"));
            availableBooks.Add(new Book("Dragon Ball"));
            availableBooks.Add(new Book("Lord Of The Rings"));
            availableBooks.Add(new Book("Halo"));
        }
        public void AddBookToLibraryAdmin()
        {
            foreach(Book i in availableBooks)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("What book would you like to add?");
            string addNewBookAdmin = Console.ReadLine();
            availableBooks.Add(new Book(addNewBookAdmin));
            Console.WriteLine("The book {0} has now been added to library ", addNewBookAdmin);
            Console.WriteLine("The bookshell has been updated");
            foreach(Book newBookList in availableBooks)
            {
                Console.WriteLine(newBookList.Title);
            }
            Console.ReadLine();
        }
    }
}
