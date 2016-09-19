using System;
using UnityEngine;
using System.Collections.Generic;

public class UI_Market : MonoBehaviour {

    [SerializeField] private RectTransform _content;

    [SerializeField] private Vector3 _startingPos;
    [SerializeField] private Vector3 _verticalAdjustment;

    [SerializeField] private Planet _currentPlanet;
    [SerializeField] private List<GameObject> _resources;
    [SerializeField] private GameObject _resourcePrefab;
    

	void Start () {
        
        _currentPlanet = null;
        
        for (int i = 0; i < Enum.GetNames(typeof (Resource.ResourceTypes)).Length ; i++) {

            _resources.Add(Instantiate(_resourcePrefab, _content.position + _startingPos + (_verticalAdjustment*i), Quaternion.identity, _content) as GameObject);
            var r = _resources[i].GetComponent<UI_Resource>();
            r.Create(Enum.GetNames(typeof(Resource.ResourceTypes))[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    public void Show() { }


}
