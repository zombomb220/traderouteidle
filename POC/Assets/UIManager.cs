using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    private static UIManager Instance;

    [SerializeField] private UI_Market _marketUI;


	// Use this for initialization
	void Start () {
	    if (Instance == null)
	        Instance = this;
	    else
	        Destroy(this);

	    if (_marketUI == null)
	        _marketUI = FindObjectOfType<UI_Market>();
	}



    public static void UpdateMarketUI(Vector3 pos, List<Resource> data) {
        Instance._marketUI.transform.position = Camera.main.WorldToScreenPoint(pos);
        Instance._marketUI.Show(data);
    }

    public static void HideMarketUI() {
        Instance._marketUI.Hide();
    }
}
