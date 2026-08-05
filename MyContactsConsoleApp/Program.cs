using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsolApp
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");
            }
        }

        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Contact1.FirstName = "Lina";
                Contact1.LastName = "Maher";
                Contact1.Email = "A2@a.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";

                if (Contact1.Save())
                {
                    Console.WriteLine("Contact updated Successfully.");
                }
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteContact(int ID)
        {
            if (clsContact.DeleteContact(ID))
                Console.WriteLine("Contact Deleted Successfully.");
            else
                Console.WriteLine("Failed to delete contact.");
        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void TestExistence(int ID)
        {
            if (clsContact.IsContactExist(ID))
            {
                Console.WriteLine($"Contact [{ID}] exists.");
            }
            else
            {
                Console.WriteLine($"Contact [{ID}] does NOT exist.");
            }
        }

        static void findCountryByName(string name)
        {
            if (clsContact.FindCountry(name))
            {
                Console.WriteLine($"Country '{name}' was found.");
            }
            else
            {
                Console.WriteLine($"Country '{name}' was Not found.");
            }
        }

        static void ISExistedCountryByName(string name)
        {
            if (clsContact.isCountryExist(name))
            {
                Console.WriteLine($"Country '{name}' was Existed.");
            }
            else
            {
                Console.WriteLine($"Country '{name}' was Not Existed.");
            }
        }

        static void Main(string[] args)
        {
            // testFindContact(6);
            // testAddNewContact();
            //testUpdateContact(1);
            // testDeleteContact(1);
            // ListContacts();
            ISExistedCountryByName("Canada");

            Console.ReadKey();
        }
    }
}