using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    [SerializeField] float _forceScale;
    [SerializeField] float _damping;
    
    Rigidbody2D _playerRB;

    private float dt = 0;
    private Vector2 _force;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _force = Vector2.zero;
    }

    public void AddForce(Vector2 force)
    {
        _force = force;
    }

    void Update()
    {
        dt = Time.deltaTime;
        _force = _force*_forceScale - _damping * _playerRB.velocity;

        if (_force != Vector2.zero)
        {
           
            _playerRB.AddForce(_force );
            _force = Vector2.zero;
        }

        
    }
}
