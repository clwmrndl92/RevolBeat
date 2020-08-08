using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum State
{
    Loading,
    Play,
    Pause,
    End
}


public class SongManager : GameManager
{
    private AudioSource audioSource;
<<<<<<< HEAD
    public float noteSpeed;
=======
<<<<<<< HEAD
    public float noteSpeed;
=======
>>>>>>> 9bcd32e890cb1bb5fe29dd3fb1d583d0d5fb61e1
>>>>>>> dfe8766cead11049eeee8ef5ebce95b65ab53731
    public static SongManager songManager = null;

    public State state = State.Loading;
    public GameObject notePrefab;
    public float noteInterval = 10;
    public GameObject[] notePanels;
    public GameObject[] buttons;
    public Color[] noteColors;
    public Text scoreText, comboText;
    public GameObject background;
    [SerializeField]public static Song selectedSong = null;
    public static int score = 0;
    public static int combo = 0;
    public static int[] noteScores = new int[5];
    public static GameObject[] bottomNote;
    public static float[] notePosx;
    public static int noteNum;
    public int[,] notelist;
    public static int difficulty = 0;
    float timer, notePosY,tmptimer = 0;
    int x = 0, y = 0;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (songManager == null)
            songManager = this;
        else if (songManager != this)
            Destroy(this.gameObject);
        timer = 0.0f;
        noteNum = notePanels.Length;
        notePosx = new float[noteNum];
        for(int i = 0; i < noteNum; ++i)
        {
            notePosx[i] = notePanels[i].transform.position.x;
        }
        notePosY = notePanels[0].transform.position.y;
        bottomNote = new GameObject[noteNum];
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnClick(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            OnClick(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnClick(2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToLeftButton();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToRightButton();
        }
        if(state == State.Loading)
        {
            Loading();
            state = State.Play;
        }
        if (state == State.Play)
        {
            timer += Time.deltaTime;
            tmptimer += Time.deltaTime;
            if (tmptimer > noteInterval && y==0)
            {
                audioSource.Play();
                Debug.Log("Play");
                y = 1;
            }
            if (x < selectedSong.notenum[difficulty]) {
                if (tmptimer * 1000 > notelist[x, 0])
                {
                    MakeNote(notelist[x, 1], 3);
                    //MakeNote(notelist[x, 1], notelist[x, 2]);
                    if (x == 0)
                    {
                        Debug.Log("First Note");
                    }
                    if (x < selectedSong.notenum[difficulty])
                    {
                        x++;
                    }
                }
            }
            if (tmptimer > selectedSong.length+3)
            {
                state = State.End;
            }
            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
        }
        if (state == State.End)
        {
            SceneManager.LoadScene("Result");
        }
}
    
    void Loading()
    {
        selectedSong = GameManager.instance.songList[SelectMusic.currentsong];
        difficulty = GameManager.instance.Difficulty;
        noteSpeed = 3*selectedSong.bpm[difficulty];
        noteInterval = 4*259/noteSpeed;
        LoadSong(selectedSong);
<<<<<<< HEAD
        selectedSong.LoadNote();
        LoadNote(selectedSong);
=======
<<<<<<< HEAD
        selectedSong.LoadNote();
        LoadNote(selectedSong);
=======
        state = State.Play;
>>>>>>> 9bcd32e890cb1bb5fe29dd3fb1d583d0d5fb61e1
>>>>>>> dfe8766cead11049eeee8ef5ebce95b65ab53731
    }

    void LoadSong(Song song)
    {
        score = 0;
        combo = 0;
        for(int i = 0; i < 5; ++i)
        {
            noteScores[i] = 0;
        }
        background.GetComponent<Image>().sprite = song.cover;
        audioSource.clip = song.music;
        audioSource.loop = false;
        audioSource.mute = false;
        audioSource.volume = 0.5f;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        audioSource.Play();
>>>>>>> 9bcd32e890cb1bb5fe29dd3fb1d583d0d5fb61e1
>>>>>>> dfe8766cead11049eeee8ef5ebce95b65ab53731
        audioSource.priority = 0;
    }

    void LoadNote(Song sn)
    {
        if (difficulty == 0)
        {
            notelist = (int[,]) sn.ListEasy.Clone();
        }
        else if(difficulty == 1)
        {
            notelist = (int[,])sn.ListNormal.Clone();
        }
        else
        {
            notelist = (int[,])sn.ListHard.Clone();
        }
        Debug.Log(notelist[0,0]);
    }
    void RandomNote()
    {
        MakeNote(UnityEngine.Random.Range(0, noteNum), UnityEngine.Random.Range(0, noteNum + 1));
    }

    void MakeNote(int noteLocation, int noteColor)
    {
        GameObject tmpNote = Instantiate(notePrefab, new Vector3(notePosx[noteLocation], notePosY, 0), Quaternion.identity) as GameObject;
        tmpNote.GetComponent<Note>().SetColor((Note.Note_Color)noteColor);
        tmpNote.GetComponent<Note>().noteLocation = (Note.Note_Location)noteLocation;
    } 
    public void Quit(string next_scene)
    {
        SceneManager.LoadScene(next_scene);
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        //audioSource.Stop();
        audioSource.Pause();
    }
    public void ReStart()
    {
        Time.timeScale = 1.0f;
        audioSource.UnPause();
    }
    public void OnClick(int buttonLocation)
    {
        if (bottomNote[buttonLocation] != null)
        {
            bottomNote[buttonLocation].GetComponent<Note>().AddScore(bottomNote[buttonLocation].GetComponent<Note>().noteState, 
                bottomNote[buttonLocation].GetComponent<Note>().matchColor(buttons[buttonLocation]));
        }
    }
    public void ToLeftButton()
    {
        for(int i = 0; i < noteNum; ++i)
        {
            buttons[i].gameObject.GetComponent<NoteButton>().ToLeftButton();
        }
    }
    public void ToRightButton()
    {
        for (int i = 0; i < noteNum; ++i)
        {
            buttons[i].gameObject.GetComponent<NoteButton>().ToRightButton();
        }
    }
}