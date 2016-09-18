using UnityEngine;

public class Planet : ObjectID {

    private TextMesh _text;
	private string _marketText;
	private bool _isSelected = false;

    private PlanetMarket _market;
    public PlanetMarket Market {
        get { return _market; }
        set { _market = value; }
    }

    void Start() {
        Market = new PlanetMarket();
        GameManager.RegisterPlanet(this);

        _marketText = "";

        foreach (var resource in Market.Resources) {

            _marketText += "S: " + resource.SellPrice + "\t\t\tB: " + resource.BuyPrice + " : " + resource.Name + "\n";

        }

        _text = GetComponentInChildren<TextMesh>();

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
					_isSelected = true;
					_text.text = _marketText;
				}


			} else {
				_isSelected = false;
				_text.text = "";
			}
		} else {
			Debug.Log ("Name: " + name + ". Event was null!");
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