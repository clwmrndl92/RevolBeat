using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool _pressed = false;
    bool _up = false;
    public Note.Note_Color buttonColor;
    public Note.Note_Location buttonLocation;
    public GameObject yellowEffect;
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("버튼이 눌려지고 있음");
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("버튼 눌림이 해제됨");
        _up = true;
    }
    // Use this for initialization
        void Start()
    {
        ChangeButtonColor(buttonColor);
        gameObject.transform.position = new Vector3(SongManager.notePosx[(int)buttonLocation], gameObject.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_up)
        {
            yellowEffect.GetComponent<FadeOutAnim>().EffectOff();
            _up = false;
            _pressed = false;
        }
        if (_pressed)
        {
            yellowEffect.GetComponent<FadeOutAnim>().resetEffect();
        }
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
    public void ButtonDown()
    {
        _pressed = true;
    }
    public void ButtonUp()
    {
        _up = true;
    }
}

