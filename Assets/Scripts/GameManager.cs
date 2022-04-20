using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    private TMP_InputField NameInput;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore;

    public void Awake()
    {
        NameInput = GameObject.Find("Name Input").GetComponent<TMP_InputField>();

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
}
