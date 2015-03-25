using UnityEngine;
using System.Collections;

public class UI_2D_Custem_Rotate : MonoBehaviour {

	public float m_fSpeed = 30;
	private RectTransform m_trans;
	
	// Use this for initialization
	void Start () {
		m_trans = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion quater = m_trans.localRotation;
		Vector3 rot = quater.eulerAngles;
		quater = Quaternion.Euler(rot.x, rot.y , rot.z + m_fSpeed * Time.deltaTime);
		m_trans.localRotation = quater;
	}
	
	public void setSpeed(float fSpeed)
	{
		m_fSpeed = fSpeed;
	}
}
