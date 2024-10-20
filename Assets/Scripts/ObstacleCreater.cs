using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreater : MonoBehaviour
{
    public Obstacle[] Obs;
    public float Min_create_delay, Max_create_delay;
    public float CreatePosY;
    public GameObject Pool;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(Min_create_delay, Max_create_delay));
            Obstacle.ObsCnt = Pool.transform.GetChildCount();
            if (Obstacle.ObsCnt <= 3)
            {
                GameObject temp = Instantiate(Obs[Random.Range(0, Obs.Length)].gameObject);
                temp.transform.position = new Vector3(11.5f, CreatePosY, 0);
                temp.transform.SetParent(Pool.transform);
            }
        }
    }
}
