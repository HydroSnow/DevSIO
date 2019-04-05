package dev.hydrosnow.devsio.maismorry;

public class TuileClickManager {
	private static Tuile tuile = null;
	
	public static void click(final Tuile clicked) {
		if (tuile == null) {
			clicked.putTypeImage();
			tuile = clicked;
		} else {
			if (tuile != clicked) {
				clicked.putTypeImage();
				final Tuile tuile = TuileClickManager.tuile;
				TuileClickManager.tuile = null;
				if (clicked.getType() == tuile.getType()) {
					MaisMorry.get().timeEvent(20, () -> {
						clicked.grenadeFlash();
						tuile.grenadeFlash();
					});
				} else {
					MaisMorry.get().timeEvent(20, () -> {
						clicked.putUnknownImage();
						tuile.putUnknownImage();
					});
				}
			}
		}
	}
}
