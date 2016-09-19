using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Resource : MonoBehaviour {


    [SerializeField] private Text _resourceText;
    [SerializeField] private Text _buyText;
    [SerializeField] private Text _sellText;

    private Resource.ResourceTypes _resourceType;
    private float _buyCost;
    private float _sellCost;
    
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }



    public void Create(string resourceType) {
        _resourceType = (Resource.ResourceTypes)Enum.Parse(typeof(Resource.ResourceTypes), resourceType);
        _resourceText.text = _resourceType.ToString();
    }

    public void LoadInfo(float buyCost, float sellCost) {

        _buyCost = buyCost;
        _buyText.text = _buyCost.ToString();

        _sellCost = sellCost;
        _sellText.text = _sellCost.ToString();
    }

    public void OnBuy() {


    }

    public void OnSell() {


    }



}
