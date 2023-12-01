using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] public int _CurrentScore;
    [SerializeField] private TMP_Text _scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        _CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _CurrentScore.ToString();
    }
}
