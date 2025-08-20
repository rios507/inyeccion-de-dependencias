using UnityEngine;
using Zenject;

public class UIManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject uiManagerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromComponentInNewPrefab(uiManagerPrefab).AsSingle();
    }
}