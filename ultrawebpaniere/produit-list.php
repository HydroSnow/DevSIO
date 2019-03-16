<?php
	include('mysql-conn.php');

	$result = $conn->query('SELECT IdProd FROM produits');
	$produits = array();
	if (!$result) {
		$error = 'database error, query is false';
		error_log($error);
	    die('error: database nope');
	}
	while ($row = $result->fetch_assoc()) {
		array_push($produits, $row['IdProd']);
	}
	$result->close();
	$json = json_encode($produits);
	echo($json);
?>
