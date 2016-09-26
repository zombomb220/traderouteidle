using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class UI_Fuel : MonoBehaviour {

    private RectTransform _rect;
    [SerializeField] private Ship _selectedShip;

	// Use this for initialization
	void Start () {
	    _rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	    _rect.anchorMax = new Vector2(_selectedShip.GetCurrentFuel(), .5f);
    }
}
