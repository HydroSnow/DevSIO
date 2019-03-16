<?php
	include('mysql-conn.php');

	$id_exists = isset($_GET['id']);
	if (!$id_exists) {
		die("error: no id provided");
	}

	$escaped = $conn->real_escape_string($_GET['id']);
	$result = $conn->query('SELECT * FROM produits WHERE IdProd = "' . $escaped . '"');
	$produit = array();
	if (!$result) {
	    die('error: id not found');
	}
	if ($result->lengths > 1) {
		$error = 'database error, illegal number of results';
		error_log($error);
	    die('error: database nope');
	}
	$row = $result->fetch_assoc();

	$produit['id'] = $row['IdProd'];
	$produit['categorie'] = $row['NumCat'];
	$produit['libelle'] = $row['LibProd'];
	$produit['prix'] = $row['PrixProd'];
	$produit['description'] = $row['DescProd'];
	
	$result->close();
	$json = json_encode($produit);
	echo($json);
?>
