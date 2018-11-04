using UnityEngine;

public class SuitManager : MonoBehaviour {
    private static SuitManager _instance;

    [SerializeField]
    private Sprite club;

    [SerializeField]
    private Sprite spade;

    [SerializeField]
    private Sprite heart;

    [SerializeField]
    private Sprite diamond;

    public static SuitManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<SuitManager>();
            }
            return _instance;
        }
    }

    public Sprite GetIcon(Suit suit) {
        Sprite sprite = null;
        switch (suit) {
            case Suit.CLUB:
                sprite = club;
                break;
            case Suit.SPADE:
                sprite = spade;
                break;
            case Suit.DIAMOND:
                sprite = diamond;
                break;
            case Suit.HEART:
                sprite = heart;
                break;
        }
        return sprite;
    }
}