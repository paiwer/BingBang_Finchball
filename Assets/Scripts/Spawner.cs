using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private int _spawnNumber = 3;

    [SerializeField] private float _spawnDelay;

    [SerializeField] public bool spawned;

    public int _currentSpawnNum;

    private void Start()
    {
        spawned = true;
        Instantiate(_ballPrefab, transform.position, Quaternion.identity);
        _currentSpawnNum++;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawned && _currentSpawnNum < _spawnNumber)
        {
            StartCoroutine(WaitForSpawn());
            spawned = true;
            _currentSpawnNum++;
        }
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(_spawnDelay);
        Instantiate(_ballPrefab, transform.position, Quaternion.identity);
    }
}
