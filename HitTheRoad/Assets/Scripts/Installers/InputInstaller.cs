using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor: 
                Container.Bind<IInput>().To<DesktopInput>().AsSingle().NonLazy();
                break;
            case RuntimePlatform.Android:
                Container.Bind<IInput>().To<MobileInput>().AsSingle().NonLazy();
                break;
            default:
                Debug.LogError("Unsupported platform. Cannot inject dependencies");
                break;
        }
    }
}
