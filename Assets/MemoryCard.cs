using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = image;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown() {
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
		}
	}

}
