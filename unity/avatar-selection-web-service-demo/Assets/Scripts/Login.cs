using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	// paramters
	static string   domain = "http://localhost/demo/";
	static string   login = "login.php?";

	// User id
	public static int uid = -1;

	// Use this for initialization
	void Start ()
	{
		uid = PlayerPrefs.GetInt ( "Pid" , -1 );
		//uid = -1;
	}
	
	


	// button click event
	public void BtnLogin()
	{
		StartCoroutine ( DoLogin ( ) );
	}

	// call to web API for data
	public static IEnumerator DoLogin()
	{
		string reg;
		// uid == -1, new user, uid = userid
		if ( uid != -1 )
		{
			reg = string.Format ( "{0}{1}uid={2}" , domain , login , uid);
			// log message 
			print ( reg );

			// web API call
			UnityWebRequest www = UnityWebRequest.Get( reg );

			// wait until, we receive callback
			yield return www.SendWebRequest ( );

			// check error or not
			if ( www.isNetworkError || www.isHttpError )
			{
				Debug.Log ( www.error );
			}
			else
			{
				// Show results as text
				Debug.Log ( "DoLogin:" + www.downloadHandler.text );
				// {"login":"success","name":"my","age":"17","uid":"1","charid":"0"}
				LoginResponse lr = JsonUtility.FromJson<LoginResponse> ( www.downloadHandler.text );
				Game.age = lr.age;
				Game.charid = lr.charid;
				Game.uname = lr.name;
				SceneManager.LoadScene ( "game" );

			}
		}
		else
		{
			// load register screen
			SceneManager.LoadScene ( 1 );
		}
		yield break;
	}

	

}
