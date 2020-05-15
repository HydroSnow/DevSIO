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

if (isset($_POST['id']) && isset($_POST['pseudo'])) {
    $request = $pdo->prepare("SELECT * FROM auteur WHERE id_auteur = :id AND pseudo_auteur = :pseudo");
    $request->bindValue(":id", $_POST['id'], PDO::PARAM_INT);
    $request->bindValue(":pseudo", $_POST['pseudo'], PDO::PARAM_STR);
    $request->execute();

} else {
    $response["success"] = false;
    $response["message"] = "Il manque des informations.";
    echo json_encode($response);
    die();
}

$response["success"] = true;
$response["message"] = "Tout va bien.";
$response["data"] = $request->fetchAll(PDO::FETCH_ASSOC);
echo json_encode($response);
die();

?>
