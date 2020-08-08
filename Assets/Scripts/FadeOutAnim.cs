using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutAnim : MonoBehaviour
{
    float time;
    public float _fadeTime = 0.2f;
    bool off = false;

    private void Start()
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
    private void Update()
    {
        if (off)
        {
            FadeOut();
        }
    }

    // Update is called once per frame
    void FadeOut()
    {
        if(time < _fadeTime)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1f - time/_fadeTime);
        }
        else
        {
            time = 0;
            off = false;
        }
        time += Time.deltaTime;
    }

    public void resetEffect()
    {
        time = 0;
        GetComponent<Image>().color = Color.white;
        off = false;
    }

    public void EffectOff()
    {
        off = true;
    }
    
}
