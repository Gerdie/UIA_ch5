using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private Sprite[] images;
	private MemoryCard[] deck;
	public MemoryCard card;
	private int[] chosenCardIndices;
	private bool _TwoCardsRevealed;

	public bool TwoCardsRevealed {
		get { return _TwoCardsRevealed; }
	}

	// Use this for initialization
	void Start () {
		_TwoCardsRevealed = false;
		// Set card values and positions
		float[] xPositions = {-3f, 0f, 3f};
		float[] yPositions = {-1.8f, 1.8f};
		deck = new MemoryCard[xPositions.Length * yPositions.Length];
		int cardIndex = 0;

		for (int xIndex=0; xIndex < xPositions.Length; xIndex++) {
			for (int yIndex = 0; yIndex < yPositions.Length; yIndex++) {
				MemoryCard cardClone;
				cardClone = Instantiate(card) as MemoryCard;
				// assign card index and [random] image
				int imgId = Random.Range(0, images.Length);
				cardClone.SetCard(cardIndex, imgId, images[imgId]);
				// set position
				cardClone.transform.position = new Vector3 (xPositions [xIndex], yPositions [yIndex], 0);
				// add to deck array
				deck [cardIndex] = cardClone;
				cardIndex++;
			}
		}
		Debug.Log (deck [0].imgId);
		Debug.Log (deck [1].imgId);
		Debug.Log (deck [2].imgId);
		Debug.Log (deck [3].imgId);
		Debug.Log (deck [4].imgId);
		Debug.Log (deck [5].imgId);

	}

	// Update is called once per frame
	void Update () {
		int[] chosenCardIndices = { -1, -1 };
		int currentIndex = 0;
		for (int i = 0; i < deck.Length; i++) {
			if (deck [i].IsFaceUp) {
				chosenCardIndices [currentIndex] = i;
				currentIndex++;

				if (currentIndex == 2) {
					_TwoCardsRevealed = true;
					CompareCards (chosenCardIndices [0], chosenCardIndices [1]);
					_TwoCardsRevealed = false;
					return;
				}
			}
		}
	}

	void CompareCards(int CardIndex1, int CardIndex2) {
		if (deck [CardIndex1].imgId == deck [CardIndex2].imgId) {
			// TODO: remove cards and score ++
			Debug.Log("correct!");
			System.Threading.Thread.Sleep(5000);
			deck [CardIndex1].TurnFaceDown ();
			deck [CardIndex2].TurnFaceDown ();
		} else {
			// TODO: sleep before turning face down
			Debug.Log("WRONG!");
			System.Threading.Thread.Sleep(5000);
			deck [CardIndex1].TurnFaceDown ();
			deck [CardIndex2].TurnFaceDown ();
		}
	}
}
