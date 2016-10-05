using UnityEngine;
using System.Collections;

public class LEDController : MonoBehaviour {

	public RGB rgb;
	public Color color = Color.white;

	private Renderer rend;
	private void Start () {
		rend = GetComponent<Renderer>();
	}

	private void Update () {

		rend.material.color = new Color(
			Random.Range(0.0f, 1.0f),
			Random.Range(0.0f, 1.0f),
			Random.Range(0.0f, 1.0f));

		color = rend.material.color;
		rgb.SetRgbByColor(color);
	}

}
