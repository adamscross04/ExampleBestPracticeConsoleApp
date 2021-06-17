using ExampleConsoleApplication.Factories.Base;
using ExampleConsoleApplication.Models;

namespace ExampleConsoleApplication.Factories
{
    public interface IPersonListFactory : ICsvListFactory<Person>, IJsonListFactory<Person>
    {
    }
}