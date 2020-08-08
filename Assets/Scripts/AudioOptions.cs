using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite[] images;
    public int volume = 3;
    // Start is called before the first frame update
    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = this.GetComponent<AudioSource>();
        }
    }
    public void MuteButton()
    {
        if (audioSource.mute) {
            audioSource.mute = false;
            this.GetComponent<Image>().sprite = images[volume];
        }
        else
        {
            audioSource.mute = true;
            this.GetComponent<Image>().sprite = images[0];
        }
    }
}
