using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour {

    public void StartGame(int difficulty) {
        Statics.difficulty = difficulty;
        SceneManager.LoadScene(1);
    }

    public void OpenLeaderboards() {
        GameJoltUI.Instance.ShowLeaderboards();
    }

    public void OpenTrophies() {
        GameJoltUI.Instance.ShowTrophies();
    }
}
