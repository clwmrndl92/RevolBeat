using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float[] notenum = new float[4];
    public int notelist;
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
