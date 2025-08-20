using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject] DiContainer container;
    [SerializeField] UIDataBaseScriptable uiDatabase;

    Dictionary<UIPanelEnum, IUIPanel> panels = new();
    IUIPanel lastPanel;
    private void OnEnable()
    {
        EventBus.Subscribe<UIPanelEnum>(GameEvent.ChangePanel,ShowPanel);

    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<UIPanelEnum>(GameEvent.ChangePanel, ShowPanel);
    }
    public void ShowPanel(UIPanelEnum panelEnum)
    {
        StartCoroutine(ShowPanelCoroutine(panelEnum));
    }
    public IEnumerator ShowPanelCoroutine(UIPanelEnum panelEnum)
    {
        if (!panels.ContainsKey(panelEnum))
        {
            UIPanelData data = uiDatabase.GetpanelDataByEnum(panelEnum);
            GameObject PanelGO = container.InstantiatePrefab(data.Prefab);
            if (PanelGO.TryGetComponent(out BaseUIPanel panel))
            {
                panel.Initialize();
                panels.Add(panelEnum, panel);
            }
        }

        if (lastPanel != null)
        {
            lastPanel.Hide();
            AnimatorStateInfo info = lastPanel.Anim.GetCurrentAnimatorStateInfo(0);
            
            yield return new WaitForSeconds(info.length);
            lastPanel.Anim.gameObject.SetActive(false);
        }

        panels[panelEnum].Anim.gameObject.SetActive(true);
        panels[panelEnum].Show();
        lastPanel = panels[panelEnum];
    }
}
