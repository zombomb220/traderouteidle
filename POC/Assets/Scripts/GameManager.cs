using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour {

    private static GameManager Instance;

    private const int _numPlanets = 3;
    private List<PlanetData> _data;
    private static int _numResources = Enum.GetNames(typeof(Resource.ResourceTypes)).Length;
    
    public static Random Rand = new Random();

    public struct PlanetData {
        
        public Resource.ResourceTypes type;
        public float SellPrice;
        public float BuyPrice;
        public int Inventory;

        public PlanetData(Resource.ResourceTypes type, float sellPrice, float buyPrice, int inventory) {
            this.type = type;
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
            Inventory = inventory;
        }
    }
    
    public static int planetIndex = 0;

    //Instance Data:
    private List<Planet> _planets;



    void Awake() {
        // If there's already a GameManager, destroy this one
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
        }

        _planets = new List<Planet>();
    }

    void Start() {

        _data = new List<PlanetData>();

        _data.Add(new PlanetData(Resource.ResourceTypes.FOOD, 3.2f, 3.0f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.FOOD, 4.0f, 3.6f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.FOOD, 3.0f, 2.9f, 100000));

        _data.Add(new PlanetData(Resource.ResourceTypes.WATER, 2.0f, 1.0f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.WATER, 2.5f, 1.2f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.WATER, 2.2f, 1.1f, 100000));

        _data.Add(new PlanetData(Resource.ResourceTypes.MEDICAL, 15.2f, 15.0f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.MEDICAL, 16.0f, 15.5f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.MEDICAL, 14.8f, 17.5f, 100000));

        _data.Add(new PlanetData(Resource.ResourceTypes.POWER, 30.0f, 27.5f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.POWER, 26.0f, 36.0f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.POWER, 31.2f, 33.5f, 100000));

        _data.Add(new PlanetData(Resource.ResourceTypes.TECHNOLOGY, 100.0f, 90.6f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.TECHNOLOGY, 95.8f, 92.5f, 100000));
        _data.Add(new PlanetData(Resource.ResourceTypes.TECHNOLOGY, 105.5f, 110.5f, 100000));

    }

    public static void RegisterPlanet(Planet p) {

        Instance._planets.Add(p);

        for (var i = 0; i < _numResources; i++) {
            var x = i*_numPlanets + planetIndex;

            p.Market.AddResourceToMarket(Instance._data[x]);
        }

        planetIndex++;
    }

    public static List<Planet> GetPlanetsRef() {
        return Instance._planets;
    }
}