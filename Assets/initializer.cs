using UnityEngine;
using Zenject;

public class initializer : MonoBehaviour
{
    [Inject] UIManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager.ShowPanel(UIPanelEnum.MainMenu);
    }

}
