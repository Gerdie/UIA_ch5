using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;
	private int _id;
	private int _imgId;

	public int id {
		get {return _id;}
	}

	public int imgId {
		get {return _imgId;}
	}

	public bool IsFaceUp {
		get {return !cardBack.activeSelf; }
	}

	public void SetCard(int id, int imgId, Sprite image) {
		// initialized in SceneController.cs
		_id = id;
		_imgId = imgId;
		GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void OnMouseDown() {
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
			Debug.Log ("Show card idx " + _id);
		}
	}

	public void TurnFaceDown() {
		cardBack.SetActive (true);
		Debug.Log ("Hide card idx " + _id);
	}

	public void Remove() {
		//TODO: remove card from board
		Debug.Log ("Remove card idx " + _id);
	}
}
