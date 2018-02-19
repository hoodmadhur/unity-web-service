using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownSelection : MonoBehaviour {

	// available characters
	[SerializeField]
	GameObject[] chars;

	// character user selected
	public int selectedChar = 0;

	// UI element reference
	Dropdown m_Dropdown;

	private void Start ()
	{
		// assign callback
		m_Dropdown = GetComponent<Dropdown> ( );
		m_Dropdown.onValueChanged.AddListener ( delegate {
			OnDropDownSelect ( m_Dropdown );

		});
	}


	public void OnDropDownSelect ( Dropdown selected )
	{
		// change characters based on user selection
		print ( "Char :" + selected );
		selectedChar = selected.value;

		for ( int i = 0; i < chars.Length; i++ )
		{
			if( i == selectedChar  )
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
