using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataInserter : MonoBehaviour {

	public InputField minombre;
	public InputField mimail;
	string CreateUserURL = "http://atixsoftware.com/zoo/newuser.php";

	public void CreateUser(string username, string email){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("emailPost", email);

		WWW www = new WWW(CreateUserURL, form);
	}

	public void CrearUsuario()
	{
		string inputUserName = minombre.text;
		string inputEmail = mimail.text;

		CreateUser(inputUserName, inputEmail);

		SceneManager.LoadScene (3);

	}
}
