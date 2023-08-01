using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
  // Start is called before the first frame update
  public Transform player;

  public Vector3 offset;

  // Update is called once per frame
  void Update()
  {
    Vector3 playerPosition = player.position;
    transform.position = player.position + offset;
  }
}
