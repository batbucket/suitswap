using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour {
    private static readonly Suit[] SUITS = new Suit[] { Suit.CLUB, Suit.DIAMOND, Suit.HEART, Suit.SPADE };

    [SerializeField]
    private Transform guideParent;

    [SerializeField]
    private Transform inputParent;

    [SerializeField]
    private GameObject guidePrefab;

    [SerializeField]
    private GameObject inputPrefab;

    private Display[] guides;

    private Display[] inputs;

    public int Count {
        get {
            return inputs.Length;
        }
    }

    public bool IsCorrect {
        get {
            for (int i = 0; i < guides.Length; i++) {
                if (!guides[i].Suit.Equals(inputs[i].Suit)) {
                    return false;
                }
            }
            return true;
        }
    }

    public void Init() {
        foreach (Display guide in guides) {
            guide.Set(SUITS.PickRandom());
        }
    }

    private void Awake() {
        for (int i = 0; i < Statics.difficulty; i++) {
            Instantiate(guidePrefab, guideParent);
            Instantiate(inputPrefab, inputParent);
        }
    }

    private void Start() {
        guides = guideParent.GetComponentsInChildren<Display>();
        inputs = inputParent.GetComponentsInChildren<Display>();
    }
}
