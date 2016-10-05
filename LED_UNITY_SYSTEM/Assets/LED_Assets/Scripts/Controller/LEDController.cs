using UnityEngine;
using System.Collections;

public class LEDController : MonoBehaviour {

	private Const.LEDPattern ledPattern {
		get { return LEDManager.instance.ledPattern; }
	}
	private readonly Color 
		darkColor = new Color (0.1f, 0.1f, 0.1f, 1.0f),
		darkRedColor = new Color (0.6f, 0.2f, 0.2f, 1.0f);
	private readonly float colorEasing = 2f;

	public RGB rgb;
	public Color color = Color.white;

	private Renderer renderer;
	private void Start () {
		renderer = GetComponent<Renderer>();
	}

	private void Update () {

		switch (ledPattern) {
			case Const.LEDPattern.RandomChange:
				color = new Color(
					Random.Range(0.0f, 1.0f),
					Random.Range(0.0f, 1.0f),
					Random.Range(0.0f, 1.0f));
				break;
			case Const.LEDPattern.LerpDark:
				color = Color.Lerp(
					color, darkColor, colorEasing * Time.deltaTime);
				break;
			case Const.LEDPattern.LerpDarkRed:
				color = Color.Lerp(
					color, darkRedColor, colorEasing * Time.deltaTime);
				break;
		}

		renderer.material.color = color;
		rgb.SetRgbByColor(renderer.material.color);
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Enter") {
			color = other.GetComponent<Renderer>().material.color;
		}
	}

	private void OnTriggerStay (Collider other) {
		if (other.tag == "Stay") {
			color = other.GetComponent<Renderer>().material.color;
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Exit") {
			color = other.GetComponent<Renderer>().material.color;
		}
	}

}
