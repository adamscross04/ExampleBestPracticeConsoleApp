using System.Collections.Generic;

namespace ExampleConsoleApplication.Factories.Base
{
    public interface IJsonListFactory<TOut>
    {
        List<TOut> CreateFromJson(string inputJson);
    }
}