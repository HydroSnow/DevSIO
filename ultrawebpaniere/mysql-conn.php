<?php
	$conn = new mysqli('localhost', 'root', 'root', 'vegania');
	if ($conn->connect_error) {
		$error = 'database error: ' . $conn->connect_error;
		error_log($error);
	    die('error: database nope');
	}
?>
