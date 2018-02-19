using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	// character meshes
	[SerializeField]
	GameObject[] chars;

	// player parameters
	public static string uname, age, charid;

	// UI refernce elements
	[SerializeField]
	Text    nameUI, ageUI;

	// Use this for initialization
	void Start () {
		// assign properties to UI elements
		nameUI.text = uname;
		ageUI.text = age;

		// enable selected character
		int chid = Convert.ToInt32( charid);

		for ( int i = 0; i < chars.Length; i++ )
		{
			if ( i == chid )
			{
				chars[i].SetActive ( true );
			}
			else
			{
				chars[i].SetActive ( false );

			}
		}


	}
	
	
}
