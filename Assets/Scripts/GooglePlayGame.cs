using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayGame : MonoBehaviour {


	public static void Init(){
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}

	public static void Login(Action<bool> onLogin)
 	{

 		if(Social.Active == null)
 		{
 			return;
 		}

 		if (IsAuthenticated())
 		{
 			return;
 		}
		PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
			onLogin(true);
		});
 	}
	public static bool IsAuthenticated()

	{

		return Social.localUser.authenticated;

	}

	// <summary>

	/// Reporta o score

	/// </summary>

	/// <param name=”scoreID”></param>

	/// <param name=”score”></param>

	/// <param name=”onReportScore”></param>

	public static void ReportScore(string scoreID, int score,

		Action<bool> onReportScore )

	{

		// post score

		Social.ReportScore(score, scoreID, (bool success) => {

			if (onReportScore != null)

			{

				onReportScore(success);

			}

		});

	}
	public static void ShowLeadboards()

	{

		PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI5tiH5Z8cEAIQAQ");

	}

}

