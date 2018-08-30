using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private Sprite[] images;
	private MemoryCard[] deck;
	public MemoryCard card;

	// Use this for initialization
	void Start () {
		float[] xPositions = {-3f, 0f, 3f};
		float[] yPositions = {-1.8f, 1.8f};
		deck = new MemoryCard[xPositions.Length * yPositions.Length];
		int cardIndex = 0;

		for (int xIndex=0; xIndex < xPositions.Length; xIndex++) {
			for (int yIndex = 0; yIndex < yPositions.Length; yIndex++) {
				MemoryCard cardClone;
				cardClone = Instantiate(card) as MemoryCard;
				// choose a random card image
				cardClone.SetCard(cardIndex, images[Random.Range(0, images.Length)]);
				// set position
				cardClone.transform.position = new Vector3 (xPositions [xIndex], yPositions [yIndex], 0);
				// add to deck array
				deck [cardIndex] = cardClone;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
