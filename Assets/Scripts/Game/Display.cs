using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour {
    [SerializeField]
    private Image icon;
    private Suit suit;

    public Suit Suit {
        get {
            return suit;
        }
    }

    public override bool Equals(object obj) {
        var display = obj as Display;
        return display != null &&
               base.Equals(obj) &&
               suit == display.suit;
    }

    public void Set(Suit suit) {
        this.suit = suit;
        this.icon.sprite = SuitManager.Instance.GetIcon(suit);
    }

    public void Swap() {
        Set(suit.Swap());
    }
}
