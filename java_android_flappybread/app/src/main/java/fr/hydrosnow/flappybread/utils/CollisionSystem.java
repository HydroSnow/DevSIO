package fr.hydrosnow.flappybread.utils;

import fr.hydrosnow.flappybread.GameView;
import fr.hydrosnow.flappybread.modeling.Model;

public abstract class CollisionSystem {
	
	public static float moveX(final Model amodel, final float move) {
		if (move == 0) {
			return 0;
		}
		
		float amp = move;
		for (final Model model : GameView.get().getModels()) {
			if (amodel != model && CollisionSystem.intersectsX(amodel, model, move)) {
				if (move < 0) {
					amp = Math.max(amp, model.getPositionX() + model.getWidth() - amodel.getPositionX());
				} else if (move > 0) {
					amp = Math.min(amp, model.getPositionX() - amodel.getPositionX() - amodel.getWidth());
				}
			}
		}
		
		return amp;
	}
	
	public static float moveY(final Model amodel, final float move) {
		if (move == 0) {
			return 0;
		}
		
		float amp = move;
		for (final Model model : GameView.get().getModels()) {
			if (amodel != model && CollisionSystem.intersectsY(amodel, model, move)) {
				if (move < 0) {
					amp = Math.max(amp, model.getPositionY() + model.getHeight() - amodel.getPositionY());
				} else if (move > 0) {
					amp = Math.min(amp, model.getPositionY() - amodel.getPositionY() - amodel.getHeight());
				}
			}
		}
		
		return amp;
	}
	
	private static boolean intersectsX(final Model amodel, final Model model, final float move) {
		return CollisionSystem.intersects(
				amodel.getPositionX() + move,
				amodel.getPositionY(),
				amodel.getWidth(),
				amodel.getHeight(),
				model.getPositionX(),
				model.getPositionY(),
				model.getWidth(),
				model.getHeight()
		);
	}
	
	private static boolean intersectsY(final Model amodel, final Model model, final float move) {
		return CollisionSystem.intersects(
				amodel.getPositionX(),
				amodel.getPositionY() + move,
				amodel.getWidth(),
				amodel.getHeight(),
				model.getPositionX(),
				model.getPositionY(),
				model.getWidth(),
				model.getHeight()
		);
	}
	
	private static boolean intersects(final float x1, final float y1, final float w1, final float h1, final float x2, final float y2, final float w2, final float h2) {
		return (x1 < x2 + w2 && x1 + w1 > x2 && y1 < y2 + h2 && y1 + h1 > y2);
	}
}
