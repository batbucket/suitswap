using UnityEngine;

public static class Util {

}

public static class ExtensionMethods {
    public static Suit Swap(this Suit suit) {
        Suit swap = Suit.NONE;
        switch (suit) {
            case Suit.CLUB:
                swap = Suit.SPADE;
                break;
            case Suit.SPADE:
                swap = Suit.CLUB;
                break;
            case Suit.DIAMOND:
                swap = Suit.HEART;
                break;
            case Suit.HEART:
                swap = Suit.DIAMOND;
                break;
        }
        return swap;
    }

    public static T PickRandom<T>(this T[] array) {
        return array[Random.Range(0, array.Length)];
    }
}