using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Translator : MonoBehaviour
{
  public bool isPortuguese;

  public TextMeshPro playButton;
  public TextMeshPro instructionsButton;
  public TextMeshPro aboutButton;
  public TextMeshPro flightForce;
  public TextMeshPro highscore;

  public TextMeshPro aboutText;
  public TextMeshPro instructionsText;

  public TextMeshPro gameOver1Title;
  public TextMeshPro gameOver1Legend;
  public TextMeshPro gameOver2Text;
  public TextMeshPro restart1;
  public TextMeshPro restart2;

  Scene scene;

  void Start()
  {
    isPortuguese = Application.systemLanguage == SystemLanguage.Portuguese;
    if (isPortuguese)
    {


    }
  }
}

