using UnityEngine;

[CreateAssetMenu(fileName = "InputSystemActionsSO", menuName = "Scriptable Object/Input/InputSystemActions")]
public class InputSystemActionsSO : ScriptableObject
{
    private InputSystem_Actions inputActions;

    public InputSystem_Actions InputActions
    {
        get
        {
            if (inputActions == null)
            {
                inputActions = new InputSystem_Actions();
            }
            return inputActions;
        }
    }
}
