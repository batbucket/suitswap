public static class Statics {
    public static int difficulty = 3;

    public const int FIVES_50_TROPHY_ID = 100017;
    public const int SIXES_50_TROPHY_ID = 100019;

    private static readonly int[] SCORE_20_TROPHY_IDS = new int[] {
        100012,
        100013,
        100014,
        100015,
        100016,
        100018
    };

    private static readonly int[] LEADERBOARD_IDS = new int[] {
        382917,
        383172,
        383173,
        383174,
        383175,
        383176
    };

    public static int Score20TrophyId {
        get {
            return SCORE_20_TROPHY_IDS[difficulty - 1];
        }
    }

    public static int LeaderboardsId {
        get {
            return LEADERBOARD_IDS[difficulty - 1];
        }
    }
}