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
    public State state = State.Loading;
    public GameObject notePrefab;
    public float setNoteSpeed = 100;
    public float noteInterval = 10;
    public GameObject[] notePanels;
    public Color[] setNoteColors;
    public Text scoreText;

    public static Color[] noteColors;
    public static int score = 0;
    public static int combo = 0;
    public static float NoteSpeed;
    public static GameObject rescentNote = null;
    public static GameObject bottomNote = null;

    static int noteNum;
    float timer, notePosY;
    float[] notePosx;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 0.0f;
        NoteSpeed = setNoteSpeed;
        noteNum = notePanels.Length;
        notePosx = new float[noteNum];
        noteColors = new Color[noteNum+1];
        for(int i = 0; i < noteNum; ++i)
        {
            notePosx[i] = notePanels[i].transform.position.x;
            noteColors[i] = setNoteColors[i];
        }
        noteColors[noteNum] = new Color(255, 255, 255, 255);
        notePosY = notePanels[0].transform.position.y;
    }
    void Start()
    {
        loading();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Play)
        {
            timer += Time.deltaTime;
            if (timer > noteInterval/10)
            {
                randomNote();
                timer = 0;
            }
            scoreText.text = score.ToString();
        }
    }

    int loading()
    {
        state = State.Play;
        return 0;
    }

    void randomNote()
    {
        System.Random random = new System.Random();
        GameObject tmpNote = Instantiate(notePrefab, new Vector3(notePosx[Random.Range(0, noteNum)], notePosY, 0), Quaternion.identity) as GameObject;
        if (rescentNote != null)
        {
            rescentNote.GetComponent<Note>().setNext(tmpNote);
        }
        else
        {
            bottomNote = tmpNote;
        }
        rescentNote = tmpNote;
        System.Array values = System.Enum.GetValues(typeof(Note.Note_Color));
        Note.Note_Color randomColor = (Note.Note_Color)values.GetValue(random.Next(values.Length));
        tmpNote.GetComponent<Note>().setColor(randomColor);
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
    public void OnClick()
    {
        if (bottomNote != null && bottomNote.GetComponent<Note>().isTouch)
        {
            bottomNote.GetComponent<Note>().destroyTile();
        }
    }
}
