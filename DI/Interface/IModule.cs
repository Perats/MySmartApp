using Unity;

namespace DI.Interface
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}
