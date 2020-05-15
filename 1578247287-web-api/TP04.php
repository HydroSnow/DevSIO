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

if (isset($_POST['categorie']) && isset($_POST['titre']) && isset($_POST['description']) && isset($_POST['illustration']) && isset($_POST['prix'])) {
	if ($auteur = $request1->fetch(PDO::FETCH_ASSOC)) {
		$request2 = $pdo->prepare("INSERT INTO blagues (id_categorie, titre_blague, desc_blague, id_illustration, id_auteur, px_blague) VALUES (:categorie, :titre, :description, :illustration, :auteur, :prix)");
		$request2->bindValue(":categorie", $_POST['categorie'], PDO::PARAM_INT);
		$request2->bindValue(":titre", $_POST['titre'], PDO::PARAM_STR);
		$request2->bindValue(":description", $_POST['description'], PDO::PARAM_STR);
		$request2->bindValue(":illustration", $_POST['illustration'], PDO::PARAM_STR);
		$request2->bindValue(":auteur", $auteur['id_auteur'], PDO::PARAM_INT);
		$request2->bindValue(":prix", $_POST['prix']);
		$request2->execute();

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
