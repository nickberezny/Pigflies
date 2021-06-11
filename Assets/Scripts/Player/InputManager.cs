using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerMotor _motor;
    private Vector2 _force;

    private void Awake()
    {
        _motor = GetComponent<PlayerMotor>();
        _force = Vector2.zero;
    }

    void Update()
    {
        _force = Vector2.zero;

        if(Input.GetKey(KeyCode.D))
        {
            _force.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _force.x = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _force.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _force.y = -1;
        }

        if (_force != Vector2.zero) _motor.AddForce(_force);
    }

}
