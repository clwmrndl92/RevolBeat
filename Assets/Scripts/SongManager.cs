using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum State
{
    Loading,
    Play,
    Pause,
    End
}


public class SongManager : GameManager
{
    public static SongManager songManager = null;

    public State state = State.Loading;
    public GameObject notePrefab;
    public float noteSpeed = 100;
    public float noteInterval = 10;
    public GameObject[] notePanels;
    public GameObject[] buttons;
    public Color[] noteColors;
    public Text scoreText, comboText;
    public GameObject background;

    public static Song selectedSong = null;
    public static int score = 0;
    public static int combo = 0;
    public static int[] noteScores = new int[5];
    public static GameObject[] bottomNote;
    public static float[] notePosx;
    public static int noteNum;

    float timer, notePosY,tmptimer = 0;

    // Start is called before the first frame update
    void Awake()
    {
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
        Loading();
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
        if (state == State.Play)
        {
            timer += Time.deltaTime;
            tmptimer += Time.deltaTime;
            Debug.Log(tmptimer);
            if (timer > noteInterval/10)
            {
                RandomNote();
                timer = 0;
            }
            if (tmptimer > 50)
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
        LoadSong(selectedSong);
        state = State.Play;
    }

    void LoadSong(Song song)
    {
        score = 0;
        combo = 0;
        for(int i = 0; i < 5; ++i)
        {
            noteScores[i] = 0;
        }
        background.GetComponent<SpriteRenderer>().sprite = song.cover;
    }


    void RandomNote()
    {
        MakeNote(Random.Range(0, noteNum), Random.Range(0, noteNum + 1));
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
    }
    public void ReStart()
    {
        Time.timeScale = 1.0f;
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