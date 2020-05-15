<?php
header('Content-Type: application/json');
$response = array();

if ($_SERVER['REQUEST_METHOD'] != "POST") {
    $response["success"] = false;
    $response["message"] = "Les données doivent être envoyées via la méthode POST.";
    echo json_encode($response);
    die();
}

require_once("database.php");

if (isset($_POST['pseudo']) && isset($_POST['mdp'])) {
	$request1 = $pdo->prepare("SELECT * FROM auteur WHERE pseudo_auteur = :pseudo AND mdp_auteur = :mdp");
	$request1->bindValue(":pseudo", $_POST['pseudo'], PDO::PARAM_STR);
	$request1->bindValue(":mdp", md5($_POST['mdp']), PDO::PARAM_STR);
	$request1->execute();

} else {
    $response["success"] = false;
    $response["message"] = "Il manque des informations.";
    echo json_encode($response);
    die();
}

if (isset($_POST['new_img']) && isset($_POST['new_nom']) && isset($_POST['new_pre']) && isset($_POST['new_rue']) && isset($_POST['new_cp']) && isset($_POST['new_ville']) && isset($_POST['new_tel']) && isset($_POST['new_email']) && isset($_POST['new_desc'])) {
	if ($auteur = $request1->fetch(PDO::FETCH_ASSOC)) {
		$request2 = $pdo->prepare("UPDATE auteur SET img_auteur = :new_img, nom_auteur = :new_nom, pre_auteur = :new_pre, rue_auteur = :new_rue, cp_auteur = :new_cp, ville_auteur = :new_ville, tel_auteur = :new_tel, email_auteur = :new_email, descriptif = :new_desc WHERE id_auteur = :auteur");
		$request2->bindValue(":auteur", $auteur['id_auteur'], PDO::PARAM_INT);
		$request2->bindValue(":new_img", $_POST['new_img'], PDO::PARAM_STR);
		$request2->bindValue(":new_nom", $_POST['new_nom'], PDO::PARAM_STR);
		$request2->bindValue(":new_pre", $_POST['new_pre'], PDO::PARAM_STR);
		$request2->bindValue(":new_rue", $_POST['new_rue'], PDO::PARAM_STR);
		$request2->bindValue(":new_cp", $_POST['new_cp'], PDO::PARAM_STR);
		$request2->bindValue(":new_ville", $_POST['new_ville'], PDO::PARAM_STR);
		$request2->bindValue(":new_tel", $_POST['new_tel'], PDO::PARAM_STR);
		$request2->bindValue(":new_email", $_POST['new_email'], PDO::PARAM_STR);
		$request2->bindValue(":new_desc", $_POST['new_desc'], PDO::PARAM_STR);
		$request2->execute();
		print_r($request2->errorInfo());

	} else {
	    $response["success"] = false;
	    $response["message"] = "Nom d'utilisateur ou mot de passe incorrect.";
	    echo json_encode($response);
	    die();
	}

} else {
    $response["success"] = false;
    $response["message"] = "Il manque des informations.";
    echo json_encode($response);
    die();
}

$response["success"] = true;
$response["message"] = "Tout va bien.";
echo json_encode($response);
die();

?>
