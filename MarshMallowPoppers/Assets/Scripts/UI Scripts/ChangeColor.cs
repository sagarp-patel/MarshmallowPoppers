using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image panel;
    public Text title;
    float value1;
    float value2;
    float value3;

    float othervalue1;
    float othervalue2;
    float othervalue3;
    int state;
    int otherstate = 1;

    // Use this for initialization
    void Start ()
    {
        //panel = GetComponent<Image>();
        state = 1;
        value1 = 1.0f;
        othervalue1 = 1.0f;
        otherstate = 2;
    }

    void Update()
    {
        //panel.color = GetRandomColor();
        GetColor();
        OtherColor();
    }

    /*Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }*/

    void GetColor()
    {
        if(state == 1)
        {
            value2 += 0.01f;
            if(value2 >= 1.0f)
            {
                state = 2;
            }
        }
        else if (state == 2)
        {
            value1 -= 0.01f;
            if (value1 <= 0.0f)
            {
                state = 3;
            }
        }
        else if (state == 3)
        {
            value3 += 0.01f;
            if (value3 >= 1.0f)
            {
                state = 4;
            }
        }
        else if (state == 4)
        {
            value2 -= 0.01f;
            if (value2 <= 0.0f)
            {
                state = 5;
            }
        }
        else if (state == 5)
        {
            value1 += 0.01f;
            if (value1 >= 1.0f)
            {
                state = 6;
            }
        }
        else if (state == 6)
        {
            value3 -= 0.01f;
            if (value3 <= 0.0f)
            {
                state = 1;
            }
        }
        panel.color = new Color(value1, value2, value3);
    }

    void OtherColor()
    {
        if (otherstate == 1)
        {
            othervalue2 += 0.01f;
            if (othervalue2 >= 1.0f)
            {
                otherstate = 2;
            }
        }
        else if (otherstate == 2)
        {
            othervalue1 -= 0.01f;
            if (othervalue1 <= 0.0f)
            {
                otherstate = 3;
            }
        }
        else if (otherstate == 3)
        {
            othervalue3 += 0.01f;
            if (othervalue3 >= 1.0f)
            {
                otherstate = 4;
            }
        }
        else if (otherstate == 4)
        {
            othervalue2 -= 0.01f;
            if (othervalue2 <= 0.0f)
            {
                otherstate = 5;
            }
        }
        else if (otherstate == 5)
        {
            othervalue1 += 0.01f;
            if (othervalue1 >= 1.0f)
            {
                otherstate = 6;
            }
        }
        else if (otherstate == 6)
        {
            othervalue3 -= 0.01f;
            if (othervalue3 <= 0.0f)
            {
                otherstate = 1;
            }
        }
        title.color = new Color(othervalue1, othervalue2, othervalue3);
    }

}
