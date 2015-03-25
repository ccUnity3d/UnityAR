using UnityEngine;
using System.Collections;

public class UI_SideCircle : MonoBehaviour {

	public GameObject m_objCircle1;
	public GameObject m_objCircle2;

	private UI_2D_Custem_Rotate m_circle1;
	private UI_2D_Custem_Rotate m_circle2;

	private float m_fMaxTime  = 5.0f;
	private float m_fTime = 0.0f;
	public float m_fSpeed = 30;
	private RectTransform m_trans;

	
	// Use this for initialization
	void Start () {
		m_trans = GetComponent<RectTransform> ();
		m_circle1 = m_objCircle1.GetComponent<UI_2D_Custem_Rotate>();
		m_circle2 = m_objCircle2.GetComponent<UI_2D_Custem_Rotate>();

		reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
		m_fSpeed = Random.Range (-10, 10) * 10;

		m_circle1.setSpeed (m_fSpeed);
		m_circle2.setSpeed (-m_fSpeed);
	}
}
