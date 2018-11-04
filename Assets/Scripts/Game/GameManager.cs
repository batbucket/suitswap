using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    [SerializeField]
    private GuideManager guide;

    [SerializeField]
    private ButtonManager buttons;

    [SerializeField]
    private Image timeBar;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private PostProcessingBehaviour greyscale;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Gradient timeColor;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private Button gameOverButton;

    [SerializeField]
    private GraphicRaycaster gameRaycaster;

    private int score;

    private float timer;
    private float timeRemaining;
    private bool isGameOver;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Start() {
        StartProblem();
    }

    private float GetDuration(int score) {
        if (score == 0) {
            return 666;
        }

        float minDuration = 0;
        if (Statics.difficulty > 2) {
            if (score < 100) {
                minDuration = Statics.difficulty * 1f;
            } else if (score < 200) {
                minDuration = Statics.difficulty * 0.75f;
            } else {
                minDuration = Statics.difficulty * 0.50f;
            }
        }

        return Mathf.Max(20 * Mathf.Pow(.95f, score), minDuration);
    }

    public void OnButtonInvoke() {
        if (guide.IsCorrect) {
            score++;
            StartProblem();
            SoundManager.Instance.Play(SoundManager.Instance.correct);
        }
    }

    public void GiveUp() {
        timer = 0;
    }

    public void ReturnToDifficultySelect() {
        SceneManager.LoadScene(0);
    }

    private void StartProblem() {
        scoreText.SetText(score.ToString());
        guide.Init();
        buttons.Clear();
        timeRemaining = GetDuration(score);
        Debug.Log("Time remaining: " + timeRemaining);
        timer = timeRemaining;
    }


    private void Update() {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
            GiveUp();
        }

        timeBar.fillAmount = timer / timeRemaining;
        timeBar.color = timeColor.Evaluate(1 - timeBar.fillAmount);
        if (!isGameOver && (timer -= Time.deltaTime) < 0) {
            if (score > 0) {
                Scores.Add(
                    score,
                    score.ToString(), 
                    "Guest", 
                    Statics.LeaderboardsId,
                    "",
                    isSuccess => Debug.Log("Post score success=" + isSuccess));
            }
            UnlockTrophies();
            gameRaycaster.enabled = false;
            isGameOver = true;
            greyscale.enabled = true;
            SoundManager.Instance.Play(SoundManager.Instance.wrong);
            gameOverScreen.SetActive(true);
            gameOverText.SetText(string.Format("* You scored {0}.\n(Click anywhere to exit.)", score));
            StartCoroutine(WaitForButtonActive());
        }
    }

    private void UnlockTrophies() {
        if (score >= 20) {
            Trophies.Unlock(Statics.Score20TrophyId);
        }
        if (score >= 50) {
            if (Statics.difficulty == 5) {
                Trophies.Unlock(Statics.FIVES_50_TROPHY_ID);
            } else if (Statics.difficulty == 6) {
                Trophies.Unlock(Statics.SIXES_50_TROPHY_ID);
            }
        }

    }

    private IEnumerator WaitForButtonActive() {
        yield return new WaitForSeconds(1);
        gameOverButton.interactable = true;
    }
}
