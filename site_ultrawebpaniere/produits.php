<!doctype html>
<html>
	<head>
		<title>Les produits</title>
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
		<script src="ajax_json.js" type="text/javascript"></script>
		<script>
			produits = document.getElementById("produits");

			cache = {};

			function detailProduit(id, callback) {
				var produit = cache[id];
				if (produit === undefined) {
					ajax_json("api/produit.php?a=get&id=" + id, (response) => {
						cache[id] = response;
						callback(response);
					});
				} else {
					callback(produit);
				}
			}

			function updateProduitsStack(stack) {
				while (produits.rows.length > 1) { produits.deleteRow(1); }
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
						panier.style.backgroundColor = "#AAA";
						ajax_json("api/panier.php?a=add&id=" + element.id, (response) => {
							if (response.status == "error") { console.log(response.description); }
							updatePanierIds(response.panier);
						});
					};
					cell4.appendChild(button4);
				});
				produits.style.backgroundColor = "#FFF";
			}
			
			produits.style.backgroundColor = "#AAA";
			ajax_json("api/produit.php?a=list", (response) => {
				if (response.length == 0) {
					updateProduitsStack([]);
				} else {
					var stack = [];
					response.forEach((element) => {
						detailProduit(element, (produit) => {
							stack.push(produit);
							if (stack.length == response.length) { updateProduitsStack(stack); }
						});
					});
				}
			});
		</script>
	</body>
</html>
