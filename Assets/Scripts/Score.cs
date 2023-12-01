using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int scoreNumber;

    private MeshRenderer _mesh;

    private void Start()
    {
        _mesh = transform.GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.Instance._CurrentScore += scoreNumber;
    }

    private void OnTriggerExit(Collider other)
    {
        ScoreManager.Instance._CurrentScore -= scoreNumber;
    }
}
