using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class MiLoginFB : MonoBehaviour {

	// Use this for initialization
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	public void FBLoggin()
	{
		//FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" });

		//FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" });


		FB.LogInWithReadPermissions (
			new List<string> (){ "public_profile", "email", "user_friends" },
			AutoLLamado);
	
	}

	private void AutoLLamado (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
				SceneManager.LoadScene (3);
			}
		} else {
			Debug.Log("User cancelled login");

			SceneManager.LoadScene (2);
		}
	}


}