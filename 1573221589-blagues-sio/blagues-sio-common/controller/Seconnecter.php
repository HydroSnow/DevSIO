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
    function commander(){
       
    }
    
    function commanderfinaliser(){
       
        
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
