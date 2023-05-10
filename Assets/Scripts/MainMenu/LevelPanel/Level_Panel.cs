using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Panel : MonoBehaviour
{
    public List<ButtonLevel>  listButtonLevels;

    public void Start()
    {
        InitAllLevel();
    }
    public void InitAllLevel()
    {
        for(int i = 0; i < listButtonLevels.Count; i++) { 
        
            listButtonLevels[i].Init(i+1);
        }
    }
}
