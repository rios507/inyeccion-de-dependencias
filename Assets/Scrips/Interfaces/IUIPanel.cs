using UnityEngine;

public interface IUIPanel 
{
    public Animator Anim { get; }
    public void Show();
    public void Hide();
}
