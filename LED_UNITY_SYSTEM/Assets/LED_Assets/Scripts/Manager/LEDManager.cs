﻿using UnityEngine;
using System.Collections.Generic;
using LitJson;
using System.IO.Ports;

[System.SerializableAttribute]
public struct MatrixSettings { public int col, row; }

public class LEDString { public RGB[] leds; }
public class RGB {
	const int coefficient = 255;
	public int r, g, b;
	public void SetRgbByColor (Color color) {
		r = (int)(color.r * coefficient);
		g = (int)(color.g * coefficient);
		b = (int)(color.b * coefficient);
	}
}

public class LEDManager 
: SingletonMonoBehaviour<LEDManager> {

	public LEDString[] ledStrings;
	public Const.LEDPattern ledPattern;
	public MatrixSettings settings;
	public GameObject ledPrefab;
	public SerialPort stream = new SerialPort("/dev/cu.usbmodem1411",115200);

	private void Start () {

		stream.Open();

		List<LEDString> strs = new List<LEDString>();
		for (int i=0; i<settings.col; i++) {
			strs.Add( new LEDString() );
			
			List<RGB> leds = new List<RGB>();
			for (int j=0; j<settings.row; j++) {
				leds.Add( new RGB() );
			}
			strs[i].leds = leds.ToArray();
		}
		ledStrings = strs.ToArray();

		for (int i=0; i<ledStrings.Length; i++) {
			for (int j=0; j<ledStrings[i].leds.Length; j++) {

				Vector3 spawnPos = new Vector3 (i,0,j);

				GameObject obj = (GameObject)Instantiate(
					ledPrefab, spawnPos, Quaternion.identity);
				obj.transform.SetParent(this.transform);

				obj.GetComponent<LEDController>().rgb 
					= ledStrings[i].leds[j];
			}
		}

	}


	private void Update () {
		if (Input.GetKeyDown("space")) {
			string[] json = GetLEDStingJson();
			stream.Write(json[0]);
			print(json[0]);
		}
	}


	public string[] GetLEDStingJson () {
		string[] jsons = new string[ledStrings.Length]; 
		for (int i=0; i<ledStrings.Length; i++) {
			jsons[i] = JsonMapper.ToJson( ledStrings[i] );
		} 
		return jsons;
	}
}



