using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Library
{
    public class Menu
    {

        public User user = new User("", 0);
        public Menu()
        {

        }
        public void MainMenu()
        {
            Library lib = new Library();
            bool isActive = true;
            Console.WriteLine("Welcome to the Library, what would you like to do?");
            while (isActive)
            {
                Console.WriteLine("1. Borrow a new book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("3. Show all books available to borrow");
                Console.WriteLine("4. Show all books borrowed");
                Console.WriteLine("5. Exit the library");
                int menuSelection = 0;
                string result = Console.ReadLine();
                bool isParsable = Int32.TryParse(result, out menuSelection);
                if (isParsable)
                {
                    switch (menuSelection)
                    {
                        case 1:
                            Console.Clear();
                            BorrowANewBook();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            lib.ReturnToLibrary();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            lib.ShowAllAvailableBooksInLibrary();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            user.showBorrowedBooks();
                            Console.Clear();
                            break;
                        case 5:
                            isActive = false;
                            Console.WriteLine("You are leaving the library. Click enter to shutdown..");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Try using [1-5]");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try using digits between [1-5]");
                    Console.ReadLine();
                    Console.Clear();
                }
                
            }
        }
        public void LoginMenu()
        {
            UserHandler userHandler = new UserHandler();
            bool logInIsActive = true;
            while (logInIsActive)
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register new Account");
                Console.WriteLine("3.Delete Membership");
                Console.WriteLine("4.See all users registered");
                Console.WriteLine("5.Login Admin");
                Console.WriteLine("6.Exit");
                int menuSelectionLogin = 0;
                string result = Console.ReadLine();
                bool isParsable = int.TryParse(result, out menuSelectionLogin);
                if (isParsable)
                {
                    switch (menuSelectionLogin)
                    {
                        case 1:
                            Console.Clear();
                            userHandler.Login();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            userHandler.AddNewUser();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            userHandler.DeleteUser();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            userHandler.ShowAllMembers();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            LoginAdmin();
                            Console.Clear();
                            break;
                        case 6:
                            logInIsActive = false;
                            Console.WriteLine("You are exiting.. Click enter to proceed.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Try using [1-5]");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("You did not use digits.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        public void BorrowANewBook()
        {
            foreach (Book i in Library.availableBooks)
            {
                Console.WriteLine("Available books are " + i.Title);
            }
            Console.WriteLine("Write the title of the book you want to borrow");
            string borrowBook = Console.ReadLine();
            Book bookTmp = Library.availableBooks.Find(i => i.Title == borrowBook);
            if (bookTmp != null)
            {
                Library.availableBooks.Remove(bookTmp);
                User.borrowedBooks.Add(bookTmp);
                Console.WriteLine("The book " + borrowBook + " has now been borrowed. Click enter to proceed");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("The book you are trying to borrow does not exist");
                Console.ReadLine();
            }
        }
        public void LoginAdmin()
        {
            Library lib = new Library();
            UserHandler userHandler = new UserHandler();
            Console.WriteLine("Please enter your password");
            try
            {
                int passwordOfAdmin = Convert.ToInt32(Console.ReadLine());
                User adminTmp = UserHandler.adminUsers.Find(x => x.Password == passwordOfAdmin);

                if (adminTmp == null)
                {
                    Console.WriteLine("User with that password was not accessible");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to AdminMenu");
                    bool adminMenu = true;
                    while (adminMenu)
                    {
                        Console.WriteLine("1.Show all Admins available");
                        Console.WriteLine("2.Add new book to library");
                        Console.WriteLine("3.Remove book from library");
                        Console.WriteLine("4.Add new user");
                        Console.WriteLine("5.Delete Admin");
                        Console.WriteLine("6.Exit AdminMenu");
                        int menuSelectAdmin = Convert.ToInt32(Console.ReadLine());
                        switch (menuSelectAdmin)
                        {
                            case 1:
                                Console.Clear();
                                userHandler.SeeAllAdmins();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                lib.AddBookToLibraryAdmin();
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                lib.RemoveBookFromLibraryAdmin();
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                userHandler.AddNewAdminUser();
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                userHandler.RemoveAdminUser();
                                Console.Clear();
                                break;
                            case 6:
                                Console.WriteLine("You are leaving Admin Menu.");
                                Console.ReadLine();
                                adminMenu = false;
                                break;
                        }

                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The input did not match any user with the role Admin..");
                Console.ReadLine();
            }
        }
    }
}