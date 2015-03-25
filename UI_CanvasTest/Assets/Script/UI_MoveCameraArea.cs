using UnityEngine;
using System.Collections;

public class UI_MoveCameraArea : MonoBehaviour {

	public GameObject m_targetObject;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = m_targetObject.transform.position;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

		transform.LookAt (new Vector3 (0, 0, 0));
	}
}
