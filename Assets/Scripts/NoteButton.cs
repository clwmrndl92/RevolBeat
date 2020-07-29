using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButton : MonoBehaviour
{
    public Note.Note_Color buttonColor;
    public Note.Note_Location buttonLocation;
    // Start is called before the first frame update
    void Start()
    {
        ChangeButtonColor(buttonColor);
        gameObject.transform.position = new Vector3(SongManager.notePosx[(int)buttonLocation], gameObject.transform.position.y, 0);
    }
    public void ChangeButtonColor(Note.Note_Color color)
    {
        gameObject.GetComponent<Image>().color = SongManager.songManager.noteColors[(int)color];
        buttonColor = color;
    }
    public void ToLeftButton()
    {
        ChangeButtonColor ((Note.Note_Color) (((int)buttonColor + 1) % SongManager.noteNum));
    }
    public void ToRightButton()
    {
        ChangeButtonColor((Note.Note_Color)(((int)buttonColor + SongManager.noteNum - 1) % SongManager.noteNum));
    }
}
