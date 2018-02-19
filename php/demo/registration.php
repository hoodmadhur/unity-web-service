<?php
require('db.php');


// If user id not submitted, create new user with data.
if (!isset($_GET['uid']))
{
        // removes backslashes
	$username = stripslashes($_GET['name']);
        //escapes special characters in a string
	$username = mysqli_real_escape_string($conn,$username); 
	// get other params
	$age = stripslashes($_GET['age']);
	$charid = stripslashes($_GET['charid']);
	
	// search if values exist
	$query = "SELECT uid from demo where name='$username' AND age='$age' AND characterid='$charid'";
	//echo $query;
	$search = mysqli_query($conn,$query);
	$row=mysqli_fetch_row($search);
	
	$rows = mysqli_num_rows($search);
		
	// if no user found
    if($rows==0 )
	{
	
		// insert in db
        $query = "INSERT into `demo` (name, age , characterid ) VALUES ('$username', '$age' , '$charid' )";
        $result = mysqli_query($conn,$query);
        if($result)
		{
			// send user id
			
			$query = "SELECT uid from demo where name='$username' AND age='$age' AND characterid='$charid'";
			//echo $query;
			$result = mysqli_query($conn,$query);
			$row=mysqli_fetch_row($result);
			
			//echo  $row[0]; 
			$json=[
			'response' => 'success',
		    'uid' => $row[0]
			 
			];
					
		}
		//echo "registered" .$result;
		$jsonstring = json_encode($json);
		header('Content-type: application/json');
		echo $jsonstring;
	}
	else{
		$json=[
			'response' => 'fail',
			'reason' => 'user already registered',
		    'uid' => $row[0]
			];
			
		$jsonstring = json_encode($json);
		header('Content-type: application/json');
		echo $jsonstring;
			
	}
		
			
}
else{
	//echo "params not set properly";
	include('login.php');
}
 
 
 ?>