using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private float _moveSpeed;

    private Vector3 _objectPosition;

    void Start()
    {
        _objectPosition = _pos1.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _objectPosition, _moveSpeed * Time.deltaTime);

        if (transform.position == _objectPosition)
        {
            if (_objectPosition == _pos1.position)
            {
                _objectPosition = _pos2.position;
            }
            else
            {
                _objectPosition = _pos1.position;
            }
        }
    }
}
