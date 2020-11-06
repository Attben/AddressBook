using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBook
{
    class Person
    {
        string name, address, phone, email;

        public Person(string name, string address, string phone, string email)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }
    }
    class Program
    {
        static List<Person> LoadAddressBook(string srcFilePath)
        {
            List<Person> addressBook = new List<Person>();
            string[] lines = File.ReadAllLines(srcFilePath);

            for (int n = 0; n < lines.Length; n += 4)
            {
                string name = lines[n];
                string address = lines[n + 1];
                string phone = lines[n + 2];
                string email = lines[n + 3];
                addressBook.Add(new Person(name, address, phone, email));
            }
            return addressBook;
        }

        static void SaveAddressBook(List<Person> data, string destFilePath)
        {
            //NYI
        }
        static void Main()
        {
            Console.WriteLine("Welcome to the MJU20 address book assignment.");
            //Source: https://stackoverflow.com/questions/38075381/get-documents-folder-path-of-current-logged-on-user
            string addressBookPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AddressBook.txt";
            List<Person> addressBook;
            try
            {
                addressBook = LoadAddressBook(addressBookPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not load address book: " + ex.Message);
                addressBook = new List<Person>();
            }
        }
    }
}
