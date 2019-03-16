<?php
	session_start();

	$panier_exists = isset($_SESSION['panier']);
	if (!$panier_exists) {
		$_SESSION['panier'] = array();
	}

	$action_exists = isset($_GET['a']);
	if (!$action_exists) {
		die("error: action not provided");
	}

	if ($_GET['a'] == "add") {

		$id_exists = isset($_GET['id']);
		if (!$id_exists) {
			die("error: no id provided");
		}
	
		$entry_exists = isset($_SESSION['panier'][$_GET['id']]);
		if ($entry_exists) {
			die("error: item already in");
		}

		$_SESSION['panier'][$_GET['id']] = 1;
		die("success");
	}

	if ($_GET['a'] == "rem") {

		$id_exists = isset($_GET['id']);
		if (!$id_exists) {
			die("error: no id provided");
		}
	
		$entry_exists = isset($_SESSION['panier'][$_GET['id']]);
		if (!$entry_exists) {
			die("error: item not in");
		}

		unset($_SESSION['panier'][$_GET['id']]);
		die("success");
	}

	if ($_GET['a'] == "set") {

		$id_exists = isset($_GET['id']);
		if (!$id_exists) {
			die("error: no id provided");
		}
		
		$entry_exists = isset($_SESSION['panier'][$_GET['id']]);
		if (!$entry_exists) {
			die("error: item not in");
		}

		$value_exists = isset($_GET['value']);
		if (!$value_exists) {
			die("error: no value provided");
		}

		if (filter_var($_GET['value'], FILTER_VALIDATE_INT) === false) {
			die("error: value is not an integer");
		}

		if ($_GET['value'] < 1) {
			die("error: value is not positive");
		}

		$_SESSION['panier'][$_GET['id']] = $_GET['value'];
		die("success");
	}

	if ($_GET['a'] == "list") {

		$json = json_encode($_SESSION['panier']);
		die($json);
	}


?>
