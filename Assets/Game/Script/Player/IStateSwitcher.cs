namespace Script
{
    public interface IStateSwitcher
    {
        void Switch<T>() where T : StateBase;
    }
}