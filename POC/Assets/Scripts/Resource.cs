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

    public float SellPrice {
        get { return _sellPrice; }
        set { _sellPrice = value; }
    }
    private float _sellPrice;

    public float BuyPrice
    {
        get { return _buyPrice; }
        set { _buyPrice = value; }
    }
    private float _buyPrice;

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

    public Resource(ResourceTypes type, float startingPrice, float buyPrice, int startingInventory) {

        ResourceType = type;
        Name = type.ToString();
        SellPrice = StartingPrice = startingPrice;
        BuyPrice = buyPrice;
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