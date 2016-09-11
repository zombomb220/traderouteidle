using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMoneyUI : MonoBehaviour {
	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "Money: " + System.Math.Round(Player.CurrentBalance(),2);
	}
}
