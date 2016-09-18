using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private static Player Instance;

    [SerializeField]
    private float _money = 5;
	public static float CurrentBalance(){
		return Instance._money;
	}

    [SerializeField] private List<Ship> _myShip;

    private List<Planet> _planets;

	// Use this for initialization
	void Start () {

		if (Instance != null && Instance != this) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
		}

	    _planets = GameManager.GetPlanetsRef();

		GameManager.Events.RegisterSubscription (GameEventNames.Tick, OnTick);
		GameManager.Events.RegisterSubscription (GameEventNames.OnPlanetDestinationUpdate, OnPlanetDestinationUpdate);


	}
    
	public void OnPlanetDestinationUpdate(object e){
		var d = (Planet.Events.OnPlanetDestinationUpdate)e;
		_myShip [0].OnDestinationUpdate (d.planetID);
	}

	public void OnTick(object e){
		_money += .1f;
	}


    public void TravelToPlanet(Planet newPlanet) {
        transform.position = newPlanet.transform.position;
    }

	/// <summary>
	/// Spends  money.
	/// </summary>
	/// <param name="amount">Amount.</param>
	public static void WithdrawMoney(float amount){
		if (amount <= Instance._money) {
			Instance._money -= amount;
			Debug.Log ("Money = " + Instance._money);
		} else
			throw new UnityException ("Shouldn't get this far... Need to make sure to check if player has enough money first before using this method");
	}

	public static void DepositMoney(float amount){
		Instance._money += amount;
	}

	public static bool CanAfford(float cost){
		return cost <= Instance._money;
	}
}
