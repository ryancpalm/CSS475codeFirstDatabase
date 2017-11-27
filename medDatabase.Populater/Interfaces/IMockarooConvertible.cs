namespace medDatabase.Populater.Interfaces
{
    public interface IMockarooConvertible<out T>
    {
        T Convert();
    }
}
