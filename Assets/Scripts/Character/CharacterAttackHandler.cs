using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttackHandler : MonoBehaviour
{
    [SerializeField] private Animator character;
    [SerializeField] private Transform rayStartTransform;
    [SerializeField] private float sphereCastRadius;
    [SerializeField] private AudioSource sliceAudio;
    [SerializeField] private PlayerInput playerInput;
    
    private static readonly int AttackLeft = Animator.StringToHash("AttackLeft");
    private static readonly int AttackRight = Animator.StringToHash("AttackRight");

    private void Awake()
    {
        playerInput.actions["AttackLeft"].performed += AttackSliceLeft;
        playerInput.actions["AttackRight"].performed += AttackSliceRight;
    }

    private void AttackSliceRight(InputAction.CallbackContext obj)
    {
        character.SetTrigger(AttackRight);
    }

    private void AttackSliceLeft(InputAction.CallbackContext obj)
    {
        character.SetTrigger(AttackLeft);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rayStartTransform.position, sphereCastRadius);
    }

    private void HitEvent(int swingDirection)
    {
        Collider[] overlapSphereCollider = Physics.OverlapSphere(rayStartTransform.position, sphereCastRadius);
        if (overlapSphereCollider.Length == 0 || !overlapSphereCollider[0].CompareTag("Cuttable")) return;

        sliceAudio.Play();
        overlapSphereCollider[0]?.transform.GetComponent<PropHandler>()
            .PlayCutAnimation(swingDirection == 0 ? "CutRight" : "CutLeft");
    }
}
