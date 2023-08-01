using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class QuizManager1 : MonoBehaviour
{
  // Start is called before the first frame update
  public TMP_InputField answerInput0;
  public TMP_InputField answerInput1;
  public TMP_InputField answerInput2;
  public string correctAnswer0;
  public string correctAnswer1;
  public string correctAnswer2;
  public Text grade;
  public GameObject restart;
  public GameObject next;
  void Start()
  {
    restart.SetActive(false);
    next.SetActive(false);
    grade.text = null;
  }

  public void CheckAnswer()
  {
    string userAnswer0 = answerInput0.text;
    string userAnswer1 = answerInput1.text;
    string userAnswer2 = answerInput2.text;

    if (userAnswer0 == correctAnswer0 && userAnswer1 == correctAnswer1 && userAnswer2 == correctAnswer2)
    {
      grade.text = "Good job! Correct answer!";
      next.SetActive(true);
    }
    else
    {
      grade.text = "The answer is incorrect. You can resubmit or play the game again.";
      answerInput0.text = null;
      answerInput1.text = null;
      answerInput2.text = null;
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
