using System;
using System.Collections.Generic;

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
            //Logic not yet implemented
            return addressBook;
        }

        static void SaveAddressBook(List<Person> data, string destFilePath)
        {
            //NYI
        }
        static void Main()
        {
            //Source: https://stackoverflow.com/questions/38075381/get-documents-folder-path-of-current-logged-on-user
            string addressBookPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AddressBook.txt";
            List<Person> addressBook = LoadAddressBook(addressBookPath);
        }
    }
}
