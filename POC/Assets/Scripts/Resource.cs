using System;

public class Resource {
    public enum ResourceTypes {
        FOOD,
        MEDICAL,
        WATER,
        TECHNOLOGY,
        POWER
    };

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private string _name;

    public ResourceTypes ResourceType { get; private set; }
    private readonly ResourceTypes _resourceType;

    public float PlanetSellPrice {
        get { return _planetSellPrice; }
        set { _planetSellPrice = value; }
    }
    private float _planetSellPrice;

    public float PlanetBuyPrice
    {
        get { return _planetBuyPrice; }
        set { _planetBuyPrice = value; }
    }
    private float _planetBuyPrice;

    public float StartingPrice
    {
        get { return _startingPrice; }
        set { _startingPrice = value; }
    }
    private float _startingPrice;

    public int Inventory
    {
        get { return _inventory; }
        set { _inventory = Math.Max(0, value); }
    }
    private int _inventory;

    public Resource(ResourceTypes type, float startingPrice, float planetBuyPrice, int startingInventory) {

        ResourceType = type;
        Name = type.ToString();
        PlanetSellPrice = StartingPrice = startingPrice;
        PlanetBuyPrice = planetBuyPrice;
        Inventory = startingInventory;
    }

    /// <summary>
    /// Removes resources from market, and returns the amount of successfully purchased resources
    /// </summary>
    /// <param name="numSold"></param>
    /// <returns>How many were successfully sold</returns>
    public int RemoveResources(int numSold) {

        if (Inventory < numSold) {
            var r = Inventory;
            Inventory = 0;
            return r;
        }

        Inventory -= numSold;

        //TODO: Adjust price

        return numSold;
    }

    public void AddResource(int numPurchased) {

        Inventory += numPurchased;
        //TODO: Adjust price..
    }
}