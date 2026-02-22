using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float gravityForce = 140f;
  Vector3 velocity;

  LayerMask groundMask;

  public bool isGrounded;

  void Start()
  {
    groundMask = LayerMask.GetMask("ground");
    rb = GetComponent<Rigidbody>();
    velocity.y -= gravityForce * Time.fixedDeltaTime;
  }

  void FixedUpdate()
  {
    IsGroundedCheck();
    if (!isGrounded)
    {
      //slerp later 
      rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
  }

  void IsGroundedCheck()
  {
    //make it get the player height and divide by 2
    if (Physics.Raycast(transform.position, Vector3.down, 0.90f, groundMask))
    {
      isGrounded = true;
    }
    else
    {
      isGrounded = false;
    }
  }
}
