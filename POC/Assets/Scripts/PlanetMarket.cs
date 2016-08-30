using UnityEngine;
using System.Collections.Generic;


public class PlanetMarket {
    public List<Resource> Resources { get; private set; }
	public class SaleDetails
	{
		public int orderQty;
		public float priceEach;
		public Resource.ResourceTypes rType;

		public SaleDetails(int qty, float pPrice, Resource.ResourceTypes pType){
			orderQty = qty;
			priceEach = pPrice;
			rType = pType;
		}

		public float TotalPrice(){
			return priceEach * orderQty;
		}

	}

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
    public void AcquireResourceFromMarket(ref SaleDetails details) {

		Resource resource = null;
		foreach (var r in Resources) {
			if (r.ResourceType == details.rType) {
				resource = r;
				break;
			}
		}

        if (resource != null) 
			details.orderQty = resource.RemoveResources(details.orderQty);
		else
			throw new UnityException("This Market doesn't sell " + details.rType + "!");
        
    }

	public SaleDetails PriceCheck(Resource.ResourceTypes pType, int orderQty){
		
		var resource = Resources.Find(n => n.ResourceType == pType);

		if (resource != null) {
			return new SaleDetails (orderQty,resource.SellPrice, pType);
		}

		throw new UnityException("This Market doesn't sell " + pType + "!");
	}

    /// <summary>
    /// Sell resources to the market.  
    /// </summary>
    /// <param name="type"></param>
    /// <param name="saleQty"></param>
    public float SellResourcesToMarket(Resource.ResourceTypes pType, int saleQty) {

        var resource = Resources.Find(n => n.ResourceType == pType);

        if (resource != null) {
            resource.AddResource(saleQty);
			return saleQty * resource.BuyPrice;
        }
		else
        	throw new UnityException("This Market doesn't buy " + pType + "!");

    }
    
}