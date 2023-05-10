using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIHomeManager : MonoBehaviour
{
    public static UIHomeManager instance;
    public BasePopup InforPanel;
    public Button InforButton;
    public BasePopup LevelPanel;
    public Button PlayButton;
    public BasePopup ShopPanel;
    public Button ShopButton;
    public BasePopup GuidePanel;
    public Button GuideButton;
    public BasePopup PlayerPanel;
    public Button PlayerButton;
    public BasePopup SettingPanel;
    public Button SettingButton;

    public Text goldText;
    public Text rubyText;
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
        InforButton.onClick.AddListener(ShowInfor);
        PlayButton.onClick.AddListener(PlayGame);
        ShopButton.onClick.AddListener(ShowShop);
        GuideButton.onClick.AddListener(ShowGuide);
        PlayerButton.onClick.AddListener(ShowPlayer);
        SettingButton.onClick.AddListener(ShowSetting);
    }
    private void Start() {
        UpdateGold();
        UpdateRuby();
        if(_curPopup)
        {
            _curPopup.Show(false);
        }
    }

    public void UpdateGold()
    {
        goldText.text = "x " + Prefs.Gold.ToString();
    }
    public void UpdateRuby(){
        rubyText.text = "x " + Prefs.Ruby.ToString();
    }
    public void ShowInfor(){
        if(InforPanel)
        {
            InforPanel.Show(true);
            _curPopup = InforPanel;

        }
    }
    public void ShowShop(){
        if(ShopPanel)
        {
            ShopPanel.Show(true);
            _curPopup = ShopPanel;
        }
    }
    public void ShowGuide(){
        if(GuidePanel)
        {
            GuidePanel.Show(true);
            _curPopup = GuidePanel;
        }
    }
    public void ShowPlayer(){
        if(PlayerPanel)
        {
            PlayerPanel.Show(true);
            _curPopup = PlayerPanel;
        }
    }
    public void ShowSetting()
    {
        if(SettingPanel)
        {
            SettingPanel.Show(true);
            _curPopup = SettingPanel;
        }
    }
    public void CloseButton(){
        if(_curPopup)
        {
            AudioManager.instance.PlaySFX("Click");
            _curPopup.Show(false);
        }
    }

    public void PlayGame(){
        if(LevelPanel)
        {
            LevelPanel.Show(true);
            _curPopup = LevelPanel;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
