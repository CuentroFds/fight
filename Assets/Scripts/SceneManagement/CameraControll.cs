using UnityEngine;

public class CameraControll : MonoBehaviour
{
  GameObject player1;
  GameObject player2;
  Vector3 camPosition;
  Vector2 camSpace;
  [SerializeField] Camera camera;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    player1 = GameObject.Find("Player1");
    player2 = GameObject.Find("Player2");
  }
  void FixedUpdate()
  {
    float difference = player2.transform.position.x - player1.transform.position.x;
    camPosition = new Vector3(difference / 2 + player1.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    camera.transform.position = camPosition;
  }
}
