using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour {

	public GameObject skyPref;
	public GameObject sucoPref;
	public GameObject penisPref;
	public GameObject tridentePref;

	void Update () {
		if(!Player.gameOver) transform.position = new Vector2 (transform.position.x - 0.1f, transform.position.y);
		if (transform.position.x < -18.3f) {
			
			Instantiate (skyPref, new Vector2 (18, 0), Quaternion.identity);

			Instantiate (sucoPref, new Vector3 (Random.Range (9.1f, 14.7f), Random.Range (0.3f, 4.7f), -0.6f), Quaternion.identity);
			Instantiate (sucoPref, new Vector3 (Random.Range (14.9f, 29.5f), Random.Range (0.3f, 4.7f), -0.6f), Quaternion.identity);
			Instantiate (sucoPref, new Vector3 (Random.Range (9.1f, 14.7f), Random.Range (-4.3f, 0.1f), -0.6f), Quaternion.identity);
			Instantiate (sucoPref, new Vector3 (Random.Range (14.9f, 29.5f), Random.Range (-4.3f, 0.1f), -0.6f), Quaternion.identity);
			Instantiate (penisPref, new Vector3 (Random.Range (9.1f, 17), 5, -0.6f), Quaternion.identity);
			Instantiate (tridentePref, new Vector3 (29, Random.Range (-4.3f, 4.7f), -0.6f), Quaternion.identity);
			if(Player.score >= 50) Instantiate (tridentePref, new Vector3 (29, Random.Range (-4.3f, 4.7f), -0.6f), Quaternion.identity);

			Destroy (gameObject);
		}
	}
}
