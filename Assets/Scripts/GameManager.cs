using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public string info;
    public Sprite cover;
    public AudioClip music;
    public float[] bpm = new float[4];
    public float length;
<<<<<<< HEAD
    public int[] notenum = new int[4];
    public string[] notelist = new string[4];
    public int[,] ListEasy = null;
    public int[,] ListNormal = null;
    public int[,] ListHard = null;
    public void LoadNote()
    {
        for (int n = 0; n < 3; n++)
        {
            string NoteFileName = this.notelist[GameManager.instance.Difficulty];
            string filePath = "Assets/Notelist/" + NoteFileName + ".txt";
            string[] list = System.IO.File.ReadAllLines(filePath);
            int[,] notelist = new int[list.Length, 3];
            if (list.Length > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    string[] nl = list[i].Split(',');
                    for (int j = 0; j < 3; j++)
                    {
                        notelist[i, j] = Convert.ToInt32(nl[j]);
                    }
                }
            }
            if (n == 0)
            {
                ListEasy = (int[,])notelist.Clone();
            }
            else if (n == 1)
            {
                ListNormal = (int[,])notelist.Clone();
            }
            else if (n == 2)
            {
                ListHard = (int[,])notelist.Clone();
            }
        }
    }
=======
    public float[] notenum = new float[4];
    public int notelist;
>>>>>>> 9bcd32e890cb1bb5fe29dd3fb1d583d0d5fb61e1
}
public class GameManager : MonoBehaviour
{
    public int Difficulty = 3;
    public Song[] songList = null;
    public static GameManager instance = null;
    
    public void setDifficulty(int num)
    {
        Difficulty = num;
    }




    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        SceneManager.LoadScene("Start");
    }
    public void Quit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
