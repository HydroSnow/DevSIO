public class Main {
	public static void main(String[] args) {
		final Identifiable matthieu_pauvre = new Matthieu("pauvre", -10);
		matthieu_pauvre.check();
		
		System.out.println();
		
		final Identifiable matthieu_riche = new Matthieu("riche", 10_000);
		matthieu_riche.check();
	}
}

interface Identifiable {
	void check();
}

abstract class SIO {
	protected double thunasse;
	
	protected SIO(final double thunasse) {
		this.thunasse = thunasse;
		System.out.println("Construction d'un SIO avec " + thunasse + "€");
	}
}

class Matthieu extends SIO implements Identifiable {
	private final String id;
	
	public Matthieu(final String id, final double thunasse) {
		super(thunasse);
		this.id = id;
		System.out.println("Construction d'un Matthieu " + id);
	}
	
	@Override
	public void check() {
		if (thunasse < 0) {
			System.out.println(id + " : je suis gilet jaune");
		} else {
			System.out.println(id + " : je conduis un hélicoptère");
		}
	}
}
