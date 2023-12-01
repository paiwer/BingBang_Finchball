using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateState : MonoBehaviour
{
    [SerializeField] private float _minAngle = -40f;
    [SerializeField] private float _maxAngle = 40f;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Quaternion _launchAngle;

    [SerializeField] private GameObject _arrowPivot;

    private float _currentAngle;

    public Quaternion LaunchAngle => _launchAngle;

    // Start is called before the first frame update
    void Start()
    {
        _currentAngle = _minAngle;

        RotateCanvas(true);
    }

    // Update is called once per frame
    void Update()
    {
        //BallRotate(false);
    }

    public void RotateBall(bool activate)
    {
        if (activate)
        {
            _arrowPivot.SetActive(activate);

            _currentAngle = Mathf.Lerp(_minAngle, _maxAngle, Mathf.PingPong(Time.time * _rotateSpeed, 1));

            _launchAngle = Quaternion.Euler(0, _currentAngle, 0);

            _arrowPivot.transform.rotation = _launchAngle;
        }
    }

    public void RotateCanvas(bool activate)
    {
        _arrowPivot.SetActive(activate);
    }
}
