using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour {


	[SerializeField]	Text username;
	[SerializeField]	Text Age;
	[SerializeField]	Dropdown    charSelected;

	
	// Use this for initialization
	public void RegisterUser ()
	{
		// validity check
		if ( username.text.Length > 0 && Age.text.Length > 0 )
		{
			StartCoroutine ( register ( username.text , Age.text , charSelected.value.ToString ( ) ) );
		}
		else
		{
			Debug.Log ( "Invalid params" );
		}
	}

	static string   domain = "http://localhost/demo/";
	static string   registration = "registration.php?";

	public IEnumerator register (string uname , string age ,string  charid )
	{
		string reg;
		reg = string.Format ( "{0}{1}name={2}&age={3}&charid={4}" , domain , registration , uname , age , charid );

		Debug.Log ( "register::request:" + reg );

		// web call
		UnityWebRequest www = UnityWebRequest.Get( reg );
		yield return www.SendWebRequest ( );

		if ( www.isNetworkError || www.isHttpError )
		{
			Debug.Log ( www.error );
		}
		else
		{
			// Show results as text
			Debug.Log ( "register response:" + www.downloadHandler.text );
			ResponseBase response =  JsonUtility.FromJson<ResponseBase> ( www.downloadHandler.text );

			if ( response.response == "success" )
			{
				int uid = (int)response.uid;
				PlayerPrefs.SetInt ( "Pid" , uid  );
				Login.uid = uid;
				// Load game data
				StartCoroutine ( Login.DoLogin ( ) );
				
			}
			else if( response.response.Equals ( "fail" ) )
			{
				// log error message
				Debug.Log ( "register response:FAILED::Reason::" + response.reason );

			}
		}
	}

	

}
