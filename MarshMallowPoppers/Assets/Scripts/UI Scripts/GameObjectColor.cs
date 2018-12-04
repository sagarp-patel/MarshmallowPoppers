using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectColor : MonoBehaviour
{
    public SpriteRenderer sprite;
    float value1;
    float value2;
    float value3;

    int state;

    // Use this for initialization
    void Start()
    {
        //panel = GetComponent<Image>();
        state = 1;
        value1 = 1.0f;
    }

    void Update()
    {
        //panel.color = GetRandomColor();
        GetColor();
    }

    /*Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }*/

    void GetColor()
    {
        if (state == 1)
        {
            value2 += 0.1f;
            if (value2 >= 1.0f)
            {
                state = 2;
            }
        }
        else if (state == 2)
        {
            value1 -= 0.1f;
            if (value1 <= 0.0f)
            {
                state = 3;
            }
        }
        else if (state == 3)
        {
            value3 += 0.1f;
            if (value3 >= 1.0f)
            {
                state = 4;
            }
        }
        else if (state == 4)
        {
            value2 -= 0.1f;
            if (value2 <= 0.0f)
            {
                state = 5;
            }
        }
        else if (state == 5)
        {
            value1 += 0.1f;
            if (value1 >= 1.0f)
            {
                state = 6;
            }
        }
        else if (state == 6)
        {
            value3 -= 0.1f;
            if (value3 <= 0.0f)
            {
                state = 1;
            }
        }
        sprite.color = new Color(value1, value2, value3);
    }

}
