using System;
using System.Collections.Generic;
using System.IO;
using CommonTests;
using ExampleConsoleApplication.Factories;
using ExampleConsoleApplication.Models;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests
{
    public class PeopleTests : TestApplicationBase
    {
        #region Setup

        protected override void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPersonFactory, PersonFactory>();
            serviceCollection.AddSingleton<IPersonListFactory, PersonListFactory>();
        }

        #endregion

        #region Tests

        [Fact]
        private void CheckValidPerson()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Person person = factory.CreateFromJson(GetValidPersonJson());

            person.FirstName.Should().Be("Adam");
            person.LastName.Should().Be("Cross");
            person.Height.Should().Be(1.93);
            person.Weight.Should().Be(180);
            person.DateOfBirth.Should().Be(new DateTime(1991, 05, 13));
        }

        [Fact]
        private void CheckMissingFirstName()
        {
            IPersonFactory factory = GetService<IPersonFactory>();
            Action action = () => factory.CreateFromJson(GetPersonWithNoFirstNameJson());
            action.Should().Throw<MissingFieldException>().WithMessage("property 'firstName' must be provided");
        }

        [Fact]
        private void CheckMissingLastName()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromJson(GetPersonWithNoLastNameJson());
            action.Should().Throw<MissingFieldException>().WithMessage("property 'lastName' must be provided");
        }

        [Fact]
        private void CheckMissingDateOfBirth()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromJson(GetPersonWithNoDateOfBirthJson());
            action.Should().Throw<MissingFieldException>().WithMessage("property 'dateOfBirth' must be provided");
        }


        [Fact]
        private void CheckMissingHeight()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromJson(GetPersonWithNoHeightJson());
            action.Should().Throw<MissingFieldException>().WithMessage("property 'height' must be provided");
        }

        [Fact]
        private void CheckMissingWeight()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromJson(GetPersonWithNoWeightJson());
            action.Should().Throw<MissingFieldException>().WithMessage("property 'weight' must be provided");
        }

        [Fact]
        private void CheckListOfPeople()
        {
            IPersonListFactory factory = GetService<IPersonListFactory>();
            List<Person> people = factory.CreateFromJson(GetMultiplePeopleJson());
            people.Count.Should().Be(3);
        }

        [Fact]
        private void CheckValidPersonCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();
            Person person = factory.CreateFromCsv(GetValidPersonCsv());

            person.FirstName.Should().Be("Adam");
            person.LastName.Should().Be("Cross");
            person.Height.Should().Be(1.93);
            person.Weight.Should().Be(180);
            person.DateOfBirth.Should().Be(new DateTime(1991, 05, 13));
        }

        [Fact]
        private void CheckShortPersonCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetShortPersonCsv());
            action.Should().Throw<InvalidDataException>().WithMessage("a person must contain exactly 5 parameters");
        }

        [Fact]
        private void CheckLongPersonCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetLongPersonCsv());
            action.Should().Throw<InvalidDataException>().WithMessage("a person must contain exactly 5 parameters");
        }

        [Fact]
        private void CheckInvalidHeightCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetPersonWithInvalidHeightCsv());
            action.Should().Throw<Exception>().WithMessage("height must not be negative");
        }

        [Fact]
        private void CheckInvalidWeightCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetPersonWithInvalidWeightCsv());
            action.Should().Throw<Exception>().WithMessage("Weight must not be negative");
        }

        [Fact]
        private void CheckInvalidFirstNameCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetPersonWithNoFirstNameCsv());
            action.Should().Throw<Exception>().WithMessage("firstName should not be empty");
        }

        [Fact]
        private void CheckInvalidLastNameCsv()
        {
            IPersonFactory factory = GetService<IPersonFactory>();

            Action action = () => factory.CreateFromCsv(GetPersonWithNoLastNameCsv());
            action.Should().Throw<Exception>().WithMessage("lastName should not be empty");
        }

        [Fact]
        private void CheckMultiplePeopleCsv()
        {
            IPersonListFactory factory = GetService<IPersonListFactory>();
            List<Person> people = factory.CreateFromCsv(GetMultiplePeopleCsv());
            people.Count.Should().Be(3);
        }

        [Fact]
        private void CheckDateInFuture()
        {
            IPersonFactory factory = GetService<IPersonFactory>();
            Action action = () => factory.CreateFromCsv(GetPersonWithDateOfBirthInFutureCsv());
            action.Should().Throw<Exception>().WithMessage("dateOfBirth must not be in the future");
        }

        #endregion

        #region Data

        private string GetMultiplePeopleJson()
        {
            return
                "[{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180},{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180 },{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180 }]";
        }

        private string GetValidPersonJson()
        {
            return
                "{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180}";
        }

        private string GetPersonWithNoFirstNameJson()
        {
            return "{'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180}";
        }

        private string GetPersonWithNoLastNameJson()
        {
            return "{'firstName': 'Adam', 'dateOfBirth': '1991/05/13', 'height': 1.93, 'weight': 180}";
        }

        private string GetPersonWithNoDateOfBirthJson()
        {
            return "{'firstName': 'Adam', 'lastName': 'Cross', 'height': 1.93, 'weight': 180}";
        }


        private string GetPersonWithNoHeightJson()
        {
            return "{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'weight': 180}";
        }

        private string GetPersonWithNoWeightJson()
        {
            return "{'firstName': 'Adam', 'lastName': 'Cross', 'dateOfBirth': '1991/05/13', 'height': 1.93}";
        }

        private string GetValidPersonCsv()
        {
            return "Adam, Cross, 1991/05/13, 1.93, 180";
        }

        private string GetShortPersonCsv()
        {
            return "Adam, Cross, 1991/05/13, 1.93";
        }

        private string GetLongPersonCsv()
        {
            return "Adam, Cross, 1991/05/13, 1.93, 180, 15";
        }

        private string GetPersonWithInvalidHeightCsv()
        {
            return "Adam, Cross, 1991/05/13, -1.93, 180";
        }

        private string GetPersonWithInvalidWeightCsv()
        {
            return "Adam, Cross, 1991/05/13, 1.93, -180";
        }

        private string GetPersonWithNoFirstNameCsv()
        {
            return ", Cross, 1991/05/13, 1.93, 180";
        }

        private string GetPersonWithNoLastNameCsv()
        {
            return "Adam, , 1991/05/13, 1.93, 180";
        }

        private string GetPersonWithDateOfBirthInFutureCsv()
        {
            return "Adam, Cross, 2025/05/13, 1.93, 180";

        }

        private string GetMultiplePeopleCsv()
        {
            return
                "Adam, Cross, 1991/05/13, 1.93, 180\nAdam, Cross, 1991/05/13, 1.93, 180\nAdam, Cross, 1991/05/13, 1.93, 180";
        }

        #endregion
    }
}