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

if (isset($_POST['titre']) && isset($_POST['description'])) {
    $request = $pdo->prepare("SELECT * FROM blagues WHERE INSTR(titre_blague, :titre) > 0 AND INSTR(desc_blague, :description) > 0");
    $request->bindValue(":titre", $_POST['titre'], PDO::PARAM_STR);
    $request->bindValue(":description", $_POST['description'], PDO::PARAM_STR);
    $request->execute();

} elseif (isset($_POST['titre'])) {
    $request = $pdo->prepare("SELECT * FROM blagues WHERE INSTR(titre_blague, :titre) > 0");
    $request->bindValue(":titre", $_POST['titre'], PDO::PARAM_STR);
    $request->execute();

} elseif (isset($_POST['description'])) {
    $request = $pdo->prepare("SELECT * FROM blagues WHERE INSTR(desc_blague, :description) > 0");
    $request->bindValue(":description", $_POST['description'], PDO::PARAM_STR);
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
