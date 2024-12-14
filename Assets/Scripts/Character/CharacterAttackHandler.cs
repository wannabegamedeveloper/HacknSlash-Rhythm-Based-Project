using UnityEngine;

public class CharacterAttackHandler : MonoBehaviour
{
    [SerializeField] private Animator character;
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            character.SetTrigger(Attack);
        }
    }
}
