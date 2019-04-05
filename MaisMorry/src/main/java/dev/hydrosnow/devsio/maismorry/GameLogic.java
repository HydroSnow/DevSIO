package dev.hydrosnow.devsio.maismorry;

public class GameLogic {
	private static GameTuile tuile = null;
	
	public static void click(final GameTuile clicked) {
		clicked.putTypeImage();
		clicked.setClickable(false);
		if (tuile == null) {
			tuile = clicked;
		} else {
			final GameTuile tuile = GameLogic.tuile;
			GameLogic.tuile = null;
			if (clicked.getType() == tuile.getType()) {
				MaisMorry.gameClock().timeEvent(20, () -> {
					clicked.putNullImage();
					clicked.setClickable(false);
					
					tuile.putNullImage();
					tuile.setClickable(false);
				});
			} else {
				MaisMorry.gameClock().timeEvent(20, () -> {
					clicked.putUnknownImage();
					clicked.setClickable(true);
					
					tuile.putUnknownImage();
					tuile.setClickable(true);
				});
			}
		}
	}
}
