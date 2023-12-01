using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _launchSpeed = 0;
    [SerializeField] private float _maxLaunchSpeed = 0;
    [SerializeField] private float _rotateSpeed = 0;
    [SerializeField] private float _increaseLaunchSpeed = 0;
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private bool _isLaunch;

    [SerializeField] private float _timer;

    private float sideRotate;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Launch();

        MoveLeftRight();

        RotateleftRight();
    }

    private void Launch()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {

            _rigidBody.AddForce(transform.forward * _launchSpeed, ForceMode.Impulse);
            _isLaunch = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _launchSpeed = Mathf.PingPong(_timer, _maxLaunchSpeed);
            _timer += _increaseLaunchSpeed;
        }
    }

    private void MoveLeftRight()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -Vector3.right * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
    }

    private void RotateleftRight()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            sideRotate -= _rotateSpeed;

            transform.rotation = Quaternion.Euler(0, sideRotate, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            sideRotate += _rotateSpeed;

            transform.rotation = Quaternion.Euler(0, sideRotate, 0);
        }
    }
}
