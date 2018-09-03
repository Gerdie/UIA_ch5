using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;
	[SerializeField] private SceneController controller;
	private int _id;
	private int _imgId;

	public int id {
		get {return _id;}
	}

	public int imgId {
		get {return _imgId;}
	}

	public void SetCard(int id, int imgId, Sprite image) {
		// initialized in SceneController.cs
		_id = id;
		_imgId = imgId;
		GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void OnMouseDown() {
		Debug.Log (string.Format("TwoCardsRevealed? {0}", controller.TwoCardsRevealed() ));
		Debug.Log (id);
		if (!controller.TwoCardsRevealed() && cardBack.activeSelf) {
			cardBack.SetActive (false);
			Debug.Log ("Show card idx " + _id);
			controller.CardRevealed (id);
			Debug.Log ("Show card idx " + _id);
		}
	}

	public void TurnFaceDown() {
		Debug.Log ("Hide card idx " + _id);
		cardBack.SetActive (true);
	}

	public void Remove() {
		Debug.Log ("Remove card idx " + _id);
		GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
	}
}
