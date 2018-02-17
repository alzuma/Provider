namespace Provider.interfaces
{
    public interface IProvider<out T>
    {
        T Get();

        T Get(params object[] parameters);
    }
}