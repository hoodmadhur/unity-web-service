using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for server response
[System.Serializable]
public class ResponseBase
{
	public string response;
	public string reason;
	public int      uid;
}

// response class from login
// {"login":"success","name":"my","age":"17","uid":"1","charid":"0"}
public class LoginResponse : ResponseBase
{
	public string	name;
	public string	age;
	public string	charid;

}
