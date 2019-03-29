<?php 
	require('template.php'); 
	show_up_header();
?>
<link rel="stylesheet" type="text/css" href="main.css">
<link rel="stylesheet" type="text/css" href="navbar.css">
<link rel="stylesheet" type="text/css" href="photos.css">
<?php
	show_low_header();
?>

<h2>Catégorie</h2>
<?php
	$json_data = file_get_contents('photos.json');
	$json = json_decode($json_data, true);
	
	$cat = null;
	if (isset($_GET['id'])) {
		$cat = $_GET['id'];
	}
	
	if ($cat != null) {
		for ($i = 0; $i < count($json); $i++) {
			$img = $json[$i];
			if ($cat == $img['category']) {
				echo('<div class="photo"><a href="photo.php?id=' . $i . '"><img class="photo-list" src="' . $img['url'] . '" /></a></div>');
			}
		}
	} else {
		echo('Aucune catégorie donnée !');
	}
?>
<p><a href="categories.php">Cliquez ici pour retourner à la liste des catégories</a></p>

<?php 
	show_footer();
?>
