using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComboEffect : MonoBehaviour
{
    float time;
    public float _fadeTime = 0.2f;
    Color color;
    private void Awake()
    {
        color = GetComponent<Text>().color;
    }
    // Update is called once per frame
    void Update()
    {
            if (time < _fadeTime)
            {
                this.GetComponent<Text>().color = new Color(color.r, color.g, color.b, 1f - time / _fadeTime);
            }
            else
            {
                gameObject.SetActive(false);
            }
            time += Time.deltaTime;
    }

    public void makeEffect()
    {
        time = 0;
        GetComponent<Text>().color = new Color(color.r, color.g, color.b, 1f);
        gameObject.SetActive(true);
    }
}
