using UnityEngine;
using System.Collections;

public class FullImage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RectTransform trans = GetComponent<RectTransform> ();
		trans.sizeDelta = new Vector2 (Screen.width, Screen.height);
		Debug.Log (trans.rect.width + " : " + trans.rect.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
