using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchState : MonoBehaviour
{
    [SerializeField] private float launchSpeedMultiplier = 0;
    [SerializeField] private float launchForceMultiplier = 0;

    [SerializeField] private GameObject _canvas;
    [SerializeField] private Image _launchParameter;

    [SerializeField] private float _launchForce;

    private float _launchAmount = 0;

    public float LaunchForce => _launchForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LaunchBall(bool activate)
    {
        _canvas.SetActive(activate);

        if (activate)
        {
            _launchAmount = Mathf.PingPong(Time.time * launchSpeedMultiplier, 1);

            _launchParameter.fillAmount = _launchAmount;

            _launchForce = _launchAmount * launchForceMultiplier;
        }
    }
}
