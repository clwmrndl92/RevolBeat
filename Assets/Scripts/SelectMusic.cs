using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMusic : MonoBehaviour
{
    [SerializeField] Text songName = null;
    [SerializeField] Text songComposer = null;
    [SerializeField] Text songInfo = null;
    [SerializeField] Image songCover = null;

    public static int currentsong = 0;

    private void Start()
    {
        SetSong();
    }

    public void BtnR()
    {
        if (++currentsong > GameManager.instance.songList.Length - 1)
            currentsong = 0;
        SetSong();
    }

    public void BtnL()
    {
        if (--currentsong < 0)
            currentsong = GameManager.instance.songList.Length - 1;
        SetSong();
    }

    void SetSong()
    {
        songName.text = GameManager.instance.songList[currentsong].name;
        songComposer.text = GameManager.instance.songList[currentsong].composer;
        songInfo.text = GameManager.instance.songList[currentsong].info;
        songCover.sprite = GameManager.instance.songList[currentsong].cover;
    }

    void Update()
    {
        //wheh left, right > change song index

        //display song info
    }
}
