using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{

  public GameObject completeLevelUI;

  void Start()
  {
    completeLevelUI.SetActive(false);

  }

  void Update()
  {
    //如果面板上没有字母和动物则游戏结束
    if (GameObject.FindGameObjectsWithTag("Letters").Length == 0)
    {

      if (GameObject.FindGameObjectsWithTag("animal").Length == 0)
      {
        completeLevelUI.SetActive(true);
        Invoke("StartQuiz", 2.0f);
      }
      //如果面板上没有字母并且所有animal都不可碰撞，则所有动物设为可碰撞

      else
      {
        GameObject[] animalObjects = GameObject.FindGameObjectsWithTag("animal");
        bool allCollideDisabled = true;
        foreach (var obj in animalObjects)
        {
          AnimalCollision animalCollision = obj.GetComponent<AnimalCollision>();
          if (animalCollision != null && animalCollision.canCollide)
          {
            allCollideDisabled = false;
            break;
          }
        }
        // 如果所有动物都不可碰撞，则将它们都设置为可碰撞
        if (allCollideDisabled)
        {
          foreach (GameObject animal in animalObjects)
          {
            animal.GetComponent<BoxCollider>().isTrigger = true;
            animal.GetComponent<AnimalCollision>().canCollide = true;

          }
        }
      }

    }
  }

  public void StartQuiz()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }





}
