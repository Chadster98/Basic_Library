using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Library
{
     class UserHandler
    {
        Menu menu = new Menu();
        public List<User> users = new List<User>();
        public static List<User> adminUsers = new List<User>();
        public int idCounter = 0;

        
        public void AddNewUser()
        {
            try
            {
                Console.WriteLine("Enter new nickname");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter new password with digits");
                int password = Convert.ToInt32(Console.ReadLine());
                users.Add(new User(newName, password));
                idCounter++;
                Console.WriteLine("Account has been registered!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The input was incorrect try again!", ex.Message);
                Console.ReadLine();
                Console.Clear();
            }
            

        }

        public void DeleteUser()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            User nickTmp = users.Find(x => x.Name == userName);
            if (nickTmp == null)
            {
                Console.WriteLine("The user does not exist");
                
            }
            else
            {
                Console.WriteLine("Please enter password");
                int password = Convert.ToInt32(Console.ReadLine());
                User passTmp = users.Find(x => x.Password == password);

                if (passTmp == null)
                {
                    Console.WriteLine("Password does not match");
                    

                }
                else
                {
                    users.Remove(nickTmp);
                    Console.WriteLine("Account was succesfully removed");
                    Console.ReadLine();
                }
            }
        }
        public void ShowAllMembers()
        {
            foreach (User user in users)
            {
                Console.WriteLine(idCounter + " " + user.Name);
            }
            Console.ReadLine();
        }
        public void Login()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            User nickTmp = users.Find(x => x.Name == userName);
            if (nickTmp == null)
            {
                Console.WriteLine("No user found with that username");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please enter password");
                int password = 0;
                string result = Console.ReadLine();
                bool isParsable = int.TryParse(result, out password);
                if (isParsable)
                {
                    if (password == nickTmp.Password)
                    {
                        Console.WriteLine("Login succesful! Click enter to proceed to Menu");
                        Console.ReadLine();
                        Console.Clear();
                        menu.MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("The password is incorrect!");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("The input was not digits or Incorrect.");
                    Console.ReadLine();
                }  
            }
        }
        public void AddNewAdminUser()
        {
            Console.WriteLine("Enter name of new Admin");
            string adminNickName = Console.ReadLine();
            Console.WriteLine("Enter new password");
            int adminNewPassword = Convert.ToInt32(Console.ReadLine());
            adminUsers.Add(new User(adminNickName, adminNewPassword));
            Console.WriteLine("New Admin with name {0} has been created.", adminNickName);
            Console.ReadLine();
        }
        public void SeeAllAdmins()
        {
            foreach(User i in adminUsers)
            {
                Console.WriteLine(i.Name);
            }
            Console.ReadLine();
        }
        public void RemoveAdminUser()
        {
            foreach(User i in adminUsers)
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("Which admin should be removed?");
            string adminUserName = Console.ReadLine();
            User adminToRemove = adminUsers.Find(x => x.Name == adminUserName);
            if(adminToRemove != null)
            {
                adminUsers.Remove(adminToRemove);
                Console.WriteLine("Admin with the name {0} has been removed. ", adminUserName);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You must have entered an invalid name or he/she does not exist");
                Console.ReadLine();
            }  
        }
        public void InitiateAdmins()
        {
            adminUsers.Add(new User("Chadi", 12345));
            adminUsers.Add(new User("Herbert", 123456));
        }
    }
}
