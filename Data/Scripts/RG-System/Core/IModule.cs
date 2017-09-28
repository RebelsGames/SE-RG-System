namespace szczepix.RGSystem.Core
{
    public interface IModule
    {
        void Enable();
        void Disable();
        string GetName();
    }
}
