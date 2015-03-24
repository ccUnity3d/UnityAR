using UnityEngine;
using System.Collections;

public class TestButtonEvent : MonoBehaviour {

	public void ClickTest()
	{
		Debug.Log ("Clicked");
	}

	public void ClickTest2(string text)
	{
		Debug.Log (text);
	}
}
