using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool disable = false;
    [SerializeField] int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pig" && !disable)
        {
            disable = true;
            collision.gameObject.TryGetComponent<PigBasic>(out PigBasic pig);
            pig.KillPig();

            StartCoroutine(WaitToEnable(2f));
        }

        
    }


    IEnumerator WaitToEnable(float time)
    {
        yield return new WaitForSeconds(time);
        disable = false;
    }
}
