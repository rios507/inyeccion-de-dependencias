using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuUIHandler : BaseUIPanel
{
    [Inject] UIManager uiManager;
    [SerializeField] Button exitButtom, playButtom, optionButtom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Initialize()
    {
        base.Initialize();
        playButtom.onClick.AddListener(delegate
        {
            Debug.Log("Oli");
        });
        optionButtom.onClick.AddListener(delegate
        {
            uiManager.ShowPanel(UIPanelEnum.options);
        });
        exitButtom.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
