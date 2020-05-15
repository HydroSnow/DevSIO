 <!-- Commande -->
  <section class="page-section" id="commande">
    <div class="container">
      <div class="row">
        <div class="col-lg-12 text-center">

<?php if(!isset($commande['resultat']))
{

?>
<a href="<?=WEBROOT."seconnecter/commanderfinaliser"?>">
<button type="button" style="margin:20px" >
          			PAYER 
        	</button>
</a>
<?php 
}else{
    echo $commande['resultat'];
    //var_dump();
}
?>
</div>
</div>
</div>
</section>