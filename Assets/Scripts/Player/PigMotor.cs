using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMotor : MonoBehaviour
{
    [SerializeField] float _forceScale;
    [SerializeField] float _damping;

    private Rigidbody2D _pigRB;
    private float dt = 0;
    private Vector2 _force;

    private bool selected = false;

    private void Awake()
    {
        _pigRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("This is" + name);
                    selected = true;
                    StartCoroutine(Drag());
                }
            }
        }


        if(!selected)
        {
            dt = Time.deltaTime;
            _force = -_damping * _pigRB.velocity;
            _pigRB.AddForce(_force * dt);
        }

    }

    IEnumerator Drag()
    {
        while(Input.GetKey(KeyCode.Mouse0))
        {
            
            dt = Time.deltaTime;
            _force = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - _pigRB.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - _pigRB.position.y);
            //Debug.Log(_force);
            _force = _force * _forceScale - _damping * _pigRB.velocity;

           
            _pigRB.AddForce(_force);
            yield return new WaitForSeconds(0.1f);
        }

        selected = false;
    }
}
