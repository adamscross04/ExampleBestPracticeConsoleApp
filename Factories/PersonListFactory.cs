using System.Collections.Generic;
using System.Linq;
using ExampleConsoleApplication.Models;
using Newtonsoft.Json.Linq;

namespace ExampleConsoleApplication.Factories
{
    public class PersonListFactory : IPersonListFactory
    {
        public PersonListFactory(IPersonFactory personFactory)
        {
            PersonFactory = personFactory;
        }

        private IPersonFactory PersonFactory { get; }

        public List<Person> CreateFromJson(string inputObject)
        {
            JArray arr = JArray.Parse(inputObject);
            return arr.Select(person => PersonFactory.CreateFromJson(person.ToString())).ToList();
        }

        public List<Person> CreateFromCsv(string people)
        {
            List<string> rows = people.Split("\n").ToList();
            return rows.Select(person => PersonFactory.CreateFromCsv(person)).ToList();
        }
    }
}