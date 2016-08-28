using UnityEngine;
using System.Collections.Generic;


public class PlanetMarket {
    public List<Resource> Resources { get; private set; }

    public PlanetMarket() {
        Resources = new List<Resource>();
    }

    public void AddResourceToMarket(GameManager.PlanetData data) {
        Resources.Add(new Resource(data.type, data.SellPrice, data.BuyPrice, data.Inventory));
    }

    //Gets the total cost of a purchase of a specific resource.  Doesn't take into account inventory's ability to fulfill order
    public float GetTotalCost(Resource.ResourceTypes type, int orderQty) {

        var resource = Resources.Find(n => n.ResourceType == type);

        if (resource != null) {
            return resource.SellPrice * orderQty;
        }
        
        throw new UnityException("This Market doesn't sell " + type + "!");
        
    }

    /// <summary>
    /// Purchase resource(s) from market.  Returns number of units successfully purchased
    /// </summary>
    /// <param name="type"></param>
    /// <param name="orderQty"></param>
    /// <returns>Number of units successfully purchased</returns>
    public int AcquireResourceFromMarket(Resource.ResourceTypes type, int orderQty) {

        var resource = Resources.Find(n => n.ResourceType == type);

        if (resource != null) {
            return resource.RemoveResources(orderQty);
        }
        
        throw new UnityException("This Market doesn't sell " + type + "!");
        
    }

    /// <summary>
    /// Sell resources to the market.  
    /// </summary>
    /// <param name="type"></param>
    /// <param name="saleQty"></param>
    public void SellResourcesToMarket(Resource.ResourceTypes type, int saleQty) {

        var resource = Resources.Find(n => n.ResourceType == type);

        if (resource != null) {
            resource.AddResource(saleQty);
        }

        throw new UnityException("This Market doesn't sell " + type + "!");

    }
    
}