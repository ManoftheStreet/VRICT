using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FinalUIControllerSwapper : MonoBehaviour
{
    [SerializeField] private InputActionReference toggleUIBtn;

    public UnityEvent OnUiActivate;
    public UnityEvent OnUiDeActivate;
    public UnityEvent OnXRControllerButtonPress;

    private bool isVisible = false;

    #region Input Action Listeners

    private void OnEnable()
    {
        toggleUIBtn.action.performed += ToggleUISystem;
        DeactivateMenuSystem();
    }

    private void OnDisable()
    {
        toggleUIBtn.action.performed -= ToggleUISystem;
    }

    private void ToggleUISystem(InputAction.CallbackContext obj) => OnXRControllerButtonPress.Invoke();

    #endregion

    private void ActivateMenuSystem() => OnUiActivate.Invoke();

    private void DeactivateMenuSystem() => OnUiDeActivate.Invoke();

    public void ToggleUI()
    {
        isVisible = !isVisible;

        if (isVisible)
        {
            ActivateMenuSystem();
        }
        else
        {
            DeactivateMenuSystem();
        }
    }
}