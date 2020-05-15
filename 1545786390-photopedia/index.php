<?php
	require('template.php'); 
	show_up_header();
?>
<link rel="stylesheet" type="text/css" href="main.css">
<link rel="stylesheet" type="text/css" href="navbar.css">
<link rel="stylesheet" type="text/css" href="index.css">
<?php
	show_low_header();
?>

<h2>Bienvenue sur Photopedia</h2>
<p>Nous proposons des photos à télécharger pour les professionnels comme pour les particuliers.</p>
<div id="pre-container">
	<div class="pre-element">
		<h3>Catalogue riche</h3>
		<p>Nous sommes le partenaire de milliers de photographes : peu importe ce que vous recherchez, grâce à notre tri par catégories, vous trouverez toujours ce qu'il vous faut.</p>
	</div>
	<div class="pre-element">
		<h3>Informations</h3>
		<p>En plus d'un riche catalogue de photos, nous répertorions aussi les informations associées aux clichés et les coordonnées des photographes.</p>
	</div>
	<div class="pre-element">
		<h3>Licence libre</h3>
		<p>Toutes les photos disponibles ici sont disponibles sous licence Creative Commons (pour en savoir plus, <a href="https://creativecommons.org/licenses/?lang=fr-FR" target="_blank">cliquez ici</a>)</p>
	</div>
</div>
<p><a href="photos.php">Cliquez ici pour voir nos photos</a></p>

<?php
	show_footer();
?>