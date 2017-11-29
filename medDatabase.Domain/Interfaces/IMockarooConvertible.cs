namespace medDatabase.Domain.Interfaces
{
    public interface IMockarooConvertible<out T>
    {
        T Convert();
    }
}
