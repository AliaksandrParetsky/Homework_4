using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputContrpller : MonoBehaviour, GameInput.IGameplayActions
{
    private GameInput gameInput;
    private GameInput.GameplayActions gamePlayActions;

    public static event Action<Vector2> MoveEvent;
    public static event Action ShotEvent;
    public static event Action<float> MouseRotX;
    public static event Action<float> MouseRotY;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gamePlayActions = gameInput.Gameplay;

            gameInput.Enable();

            gameInput.Gameplay.SetCallbacks(this);

        }
    }

    private void OnDisable()
    {
        if(gameInput != null)
        {
            gameInput.Disable();

            gameInput.Gameplay.RemoveCallbacks(this);
        } 
    }

    public void OnMouseX(InputAction.CallbackContext context)
    {
        MouseRotX?.Invoke(context.ReadValue<float>());
    }

    public void OnMouseY(InputAction.CallbackContext context)
    {
        MouseRotY?.Invoke(context.ReadValue<float>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            ShotEvent?.Invoke();
        }
    }
}
