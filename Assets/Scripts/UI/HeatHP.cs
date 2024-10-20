using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatHP : MonoBehaviour
{
    public float Heat_time = 10f;
    public float Cool_time = 15f;
    public Image HeatHPImg;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GM.CheckDive())
        {
            HeatHPImg.fillAmount = Mathf.Clamp(HeatHPImg.fillAmount - 0.75f / Cool_time * Time.deltaTime * GameManager.GM.stop_move, 0.25f, 1.0f);
        }
        else
        {
            HeatHPImg.fillAmount = Mathf.Clamp(HeatHPImg.fillAmount + 0.75f / Heat_time * Time.deltaTime * GameManager.GM.stop_move, 0.25f, 1.0f);
        }

        CheckHeat();

        this.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(-1f, 1f, 0));
    }

    public void CheckHeat()
    {
        if(HeatHPImg.fillAmount >= 1.0f)
        {
            GameManager.GM.GameOVer();
        }
    }
}
