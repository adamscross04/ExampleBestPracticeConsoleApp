using System;
using System.Collections.Generic;
using System.IO;
using ExampleConsoleApplication.Extensions;
using ExampleConsoleApplication.Models;
using Newtonsoft.Json;

namespace ExampleConsoleApplication.Factories
{
    public class PersonFactory : IPersonFactory
    {
        public Person CreateFromJson(string inputObject)
        {
            Dictionary<string, object> obj = JsonConvert.DeserializeObject<Dictionary<string, object>>(inputObject);

            obj.EnsureFieldPresent("firstName", out string firstName);
            obj.EnsureFieldPresent("lastName", out string lastName);
            obj.EnsureFieldPresent("dateOfBirth", out DateTime dateOfBirth);
            obj.EnsureFieldPresent("height", out double height);
            obj.EnsureFieldPresent("weight", out int weight);

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Height = height,
                Weight = weight
            };

            ValidateFields(person);

            return person;
        }

        public Person CreateFromCsv(string inputCsv)
        {
            string[] data = inputCsv.Split(',');

            if (data.Length != 5) throw new InvalidDataException("a person must contain exactly 5 parameters");

            data.EnsureFieldPresent(0, out string firstName);
            data.EnsureFieldPresent(1, out string lastName);
            data.EnsureFieldPresent(2, out DateTime dateOfBirth);
            data.EnsureFieldPresent(3, out double height);
            data.EnsureFieldPresent(4, out int weight);

            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Height = height,
                Weight = weight
            };

            ValidateFields(person);

            return person;
        }

        private void ValidateFields(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName)) throw new Exception("firstName should not be empty");

            if (string.IsNullOrWhiteSpace(person.LastName)) throw new Exception("lastName should not be empty");

            if (person.DateOfBirth > DateTime.Now) throw new Exception("dateOfBirth must not be in the future");

            if (person.Height <= 0) throw new Exception("height must not be negative");

            if (person.Weight <= 0) throw new Exception("weight must not be negative");
        }
    }
}