using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public Heart[] Hearts;
    int cnt = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage()
    {
        cnt--;
        Hearts[cnt].Damage();
        if(cnt <= 0)
        {
            GameManager.GM.GameOVer();
        }
    }
}
