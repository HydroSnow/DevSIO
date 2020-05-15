package dev.hydrosnow.shifumi.server;

public enum Choice {
	PIERRE, FEUILLE, CISEAUX;
	
	public boolean win(final Choice other) {
		if (this == PIERRE) {
			return other == CISEAUX;
		} else if (this == FEUILLE) {
			return other == PIERRE;
		} else if (this == CISEAUX) {
			return other == FEUILLE;
		}
		throw new IllegalStateException("oh");
	}
	
	public boolean draw(final Choice other) {
		if (this == PIERRE) {
			return other == PIERRE;
		} else if (this == FEUILLE) {
			return other == FEUILLE;
		} else if (this == CISEAUX) {
			return other == CISEAUX;
		}
		throw new IllegalStateException("oh");
	}
	
	public boolean lose(final Choice other) {
		if (this == PIERRE) {
			return other == FEUILLE;
		} else if (this == FEUILLE) {
			return other == CISEAUX;
		} else if (this == CISEAUX) {
			return other == PIERRE;
		}
		throw new IllegalStateException("oh");
	}
}
