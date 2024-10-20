using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTurtle : MonoBehaviour
{
    public GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(p.transform.position.x, -0.9f, 0);
    }
}
