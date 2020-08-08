using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Note : MonoBehaviour
{
    public enum Note_Color
    {
        Blue, 
        Green,
        Orange,
        White
    }
    public enum Note_State
    {
        Perfect,
        Great,
        Good,
        Miss
    }
    public enum Note_Location
    {
        Left,
        Center,
        Right
    }
    public bool isFall = true;
    public bool isTouch = false;

    Transform target;
    SpriteRenderer targetRender;

    public Note_State noteState = Note_State.Miss;
    public Note_Location noteLocation = Note_Location.Center;
    Note_Color color = Note_Color.White;

    private void Awake()
    {
        target = GetComponent<Transform>();
        targetRender = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        targetRender.color = SongManager.songManager.noteColors[(int)this.color];
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            NoteFall();
        }
    }

    void NoteFall()
    {
        target.Translate(new Vector3(0, (-1) * SongManager.songManager.noteSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Touch")
        {
            isTouch = true;
            SongManager.bottomNote[(int)noteLocation] = gameObject;
        }
        else if (collision.tag == "Good")
        {
            noteState = Note_State.Good;
        }
        else if (collision.tag == "Great")
        {
            noteState = Note_State.Great;
        }
        else if (collision.tag == "Perfect")
        {
            noteState = Note_State.Perfect;
        }
        else if(collision.tag == "Destroy")
        {
            AddScore(Note_State.Miss, false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Perfect")
        {
            noteState = Note_State.Great;
        }
        else if (collision.tag == "Great")
        {
            noteState = Note_State.Good;
        }
        else if (collision.tag == "Good")
        {
            noteState = Note_State.Miss;
        }
    }

    public void SetColor(Note_Color color)
    {
        this.color = color;
    }
    public void AddScore(Note_State state, bool colorMatch)
    {
        if (colorMatch)
        {
            if (state == Note_State.Perfect)
            {
                SongManager.combo++;
                SongManager.score += 150;
            }
            else if (state == Note_State.Great)
            {
                SongManager.combo++;
                SongManager.score += 100;
            }
            else if (state == Note_State.Good)
            {
                SongManager.combo=0;
                SongManager.score += 50;
            }
            else if (state == Note_State.Miss)
            {
                SongManager.combo = 0;
                SongManager.score -= 0;
            }
        }
        else
        {
            if (color == Note_Color.White)
            {
                if (state == Note_State.Perfect)
                {
                    SongManager.combo++;
                    SongManager.score += 150;
                }
                else if (state == Note_State.Great)
                {
                    SongManager.combo++;
                    SongManager.score += 100;
                }
                else if (state == Note_State.Good)
                {
                    SongManager.combo =0;
                    SongManager.score += 50;
                }
                else if (state == Note_State.Miss)
                {
                    SongManager.combo = 0;
                    SongManager.score -= 0;
                }
            }
            else
            {
                SongManager.combo = 0;
                SongManager.score -= 0;
                state = Note_State.Miss;
            }
        }
        SongManager.noteScores[(int)state] += 1;
        if(SongManager.noteScores[4] < SongManager.combo)
        {
            SongManager.noteScores[4] = SongManager.combo;
        }
        Destroy(gameObject);
    }
    public bool matchColor(GameObject button)
    {
        if(button.GetComponent<NoteButton>().buttonColor == color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
