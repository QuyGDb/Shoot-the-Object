using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShooterController : MonoBehaviour
{
    [SerializeField] private InputSystemActionsSO inputSystemActionsSO;
    [SerializeField] private Transform pivot;
    public float temp;
    private bool isPress;

    private void OnEnable()
    {
        inputSystemActionsSO.InputActions.Player.PositonShooter.Enable();
        inputSystemActionsSO.InputActions.Player.Shooter.Enable();
        inputSystemActionsSO.InputActions.Player.Shooter.performed += StartDrawShooter;
        inputSystemActionsSO.InputActions.Player.Shooter.canceled += ReleaseDrawShooter;
    }
    private void OnDisable()
    {
        inputSystemActionsSO.InputActions.Player.PositonShooter.Disable();
        inputSystemActionsSO.InputActions.Player.Shooter.Disable();
        inputSystemActionsSO.InputActions.Player.Shooter.performed -= StartDrawShooter;
        inputSystemActionsSO.InputActions.Player.Shooter.canceled -= ReleaseDrawShooter;
    }
    private void Awake()
    {
    }
    private void StartDrawShooter(InputAction.CallbackContext context)
    {
        isPress = true;
    }

    public void ReleaseDrawShooter(InputAction.CallbackContext contextCallback)
    {
        isPress = false;

    }
    private void Update()
    {
        if (isPress)
        {
            Vector3 screenPosition = inputSystemActionsSO.InputActions.Player.PositonShooter.ReadValue<Vector2>();
            screenPosition.z = 6;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            worldPosition.z = temp;
            Debug.Log("pivot" + pivot.position);
            Vector3 direction = ((pivot).position - worldPosition);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(
               transform.rotation,
               targetRotation,
               100 * Time.deltaTime
           );
        }

    }


}
