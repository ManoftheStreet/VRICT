using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputActionReference move;

    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        move.action.started += AnimateLegs;
        move.action.canceled += StopAnimation;
    }


    private void AnimateLegs(InputAction.CallbackContext obj)
    {
        bool isMovingForward = move.action.ReadValue<Vector2>().y > 0;
        //Debug.Log("AnimateLegs On");
        if (isMovingForward)
        {
            //Debug.Log("isWalking True");
            animator.SetBool("isWalking", true);
            animator.SetFloat("animSpeed", 2f);
        }
        else
        {
            //Debug.Log("isWalking false");
            animator.SetBool("isWalking", true);
            animator.SetFloat("animSpeed", -2f);
        }
    }

    private void StopAnimation(InputAction.CallbackContext obj)
    {
        //Debug.Log("Stop");
        animator.SetBool("isWalking", false);
        animator.SetFloat("animSpeed", 0);
    }
    
    
}
