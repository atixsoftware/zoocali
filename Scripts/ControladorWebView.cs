using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorWebView : MonoBehaviour
{

    UniWebView webView;

    // Use this for initialization
    void Start()
    {
        // Create a game object to hold UniWebView and add component.
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();
        webView.Frame = new Rect(0, 0, Screen.width, Screen.height*0.89f);
        string miURL = PlayerPrefs.GetString("Url");
        webView.Load(miURL);
        webView.Show();
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}