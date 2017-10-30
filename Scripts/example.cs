using ProgressBar;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class example : MonoBehaviour
{
  

		ProgressBarBehaviour BarBehaviour;
		[SerializeField] float UpdateDelay = 2f;

		IEnumerator Start ()
	{
        
		BarBehaviour = GetComponent<ProgressBarBehaviour> ();
		while (true) {
			BarBehaviour.Value = 100;
			yield return new WaitForSeconds (UpdateDelay);
			if (PlayerPrefs.GetInt ("login") == 1) {
				SceneManager.LoadScene (3);
			} else
				SceneManager.LoadScene (1);
		} 
	}
}