package fr.hydrosnow.sio;

import java.util.List;
import java.util.ArrayList;

public class Auteur extends Personne {
	private List<Titre> titres = new ArrayList<>();

	public Auteur(String p, String n, int a) {
		super(p, n, a);
		super.setProfession("Auteur");
	}

	public Auteur(String p, String n) {
		super(p, n);
		super.setAge(-1);
		super.setProfession("Auteur");
	}

	public void addTitre(Titre t) {
		titres.add(t);
	}

	public void setTitres(List<Titre> lt) {
		titres = lt;
	}

	public List<Titre> getTitres() {
		return titres;
	}

	public int nbTitres() {
		return titres.size();
	}

	@Override
	public String sePresenter() {
		if (super.getAge() == -1) {
			return "Je m'appelle " + super.getPrenom() + " " + super.getNom() + ". Je suis auteur !";
		} else {
			return "Je m'appelle " + super.getPrenom() + " " + super.getNom() + ", j'ai " + super.getAge() + " ans."
					+ " Je suis auteur !";
		}
	}
}
