using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class Respawn : MonoBehaviour {

	void Update () {
		if (!Player.gameOver) {
			if(gameObject.tag == "Tridente")
				transform.position = new Vector3 (transform.position.x - 0.17f, transform.position.y, -1.1f);
			else
				transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, -1.1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player" || (other.name == "Destroyer" && gameObject.tag != "Rola")) {
			Destroy (gameObject);
		}
			
		if (other.name == "Deadzone") {
			Player.gameOver = true;
			PlayerPrefs.SetInt ("LastScore", Player.score);
			GooglePlayGame.ReportScore ("CgkI5tiH5Z8cEAIQAQ", Player.score, (bool success) => {
			});
			Player.Record ();
		}
	}
}
