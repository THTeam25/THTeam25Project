using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1_Boss_HPColorChange : MonoBehaviour
{
    public Color color_1, color_2, color_3, color_4;
    public float maxHP = 3;
    [Range(0, 3)] public float hp = 3;
    private Image image_HPgauge;
    private float hp_ratio;

    // Start is called before the first frame update
    void Start()
    {
        image_HPgauge = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hp_ratio = hp / maxHP;

        if (hp_ratio > 0.75f)
        {
            image_HPgauge.color = Color.Lerp(color_2, color_1, (hp_ratio - 0.75f) * 4f);
        }
        else if (hp_ratio > 0.25f)
        {
            image_HPgauge.color = Color.Lerp(color_3, color_2, (hp_ratio - 0.25f) * 4f);
        }
        else
        {
            image_HPgauge.color = Color.Lerp(color_4, color_3, hp_ratio * 4f);
        }

        image_HPgauge.fillAmount = hp_ratio;
    }
}
