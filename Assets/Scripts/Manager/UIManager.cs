using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UM;
    public HP hp;
    public GameObject OptionPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (UM == null)
        {
            UM = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OptionPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void CloseOption()
    {
        OptionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
