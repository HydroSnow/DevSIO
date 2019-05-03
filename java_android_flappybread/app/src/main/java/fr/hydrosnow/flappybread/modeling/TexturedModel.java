package fr.hydrosnow.flappybread.modeling;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;

import fr.hydrosnow.flappybread.update.UpdateListener;

public class TexturedModel extends Model {
	private Bitmap texture = null;
	
	public TexturedModel(final float x, final float y, final UpdateListener... listeners) {
		super(x, y, listeners);
	}
	
	@Override
	public int getWidth() {
		return texture.getWidth();
	}
	
	@Override
	public int getHeight() {
		return texture.getHeight();
	}
	
	public void setTexture(final Bitmap bmp) {
		texture = bmp;
	}
	
	@Override
	public void draw(final Canvas canvas) {
		canvas.drawBitmap(texture, getPositionX(), getPositionY(), null);
	}
}
