using UnityEngine;
using System.Collections;

public class ColorChangeController : MonoBehaviour {

	public Camera mainCamera;
	public GameObject spawnObj;
	public LayerMask layerMask;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
	        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, layerMask); 
	        if (Physics.Raycast(ray, out hit, layerMask)) {
	            GameObject obj = Instantiate (spawnObj);
	            Renderer r = obj.GetComponent<Renderer>();
				r.material.EnableKeyword("_Color");
				r.material.SetColor("_Color", new Color(
					Random.Range(0.0f, 1.0f),
					Random.Range(0.0f, 1.0f),
					Random.Range(0.0f, 1.0f))
				);
	            obj.transform.position = hit.point;
	            Destroy (obj, 2.0f);
	        }
		}
	}
}
