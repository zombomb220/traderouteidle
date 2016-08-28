using UnityEngine;

public class Planet : MonoBehaviour {

    private TextMesh _text;

    private PlanetMarket _market;
    public PlanetMarket Market {
        get { return _market; }
        set { _market = value; }
    }

    void Start() {
        Market = new PlanetMarket();
        GameManager.RegisterPlanet(this);

        var marketText = "";

        foreach (var resource in Market.Resources) {

            marketText += "S: " + resource.SellPrice + "\t\t\tB: " + resource.BuyPrice + " : " + resource.Name + "\n";

        }

        _text = GetComponentInChildren<TextMesh>();
        _text.text = marketText;
    }


}