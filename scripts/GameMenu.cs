using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
  public void StartLevel0()
  {
    Debug.Log("start Level0");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void StartLevel1()
  {
    Debug.Log("start Level1");
    SceneManager.LoadScene(3);
  }
  public void StartLevel2()
  {
    Debug.Log("start Level2");
    SceneManager.LoadScene(5);
  }
}
