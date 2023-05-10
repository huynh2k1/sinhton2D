using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _name;
    [SerializeField] Text _attack;
    [SerializeField] Text _health;
    [SerializeField] Text _price;
    public Button _button;
    public BaseItem _item;

    private void Start() {
        _button = GetComponent<Button>();
    }
    public BaseItem Item{
        get{
            return _item;
        }
        set{
            _item = value;
            if(_item == null)
            {
                _image.enabled = false;
                _price.enabled = false;
                _attack.enabled = false;
                _health.enabled = false;
            }
            else{
                _image.sprite = _item.itemImage;
                _image.enabled = true;
                
                _name.text = _item.itemName;
                _name.enabled = true;

                _attack.text = "ATK + " + _item.AttackBonus.ToString();
                _attack.enabled = true;

                _health.text = "HP + " + _item.HealthBonus.ToString();
                _health.enabled = true;

                _price.text = _item.Price.ToString();
                _price.enabled = true;
            }
        }
    }
    protected virtual void OnValidate() {
        if(_image == null)
        {
            _image = GetComponent<Image>();
        }    
    }
}
