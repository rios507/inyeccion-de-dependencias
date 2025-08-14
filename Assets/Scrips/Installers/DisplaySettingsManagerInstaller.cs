using UnityEngine;
using Zenject;

public class DisplaySettingsManagerInstaller : MonoInstaller
{
    [SerializeField] GameObject displaySettingsPrefab;
    public override void InstallBindings()
    {
        Container.Bind<DisplaySettingsManager>().FromComponentInNewPrefab(displaySettingsPrefab).AsSingle();
    }
}