<?php
function show_up_header() {
	?>
	<!doctype html>
	<html>
		<head>
			<title>Photopédia</title>
			<meta charset="UTF-8" />
	<?php
}

function show_low_header() {
	?>
			<meta name="viewport" content="width=device-width" />
		</head>
		<body>
			<div id="wrapper">
				<header>
					<div id="up-header" class="vertical-align-container">
						<a href="index.php"><img id="logo" src="img/logo.png" alt="Photopédia" /></a>
					</div>
					<nav id="low-header">
						<ul>
							<li><a href="index.php">ACCUEIL</a></li>
							<li><a href="photos.php">PHOTOS</a></li>
							<li><a href="categories.php">CATÉGORIES</a></li>
							<li><a href="contact.php">CONTACT</a>
								<ul>
									<li><a href="mathis.php">MATHIS</a></li>
									<li><a href="alexis.php">ALEXIS</a></li>
									<li><a href="dylan.php">DYLAN</a></li>
								</ul>
							</li>
						</ul>
					</nav>
				</header>
				<div id="content">
	<?php
}

function show_footer() {
	?>
				</div>
				<footer>
					<p>© Photopedia, 2018</p>
				</footer>
			</div>
		</body>
	</html>
	<?php
}
?>

