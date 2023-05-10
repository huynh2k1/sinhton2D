using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinPanel : MonoBehaviour
{
    public Text killedText;
    public Text goldText;
    public Text rubyText;
    private void Update() {
        UpdateStat();
    }
    private void UpdateStat(){
        killedText.text = "Killed: " + UIGameManager.instance.killed.ToString("00");
        goldText.text = "Gold: " + UIGameManager.instance.gold.ToString("00");
        rubyText.text = "Ruby: " + UIGameManager.instance.ruby.ToString("00");
    }
    public void HomeButton()
    {
        UIGameManager.instance.ResumeButton();
        SceneManager.LoadScene("MainMenu");
    }
    public void ReStartButton(){
        UIGameManager.instance.ResumeButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
