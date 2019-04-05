package dev.hydrosnow.devsio.maismorry;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import static dev.hydrosnow.devsio.maismorry.GameTuile.State.*;

class GameLogic {
	private static final List<GameTuile> tuiles = new ArrayList<>();
	private static final Random random = new Random();
	
	private static GameTuile tuile = null;
	private static int tries = 0;
	
	public static void add(final GameTuile tuile) {
		tuiles.add(tuile);
	}
	
	public static void click(final GameTuile clicked) {
		if (clicked.getState() == IDLE) {
			clicked.setState(SELECTED);
			if (tuile == null) {
				tuile = clicked;
			} else {
				final GameTuile tuile = GameLogic.tuile;
				GameLogic.tuile = null;
				if (clicked.getType() == tuile.getType()) {
					MaisMorry.gameClock().timeEvent(20, () -> {
						clicked.setState(DISABLED);
						tuile.setState(DISABLED);
						checkVictory();
					});
				} else {
					MaisMorry.gameClock().timeEvent(20, () -> {
						clicked.setState(IDLE);
						tuile.setState(IDLE);
					});
				}
				
				tries++;
				MaisMorry.gameClock().gameWindow().setText("Tentatives : " + tries);
			}
		} else if (clicked.getState() == FINISHED) {
			clicked.setState(DISABLED);
			checkVictory();
		}
	}
	
	private static void checkVictory() {
		boolean finished = true;
		for (final GameTuile t : tuiles) {
			if (t.getState() != DISABLED) {
				finished = false;
				break;
			}
		}
		
		if (finished) {
			final int index = random.nextInt(tuiles.size());
			final GameTuile tuile = tuiles.get(index);
			tuile.setState(FINISHED);
		}
	}
}
