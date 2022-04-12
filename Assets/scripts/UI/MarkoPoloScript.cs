using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkoPoloScript : MonoBehaviour
{
    public Text textMarkoPolo;

    // Start is called before the first frame update

    private void AddText (string text)
    {
        textMarkoPolo.text += text + Environment.NewLine;
        textMarkoPolo.rectTransform.sizeDelta += new Vector2(0, (textMarkoPolo.fontSize + 1) * textMarkoPolo.lineSpacing);
    }

    public void CreateMarkoPolo()
    {
        textMarkoPolo.rectTransform.sizeDelta = new Vector2(textMarkoPolo.rectTransform.sizeDelta.x,0);
        textMarkoPolo.text = "";
        for(int i = 1; i <= 100;i++)
        {

            if (i % 3 == 0 && i % 5 == 0)
            {
                AddText(i + " MarkoPolo");
            }
            else if (i % 3 == 0)
            {
                AddText(i + " Marko");
            }
            else if (i % 5 == 0)
            {
                AddText(i + " Polo");
            }
            else
                AddText(i.ToString());
        }
    }
}
