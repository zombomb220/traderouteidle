using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	RaycastHit2D[] hits;



	// Use this for initialization
	void Start () {
		hits = new RaycastHit2D[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			OnMouseDown ();
	}


	public void CheckClickForObject(Vector2 pos){

		var num = Physics2D.RaycastNonAlloc (pos, Camera.main.transform.forward, hits, Mathf.Infinity);
		if (num > 0) {
			//Debug.Log ("Hit " + hits [0].transform.name + " number of hits: " + num);
			var id = hits [0].transform.GetComponent<ObjectID> ().GetID ();

			var d = new Planet.Events.OnPlanetSelected { planetID = id };
			GameManager.Events.CallEvent (GameEventNames.OnPlanetSelected, d);
		} else {
			//Debug.Log ("Didn't find anything at " + pos);
			var d = new Planet.Events.OnPlanetSelected { planetID = -2};
			GameManager.Events.CallEvent (GameEventNames.OnPlanetSelected, d);
		}
	}


	void OnMouseDown(){
		CheckClickForObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}


	void OnDrawGizmos(){

		Gizmos.color = Color.black;

		Gizmos.DrawRay (Camera.main.transform.position, Camera.main.transform.forward);
	}
}
