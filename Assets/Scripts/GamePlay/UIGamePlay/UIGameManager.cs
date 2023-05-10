using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGameManager : MonoBehaviour
{
    
    public static UIGameManager instance;
    public Text timeText;
    public Text hpText;
    public Text atkText;
    public int killed;
    public int gold;
    public int ruby;
    public Text killedText;
    public Text goldText;
    public Text rubyText;

    public BasePopup pausePopup;
    public Button pauseButton;
    public BasePopup winPopup;
    public BasePopup losePopup;
    private BasePopup _curPopup;
    public BasePopup CurPopup{
        get => _curPopup;
        set => _curPopup = value;
    }

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        pauseButton.onClick.AddListener(PauseGame);
    }
    private void Start() {
        killed = 0;
        gold = 0;

        UpdateStat();
    }
    public void PauseGame(){
        Time.timeScale = 0f;
        if(pausePopup){
            pausePopup.Show(true);
            _curPopup = pausePopup;
        }
    }
    public void ResumeButton(){
        if(_curPopup)
        {
            _curPopup.Show(false);
            Time.timeScale = 1f;
        }
    }
    public void UpdateTime(string time)
    {
        timeText.text = time;
    }
    public void UpdateStat(){
        killedText.text = "x " + killed.ToString("00");
        goldText.text = "x " + gold.ToString("00");
        rubyText.text = "x " + ruby.ToString("00");
    }
    public IEnumerator WinGame(){

        if(winPopup)
        {
            yield return new WaitForSeconds(1f);
            winPopup.Show(true);
            _curPopup = winPopup;
            Prefs.Gold += gold;
            Prefs.Ruby += ruby;
            AudioManager.instance.PlaySFX("Win");
        }
    }
    public IEnumerator LoseGame(){

        if(losePopup)
        {
            yield return new WaitForSeconds(1f);
            losePopup.Show(true);
            _curPopup = losePopup;
            Prefs.Gold += gold;
            Prefs.Ruby += ruby;
        }
    }
    public void ResetStat()
    {
        killed = 0;
        gold = 0;
        ruby = 0;
    }
}
