using UnityEngine;

public class BaseUIPanel : MonoBehaviour, IUIPanel
{
    public Animator Anim { get; }
    Animator _anim;

    public void Show()
    {
        _anim.Play("Show");
    }
    public void Hide()
    {
        _anim.Play("Hide");
    }

}
