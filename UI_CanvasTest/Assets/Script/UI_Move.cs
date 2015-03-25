using UnityEngine;
using System.Collections;

public class UI_Move : MonoBehaviour {

	private enum TYPE
	{
		NONE = 0,
		FOCUS = 1,
		MOVE = 2,
		FLICKER = 3,
		MAX = 4
	};

	public Collider anObjectCollider;
	private Camera cam;
	private Plane[] Planes;
	private Vector3	prevPosition;

	private float m_fTime = 0.0f;
	private float m_fMaxTime = 10.0f;
	private float m_fMoveX = 1.0f;
	private float m_fMoveY = 1.0f;

	// Use this for initialization
	void Start () {
		Camera[] cameras = Camera.allCameras;

		for (int i=0; i<cameras.Length; i++)
		{
			if (cameras[i].name == "SubCamera")
			{
				cam = cameras[i];
				break;
			}
		}
		Debug.Log ("camera : " + cam.name);

		anObjectCollider = GetComponent<Collider> ();

		reset ();
	}

	void move()
	{
		Vector3 pos = transform.localPosition;
		
		Bounds bounds = anObjectCollider.bounds;
		bounds.center = transform.position;
		
		Planes = GeometryUtility.CalculateFrustumPlanes (cam);
		
		pos.x += m_fMoveX * Time.deltaTime;
		pos.y += m_fMoveY * Time.deltaTime;
		transform.localPosition = pos;
		
		//change direction
		float moveX = m_fMoveX;
		float moveY = m_fMoveY;
		prevPosition = pos;

		if (GeometryUtility.TestPlanesAABB (Planes, bounds))
		{
			for (int i=0; i<2; i++) {
				pos = prevPosition;
				if (i == 0) {
					moveX = -m_fMoveX;
					moveY = m_fMoveY;
				} else if (i == 1) {
					moveX = m_fMoveX;
					moveY = -m_fMoveY;
				}
				
				pos.x += moveX * Time.deltaTime;
				pos.y += moveY * Time.deltaTime;
				transform.localPosition = pos;

				bounds.center = transform.position;
				if (GeometryUtility.TestPlanesAABB (Planes, bounds))
				{
					break;
				}
			}
		}
		m_fMoveX = moveX;
		m_fMoveY = moveY;

	}

	// Update is called once per frame
	void Update () {

		move ();

		m_fTime += Time.deltaTime;
		if (m_fTime > m_fMaxTime)
		{
			reset();
		}
	}

	void reset()
	{
		int type = (int)Random.Range(0, 3);

		//akira
		type = 2; //TYPE.MOVE;

		switch (type)
		{
		case 0://TYPE.NONE:
			resetTime();
			break;
		case 1://TYPE.FOCUS:
			resetPosition();
			break;
		case 2://TYPE.MOVE:
			resetMove();
			break;
		case 3://TYPE.FLICKER:
			resetFlicker();
			break;
		}
	}

	void resetTime()
	{
		m_fTime = 0.0f;
		m_fMaxTime = Random.Range (10, 20);
	}

	void resetPosition()
	{
	}

	void resetMove()
	{
		reset ();

		m_fMoveX = Random.Range (5, 15);
		m_fMoveY = Random.Range (5, 15);
	}

	void resetFlicker()
	{
	}
}
