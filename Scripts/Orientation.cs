using UnityEngine;
using System.Collections;

public class Orientation : MonoBehaviour {


	void Start() {
		Screen.orientation = ScreenOrientation.Portrait;
		PlayerPrefs.SetInt ("login", 1);
	}
}