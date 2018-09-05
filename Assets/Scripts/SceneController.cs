using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	[SerializeField] private Sprite[] images;
	private MemoryCard[] deck;
	public MemoryCard card;
	private int _secondCardIdx = -1;
	private int _firstCardIdx = -1;

	public int firstCardIdx {
		get { return _firstCardIdx; }
		set { _firstCardIdx = value; }
	}

	public int secondCardIdx {
		get { return _secondCardIdx; }
		set { _secondCardIdx = value; }
	}

	// Use this for initialization
	void Start () {

		// Set card values and positions
		float[] xPositions = {-3f, 0f, 3f};
		float[] yPositions = {-1.8f, 1.8f};
		deck = new MemoryCard[xPositions.Length * yPositions.Length];
		int cardIndex = 0;

		// Order random images but enforce pairs
		IDictionary<int, int> imgCounter = new Dictionary<int, int>();
		int num_card_occurances = xPositions.Length * yPositions.Length / images.Length;
		int[] imageOrder = {-1, -1, -1, -1, -1, -1};
		int currImageOrderIdx = 0;
		for (int imgIdx = 0; imgIdx < images.Length; imgIdx++) {
			imgCounter [imgIdx] = 0;
		}
		while (imageOrder [(xPositions.Length * yPositions.Length) - 1] == -1) {
			int imgId = Random.Range(0, images.Length);
			if (imgCounter [imgId] < num_card_occurances) {
				imgCounter [imgId] = imgCounter [imgId] + 1;
				imageOrder [currImageOrderIdx] = imgId;
				currImageOrderIdx++;
			}
		}

		for (int xIndex=0; xIndex < xPositions.Length; xIndex++) {
			for (int yIndex = 0; yIndex < yPositions.Length; yIndex++) {
				MemoryCard cardClone;
				cardClone = Instantiate(card) as MemoryCard;
				// assign card index and image
				int imgId = imageOrder[cardIndex];
				cardClone.SetCard(cardIndex, imgId, images[imgId]);
				// set position
				cardClone.transform.position = new Vector3 (xPositions [xIndex], yPositions [yIndex], -0.1f);
				// add to deck array
				deck [cardIndex] = cardClone;
				cardIndex++;
			}
		}
		Debug.Log (string.Format ("{0} {1} {2} {3} {4} {5}", deck [0].id, deck [1].id, deck [2].id, deck [3].id, deck [4].id, deck [5].id));
		Debug.Log (string.Format("{0} {1} {2} {3} {4} {5}", deck [0].imgId, deck [1].imgId, deck [2].imgId, deck [3].imgId, deck [4].imgId, deck [5].imgId));
	}

	public bool TwoCardsRevealed {
		get { return _secondCardIdx != -1; }
	}

	public void CardRevealed(int cardId) {
		if (firstCardIdx == -1) {
			firstCardIdx = cardId;
		} else if (secondCardIdx == -1) {
			secondCardIdx = cardId;
			StartCoroutine(CompareCards (firstCardIdx, secondCardIdx));
		} else {
			Debug.Log ("ERROR! NEITHER CARDIDX IS -1");
		}
	}

	private IEnumerator CompareCards(int CardIndex1, int CardIndex2) {
		if (deck [CardIndex1].imgId == deck [CardIndex2].imgId) {
			// TODO: remove cards and score ++
			Debug.Log("Correct!");
			yield return new WaitForSeconds (1.2f);
			deck [CardIndex1].Remove ();
			deck [CardIndex2].Remove ();
		} else {
			Debug.Log("WRONG!");
			yield return new WaitForSeconds (1.2f);
			deck [CardIndex1].TurnFaceDown ();
			deck [CardIndex2].TurnFaceDown ();
		}
		firstCardIdx = -1;
		secondCardIdx = -1;
	}
}
