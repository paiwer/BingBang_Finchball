using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private bool _moveState;
    [SerializeField] private bool _rotateState;
    [SerializeField] private bool _LaunchState;

    [SerializeField] private bool _launched;

    [SerializeField] private float _launchForce;
    [SerializeField] private Vector3 _launchDirection;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private LaunchState _launchScript;
    [SerializeField] private RotateState _rotateScript;
    [SerializeField] private MoveState _moveScript;

    // Start is called before the first frame update
    void Start()
    {
        _moveState = true;
        _rotateState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveState)
        {
            _moveScript.MoveBall(true);
            _rotateScript.RotateBall(true);
            _launchScript.LaunchBall(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(_rotateState)
            {
                _moveState = false;
                _LaunchState = true;

                _moveScript.MoveBall(false);
                _rotateScript.RotateBall(false);
                _launchScript.LaunchBall(true);

                _launchDirection = _rotateScript.LaunchAngle * Vector3.forward;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(_LaunchState)
            {
                _rotateState = false;
                _LaunchState = false;

                _rotateScript.RotateBall(false);
                _rotateScript.RotateCanvas(false);

                _launchScript.LaunchBall(false);

                _launchForce = _launchScript.LaunchForce;

                _rigidBody.AddForce(_launchDirection * _launchForce, ForceMode.Impulse);

                _launched = true;
            }
        }

        if(_launched)
        {
            GameState.Instance.BallLaunched = true;
            enabled = false;
        }
    }
}
