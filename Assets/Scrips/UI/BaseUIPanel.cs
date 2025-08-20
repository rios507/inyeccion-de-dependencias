using UnityEngine;

public class BaseUIPanel : MonoBehaviour, IUIPanel
{
    public Animator Anim { get => _anim; }
    Animator _anim;
    public virtual void Initialize()
    {
        TryGetComponent(out _anim);
    }
    public virtual void Show()
    {
        _anim?.Play("Show");
    }
    public virtual void Hide()
    {
        _anim?.Play("Hide");
    }

}
