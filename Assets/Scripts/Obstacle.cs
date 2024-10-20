using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Speed;
    public Sprite[] Imgs;
    SpriteRenderer SR;
    static public int ObsCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        SR = this.GetComponent<SpriteRenderer>();
        SR.sprite = Imgs[Random.Range(0, Imgs.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x -= Speed * Time.deltaTime * GameManager.GM.stop_move;
        this.transform.position = pos;
        Del();
    }

    void Del()
    {
        if(this.transform.position.x <= -11)
        {
            Destroy(this.gameObject);
        }
    }
}
