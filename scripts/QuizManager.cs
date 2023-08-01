using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
  // Start is called before the first frame update
  public TMP_InputField answerInput;
  public string correctAnswer;

  public GameObject restart;
  public GameObject next;
  public Text grade;

  void Start()
  {
    restart.SetActive(false);
    next.SetActive(false);
    grade.text = null;
  }

  public void CheckAnswer()
  {
    string userAnswer = answerInput.text;

    if (userAnswer == correctAnswer)
    {
      grade.text = "Good job! Correct answer! There are many other animals next, and you must complete them one by one.";
      next.SetActive(true);
    }
    else
    {
      grade.text = "The answer is incorrect. You can resubmit or play the game again.";
      restart.SetActive(true);
    }
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
  public void NextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void ToMenu()
  {
    SceneManager.LoadScene(0);
  }

}
