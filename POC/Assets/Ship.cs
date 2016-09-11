using UnityEngine;

public class Ship : MonoBehaviour {

	[SerializeField] CargoHold _hold;
	[SerializeField] Planet _currentLocation;
	private Planet _previousPlanet;
	[SerializeField] Resource.ResourceTypes _buyType;
	[SerializeField] bool _toggleBuy;
	bool _toggleBuyLastState;
	[SerializeField] bool _toggleSell;
	bool _toggleSellLastState;

	[SerializeField] int _buyAmount = 1;

	//Starting Values
	[SerializeField] int _startingCargoSize = 5;    
	[SerializeField] private float _speed;
	[SerializeField] private float _fuelCost;



    // Use this for initialization
    void Start () {
		_hold = new CargoHold (_startingCargoSize);
    }
	
	// Update is called once per frame
	void Update () {
		
		if (_toggleBuy != _toggleBuyLastState) {
			_toggleBuyLastState = _toggleBuy;
			OnBuy ();
		}

		if (_toggleSell != _toggleSellLastState) {
			_toggleSellLastState = _toggleSell;
			OnSell ();
		}

		if (_previousPlanet != _currentLocation) {

			float step = _speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, _currentLocation.transform.position, step);

			if(Vector3.Distance(transform.position, _currentLocation.transform.position) < .01f)
				_previousPlanet = _currentLocation;

		}
	}

	private void OnBuy(){

		if ((_buyAmount + _hold._currentInventory) > _hold._maxCargoHold) {
			Debug.Log ("No more room in the cargo hold!");
			return;
		}

		var contract = _currentLocation.Market.PriceCheck (_buyType, _buyAmount);

		if (Player.CanAfford (contract.TotalPrice ())) {
			_currentLocation.Market.AcquireResourceFromMarket (ref contract);
			_hold.StoreCargo (contract.rType, contract.orderQty);
			Player.WithdrawMoney (contract.TotalPrice ());

		} else {
			Debug.Log ("Can't afford that!");
		}

	}


	private void OnSell(){
		
		var cargo = _hold.RetrieveCargo ();
		if (cargo != null) {
			Player.DepositMoney (_currentLocation.Market.SellResourcesToMarket (cargo.ResourceType, cargo.NumInventory) );
		} else
			Debug.Log ("nothing to sell!");
	}


	public void OnDestinationUpdate(int newPlanetID){
		_currentLocation = GameManager.GetPlanetByID(newPlanetID);
	}

}
