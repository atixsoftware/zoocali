using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Webcam : MonoBehaviour {

	//int currentCamIndex = 0;
	public GameObject miobjeto;
	WebCamTexture tex;
	public RawImage display;
	public bool cam;


	public void SwapCam_Clicked()
	{
		if (cam == true) {
			
			StartCamera1 (1);

			cam = false;
		} else {
			
			StartCamera2 (0);
			cam = true;
		}
	}



	public void StartCamera1(int currentCamIn)  {

		tex.Stop ();
		display.transform.Rotate (0, 0, 90);
		WebCamDevice device = WebCamTexture.devices [currentCamIn];
		tex = new WebCamTexture (device.name); 
		display.texture = tex;
		tex.Play ();
		display.transform.Rotate (0, 0, 90);


	
	}

	public void StartCamera2(int currentCamIn)  {

		tex.Stop ();
		display.transform.Rotate (0, 0, -90);
		WebCamDevice device = WebCamTexture.devices [currentCamIn];
		tex = new WebCamTexture (device.name); 
		display.texture = tex;
		tex.Play ();
		display.transform.Rotate (0, 0, -90);

	}

	public void Capture ()
	{
		/*StartCoroutine ("UploadPNG");
	}

		IEnumerator UploadPNG() {
			// We should only read the screen buffer after rendering is complete
			yield return new WaitForEndOfFrame();*/

			// Create a texture the size of the screen, RGB24 format
			int width = Screen.width;
		int height = Mathf.RoundToInt(Screen.height*0.23f);
		int height2 = Mathf.RoundToInt(Screen.height*0.77f);
			Texture2D tex = new Texture2D(width, height2, TextureFormat.RGB24, false);

			// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, height, width, height2), 0, 0);
			tex.Apply();

			// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

		int fileNumber = PlayerPrefs.GetInt ("FileNumber", 0);
		fileNumber++;
		PlayerPrefs.SetInt ("FileNumber", fileNumber);
		string fileName = (fileNumber + ".png");
		string myFolderLocation = "/storage/emulated/0/ZoologicoCali/Media/ZoologicoCali/";

		if(!Directory.Exists(myFolderLocation)){
            Directory.CreateDirectory(myFolderLocation);
		}

			// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(myFolderLocation + "Zoo"+fileName, bytes);

		}

	// Use this for initialization
	void Start () {


		WebCamDevice device = WebCamTexture.devices [0];
		tex = new WebCamTexture (device.name); 
		display.texture = tex;
		tex.Play ();
		display.transform.Rotate (0, 0, -90);
		
	}

	public void SalirFotos()
	{
		tex.Stop ();
		SceneManager.LoadScene (8);
	
	}

}
