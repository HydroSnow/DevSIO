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

<h2>Photos</h2>
<p>Voici les photos que nous proposons :</p>
<?php
	$json_data = file_get_contents('photos.json');
	$json = json_decode($json_data, true);
	
	for ($i = 0; $i < count($json); $i++) {
		echo('<div class="photo"><a href="photo.php?id=' . $i . '"><img class="photo-list" src="' . $json[$i]['url'] . '" /></a></div>');
	}
?>
<p>Cliquez sur une photo pour afficher ses informations.</p>

<?php 
	show_footer();
?>