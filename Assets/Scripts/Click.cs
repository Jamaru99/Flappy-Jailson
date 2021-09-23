using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using TMPro;

public class Click : MonoBehaviour
{

  BannerView banner;
  Scene s;

  void OnMouseDown()
  {
    if (gameObject.name == "txtPlus")
    {
      Player.flapForce += 1;
      PlayerPrefs.SetInt("FlapForce", Player.flapForce);
      GameObject.Find("txtFlapForce").GetComponent<TextMeshPro>().text = "" + Player.flapForce;
    }
    else if (gameObject.name == "txtMinus")
    {
      Player.flapForce -= 1;
      PlayerPrefs.SetInt("FlapForce", Player.flapForce);
      GameObject.Find("txtFlapForce").GetComponent<TextMeshPro>().text = "" + Player.flapForce;
    }
    else transform.localScale *= 0.9f;
  }

  void Start()
  {
    s = SceneManager.GetActiveScene();
    if (s.name == "Instrucoes" || s.name == "Sobre")
    {
      banner = new BannerView("ca-app-pub-1541045839364233/8738834646", AdSize.Banner, AdPosition.Bottom);
      banner.LoadAd(new AdRequest.Builder().Build());
      banner.Show();
    }
    if (PlayerPrefs.HasKey("FlapForce"))
      Player.flapForce = (sbyte)PlayerPrefs.GetInt("FlapForce");
    if(s.name == "Menu" && gameObject.name == "Jogar") {
      GameObject.Find("txtFlapForce").GetComponent<TextMeshPro>().text = "" + Player.flapForce;
      GameObject.Find("txtRecorde").GetComponent<TextMeshPro>().text += PlayerPrefs.GetInt("record");
      GameObject.Find("JailsonIntro").transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)) + new Vector3(1.65f, 2.9f, 10);
    }
    if (gameObject.name == "Ranking")
    {
      GooglePlayGame.Init();
      GooglePlayGame.Login((bool success) =>
      {
      });
    }
  }

  void OnMouseUp()
  {
    if (gameObject.name == "Jogar" || gameObject.name == "txtRecomecar")
    {
      Player.secondChance = true;
      SceneManager.LoadScene("Game");
    }
    if (gameObject.name == "txtMenu")
    {
      if (s.name != "Game") banner.Hide();
      SceneManager.LoadScene("Menu");
    }
    if (gameObject.name == "Instrucoes")
      SceneManager.LoadScene("Instrucoes");
    if (gameObject.name == "Sobre")
      SceneManager.LoadScene("Sobre");
    if (gameObject.name == "Ranking")
    {
      GooglePlayGame.ShowLeadboards();
      transform.localScale /= 0.9f;
    }
  }

}
