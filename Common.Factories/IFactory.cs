namespace Common.Factories;

public interface IFactory<in TIn, out TOut>
{
    TOut Create(TIn obj);
}