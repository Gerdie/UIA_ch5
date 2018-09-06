using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public float timeElapsed = 0;

	// Use this for initialization
	void Start () {
		GetComponent<UnityEngine.UI.Text> ().text = "0.0";
	}
	
	// When called from inside MonoBehaviour's FixedUpdate, 
	// Time.deltaTime returns the fixed framerate delta time.
	// https://docs.unity3d.com/530/Documentation/ScriptReference/Time-deltaTime.html
	void FixedUpdate () {
		timeElapsed += Time.deltaTime;
		System.String timeString = System.String.Format("{0:0.0}", timeElapsed);
		GetComponent<UnityEngine.UI.Text> ().text = timeString;
	}
}
