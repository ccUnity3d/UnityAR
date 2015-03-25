using UnityEngine;
using System.Collections;

public class UI_Rotate : MonoBehaviour {
	
	private float m_fMaxTime  = 5.0f;
	private float m_fTime = 0.0f;
	public float m_fSpeed = 30;

	// Use this for initialization
	void Start () {
		reset ();
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion quater = transform.localRotation;
		Vector3 rot = quater.eulerAngles;
		quater = Quaternion.Euler(rot.x, rot.y + m_fSpeed * Time.deltaTime, rot.z);
		transform.localRotation = quater;

		m_fTime += Time.deltaTime;

		if (m_fTime > m_fMaxTime)
		{
			reset();
		}
	}

	void reset()
	{
		m_fTime = 0.0f;
		m_fMaxTime = Random.Range (3, 10);
		m_fSpeed = Random.Range (-10, 10) * 5;
	}
}
