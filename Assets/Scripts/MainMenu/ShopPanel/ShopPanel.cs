using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopPanel : MonoBehaviour
{
    public Button itemButton;
    public Button randomButton;

    public GameObject itemMenuPanel;
    public GameObject randomMenuPanel;
    private void Awake() {
        itemButton.onClick.AddListener(ShowItemMenu);
        randomButton.onClick.AddListener(ShowRandomMenu);
    }
    private void Start() {
        itemMenuPanel.SetActive(true);
        randomMenuPanel.SetActive(false);
    }
    public void ShowItemMenu(){
        itemMenuPanel.SetActive(true);
        randomMenuPanel.SetActive(false);
    }
    public void ShowRandomMenu(){
        randomMenuPanel.SetActive(true);
        itemMenuPanel.SetActive(false);
    }

}
