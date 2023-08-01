using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;



public class AnimalCollision : MonoBehaviour
{
  //可碰撞
  public bool canCollide = true;
  //已经碰撞/首次碰撞
  public bool hasCollided = false;
  //错误字母数
  public int wrongLettercount = 2;
  //提示文本
  public Text introText;
  //单词文本
  public TMP_Text wordText;

  private float timer = 0f;

  void Start()
  {
    //开始时 单词文本为空，碰撞后产生单词文本
    wordText.text = null;
  }
  void OnTriggerEnter(Collider collider)
  {
    //玩家碰撞动物
    if (collider.gameObject.tag == "Player")
    {
      Debug.Log("play crash"+this.gameObject.name);
      //碰撞时，显示单词播放音频
      string word = this.gameObject.name;

      AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
      if (audioSource != null)
      {
        audioSource.Play();
        Debug.Log("music");
      }
      //首次碰撞创建预制体
      if (hasCollided == false)
      {
        wordText.text = word;
        introText.text = "Are you notice the words?\nThere are some letters around try to find them!\nBy the way, some letters are incorrect.";
        hasCollided = true;
        string path = "Prefabs/Letters/";
        char[] myChars = word.ToCharArray();
        foreach (char character in myChars)
        {
          // 根据字母名称查找对应的预制体
          GameObject letterCreate = Resources.Load<GameObject>(path + character.ToString().ToUpper());
          // 如果找到了预制体，创建它并绑定脚本
          if (letterCreate != null)
          {
            float x = Random.Range(-18f, 18f);
            float z = Random.Range(-18f, 18f);
            Vector3 newPosition = new Vector3(x, 1f, z);
            Quaternion newRotation = Quaternion.Euler(90f, 180f, 0f);
            GameObject newLetter = Instantiate(letterCreate, newPosition, newRotation);
            LetterScript letterScript = newLetter.AddComponent<LetterScript>();
            letterScript.isCorrectLetter = true;

          }
        }

        List<char> charList = GetWrongLetters(word, wrongLettercount); // 将HashSet<char>转换为List<char>

        foreach (char c in charList)
        {
          GameObject letterCreate = Resources.Load<GameObject>(path + c.ToString().ToUpper());
          float x = Random.Range(-18f, 18f);
          float z = Random.Range(-18f, 18f);
          Vector3 newPosition = new Vector3(x, 1f, z);
          Quaternion newRotation = Quaternion.Euler(90f, 180f, 0f);
          GameObject newLetter = Instantiate(letterCreate, newPosition, newRotation);
          LetterScript letterScript = newLetter.AddComponent<LetterScript>();
          letterScript.isCorrectLetter = false;
        }
      }
    }
  }

  //todo:当玩家集齐所有正确字母，该动物消失，干扰字母也消失
  void Update()
  {
    int count = CheckCorrectLetters();
    if (hasCollided && count == 0)
    {
      introText.text="Congratulations on completing your first animal!";
      GameObject cameraObject = GameObject.Find("Main Camera");
      Transform animalTransform = this.transform;
      Vector3 cameraPosition = Camera.main.transform.position;
      Vector3 animalPosition = cameraPosition + new Vector3(0f, -1f, 10f);
      transform.SetParent(cameraObject.transform);
      this.transform.position = animalPosition;
      timer += Time.deltaTime;
      //两秒后使物体消失

      if (timer >= 2f)
      {
        // 将物体设置为不可见或者删除该物体
        DestroyObject();
      }


    }

    void DestroyObject()
    {
      GameObject[] letterObjects = GameObject.FindGameObjectsWithTag("Letters");
      foreach (GameObject obj in letterObjects)
      {
        Destroy(obj);
      }
      Destroy(this.gameObject);
    }
  }

  //创建错误字母干扰项，根据设置个数返回干扰项列表
  List<char> GetWrongLetters(string word, int count)
  {
    string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // 包含所有大写字母的字符串

    // 将字符串转换为Set集合
    HashSet<char> allLettersSet = new HashSet<char>(allLetters.ToCharArray());
    HashSet<char> wordSet = new HashSet<char>(word.ToUpper().ToCharArray());
    // 求两个集合的差集
    HashSet<char> difference = new HashSet<char>(allLettersSet);
    difference.ExceptWith(wordSet);
    List<char> pickLetters = difference.OrderBy(c => UnityEngine.Random.value).Take(count).ToList();
    return pickLetters;
  }

  int CheckCorrectLetters()
  {
    // 获取场上所有正确字母物体
    // 获取所有带有"letter"标签的物体
    GameObject[] letterObjects = GameObject.FindGameObjectsWithTag("Letters");
    int count = 0;
    // 遍历所有物体并查找isCorrectLetter变量的值
    foreach (GameObject letterObject in letterObjects)
    {
      // 获取Letter脚本
      LetterScript letter = letterObject.GetComponent<LetterScript>();
      if (letter != null)
      {
        // 获取isCorrectLetter变量的值
        bool isCorrect = letter.isCorrectLetter;
        // 根据isCorrect的值进行相应的处理
        if (isCorrect)
        {
          // Debug.Log("还有正确字母");
          count++;
        }
      }
    }
    return count;
  }

}
