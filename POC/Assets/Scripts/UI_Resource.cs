using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Resource : MonoBehaviour {


    [SerializeField]
    public Text _resourceText;
    [SerializeField]
    public Text _buyText;
    [SerializeField]
    public Text _sellText;

    public Resource.ResourceTypes _resourceType;
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
		
		GameManager.Events.CallEvent (GameEventNames.OnBttn_MarketBuy, new Events.OnBttnBuySell{
			rType = _resourceType, 
			Amt = 1,
			Price = _buyCost
		});

    }

    public void OnSell() {

		GameManager.Events.CallEvent (GameEventNames.OnBttn_MarketSell, new Events.OnBttnBuySell{
			rType = _resourceType,
			Amt = 1,
			Price = _sellCost
		});
    }


	public class Events {
		public class OnBttnBuySell{
			public Resource.ResourceTypes rType;
			public int Amt;
			public float Price;
		}
	}
}
