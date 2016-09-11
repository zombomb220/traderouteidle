using UnityEngine;
using System.Collections;

[System.Serializable]
public class CargoHold {

	public class CargoPackage{
		[SerializeField]
		public int NumInventory;
		[SerializeField]
		public Resource.ResourceTypes ResourceType;

		public CargoPackage(int inv, Resource.ResourceTypes rType){
			NumInventory = inv;
			ResourceType = rType;
		}
	}

	[SerializeField] public int _maxCargoHold;
	[SerializeField] public int _currentInventory;
	[SerializeField] private Resource.ResourceTypes _currentType;

	public CargoHold(int maxCargo){
		_maxCargoHold = maxCargo;

	}

	/// <summary>
	/// Store the specified type and number of inventory.
	/// </summary>
	/// <param name="invType">Cargo Type</param>
	/// <param name="numInventory">Number inventory.</param>
	/// <returns>True if successfully stored the cargo, false if it failed.</returns>
	public bool StoreCargo(Resource.ResourceTypes invType, int numInventory){

		if (_currentInventory > 0) {
			//make sure current inventory is the same type

			if (invType != _currentType) {
				Debug.Log ("Can't store this, as you are storing something else! Sell existing inventory first!");
				return false;
			}
		}

		if ((numInventory + _currentInventory) <= _maxCargoHold) {
			_currentInventory += numInventory;
			_currentType = invType;
			return true;

		} else {
			_currentInventory = _maxCargoHold;
			_currentType = invType;
			return false;
		}
	}

	/// <summary>
	/// Retrieves stored cargo. 
	/// </summary>
	/// <returns>Cargo Class.  Null if there is no cargo to retrieve.</returns>
	public CargoPackage RetrieveCargo(){

		if (_currentInventory > 0) {
			var c = new CargoPackage (_currentInventory, _currentType);

			_currentInventory = 0;

			return c;
		} else {
			return null;
		}
	}

	public void IncreaseMaxCapacity(int newInventorySlots){
		_maxCargoHold += newInventorySlots;
	}


}
