using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [SerializeField] public bool BallLaunched;

    [SerializeField] private Spawner _spawnerScript;

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

        _spawnerScript = FindObjectOfType<Spawner>();
    }


    private void OnLevelWasLoaded(int level)
    {
        _spawnerScript = FindObjectOfType<Spawner>();
    }

    void Update()
    {
        if(BallLaunched)
        {
            _spawnerScript.spawned = false;
            BallLaunched = false;
        }
    }
}
