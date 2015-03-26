using UnityEngine;
using System.Collections;

public class CameraPreview : MonoBehaviour {

	public int m_nCameraWidth	= 320;
	public int m_nCameraHeight 	= 240;

	// Use this for initialization
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		for (int i=0; i<devices.Length; i++) {
			Debug.Log (devices[i].name);
		}

		GetComponent<GUITexture> ().pixelInset = new Rect (0, 0, Screen.width, Screen.height);

		WebCamTexture texture = new WebCamTexture (devices [0].name, m_nCameraWidth, m_nCameraHeight, 30);
		texture.Play ();

		GetComponent<GUITexture> ().texture = texture;
//		GetComponent<Renderer> ().material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
