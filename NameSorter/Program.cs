using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using NameSorter;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;     //Gets file path for NameSorter folder, where unsorted-names-list.txt is located and where sorted-names-list.txt will be located
        string fileName = "\\unsorted-names-list.txt";
        string sortedFileName = "\\sorted-names-list.txt";

        string[] names = File.ReadAllLines(path+fileName);      //Adds each name as an element to the Array 'names'.

        //Display in console all names as found in 'unsorted-names-list.txt. and waits for user input to continue.
        foreach (string name in names) { Console.WriteLine(name); }
        Console.WriteLine("\nPress any key to sort names...");
        Console.ReadKey();
        Console.Clear();

        Person[] people = new Person[names.Length];     //Initialise new Array for 'Person' class with equal length to number of elements in Array 'names'.

        //Iterates through 'names' Array to seperate first and last name.
        for (int i = 0; i < names.Length; i++)
        {
            Person p = new Person();
            p.LastName = names[i].Split(' ').Last();
            string givenN = names[i].Substring(0, (names[i].Length-p.LastName.Length)).Trim();
            if (p.FirstNameLimit(givenN)) { p.FirstName = givenN; } 
            else { break; }
            people[i] = p;
        }
        //Sort Array of 'Person' class by last name then by first name.
        IEnumerable<Person> results = people.OrderBy(person => person.LastName).ThenBy(person => person.FirstName);

        //Display in console of new 'Person' class Array 'resuls' in sorted order.
        foreach (Person p in results) { Console.WriteLine(p.FirstName + p.LastName); }
        Console.WriteLine("\nPress any key to create new 'sorted-names-list.txt'...");
        Console.ReadKey();
        Console.Clear();

        //Check if file already exists. If yes, delete it.
        if (File.Exists(path + sortedFileName))
        {
            File.Delete(path + sortedFileName);
        }
        //Create new file for sorted names.
        using (FileStream fs = File.Create(path + sortedFileName))
        {
            //Create TextWriter to write each sorted name on seperate lines.
            StreamWriter streamWriter = new StreamWriter(fs);
            TextWriter textWriter = streamWriter;
            foreach (Person person in results) { textWriter.WriteLine(person.FirstName + person.LastName); }
            textWriter.Close();
        }

        Console.WriteLine("New file 'sorted-names-list.txt' has been created.");
        Console.ReadKey();
    }
}