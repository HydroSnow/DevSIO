<?php 
	require('template.php'); 
	show_up_header();
?>
<link rel="stylesheet" type="text/css" href="main.css">
<link rel="stylesheet" type="text/css" href="navbar.css">
<?php
	show_low_header();
?>

<h2>Catégories</h2>
<p>Voici les catégories d'images disponibles :</p>
<?php
	$json_data = file_get_contents('photos.json');
	$json = json_decode($json_data, true);
	
	$arr = [];
	
	for ($i = 0; $i < count($json); $i++) {
		$cat = $json[$i]['category'];
		
		if (isset($arr[$cat])) {
			$arr[$cat] = $arr[$cat] + 1;
		} else {
			$arr[$cat] = 1;
		}
	}
	
	foreach(array_keys($arr) as $key) {
		$count = $arr[$key];
		echo('<p><a href="categorie.php?id=' . $key . '">Catégorie "' . $key . '" : ' . $count . ' images</a></p>');
	}
	
?>
<p>Cliquez sur une catégorie pour afficher ses photos.</p>

<?php 
	show_footer();
?>
