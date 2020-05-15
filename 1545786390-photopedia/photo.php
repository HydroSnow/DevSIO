<?php 
	require('template.php'); 
	show_up_header();
?>
<link rel="stylesheet" type="text/css" href="main.css">
<link rel="stylesheet" type="text/css" href="navbar.css">
<link rel="stylesheet" type="text/css" href="photo.css">
<?php
	show_low_header();
?>

<h2>Photo</h2>
<table class="photo-info">
	<tr>
		<?php
			$json_data = file_get_contents('photos.json');
			$json = json_decode($json_data, true);
			
			$photo = null;
			if (isset($_GET['id'])) {
				$photo = $json[$_GET['id']];
			}
			
			if ($photo != null) {
		?>
			<td>
				<img class="photo-info" src="<?php echo($photo['url']); ?>" />
			</td>
			<td>
				<p>Photographe : <?php echo($photo['photographer']); ?></p>
				<p>Lieu : <?php echo($photo['location']); ?></p>
				<p>Description : <?php echo($photo['description']); ?></p>
				<p>Catégorie : <?php echo($photo['category']); ?></p>
			</td>
		<?php
			} else {
				echo('Photo introuvable !');
			}
		?>
	</tr>
</table>
<p><a href="photos.php">Cliquez ici pour retourner à la liste des photos</a></p>

<?php 
	show_footer();
?>