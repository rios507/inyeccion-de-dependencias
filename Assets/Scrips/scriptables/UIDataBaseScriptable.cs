using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIDataBase", menuName = "New UI DataBase")]
public class UIDataBaseScriptable : ScriptableObject
{
    [SerializeField] List<UIPanelData> panels = new();

    public UIPanelData GetpanelDataByEnum(UIPanelEnum panelEnum)
    {
        return panels.Find(x => x.PanelEnum == panelEnum);
    }

}
