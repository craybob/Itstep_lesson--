using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCollider : MonoBehaviour
{
    public int hp = 10;


    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterScr>().hp--;
        }
    }
    
}
