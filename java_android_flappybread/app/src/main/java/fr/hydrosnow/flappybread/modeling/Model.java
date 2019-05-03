package fr.hydrosnow.flappybread.modeling;

import android.graphics.Canvas;

import fr.hydrosnow.flappybread.GameView;
import fr.hydrosnow.flappybread.update.UpdateListener;
import fr.hydrosnow.flappybread.utils.CollisionSystem;

public abstract class Model {
	
	private float positionX = 0;
	private float positionY = 0;
	
	private float speedX = 0;
	private float speedY = 0;
	
	private final UpdateListener[] listeners;
	
	public Model(final float x, final float y, final UpdateListener... ul) {
		positionX = x;
		positionY = y;
		listeners = ul;
	}
	
	public abstract int getWidth();
	
	public abstract int getHeight();
	
	public float getPositionX() {
		return positionX;
	}
	
	public void moveX(final float dpx) {
		final float rdpx = CollisionSystem.moveX(this, dpx);
		if (rdpx != dpx) {
			setSpeedX(0);
		}
		positionX += rdpx;
	}
	
	public float getPositionY() {
		return positionY;
	}
	
	public void moveY(final float dpy) {
		final float rdpy = CollisionSystem.moveY(this, dpy);
		if (rdpy != dpy) {
			setSpeedY(0);
		}
		positionY += rdpy;
	}
	
	public float getSpeedX() {
		return speedX;
	}
	
	public void setSpeedX(final float sx) {
		speedX = sx;
	}
	
	public void addSpeedX(final float dsx) {
		speedX += dsx;
	}
	
	public float getSpeedY() {
		return speedY;
	}
	
	public void setSpeedY(final float sy) {
		speedY = sy;
	}
	
	public void addSpeedY(final float dsy) {
		speedY += dsy;
	}
	
	public void update() {
		for (final UpdateListener ul : listeners) {
			ul.update(this);
		}
	}
	
	public void remove() {
		GameView.get().getModels().remove(this);
	}
	
	public abstract void draw(final Canvas canvas);
}
