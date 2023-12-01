using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _minLength;
    [SerializeField] private float _maxLength;

    [SerializeField] private GameObject _canvas;

    public void MoveBall(bool activate)
    {
        _canvas.SetActive(activate);

        if (activate)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -Vector3.right * _moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
            }

            float clampedLength = Mathf.Clamp(transform.position.x, _minLength, _maxLength);
            transform.position = new Vector3(clampedLength, transform.position.y, transform.position.z);
        }
    }
}
