using UnityEngine;
using Zenject;

public class AudioManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject prefab;
    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromComponentsInNewPrefab(prefab).AsSingle();
     
    }
}