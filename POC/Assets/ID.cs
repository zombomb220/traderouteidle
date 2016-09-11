using UnityEngine;
using System;
using System.Runtime.Serialization;

public class ObjectID : MonoBehaviour {

	private static ObjectIDGenerator idGenerator = new ObjectIDGenerator();
	[SerializeField]
	private int ID = -1;

	protected void GenerateID() {

		bool newLongID = false;
		ID = Convert.ToInt32(idGenerator.GetId(this, out newLongID));
	}

	public int GetID() {

		if(ID == -1)
			GenerateID ();

		return ID;
	}
}
