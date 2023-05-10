using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    private List<GameObject> _kunaiList = new List<GameObject>();
    public int amoutToPool;
    // public Transform firePoint;
    public GameObject _kunaiPrefabs;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start() {
        Init();
    }
    private void Init(){
        for(int i = 0; i < amoutToPool; i++) {
            GameObject kunai = Instantiate(_kunaiPrefabs);
            kunai.SetActive(false);
            _kunaiList.Add(kunai);
        }
    }
    public GameObject GetPooledKunai(){
        for(int i = 0; i < _kunaiList.Count; i++) {
            if(!_kunaiList[i].activeInHierarchy)
            {
                return _kunaiList[i];
            }
        }
        return null;
    }
}
