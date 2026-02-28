using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerInput1Actions
{
  PlayerInput playerInput;

  void Start()
  {
    if (playerInput == null)
    {
      playerInput = new PlayerInput();
      playerInput.PlayerInput1.SetCallbacks(this);
      playerInput.PlayerInput1.Enable();
    }
  }

  public event Action<InputAction.CallbackContext> UpEvent;
  public event Action<InputAction.CallbackContext> DownEvent;
  public event Action<InputAction.CallbackContext> LeftEvent;
  public event Action<InputAction.CallbackContext> RightEvent;
  public event Action<InputAction.CallbackContext> PunchEvent;
  public event Action<InputAction.CallbackContext> KickEvent;
  public event Action<InputAction.CallbackContext> GrabEvent;

  public void OnUp(InputAction.CallbackContext context)
  {
    UpEvent?.Invoke(context);
  }

  public void OnDown(InputAction.CallbackContext context)
  {
    DownEvent?.Invoke(context);
  }

  public void OnLeft(InputAction.CallbackContext context)
  {
    LeftEvent?.Invoke(context);
  }

  public void OnRight(InputAction.CallbackContext context)
  {
    RightEvent?.Invoke(context);
  }

  public void OnPunch(InputAction.CallbackContext context)
  {
    PunchEvent?.Invoke(context);
  }

  public void OnKick(InputAction.CallbackContext context)
  {
    KickEvent?.Invoke(context);
  }

  public void OnGrab(InputAction.CallbackContext context)
  {
    GrabEvent?.Invoke(context);
  }

}
