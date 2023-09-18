using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FinalTeleportSwapper : MonoBehaviour
{
    [SerializeField] private InputActionReference teleportToggleBtn;

    public UnityEvent OnTeleportActivate;
    public UnityEvent OnTeleportCancel;
    private float teleportDeactivateDelay = 0.1f;

    #region Input Action Listeners

    private void OnEnable()
    {
        teleportToggleBtn.action.performed += ActivateTeleport;
        teleportToggleBtn.action.canceled += DeactivateTeleport;
    }

    private void OnDisable()
    {
        teleportToggleBtn.action.performed -= ActivateTeleport;
        teleportToggleBtn.action.canceled -= DeactivateTeleport;
    }
    #endregion

    private void ActivateTeleport(InputAction.CallbackContext obj) => OnTeleportActivate.Invoke();

    private void DeactivateTeleport(InputAction.CallbackContext obj) => Invoke("TurnOffTeleport", teleportDeactivateDelay);

    private void TurnOffTeleport() => OnTeleportCancel.Invoke();
}