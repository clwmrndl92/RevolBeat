using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ButtonManager : MonoBehaviour
{

    public Outline o1 = null;
    public Outline o2 = null;
    public Outline o3 = null;

    //Change Difficulty
    public void ChDifficulty(int num)
    {
        GameManager.instance.setDifficulty(num);
        Debug.Log(GameManager.instance.Difficulty);
    }

    //Make Button Glow
    public void GlowButton()
    {
        if(GameManager.instance.Difficulty == 0)
        {
            o1.enabled = true;
            o2.enabled = false;
            o3.enabled = false;
        }

        else if(GameManager.instance.Difficulty == 1)
        {
            o1.enabled = false;
            o2.enabled = true;
            o3.enabled = false;
        }

        else if (GameManager.instance.Difficulty == 2)
        {
            o1.enabled = false;
            o2.enabled = false;
            o3.enabled = true;
        }
    }

    private void Update()
    {
        //Make Button Glow by Selected Difficulty
        GlowButton();
        
    }
}
