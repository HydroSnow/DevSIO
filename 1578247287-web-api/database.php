<?php
$host = "localhost";
$dbname = "blague";
$user = "root";
$password = "root";

try {
    $pdo = new PDO("mysql:host=" . $host . ";dbname=" . $dbname . ";charset=utf8", $user, $password);
} catch (Exception $e) {
    $response["success"] = false;
    $response["message"] = "Erreur de connexion à la base de données.";
    echo json_encode($response);
    die();
}
?>
