using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager :MonoBehaviour
{
    public Text Score, Combo;
    public Text[] Scores;
    public Text Result;
    public Text songName;
    public Text songComposer;
    public Image songCover;
    public float average;
    // Start is called before the first frame update
    private void Start()
    {
        string result;
        for(int i = 0; i < Scores.Length; ++i)
        {
            Scores[i].text = SongManager.noteScores[i].ToString();
        }
        Combo.text = SongManager.noteScores[Scores.Length].ToString();
        average = SongManager.score / SongManager.selectedSong.notenum[SongManager.difficulty];
        if(average >= 120)
        {
            result = "S";
        }
        else if (average >= 100)
        {
            result = "A";
        }
        else if (average >= 80)
        {
            result = "B";
        }
        else if (average >= 40)
        {
            result = "C";
        }
        else if (average > 0)
        {
            result = "D";
        }
        else
        {
            result = "F";
        }

        Score.text = SongManager.score.ToString();
        Result.text = result;
        songName.text = SongManager.selectedSong.name;
        songComposer.text = SongManager.selectedSong.composer;
        songCover.sprite = SongManager.selectedSong.cover;
    }
}
