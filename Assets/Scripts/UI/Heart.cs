using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite FillImg, EmptyImg;
    Image Img;

    private void Start()
    {
        Img = this.GetComponent<Image>();
    }

    public void Damage()
    {
        Img.sprite = EmptyImg;
    }

    public void Heal()
    {
        Img.sprite = FillImg;
    }
}
