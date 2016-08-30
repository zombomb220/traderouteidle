using UnityEngine;
using System.Collections;

[System.Serializable]
public class CargoHold {

	public class Cargo{
		[SerializeField]
		public int NumInventory;
		[SerializeField]
		public Resource.ResourceTypes ResourceType;

		public Cargo(int inv, Resource.ResourceTypes rType){
			NumInventory = inv;
			ResourceType = rType;
		}
	}

	[SerializeField] private int _maxCargoHold;
	[SerializeField] private int _currentHold;
	[SerializeField] private Resource.ResourceTypes _currentType;

	public CargoHold(int maxCargo){
		_maxCargoHold = maxCargo;

	}

	/// <summary>
	/// Store the specified type and number of inventory.
	/// </summary>
	/// <param name="type">Cargo Type</param>
	/// <param name="numInventory">Number inventory.</param>
	/// <returns>True if successfully stored the cargo, false if it failed.</returns>
	public bool StoreCargo(Resource.ResourceTypes invType, int numInventory){

		if (numInventory > 0) {
			//make sure current inventory is the same type

			if (invType != _currentType) {
				Debug.Log ("Can't store this, as you are storing something else!");
				return false;
			}
		}

		if (numInventory <= _maxCargoHold) {
			_currentHold += numInventory;
			_currentType = invType;
			return true;

		} else {
			return false;
		}
	}

	/// <summary>
	/// Retrieves stored cargo. 
	/// </summary>
	/// <returns>Cargo Class.  Null if there is no cargo to retrieve.</returns>
	public Cargo RetrieveCargo(){

		if (_currentHold > 0) {
			var c = new Cargo (_currentHold, _currentType);

			_currentHold = 0;

			return c;
		} else {
			return null;
		}
	}

	public void IncreaseMaxCapacity(int newInventorySlots){
		_maxCargoHold += newInventorySlots;
	}


}
