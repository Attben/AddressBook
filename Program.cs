using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Services;

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

        public string[] GetData()
        {
            string[] data = { name, address, phone, email };
            return data;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Phone number: {phone}");
            Console.WriteLine($"Email: {email}");
        }
    }
    class Program
    {
        static void AddPerson(List<Person> addressBook)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            addressBook.Add(new Person(name, address, phone, email));
        }

        static void RemovePerson(List<Person> addressBook)
        {
            Console.Write("Enter the ID of the person you wish to remove: ");
            int ID;
            while (!int.TryParse(Console.ReadLine(), out ID)) ;

            if (ID > addressBook.Count)
            {
                Console.WriteLine("Error: ID does not exist.");
            }
            else
            {
                addressBook.RemoveAt(ID - 1);
                Console.WriteLine($"Removed person at ID {ID} from the address book.");
            }
        }

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

        static void SaveAddressBook(List<Person> addressBook, string destFilePath)
        {
            //Probably space inefficient. Would probably work better with file streams.
            List<string> writeBuf = new List<string>();
            foreach (Person p in addressBook)
            {
                string[] personalInfo = p.GetData();
                foreach (string s in personalInfo)
                {
                    writeBuf.Add(s);
                }
            }
            File.WriteAllLines(destFilePath, writeBuf);
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
            catch (Exception ex)
            {
                Console.WriteLine("Could not load address book: " + ex.Message);
                addressBook = new List<Person>();
            }
            bool running = true;
            while (running)
            {
                Console.Write('>');
                string command = Console.ReadLine().ToLower();

                if (command == "add")
                {
                    AddPerson(addressBook);
                }
                else if (command == "print")
                {
                    if (addressBook.Count == 0)
                    {
                        Console.WriteLine("Address book is empty.");
                    }
                    else
                    {
                        for (int n = 0; n < addressBook.Count; ++n)
                        {
                            Console.WriteLine($"---Person number {n + 1}");
                            addressBook[n].Print();
                        }
                    }
                }
                else if (command == "remove")
                {
                    RemovePerson(addressBook);
                }
                else if (command == "quit")
                {
                    Console.WriteLine("Saving address book. Goodbye.");
                    SaveAddressBook(addressBook, addressBookPath);
                    running = false;
                }
                else if (command == "")
                {
                    //do nothing
                }
                else
                {
                    Console.WriteLine($"Unrecognized command: {command}");
                }
            }
        }
    }
}
