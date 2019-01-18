/*
 * Alexis Trupin 
 * 18 janvier 2019
 * BTS SIO - SLAM2
 * CHAPITRE 1 : Classes et Objets
 * Exemple Rectangle
 */
class Rectangle {
	private int longueur;
	private int largeur;
	
	private int origine_x;
	private int origine_y;
	
	public void deplace(int x, int y) {
		this.origine_x += x;
		this.origine_y += y;
	}
	
	public int surface() {
		return longueur * largeur;
	}
}
