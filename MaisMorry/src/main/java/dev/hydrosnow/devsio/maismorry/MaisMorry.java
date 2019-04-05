package dev.hydrosnow.devsio.maismorry;

import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class MaisMorry {
	private static final int TICKS_PER_SECOND = 20;
	private static final int DURATION_OF_TICK = 1_000_000_000 / TICKS_PER_SECOND;
	
	private static MaisMorry instance;
	
	public static MaisMorry get() {
		return instance;
	}
	
	public static void main(final String[] args) {
		instance = new MaisMorry();
		instance.run();
	}
	
	private GameWindow window = null;
	private boolean running = true;
	private long tick = 0;
	private Map<Long, ArrayList<Runnable>> events;
	
	private MaisMorry() {
		events = new HashMap<>();
		timeEvent(0, () -> window = new GameWindow());
	}
	
	private void run() {
		long time;
		while (running) {
			time = System.nanoTime();
			
			final List<Runnable> list = events.get(tick);
			if (list != null) {
				for (final Runnable r : list) {
					r.run();
				}
				events.remove(tick);
			}
			
			try {
				loop();
			} catch (final Exception e) {
				e.printStackTrace();
				exit();
			}
			
			time = (System.nanoTime() - time);
			time = DURATION_OF_TICK - time;
			if (time > 0) {
				try {
					Thread.sleep(time / 1_000_000L, (int) (time % 1_000_000));
				} catch (final InterruptedException ignored) {
				}
			} else {
				System.out.println("Can't keep up!");
			}
			
			tick++;
		}
	}
	
	private void exit() {
		window.dispose();
		running = false;
	}
	
	private void loop() {
		if (!window.isVisible()) {
			exit();
		}
	}
	
	public URL getResource(final String path) {
		return MaisMorry.class.getResource(path);
	}
	
	public void timeEvent(final long delta, final Runnable event) {
		events.computeIfAbsent(tick + delta, (x) -> new ArrayList<>()).add(event);
	}
}
