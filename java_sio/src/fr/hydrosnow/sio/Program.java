package fr.hydrosnow.sio;

public class Program {

	public static void main(String[] args) {

		final Personne p = new Personne("Arthur", "Titos", 10);
		p.sePresenter();
		
		final Chanteur c0 = new Chanteur("Julien", "Mari");
		final Chanteur c1 = new Chanteur("Gandhi", "Djuna");

		final MaisonEdition m = new MaisonEdition("Cheval");
		final Auteur a = new Auteur("Sarah", "Tremouille", 35);
		final Titre t1 = new Titre("Le seigneur des anneaux");
		final Titre t2 = new Titre("Le seigneur des pinceaux", 2038);
		a.addTitre(t1);
		a.addTitre(t2);

		String s = "";
		for (Titre t : a.getTitres()) {
			s += t.getNom() + " et ";
		}
		s = s.substring(s.length() - 4, 4);
		System.out.println(a.sePresenter() + s + " : " + a.nbTitres() + ".");

		m.add(c0);
		m.add(c1);

		m.show();
	}

}
