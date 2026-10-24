using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance {  get; private set; }

    private int points = 0;

    private GameObject scoreTextObj;
    private TMP_Text scoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreTextObj = GameObject.Find("PointsLabel");
        scoreText = scoreTextObj.GetComponent<TMP_Text>();
    }

    public void AddScore(int scoreToAdd)
    {
        if(scoreTextObj != null)
        {
            points += scoreToAdd;
            scoreText.text = "Points: " + points;
            if(points < 0)
            {
                points = 0;
            }
        }
    }

    public void ResetScore()
    {
        if (scoreTextObj != null)
        {
            points = 0;
            scoreText.text = "Points: " + points;

        }
    }
}
