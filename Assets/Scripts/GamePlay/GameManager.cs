using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> listLevels;
    public List<GameObject> listPlayers;
    private void OnValidate() {
    }
    private void Awake() {
        instance = this;
    }
    private void Start() {
        listLevels[Prefs.LevelSelected - 1].SetActive(true);
        listPlayers[Prefs.PlayerSelected].SetActive(true);
        AudioManager.instance.musicSource.Stop();
    }
    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Win(){
        StartCoroutine(UIGameManager.instance.WinGame());
    }
    public void Lose(){
        StartCoroutine(UIGameManager.instance.LoseGame());
    }
}
