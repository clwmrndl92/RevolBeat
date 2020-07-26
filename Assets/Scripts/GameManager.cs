using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Difficulty = 3;
    public static GameManager instance = null;

    public void changeScene(string next_scene)
    {
        SceneManager.LoadScene(next_scene);
    }
    
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
}
