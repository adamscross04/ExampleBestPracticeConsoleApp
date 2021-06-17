namespace ExampleConsoleApplication.Factories.Base
{
    public interface  ICsvFactory<out TOut>
    {
        TOut CreateFromCsv(string inputCsv);
    }
}