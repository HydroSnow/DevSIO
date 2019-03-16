<!doctype html>
<html>
	<head>
		<title>Le panière</title>
		<meta charset="utf-8" />
		<style type="text/css">
			table, td {
				border: 1px solid black;
			}

			td {
				width: 200px;
				padding: 10px;
			}
		</style>
	</head>
	<body>
		<h1>Salut</h1>
		<h2>Produits</h2>
		<table id="produits">
			<tr>
				<td> Nom </td>
				<td> Description </td>
				<td> Catégorie </td>
				<td> Prix </td>
				<td> Panier </td>
			</tr>
		</table>
		<h2>Panier</h2>
		<table id="panier">
			<tr>
				<td> Nom </td>
				<td> Description </td>
				<td> Catégorie </td>
				<td> Prix </td>
				<td> Panier </td>
			</tr>
		</table>
		<script>
			function ajax(page, callback) {
				var xhttp = new XMLHttpRequest();
				xhttp.onreadystatechange = function() {
					if (this.readyState == 4 && this.status == 200) {
						callback(this.responseText);
					}
				};
				xhttp.open("GET", page, true);
				xhttp.send();
			}

			function updateProduits() {
				var produits = document.getElementById("produits");
				produits.style.backgroundColor = "#AAA";
				if (produits == undefined) { return; }

				ajax("produit-list.php", (responseText) => {
					var ids = JSON.parse(responseText);
					var stack = [];
					if (ids.length == 0) {
						updateProduitsStack(panier, stack);
					} else {
						ids.forEach((element) => {
							ajax("produit-get.php?id=" + element, (responseText) => {
								var produit = JSON.parse(responseText);
								stack.push(produit);
								if (stack.length == ids.length) {
									updateProduitsStack(produits, stack);
								}
							});
						});
					}
				});
			}

			function updateProduitsStack(produits, stack) {
				while (produits.rows.length > 1) {
					produits.deleteRow(1);
				}
				stack.sort((a, b) => { return (a.id - b.id); });
				stack.forEach((element) => {
					var row = produits.insertRow(produits.rows.length);

					var cell0 = row.insertCell(row.cells.length);
					var text0 = document.createTextNode(element.libelle);
					cell0.appendChild(text0);

					var cell1 = row.insertCell(row.cells.length);
					var text1 = document.createTextNode(element.description);
					cell1.appendChild(text1);

					var cell2 = row.insertCell(row.cells.length);
					var text2 = document.createTextNode(element.categorie);
					cell2.appendChild(text2);

					var cell3 = row.insertCell(row.cells.length);
					var text3 = document.createTextNode(element.prix);
					cell3.appendChild(text3);

					var cell4 = row.insertCell(row.cells.length);
					var button4 = document.createElement('button');
					button4.innerHTML = 'Ajouter';
					button4.onclick = () => {
						ajax("panier-add.php?id=" + element.id, (responseText) => {
							updatePanier();
						});
					};
					cell4.appendChild(button4);
				});
				produits.style.backgroundColor = "#FFF";
			}

			function updatePanier() {
				var panier = document.getElementById("panier");
				panier.style.backgroundColor = "#AAA";
				if (panier == undefined) { return; }

				ajax("panier-list.php", (responseText) => {
					var ids = JSON.parse(responseText);
					var stack = [];
					if (ids.length == 0) {
						updatePanierStack(panier, stack);
					} else {
						Object.keys(ids).forEach((element) => {
							ajax("produit-get.php?id=" + element, (responseText) => {
								var produit = JSON.parse(responseText);
								stack.push(produit);
								if (stack.length == ids.length) {
									updatePanierStack(panier, stack);
								}
							});
						});
					}
				});
			}

			function updatePanierStack(panier, stack) {
				while (panier.rows.length > 1) {
					panier.deleteRow(1);
				}
				stack.sort((a, b) => { return (a.id - b.id); });
				stack.forEach((element) => {
					var row = panier.insertRow(panier.rows.length);

					var cell0 = row.insertCell(row.cells.length);
					var text0 = document.createTextNode(element.libelle);
					cell0.appendChild(text0);

					var cell1 = row.insertCell(row.cells.length);
					var text1 = document.createTextNode(element.description);
					cell1.appendChild(text1);

					var cell2 = row.insertCell(row.cells.length);
					var text2 = document.createTextNode(element.categorie);
					cell2.appendChild(text2);

					var cell3 = row.insertCell(row.cells.length);
					var text3 = document.createTextNode(element.prix);
					cell3.appendChild(text3);

					var cell4 = row.insertCell(row.cells.length);
					var button4 = document.createElement('button');
					button4.innerHTML = 'Retirer';
					button4.onclick = () => {
						ajax("panier-rem.php?id=" + element.id, (responseText) => {
							updatePanier();
						});
					};
					cell4.appendChild(button4);
				});
				panier.style.backgroundColor = "#FFF";
			}

			updateProduits();
			updatePanier();
		</script>
	</body>
</html>
