package fr.hydrosnow.flappybread;

import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;

import java.util.Random;

import fr.hydrosnow.flappybread.modeling.ColoredModel;
import fr.hydrosnow.flappybread.modeling.Model;
import fr.hydrosnow.flappybread.utils.SafeModelList;
import fr.hydrosnow.flappybread.modeling.TexturedModel;

import static fr.hydrosnow.flappybread.update.DefaultUpdateListeners.*;

public class GameView extends SurfaceView implements SurfaceHolder.Callback {
	private static GameView gameView;
	public static GameView get() {
		return gameView;
	}
	
	private final MainThread thread;
	private final SafeModelList models;
	private final Random random;
	
	private final int width;
	private final int height;
	
	public GameView(final MainActivity mainActivity) {
		super(mainActivity);
		
		gameView = this;
		
		getHolder().addCallback(this);
		thread = new MainThread(getHolder(), this);
		setFocusable(true);
		
		models = new SafeModelList();
		random = new Random();
		
		width = Resources.getSystem().getDisplayMetrics().widthPixels;
		height = Resources.getSystem().getDisplayMetrics().heightPixels;
		
		final Bitmap bmp = BitmapFactory.decodeResource(getResources(), R.mipmap.ic_launcher_round);
		final TexturedModel player = new TexturedModel(100, 100, GRAVITY, SPEED_PROCESS, AUTO_REMOVE);
		player.setTexture(bmp);
		models.add(player);
		
		final ColoredModel ceiling = new ColoredModel(0, 0);
		ceiling.setColor(Color.RED);
		ceiling.setWidth(width);
		ceiling.setHeight(50);
		models.add(ceiling);
		
		final ColoredModel floor = new ColoredModel(0, height - 50);
		floor.setColor(Color.RED);
		floor.setWidth(width);
		floor.setHeight(50);
		models.add(floor);
		
		setOnTouchListener(new OnTouchListener() {
			@Override
			public boolean onTouch(final View v, final MotionEvent event) {
				if (event.getAction() == MotionEvent.ACTION_DOWN) {
					v.performClick();
					
					if (player.getSpeedY() > 0) {
						player.setSpeedY(-15);
					} else {
						player.setSpeedY(player.getSpeedY() - 15);
					}
				}
				return true;
			}
		});
	}
	
	@Override
	public void surfaceCreated(final SurfaceHolder holder) {
		thread.setRunning(true);
		thread.start();
	}
	
	@Override
	public void surfaceChanged(final SurfaceHolder holder, final int format, final int width, final int height) {
	}
	
	@Override
	public void surfaceDestroyed(final SurfaceHolder holder) {
		thread.setRunning(false);
		thread.waitForEnd();
	}
	
	@Override
	public void draw(final Canvas canvas) {
		super.draw(canvas);
		if (canvas != null) {
			canvas.drawColor(Color.WHITE);
			for (final Model model : models) {
				model.draw(canvas);
			}
		}
		
	}
	
	public void update() {
		if (thread.getTick() % 180 == 0) {
			final int clocate = random.nextInt() % 300 - 150 + (height / 2);
			
			final ColoredModel top = new ColoredModel(width - 1,  50, SPEED_PROCESS, AUTO_REMOVE);
			top.setColor(Color.BLACK);
			top.setWidth(50);
			top.setHeight(clocate - 50 - 200);
			top.setSpeedX(-2);
			models.add(top);
			
			final ColoredModel bottom = new ColoredModel(width - 1, clocate + 200, SPEED_PROCESS, AUTO_REMOVE);
			bottom.setColor(Color.BLACK);
			bottom.setWidth(50);
			bottom.setHeight(height - clocate - 200 - 50);
			bottom.setSpeedX(-2);
			models.add(bottom);
		}
		
		models.update();
		
		for (final Model model : models) {
			model.update();
		}
		
	}
	
	public SafeModelList getModels() {
		return models;
	}
}
