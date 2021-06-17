using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ExampleConsoleApplication.Factories;
using ExampleConsoleApplication.Models;

namespace ExampleConsoleApplication.Services
{
    internal class BootstrapService : IBootstrapService
    {
        // We can dependency inject any of the services we have registered in our ServiceCollection in the Program.cs
        // Using our constructor. You should never instantiate a "new" instance of this class

        // Dependencies can either be registered via an abstractions NuGet package (for example one of our SDKs)
        // Or directly within our application for any of our custom services. For example, our factories 
        // We pull them in using the interface and not the class name

        // If when running your application you get an exception saying "Unable to resolve service for type"
        // Double check that you have registered the service as either a singleton, transient or scoped

        public BootstrapService(IPersonFactory personFactory, IPersonListFactory personListFactory)
        {
            PersonFactory = personFactory;
            PersonListFactory = personListFactory;
        }

        // Dependencies should be the least accessible they can be. In this case we have gone for private and get only
        private IPersonFactory PersonFactory { get; }
        private IPersonListFactory PersonListFactory { get; }

        // Run() is the entry point to our service, we will do most of our work from here.
        public async Task Run()
        {
            // we are using a using statement since StreamReader implements IDisposable. 
            // This means that when the reader is no longer needed, it will automatically be disposed of

            // For this part we are going to read line by line
            using (StreamReader reader = new StreamReader(@"..\..\..\data\people.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();

                    Person person = PersonFactory.CreateFromCsv(line);
                    Console.WriteLine($"FirstName: {person.FirstName}, LastName: {person.LastName}");
                }
            }

            // This time we are going to read all of the lines and process them via the list factory
            using (StreamReader reader = new StreamReader(@"..\..\..\data\people.csv"))
            {
                string lines = await reader.ReadToEndAsync();

                List<Person> people = PersonListFactory.CreateFromCsv(lines);

                foreach (Person person in people)
                    Console.WriteLine($"FirstName: {person.FirstName}, LastName: {person.LastName}");
            }
            
            using (StreamReader reader = new StreamReader(@"..\..\..\data\people.json"))
            {
                string lines = await reader.ReadToEndAsync();

                List<Person> people = PersonListFactory.CreateFromJson(lines);

                foreach (Person person in people)
                    Console.WriteLine($"FirstName: {person.FirstName}, LastName: {person.LastName}");
            }
        }
    }
}