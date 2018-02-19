<?php

require('db.php');

// login url should have following params uid, then it returns userinfo, otherwise it will return login failed.
// sample url : http://localhost/demo/login.php?uid=22
// output will a json string if user found : {"login":"success","name":"my","age":"17","uid":"1","charid":"0"}
// if user not found : {"login":"fail","reason":"error message sent"}

// Check connection
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
  
// If form submitted, insert values into the database.
if (isset( $_GET['uid'] ))	{
        // removes backslashes
	$username = $_GET['uid'];
	
	//Checking is user existing in the database or not
    $query = "SELECT * FROM `demo` WHERE uid=".$username;
		
		// sending query
		$result = mysqli_query($conn,$query) or die(mysql_error());
		
		// get no of rows returned
		$rows = mysqli_num_rows($result);
		
		// if unique user found
        if($rows==1)
		{
			// Fetch one and one row
			while ($row=mysqli_fetch_row($result))
			{
			// read data
			$json=[
			'response' => 'success',
		    'name' => $row[0],
			 'age' => $row[1],
			 'uid' => $row[2],
			 'charid' => $row[3]
			];
					
			}

			// send back data
			$jsonstring = json_encode($json);
	    
         }else{
			// login info incorrect
			$json = ['response' => 'fail',
		    'reason' => 'login info wrong',
			];

		 }
		// send back data
		$jsonstring = json_encode($json);
		header('Content-type: application/json');
		echo $jsonstring;
	
		// Free result set
	  mysqli_free_result($result);
	
    }
else{
		$json = ['response' => 'fail',
		'reason' => 'paramters not sent :uid',
		];
		// send back data
		$jsonstring = json_encode($json);
		header('Content-type: application/json');
		echo $jsonstring;

	}

	
?>