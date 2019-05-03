package fr.hydrosnow.flappybread.modeling;

import android.graphics.Canvas;
import android.graphics.Paint;

import fr.hydrosnow.flappybread.update.UpdateListener;

public class ColoredModel extends Model {
	
	private int width;
	private int height;
	
	private Paint paint;
	
	public ColoredModel(final float x, final float y, final UpdateListener... listeners) {
		super(x, y, listeners);
		paint = new Paint();
	}
	
	@Override
	public int getWidth() {
		return width;
	}
	
	public void setWidth(final int w) {
		width = w;
	}
	
	@Override
	public int getHeight() {
		return height;
	}
	
	public void setHeight(final int h) {
		height = h;
	}
	
	public void setColor(final int color) {
		paint.setColor(color);
	}
	
	@Override
	public void draw(final Canvas canvas) {
		canvas.drawRect(getPositionX(), getPositionY(), getPositionX() + width, getPositionY() + height, paint);
	}
}
