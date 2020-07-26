using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoSelect : MonoBehaviour
{
    public void MoveSel(string next_scene)
    {
        GameManager.instance.changeScene(next_scene);
    }
}
