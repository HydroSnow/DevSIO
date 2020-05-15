package fr.hydrosnow.sio;

import java.util.ArrayList;
import java.util.List;

public class MaisonEdition {
	private String nom;
	private List<Chanteur> chanteurs = new ArrayList<>();

	public MaisonEdition(String n) {
		nom = n;
	}

	public MaisonEdition() {
		nom = "Bilbo";
	}

	public void add(Chanteur c) {
		chanteurs.add(c);
	}

	public void set(List<Chanteur> t) {
		chanteurs = t;
	}

	public void show() {
		for (Chanteur c : chanteurs) {
			System.out.print(c.getNom() + " " + c.getPrenom());
		}
	}

}
