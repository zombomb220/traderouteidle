using UnityEngine;

public class Ship : MonoBehaviour {

    [SerializeField]
    public struct Cargo {
        Resource.ResourceTypes ResourceType;
        int Inventory;
    }

    [SerializeField] private float _speed;
    [SerializeField] private float _fuelCost;
    [SerializeField] private Cargo _cargo;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
