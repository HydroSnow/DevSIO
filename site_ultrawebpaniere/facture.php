<?php
	include_once('tcpdf/tcpdf.php');
	$pdf = new TCPDF(PDF_PAGE_ORIENTATION, PDF_UNIT, PDF_PAGE_FORMAT, true, 'UTF-8', false);
	$pdf->SetCreator(PDF_CREATOR);
	$pdf->SetAuthor('Vegania');
	$pdf->SetTitle('Facture');
	$pdf->SetSubject('TCPDF Tutorial');
	$pdf->SetKeywords('TCPDF, PDF, example, test, guide');
	$pdf->SetDefaultMonospacedFont(PDF_FONT_MONOSPACED);
	$pdf->SetMargins(PDF_MARGIN_LEFT, PDF_MARGIN_TOP, PDF_MARGIN_RIGHT);
	$pdf->SetAutoPageBreak(TRUE, PDF_MARGIN_BOTTOM);
	$pdf->setFontSubsetting(true);
	$pdf->SetFont('dejavusans', '', 11, '', true);
	$pdf->SetPrintHeader(false);
	$pdf->SetPrintFooter(false);
	$pdf->AddPage();

	ob_start();
?>

<style>
	.tprohead {
		text-align: left;
	}

	.tprobody {
		text-align: center;
	}
</style>

<p>Facture n°69420 à l'attention de monsieur Grenade Flash</p>
<p>Détails :</p>
<table>
	<tr>
		<td> Produit : </td>
		<td> Quantité : </td>
		<td> Prix unitaire : </td>
		<td> Prix total : </td>
	</tr>
	<tr class="tprobody">
		<td> Uranium </td>
		<td> 100 </td>
		<td> 37.90€ </td>
		<td> 3790€ </td>
	</tr>
	<tr class="tprobody">
		<td> Resolv </td>
		<td> 100 </td>
		<td> 37.90€ </td>
		<td> 3790€ </td>
	</tr>
</table>
<p>Prix :</p>
<table>
	<tr><td> Prix HT : 13942586€ </td></tr>
	<tr><td> TVA : 12€ </td></tr>
	<tr><td> Prix TTC : 1 kebab </td></tr>
</table>
<p>Adresse de livraison :</p>
<table>
	<tr><td> 85 impasse du cygne </td></tr>
	<tr><td> appartement 824319458 bâtiment C1ZNUJIJZA9R230 </td></tr>
	<tr><td> 75000 ici c'est paris ! </td></tr>
</table>
<p>Voilou</p>

<?php
	$html = ob_get_contents();
	ob_end_clean();

	$pdf->writeHTML($html, true, false, true, false, '');
	$pdf->Output('facture.pdf', 'I');
?>
