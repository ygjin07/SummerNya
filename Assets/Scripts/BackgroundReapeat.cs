using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReapeat : MonoBehaviour
{
    public float scrollSpeed = 1.2f;
    public GameObject obj1, obj2;
    GameObject temp;

    void Start()
    {

    }

    void Update()
    {
        obj1.transform.position -= new Vector3(scrollSpeed * Time.deltaTime * GameManager.GM.stop_move, 0, 0);
        obj2.transform.position = obj1.transform.position + new Vector3(19.2f, 0, 0);
        if (obj1.transform.position.x <= -19.2f)
        {
            temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
    }
}
