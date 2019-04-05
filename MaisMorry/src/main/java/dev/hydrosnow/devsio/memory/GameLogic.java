package dev.hydrosnow.devsio.memory;

import java.util.List;
import java.util.Random;

import static dev.hydrosnow.devsio.memory.Tuile.State.*;

class GameLogic {
	private final Random random;
	
	private Tuile tuile = null;
	private int tries = 0;
	
	public GameLogic() {
		random = new Random();
	}
	
	public void click(final Tuile clicked) {
		if (clicked.getState() == IDLE) {
			clicked.setState(SELECTED);
			if (tuile == null) {
				tuile = clicked;
			} else {
				final Tuile tuile = this.tuile;
				this.tuile = null;
				if (clicked.getType() == tuile.getType()) {
					Program.clock().timeEvent(20, () -> {
						clicked.setState(DISABLED);
						tuile.setState(DISABLED);
						checkVictory();
					});
				} else {
					Program.clock().timeEvent(20, () -> {
						clicked.setState(IDLE);
						tuile.setState(IDLE);
					});
				}
				
				tries++;
				Program.window().setText("Tentatives : " + tries);
			}
		} else if (clicked.getState() == FINISHED) {
			clicked.setState(DISABLED);
			victory(Program.window().getTuiles());
		}
	}
	
	private void checkVictory() {
		final List<Tuile> tuiles = Program.window().getTuiles();
		
		for (final Tuile t : tuiles) {
			if (t.getState() != DISABLED) {
				return;
			}
		}
		
		victory(tuiles);
	}
	
	private void victory(final List<Tuile> tuiles) {
		final int index = random.nextInt(tuiles.size());
		final Tuile tuile = tuiles.get(index);
		tuile.setState(FINISHED);
	}
}
