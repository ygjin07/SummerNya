using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AudioSource HitSound;
    PlayerAction p;

    // Start is called before the first frame update
    void Start()
    {
        //p = GameManager.GM.p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle")
        {
            HitSound.Play();
            UIManager.UM.hp.GetDamage();
        }
    }
}
