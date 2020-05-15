<?php
include('controller/Panier.php');
class Seconnecter extends Controller
{
    public $panier;
    function index(){
        $variable["test"]=array('titre'=>'Accueil', 'description'=>'trop de blabla');
        $this-> set($variable);
        $this->render('index');
    }

    function connect($personne=null){
        $login=null;
        $mdp=null;

        if(isset($_POST['login']) && isset($_POST['mdp'])){
            $login=$_POST['login'];
            $mdp=$_POST['mdp'];
        }

        if($personne!=null && isset($_SESSION['auteurtmp'])){
            $login= $_SESSION['auteurtmp']['login'];
            $mdp=$_SESSION['auteurtmp']['mdp'];
           // unset( $_SESSION['auteurtmp']);
        }

        $tables = Model::load("auteur");
        $tableRes['variable']=
        array("auteur"=>$tables->find(Model::connexion(),
            array('condition'=>"pseudo_auteur='".$login."' and mdp_auteur='".md5($mdp)."'")));
        Model::deconnexion();


        if(count($tableRes['variable']['auteur']) ==1 || isset($_SESSION['auteur'])){
            $_SESSION['auteur']=$tableRes['variable']['auteur'];
            //var_dump($_SESSION['auteur']);
            $this->render('connexion');
        }else{
            $this->render('inscription');
        }

        //$this-> set($tableRes);

    }

    function deconnect(){
        unset($_SESSION['auteur']);
        header('Location:'.WEBROOT.'seconnecter');
    }

    function commander() {
        if ($_SESSION['panier'] == null) {
            return;
        }

        $pdo = Model::connexion();

		$blagueModel = Model::load("blagues");
        $produit_ids_str = "(" . join(", ", array_keys($_SESSION["panier"])) . ")";
		$blagueResult = array(
            "produit" => $blagueModel->find($pdo, array(
                "condition" => "id_blague IN $produit_ids_str"
            ))
        );
		$variables["produits"] = $blagueResult["produit"];

		Model::deconnexion();

        $this->set($variables);
        $this->render('commande');
    }

    function commanderfinaliser() {
        if ($_SESSION['panier'] == null) {
            return;
        }

        $pdo = Model::connexion();

        $blagueModel = Model::load("blagues");
        $produit_ids_str = "(" . join(", ", array_keys($_SESSION["panier"])) . ")";
		$blagueResult = array(
            "produit" => $blagueModel->find($pdo, array(
                "condition" => "id_blague IN $produit_ids_str"
            ))
        );

		$auteur = $_SESSION["auteur"][0]->id_auteur;
        $date = date("Y-m-d");
		$total = 0;
		foreach ($blagueResult["produit"] as $id => $value){
			$total += $value->px_blague;
		}

		$commandeModel = Model::load("commande");
		$commandeModel->save($pdo, array(
			"id_auteur" => $auteur,
			"dated_commande" => $date,
			"tot_commande" => $total
		));
		$commandeResult = array(
            "produit" => $commandeModel->find($pdo, array(
                "condition" => "id_auteur = $auteur AND dated_commande = '$date' AND tot_commande = $total"
            ))
        );
        $id_commande = $commandeResult['produit'][0]->id_commande;

		$detailCommandeModel = Model::load("lcommande");
		foreach($_SESSION["panier"] as $id_blague => $value) {
			$detailCommandeModel->save($pdo, array(
				"id_commande"=> $id_commande,
				"id_blague"=> $id_blague
			));
		}

		Model::deconnexion();
		$_SESSION["panier"] = null;

        $this->render('commandefinaliser');
    }

    function inscription(){
        if(!isset($_POST)){
        $this->render('inscription');
        }else{

        //Charger la table auteur
        $table=Model::load("auteur");
        $tableRes['variable']=
        $table->find(Model::connexion(),
            array('condition'=>"pseudo_auteur='".$_POST["pseudo"]));
        if(count($tableRes['variable'])!=1 && $_POST["pseudo"]!=""){
        //formater l'image
        $image=($_FILES['images']['name']!="") ? $_FILES['images']['name'] : "personne.png";

        $data= array(
            "pseudo_auteur"=>$_POST["pseudo"],
            "mdp_auteur"=>md5($_POST["mdp"]),
            "img_auteur"=>$image,
            "nom_auteur"=>$_POST["nom"],
            "pre_auteur"=>$_POST["prenom"],
            "rue_auteur"=>$_POST["rue"],
            "cp_auteur"=>$_POST["cp"],
            "ville_auteur"=>$_POST["ville"],
            "tel_auteur"=>$_POST["telephone"],
            "email_auteur"=>$_POST["email"],
            "descriptif"=>$_POST["description"]

        );


                $_SESSION['auteurtmp']['mdp']=$_POST["mdp"];
                $_SESSION['auteurtmp']['login']=$_POST["pseudo"];

                $table->save(Model::connexion(),$data);
                Model::deconnexion();
                //Charger l'image
               if ((isset($_FILES['images']['tmp_name'])&&($_FILES['images']['error'] == UPLOAD_ERR_OK))) {
                    $chemin_destination = 'D:\APPLICATION\wamp\www\desbarreslessio\asset\img\illustration/';
                    move_uploaded_file($_FILES['images']['tmp_name'], $chemin_destination.$_FILES['images']['name']);
                //Se connecter
                }

                 header('location:'.WEBROOT.'seconnecter/connect/99');
        }else{
            $this->render('inscription');
        }
        }
    }

    function modifier(){
        $this->render('connexion');
    }

    function ajouterblague(){

    }

    function ajouterCB(){

    }

    function modifierCB($i){

    }
    function facture(){

    }
}
?>
