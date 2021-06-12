using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaGuy : Enemy
{
    [SerializeField] float speed;

    private bool inGravityField = false;
    private GameObject _player;
    private float dt = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravity")
        {
            _player = collision.gameObject;
            inGravityField = true;
        }
    }

    private void Update()
    {
        if(!inGravityField)
        {
            //bob up and down
        }
        else
        {
            dt = Time.deltaTime;
            transform.position += (_player.transform.position - transform.position) * speed * dt / (0.1f + Mathf.Pow(Vector3.Distance(_player.transform.position, transform.position), 2));

        }
    }
}
