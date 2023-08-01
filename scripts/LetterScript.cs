using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LetterScript : MonoBehaviour
{

  public bool isCorrectLetter = false; // 是否为正确的字母
  AudioClip audioClip;
  public Text errorCount;
  void Start()
  {
    errorCount = GameObject.Find("Count").GetComponent<Text>();
    // 通过名字查找并获取 Text 组件

    if (isCorrectLetter)
    {
      audioClip = Resources.Load<AudioClip>("Audio/yes");
    }
    else
    {
      audioClip = Resources.Load<AudioClip>("Audio/no");
    }

    // 给字母物体挂载AudioSource组件，设置音频文件并播放
    AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
    audioSource.clip = audioClip;
    audioSource.playOnAwake = false;
  }
  // 碰撞事件
  private void OnTriggerEnter(Collider collider)
  {
    GameObject wordtextObj = GameObject.Find("WordText");
    TMP_Text wordtext = wordtextObj.GetComponent<TMP_Text>();
    if (collider.gameObject.CompareTag("Player"))
    {
      AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
      if (audioSource != null)
      {
        audioSource.Play();
      }
      if (isCorrectLetter)
      {
        string targetWord = wordtext.text;
        string targetLetter = this.gameObject.name.Substring(0, 1).ToLower();
        // wordtext.text = targetWord.Replace(targetLetter, " ");
        char[] wordArray = targetWord.ToCharArray();

        // 遍历数组，如果有对应字母则替换为一个空格
        for (int i = 0; i < wordArray.Length; i++)
        {
          if (wordArray[i] == targetLetter[0])
          {
            wordArray[i] = ' ';
            break;
          }
        }
        wordtext.text = new string(wordArray);
      }
      if (!isCorrectLetter)
      {
        int count = int.Parse(errorCount.text);
        count += 1;
        errorCount.text = count.ToString();
      }
    }

  }
  private void OnTriggerExit(Collider collider)
  {
    if (collider.gameObject.CompareTag("Player"))
    {
      if (isCorrectLetter)
      {
        Destroy(this.gameObject);
      }

    }
  }


}
