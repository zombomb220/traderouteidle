using System;
using UnityEngine;
using System.Collections.Generic;

public class UI_Market : MonoBehaviour {

    [SerializeField] private RectTransform _content;

    [SerializeField] private Vector3 _startingPos;
    [SerializeField] private Vector3 _verticalAdjustment;

    [SerializeField] private Planet _currentPlanet;
    [SerializeField] private List<GameObject> _resourcesGameObjects;
    [SerializeField] private List<UI_Resource> _resources;
    [SerializeField] private GameObject _resourcePrefab;
    
    void Start () {
        
        _currentPlanet = null;
        
        for (int i = 0; i < Enum.GetNames(typeof (Resource.ResourceTypes)).Length ; i++) {

            _resourcesGameObjects.Add(Instantiate(_resourcePrefab, _content.position + _startingPos + (_verticalAdjustment*i), Quaternion.identity, _content) as GameObject);
            var r = _resourcesGameObjects[i].GetComponent<UI_Resource>();
            r.Create(Enum.GetNames(typeof(Resource.ResourceTypes))[i]);
            _resources.Add(r);
        }

        gameObject.SetActive(false);
    }
	

    public void Show(List<Resource> data) {
        
        for (int i = 0; i < data.Count; i++) {
            var d = data[i];

            foreach (var r in _resources) {
                if (r._resourceType == d.ResourceType) {
                    r._buyText.text = d.BuyPrice.ToString();
                    r._sellText.text = d.SellPrice.ToString();
                }
            }
        }

        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
