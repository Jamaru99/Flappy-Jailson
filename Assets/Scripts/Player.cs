using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using TMPro;

public class Player : MonoBehaviour
{

  public static ushort score;
  public static sbyte flapForce = 9;
  public static bool gameOver;
  public static bool secondChance = true;
  short h;
  short w;

  public GameObject gameOverObj1;
  public GameObject gameOverObj2;
  Rigidbody2D rb;
  AudioSource flap;
  TextMeshPro txtScore;
  public AudioSource aiquedelicia;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    flap = GetComponent<AudioSource>();
    txtScore = GameObject.Find("Score").GetComponent<TextMeshPro>();
		SetMobileControls();
    if (secondChance)
      score = 0;
    else
    {
      score = (ushort)PlayerPrefs.GetInt("LastScore");
      txtScore.text = "" + score;
    }

    gameOver = false;
    w = (short)Screen.width;
    h = (short)Screen.height;
    StartCoroutine(delayStart());
  }

  void Update()
  {
    if (gameOver)
    {
      if (secondChance)
      {
        gameOverObj1.SetActive(true);
        bool isPortuguese = GameObject.Find("Translator").GetComponent<Translator>().isPortuguese;
        GameObject.Find("btnVideo").GetComponentInChildren<TextMeshPro>().text = isPortuguese ? "assistir" : "watch";
      }
      else gameOverObj2.SetActive(true);
      Destroy(gameObject);
    }

/*
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.AddForce(new Vector2(0, flapForce * 50));
      flap.Play();
    }
    if (Input.GetKey(KeyCode.LeftArrow))
      transform.position = new Vector3(Mathf.Clamp(transform.position.x - 0.15f, -7.5f, 7.4f), transform.position.y, -1.1f);
    if (Input.GetKey(KeyCode.RightArrow))
      transform.position = new Vector3(Mathf.Clamp(transform.position.x + 0.15f, -7.5f, 7.4f), transform.position.y, -1.1f);*/

    for (int i = 0; i < Input.touchCount; i++)
    {
      if (Input.GetTouch(i).phase == TouchPhase.Began)
      {
        if (!(Input.GetTouch(i).position.y < h / 7 && Input.GetTouch(i).position.x < w / 4))
        {
          rb.AddForce(new Vector2(0, flapForce * 50));
          flap.Play();
        }
      }
      if (Input.GetTouch(i).phase == TouchPhase.Stationary)
      {
        if (Input.GetTouch(i).position.x < w / 4 && Input.GetTouch(i).position.x > w / 8 && Input.GetTouch(i).position.y < h / 7)
          transform.position = new Vector3(Mathf.Clamp(transform.position.x + 0.15f, -7.5f, 7.4f), transform.position.y, -1.1f);
        if (Input.GetTouch(i).position.x < w / 8 && Input.GetTouch(i).position.y < h / 7)
          transform.position = new Vector3(Mathf.Clamp(transform.position.x - 0.15f, -7.5f, 7.4f), transform.position.y, -1.1f);
      }
    }
  }

  private void SetMobileControls()
  {
    GameObject pointerR = GameObject.Find("PointerR"), pointerL = GameObject.Find("PointerL");
    Vector3 pointerPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 7, Screen.height / 7));
    pointerR.transform.position = new Vector3(pointerPos.x + 0.9f, pointerR.transform.position.y, -1.2f);
    pointerL.transform.position = new Vector3(pointerPos.x - 0.9f, pointerL.transform.position.y, -1.2f);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name == "Deadzone")
    {
      gameOver = true;
      PlayerPrefs.SetInt("LastScore", score);
      Record();
      GooglePlayGame.ReportScore("CgkI5tiH5Z8cEAIQAQ", score, (bool success) =>
      {
      });
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Rola")
      aiquedelicia.Play();
    if (other.tag == "Tridente")
    {
      gameOver = true;
      PlayerPrefs.SetInt("LastScore", score);
      GooglePlayGame.ReportScore("CgkI5tiH5Z8cEAIQAQ", score, (bool success) =>
      {
      });
      Record();
    }
    if (other.tag == "Juice")
    {
      score += 1;
      txtScore.text = "" + score;
    }
  }

  public static void Record()
  {
    if (PlayerPrefs.HasKey("record"))
    {
      if (score > PlayerPrefs.GetInt("record"))
      {
        PlayerPrefs.SetInt("record", score);
      }
    }
    else
    {
      PlayerPrefs.SetInt("record", score);
    }
  }

  IEnumerator delayStart()
  {
    yield return new WaitForSeconds(1);
    rb.gravityScale = 1.5f;
  }
}
