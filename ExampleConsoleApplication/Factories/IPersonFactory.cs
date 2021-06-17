using ExampleConsoleApplication.Factories.Base;
using ExampleConsoleApplication.Models;

namespace ExampleConsoleApplication.Factories
{
    public interface IPersonFactory : ICsvFactory<Person>, IJsonFactory<Person>
    {
    }
}