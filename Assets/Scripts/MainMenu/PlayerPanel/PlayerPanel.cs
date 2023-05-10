using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPanel : MonoBehaviour
{
    public GameObject[] characters;
    public Button nextButton;
    public Button backButton;
    private int index;
    private void Awake() {
        nextButton.onClick.AddListener(NextButton);
        backButton.onClick.AddListener(BackButton);
    }
    private void Start() {
        index = Prefs.PlayerSelected;
        SelectedPlayer();
    }
    public void BackButton()
    {
        if(index > 0)
        {
            index--;
            Prefs.PlayerSelected = index;
        }
        SelectedPlayer();
    }
    public void NextButton()
    {
        if(index < characters.Length - 1)
        {
            index++;
            Prefs.PlayerSelected = index;
        }
        SelectedPlayer();
    }
    private void SelectedPlayer(){
        for(int i = 0; i < characters.Length; i++) {
            if(i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                
            }
            else{
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;

            }

        }
    }
}
