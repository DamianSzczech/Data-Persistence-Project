using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    private TMP_Text BestScoreText;
    private TMP_InputField NameInput;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore;

    private string path;

    public void Awake()
    {
        NameInput = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
        BestScoreText = GameObject.Find("Best Score").GetComponent<TMP_Text>();

        path = $"{Application.persistentDataPath}/savedata.json";
        LoadBestScore();
        BestScoreText.text = $"Best Score: {BestPlayer} : {BestScore}";

        Instance = GetInstance();

        DontDestroyOnLoad(gameObject);
    }

    private GameManager GetInstance()
    {
        if (Instance == null)
        {
            return GetComponent<GameManager>();
        }

        return Instance;
    }

    public void StartGame()
    {
        PlayerName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    public void LoadBestScore()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);
            BestPlayer = data.PlayerName;
            BestScore = data.Score;
        }
    }

    public void SaveBestScore()
    {
        var json = JsonUtility.ToJson(new BestScoreData { PlayerName = BestPlayer, Score = BestScore });
        File.WriteAllText(path, json);
    }

    [SerializeField]
    class BestScoreData
    {
        public string PlayerName;
        public int Score;
    }
}
