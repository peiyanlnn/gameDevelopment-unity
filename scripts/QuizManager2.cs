using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class QuizManager2 : MonoBehaviour
{
  // Start is called before the first frame update
  public InputField answerInput;
  public string correctAnswer;
  public Text grade;
  public GameObject finalUI;
  public GameObject restart;
  void Start()
  {
    restart.SetActive(false);
    finalUI.SetActive(false);
    grade.text = null;
  }

  public void CheckAnswer()
  {
    string userAnswer = answerInput.text;

    if (userAnswer == correctAnswer)
    {
      // grade.text = "Good job! Correct answer!";
      finalUI.SetActive(true);
    }
    else
    {
      grade.text = "The answer is incorrect. You can resubmit or play the game again.";
      answerInput.text = null;
      restart.SetActive(true);
    }
  }

  public void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

  }

  public void ToMenu()
  {
    SceneManager.LoadScene(0);
  }

}
