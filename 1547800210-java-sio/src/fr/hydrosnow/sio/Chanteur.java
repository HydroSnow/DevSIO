package fr.hydrosnow.sio;

public class Chanteur extends Personne {

	private String MaisonEdition;

	public Chanteur(String p, String n, int a) {
		super(p, n, a);
		super.setProfession("Chanteur");
	}

	public Chanteur(String p, String n) {
		super(p, n);
		super.setAge(-1);
		super.setProfession("Chanteur");
	}

	public void Set_MaisEdit(String m) {
		MaisonEdition = m;
	}

	public String Get_MaisEdit() {
		return MaisonEdition;
	}

	@Override
	public String sePresenter() {
		if (super.getAge() == -1) {
			return "Je m'appelle " + super.getPrenom() + " " + super.getNom() + ". Je suis chanteur !";
		} else {
			return "Je m'appelle " + super.getPrenom() + " " + super.getNom() + ", j'ai " + super.getAge() + " ans."
					+ " Je suis chanteur !";
		}
	}

}
