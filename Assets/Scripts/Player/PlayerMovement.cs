using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  PlayerController playerController;
  Rigidbody rb;

  [SerializeField] float walkSpeed = 100;
  [SerializeField] float gravityForce = 140f;
  Vector3 velocity;

  LayerMask groundMask;

  bool isGrounded;
  bool isUp;
  bool isDown;
  bool isLeft;
  bool isRight;
  bool isPunch;
  bool isKick;
  bool isGrab;

  bool isLeftPressed = false;

  void Start()
  {
    groundMask = LayerMask.GetMask("ground");
    velocity = new Vector3(0, 0, 0);
    velocity.y -= gravityForce * Time.fixedDeltaTime;
    rb = GetComponent<Rigidbody>();
    playerController = GetComponent<PlayerController>();

    playerController.UpEvent += HandleUp;
    playerController.DownEvent += HandleDown;
    playerController.LeftEvent += HandleLeft;
    playerController.RightEvent += HandleRight;
    playerController.PunchEvent += HandlePunch;
    playerController.KickEvent += HandleKick;
  }

  void FixedUpdate()
  {
    HandleGravity();
    Movement();

  }

  void HandleUp(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isUp = true;
    }
    else if (context.canceled)
    {
      isUp = false;
    }

  }

  void HandleDown(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isDown = true;
    }
    else if (context.canceled)
    {
      isDown = false;
    }

  }
  void HandleLeft(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isLeft = true;
    }
    else if (context.canceled)
    {
      isLeft = false;
    }
  }
  void HandleRight(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isRight = true;
    }
    else if (context.canceled)
    {
      isRight = false;
    }
  }
  void HandlePunch(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isPunch = true;
    }
    else if (context.canceled)
    {
      isPunch = false;
    }
  }
  void HandleKick(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isKick = true;
    }
    else if (context.canceled)
    {
      isKick = false;
    }
  }
  void HandleGrab(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      isGrab = true;
    }
    else if (context.canceled)
    {
      isGrab = false;
    }
  }

  void Movement()
  {
    if (isLeft)
    {
      Vector3 moveDirection = new Vector3(0, 0, 0);
      if (true)
      {
        moveDirection.x = -walkSpeed;
      }
      else
      {
        //run speed
        //moveDirection.x = walkSpeed;
      }
      Debug.Log(moveDirection);

      rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }
    else if (isRight)
    {
      Vector3 moveDirection = new Vector3(0, 0, 0);
      if (true)
      {
        moveDirection.x = walkSpeed;
      }
      else
      {
        //run speed
        //moveDirection.x = walkSpeed;
      }
      Debug.Log(moveDirection);

      rb.MovePosition(rb.position + moveDirection * Time.deltaTime);

    }
  }

  bool IsGroundedCheck()
  {
    //make it get the player height and divide by 2
    if (Physics.Raycast(transform.position, Vector3.down, 0.90f, groundMask))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  void HandleGravity()
  {
    if (!IsGroundedCheck())
    {
      rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

  }
}

