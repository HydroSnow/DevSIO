package fr.hydrosnow.sio;

public class Personne {

	private String prenom;
	private String nom;
	private int age;
	private String profession;
	private Personne conjoint;

	public Personne(String p, String n, int a) {
		prenom = p;
		nom = n;
		age = a;
		profession = "Unknown";
	}

	public Personne(String p, String n) {
		prenom = p;
		nom = n;
		age = -1;
		profession = "Unknown";
	}

	public Personne(String p, String n, int a, String pr) {
		prenom = p;
		nom = n;
		age = a;
		profession = pr;
	}

	public void setProfession(String n) {
		profession = n;
	}

	public void Set_Nom(String n) {
		nom = n;
	}

	public void setAge(int a) {
		age = a;
	}

	public String getNom() {
		return nom;
	}

	public String getPrenom() {
		return prenom;
	}

	public int getAge() {
		return age;
	}

	public String sePresenter() {
		if (age == -1) {
			return "Je m'appelle " + prenom + " " + nom;
		} else {
			return "Je m'appelle " + prenom + " " + nom + ", j'ai " + age + " ans.";
		}
	}

	public void Marier(Personne p) {
		conjoint = p;
	}

	public Personne estMarie() {
		if (conjoint != null) {
			return conjoint;
		} else {
			return new Personne("Celibataire", "Celibataire");
		}
	}

}
