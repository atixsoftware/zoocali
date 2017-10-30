using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour {

	//public int indice;

	public void CambiarEscena(int indice)
	{
		SceneManager.LoadScene(indice);
	}

	public void CambiarPlayerPref(string miurl)
	{
		PlayerPrefs.SetString("Url", miurl);
	}


}
