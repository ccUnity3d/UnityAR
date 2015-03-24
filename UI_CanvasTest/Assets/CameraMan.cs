using UnityEngine;
using System.Collections;

public class CameraMan : MonoBehaviour {

	private Gyroscope gyro;

	// Use this for initialization
	void Start () {
		gyro = Input.gyro;
		gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("gyroupdate", 0.1f);
	}

	void gyroupdate()
	{
		Quaternion transQuat = Quaternion.identity;

		transQuat.w = gyro.attitude.w;

		transQuat.x = -gyro.attitude.x;
		transQuat.y = -gyro.attitude.y;
		transQuat.z = gyro.attitude.z;

		transform.rotation = Quaternion.Euler (90, 0, 0) * transQuat;
	}
}
