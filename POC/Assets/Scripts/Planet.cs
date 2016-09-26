using System.Collections.Generic;
using UnityEngine;

public class Planet : ObjectID {

    [SerializeField] private GameObject _uiAnchor;

	private bool _isSelected = false;


    private PlanetMarket _market;
    public PlanetMarket Market {
        get { return _market; }
        set { _market = value; }
    }

    void Start() {
        Market = new PlanetMarket();
        GameManager.RegisterPlanet(this);

		GameManager.Events.RegisterSubscription (GameEventNames.OnPlanetSelected, OnPlanetSelected);
    }


	public void OnPlanetSelected(object ed){
		var e = ed as Planet.Events.OnPlanetSelected ;
		if (e != null) {
			if (e.planetID == GetID ()) {
				//This planet is selected. 

				if (_isSelected) {
					//double clicked, send currently selected ship here

					var d = new Events.OnPlanetDestinationUpdate { planetID = GetID()};
					GameManager.Events.CallEvent (GameEventNames.OnPlanetDestinationUpdate, d);

				} else {
                    //selection updated. 
                    OnSelected(true, e.planetID);
                    
                }


            } else {
			    OnSelected(false, e.planetID);
			}
		} else {
			Debug.Log ("Name: " + name + ". Event was null!");
		}
	}

    private void OnSelected(bool isSelected, int id = -20) {
        _isSelected = isSelected;

        if (_isSelected) {            
            UIManager.UpdateMarketUI(_uiAnchor.transform.position, _market.Resources);
        }
        else {
            if(id < 0)
                UIManager.HideMarketUI();
        }
    }

    public class Events{
		public class OnPlanetSelected {
			public int planetID;
		}
		public class OnPlanetDestinationUpdate{
			public int planetID;
		}
	}
}