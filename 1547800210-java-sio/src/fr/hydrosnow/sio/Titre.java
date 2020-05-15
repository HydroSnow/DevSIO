package fr.hydrosnow.sio;

public class Titre {
	private String nom;
	private int annee;

	public Titre(String nom, int aannee) {
		this.nom = nom;
		this.annee = aannee;
	}

	public Titre(String nom) {
		this.nom = nom;
		annee = -1;
	}

	public String getNom() {
		return nom;
	}
	
	public int getAnnee() {
		return annee;
	}
}
