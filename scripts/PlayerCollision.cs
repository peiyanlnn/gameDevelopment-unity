using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerCollision : MonoBehaviour
{

  public TMP_Text wordText;

  //玩家碰撞其中一个动物后，其他动物设置为不可碰撞状态
  void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == "animal")
    {
      var animalObjects = GameObject.FindGameObjectsWithTag("animal");
      foreach (var obj in animalObjects)
      {
        if (obj != collider.gameObject)
        {
          obj.GetComponent<BoxCollider>().isTrigger = false;
          obj.GetComponent<AnimalCollision>().canCollide = false;
        }
      }
    }
  }




}
