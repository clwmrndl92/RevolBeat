using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public string info;
    public Sprite cover;
}
public class SelectMusic : MonoBehaviour
{
    [SerializeField] Song[] songList = null;
    [SerializeField] Text songName = null;
    [SerializeField] Text songComposer = null;
    [SerializeField] Text songInfo = null;
    [SerializeField] Image songCover = null;

    int currentsong = 0;

    private void Start()
    {
        SetSong();
    }

    public void BtnR()
    {
        if (++currentsong > songList.Length - 1)
            currentsong = 0;
        SetSong();
    }

    public void BtnL()
    {
        if (--currentsong < 0)
            currentsong = songList.Length - 1;
        SetSong();
    }

    void SetSong()
    {
        songName.text = songList[currentsong].name;
        songComposer.text = songList[currentsong].composer;
        songInfo.text = songList[currentsong].info;
        songCover.sprite = songList[currentsong].cover;
    }

    void Update()
    {
        //wheh left, right > change song index

        //display song info
    }
}
