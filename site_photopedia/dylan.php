<?php 
	require('template.php'); 
	show_up_header();
?>
<link rel="stylesheet" type="text/css" href="main.css">
<link rel="stylesheet" type="text/css" href="navbar.css">
<?php
	show_low_header();
?>

<h2>Bienvenue sur ma page de présentation</h2>
<p>
	<h3>
		<b>Nom :</b> 
		<i>Gouzien Dylan</i>
		<br />
		<b>Age :</b> 
		<i>18 ans</i>
	</h3>	
</p>
<h3>Mes compétences</h3>
<table border="1px" align="center">
	<tr>
		<td>Développement</td>
		<td>
			<ul>
				<li>HTML</li>
				<li>CSS</li>
				<li>PHP</li>
				<li>C#</li>
				<li>SQL</li>
			</ul>
		</td>
	</tr>
	<tr>
		<td>Réseau</td>
		<td>
			<ul>
				<li>Adressage IPV4</li>
				<li>DNS</li>
				<li>Infrastructure</li>
				<li>Sous-réseaux</li>
			</ul>
		</td>
	</tr>
</table>
<h3>Mes Loisirs</h3>
<table border="1px" align="center">
	<tr>
		<td>Développement</td>
		<td>
			<ul>
				<li>Football</li>
				<li>Tennis de table</li>
				<li>Jeux Vidéo</li>
			</ul>
		</td>
	</tr>
</table>
<div>
	<h3>Me contacter</h3>
	<p>
		<a href="#">Facebook</a> 
		- 
		<a href="#">Twitter</a>
	</p>
</div>

<?php 
	show_footer();
?>
