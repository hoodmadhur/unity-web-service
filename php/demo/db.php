<?php

// this will avoid mysql_connect() deprecation error.
 error_reporting( ~E_DEPRECATED & ~E_NOTICE );
 // but I strongly suggest you to use PDO or MySQLi.
 
 define('DBHOST', 'localhost');
 define('DBUSER', 'root');
 define('DBPASS', '');
 define('DBNAME', 'mysql');
 
 $conn = mysqli_connect(DBHOST,DBUSER,DBPASS,DBNAME);
 
 if ( !$conn ) {
  die("Connection failed : " . mysql_error());
 }
 

 //echo "success connection";

// Enter your Host, username, password, database below.
// I left password empty because i do not set password on localhost.
//$con = mysqli_connect("localhost","root","","demo");
// Check connection
//if (mysqli_connect_errno())
//  {
//  echo "Failed to connect to MySQL: " . mysqli_connect_error();
//  }


?>