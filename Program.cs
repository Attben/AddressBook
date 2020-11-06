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

        }

        static void SaveAddressBook(List<Person> data, string destFilePath)
        {

        }
        static void Main(string[] args)
        {
        }
    }
}
