using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _money = 5;

    private Ship _myShip;

    private List<Planet> _planets;
    private Planet _currentPlanet;
    private Planet _destinationPlanet;

	// Use this for initialization
	void Start () {
	    _planets = GameManager.GetPlanetsRef();


	    _destinationPlanet = null;

	}
    
    // Update is called once per frame
    void Update () {
	
	}


    public void TravelToPlanet(Planet newPlanet) {
        transform.position = newPlanet.transform.position;
    }
}
