using System;
using UnityEngine;

[Serializable]
public class UIPanelData
{
    public UIPanelEnum PanelEnum { get => _panelEnum; set => _panelEnum = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }

    [SerializeField] UIPanelEnum _panelEnum;

    [SerializeField] GameObject _prefab;

}
