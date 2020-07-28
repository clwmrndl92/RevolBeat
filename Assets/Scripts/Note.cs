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
    public enum Tile_State
    {
        Perfect,
        Great,
        Good,
        Miss
    }
    public bool isFall = true;
    public bool isTouch = false;

    Transform target;
    SpriteRenderer targetRender;

    Tile_State tileState = Tile_State.Miss;
    Note_Color color = Note_Color.White;
    GameObject prevNote = null, nextNote = null;

    private void Awake()
    {
        prevNote = SongManager.rescentNote;
        target = GetComponent<Transform>();
        targetRender = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        targetRender.color = SongManager.noteColors[(int)this.color];
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            noteFall();
        }
    }

    void noteFall()
    {
        target.Translate(new Vector3(0, (-1) * SongManager.NoteSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Touch")
        {
            isTouch = true;
        }
        else if (collision.tag == "Good")
        {
            tileState = Tile_State.Good;
        }
        else if (collision.tag == "Great")
        {
            tileState = Tile_State.Great;
        }
        else if (collision.tag == "Perfect")
        {
            tileState = Tile_State.Perfect;
        }
        else if(collision.tag == "Destroy" && prevNote == null)
        {
            destroyTile();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Perfect")
        {
            tileState = Tile_State.Great;
        }
        else if (collision.tag == "Great")
        {
            tileState = Tile_State.Good;
        }
        else if (collision.tag == "Good")
        {
            tileState = Tile_State.Miss;
        }
    }

    public void setColor(Note_Color color)
    {
        this.color = color;
    }
    public void setNext(GameObject next)
    {
        nextNote = next;
    }
    public void destroyPrev()
    {
        prevNote = null;
    }
    public void addScore()
    {
        if(tileState == Tile_State.Perfect)
        {
            SongManager.combo++;
            SongManager.score += 10;
        }
        else if (tileState == Tile_State.Great)
        {
            SongManager.combo++;
            SongManager.score += 5;
        }
        else if (tileState == Tile_State.Good)
        {
            SongManager.combo++;
            SongManager.score += 1;
        }
        else if (tileState == Tile_State.Miss)
        {
            SongManager.combo = 0;
        }
    }
    public void destroyTile()
    {
        addScore();
        if (nextNote != null)
        {
            nextNote.GetComponent<Note>().destroyPrev();
            SongManager.bottomNote = nextNote;
        }
        else
        {
            SongManager.rescentNote = null;
            SongManager.bottomNote = null;
        }
        Destroy(gameObject);
    }
}
