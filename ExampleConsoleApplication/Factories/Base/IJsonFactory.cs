namespace ExampleConsoleApplication.Factories.Base
{
    public interface IJsonFactory<out TOut>
    {
        TOut CreateFromJson(string inputJson);
    }
}