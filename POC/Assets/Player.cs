using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private static Player Instance;

    [SerializeField]
    private float _money = 5;

    private List<Ship> _myShip;

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

	}
    
    // Update is called once per frame
    void Update () {
	
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
		Debug.Log ("Money = " + Instance._money);
	}

	public static bool CanAfford(float cost){
		return cost <= Instance._money;
	}
}
