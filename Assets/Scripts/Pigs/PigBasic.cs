using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBasic : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Sprite deadPig;


    public int _weight;

    private GameObject _player;
    private bool inGravityField = false;
    private float dt = 0;
    private bool detached = true;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D pigRB;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pigRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(detached && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Pig"))
        {
            detached = false;
            inGravityField = false;
            PigManager.Instance.AddPig(gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            
        }

       
    }

    public void KillPig()
    {
        TryGetComponent<SpringJoint2D>(out SpringJoint2D joint);

        if (joint)
        {
            Destroy(joint);
            pigRB.gravityScale = 1.5f;
        }
        spriteRenderer.sprite = deadPig;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravity")
        {
            _player = collision.gameObject;
            inGravityField = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gravity")
        {
            inGravityField = false;
        }
    }

    private void Update()
    {
        dt = Time.deltaTime;
        if(inGravityField)
        {
            transform.position += (_player.transform.position - transform.position) *  speed * dt / (0.1f+Mathf.Pow(Vector3.Distance(_player.transform.position, transform.position),2));
        }
    }

}
