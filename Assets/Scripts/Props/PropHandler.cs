using UnityEngine;
using UnityEngine.VFX;

public class PropHandler : MonoBehaviour
{
    [SerializeField] private Animator cuttableAnimator;
    
    public void PlayCutAnimation(string animName)
    {
        cuttableAnimator.Play(animName, -1, 0f);
    }
}
