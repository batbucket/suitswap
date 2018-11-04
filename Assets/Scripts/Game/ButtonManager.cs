using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    [SerializeField]
    private Transform inputParent;

    private Display[] inputs;
    private int lastInputIndex;

    private void Start() {
        inputs = inputParent.GetComponentsInChildren<Display>();
    }

    public void Clear() {
        lastInputIndex = 0;
        foreach (Display input in inputs) {
            input.Set(Suit.NONE);
        }
    }

    public void AddSpade() {
        SetDisplay(Suit.SPADE);
    }

    public void AddDiamond() {
        SetDisplay(Suit.DIAMOND);
    }

    public void SwapSuits() {
        foreach (Display display in inputs) {
            display.Swap();
        }
        GameManager.Instance.OnButtonInvoke();
    }

    private void SetDisplay(Suit suit) {
        if (lastInputIndex < inputs.Length) {
            inputs[lastInputIndex++].Set(suit);
        } else {
            foreach (Display display in inputs) {
                display.Set(Suit.NONE);
            }
            lastInputIndex = 0;
        }
        GameManager.Instance.OnButtonInvoke();
    }
}
