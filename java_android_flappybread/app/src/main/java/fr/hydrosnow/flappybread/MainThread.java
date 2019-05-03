package fr.hydrosnow.flappybread;

import android.graphics.Canvas;
import android.view.SurfaceHolder;

public class MainThread extends Thread {
	private static final int TICKS_PER_SECOND = 60;
	private static final int NANO_TICK_TIME = 1_000_000_000 / TICKS_PER_SECOND;
	
	private final SurfaceHolder surfaceHolder;
	private final GameView gameView;
	
	private Integer tick = 0;
	private boolean running = true;
	
	public MainThread(final SurfaceHolder surfaceHolder, final GameView gameView) {
		super();
		this.surfaceHolder = surfaceHolder;
		this.gameView = gameView;
	}
	
	@Override
	public void run() {
		final long[] time = new long[6];
		while (running) {
			time[0] = System.nanoTime();
			
			try {
				time[1] = System.nanoTime();
				final Canvas canvas = surfaceHolder.lockCanvas();
				time[1] = System.nanoTime() - time[1];
				
				try {
					synchronized (surfaceHolder) {
						time[2] = System.nanoTime();
						gameView.update();
						time[2] = System.nanoTime() - time[2];
						
						time[3] = System.nanoTime();
						gameView.draw(canvas);
						time[3] = System.nanoTime() - time[3];
					}
				} catch (final Exception e) {
					e.printStackTrace();
				}
				
				time[4] = System.nanoTime();
				try {
					surfaceHolder.unlockCanvasAndPost(canvas);
				} catch (final Exception e) {
					e.printStackTrace();
				}
				time[4] = System.nanoTime() - time[4];
			} catch (final Exception ignored) {
			}
			
			tick++;
			
			time[0] = System.nanoTime() - time[0];
			
			time[5] = NANO_TICK_TIME - time[0];
			if (time[5] > 0) {
				try {
					Thread.sleep(time[5] / 1_000_000, (int) time[5] % 1_000_000);
				} catch (final InterruptedException ignored) {}
			} else {
				System.out.print("OVERLOADED! ");
			}
			
			System.out.print("Tick " + tick);
			for (int a = 0; a < time.length; a++) {
				System.out.print(", [" + a + "] " + time[a] + " ns");
			}
			System.out.println();
		}
	}
	
	public void waitForEnd() {
		while (true) {
			try {
				join();
				break;
			} catch (final InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
	
	public void setRunning(final boolean r) {
		running = r;
	}
	
	public int getTick() {
		return tick;
	}
}