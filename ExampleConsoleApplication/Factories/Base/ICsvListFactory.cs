using System.Collections.Generic;

namespace ExampleConsoleApplication.Factories.Base
{
    public interface ICsvListFactory<TOut>
    {
        List<TOut> CreateFromCsv(string inputCsv);
    }
}