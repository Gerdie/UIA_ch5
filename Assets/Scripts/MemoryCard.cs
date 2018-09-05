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
		if (!controller.TwoCardsRevealed && cardBack.activeSelf) {
			cardBack.SetActive (false);
			controller.CardRevealed (id);
		}
	}

	public void TurnFaceDown() {
		cardBack.SetActive (true);
	}

	public void Remove() {
		GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
	}
}
