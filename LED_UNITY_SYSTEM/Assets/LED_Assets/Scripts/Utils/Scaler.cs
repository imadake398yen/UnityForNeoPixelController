using UnityEngine;
using System.Collections;

public class Scaler : MonoBehaviour {

	public float scaleSpeed = 10.0f;
	
	void Update () {
		transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
	}
}
