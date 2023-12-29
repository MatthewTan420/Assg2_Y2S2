using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCode : MonoBehaviour
{
    public TextMeshPro text;
    public string textName;
    public int textLen;
    public TextMeshPro length;
    public string code;

    private void Start()
    {
        text.text = "";
    }

    private void Update()
    {
        textLen = text.text.Length;
    }

    public void addText()
    {
        if (textLen < 3)
        {
            text.text = text.text + textName;
        }
    }

    public void clearText()
    {
        text.text = "";
    }

    public void checkCode()
    {
        if (code == text.text)
        {
            length.text = "correct";
        }
        else
        {
            length.text = "incorrect";
        }
    }
}
