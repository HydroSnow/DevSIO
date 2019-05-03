package fr.hydrosnow.flappybread.update;

import android.content.res.Resources;

import fr.hydrosnow.flappybread.modeling.Model;

public class DefaultUpdateListeners {
	public static final UpdateListener SPEED_PROCESS = new UpdateListener() {
		@Override
		public void update(Model m) {
			m.moveX(m.getSpeedX());
			m.moveY(m.getSpeedY());
		}
	};
	
	public static final UpdateListener GRAVITY = new UpdateListener() {
		@Override
		public void update(final Model m) {
			m.addSpeedY(1);
		}
	};
	
	public static final UpdateListener AUTO_REMOVE = new UpdateListener() {
		@Override
		public void update(Model m) {
			final float screenWidth = Resources.getSystem().getDisplayMetrics().widthPixels;
			final float screenHeight = Resources.getSystem().getDisplayMetrics().heightPixels;
			if (m.getPositionX() + m.getWidth() < 0 || m.getPositionY() + m.getHeight() < 0 || m.getPositionX() > screenWidth || m.getPositionY() > screenHeight) {
				m.remove();
			}
		}
	};
}
