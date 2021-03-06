package dev.hydrosnow.memorygame;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class GameClock {
	private static final int TICKS_PER_SECOND = 20;
	private static final int DURATION_OF_TICK = 1_000_000_000 / TICKS_PER_SECOND;
	
	private final Map<Long, ArrayList<Runnable>> events;
	private boolean running = true;
	private long tick = 0;
	
	public GameClock() {
		events = new HashMap<>();
	}
	
	public void start() {
		Program.window().build();
		new Thread(this::run).start();
	}
	
	private void run() {
		long time;
		while (running) {
			time = System.nanoTime();
			
			final List<Runnable> list = events.get(tick);
			if (list != null) {
				for (final Runnable r : list) {
					try {
						r.run();
					} catch (final Exception e) {
						e.printStackTrace();
					}
				}
				events.remove(tick);
			}
			
			try {
				loop();
			} catch (final Exception e) {
				e.printStackTrace();
			}
			
			time = DURATION_OF_TICK - System.nanoTime() + time;
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
	
	private void loop() {
		if (!Program.window().isVisible()) {
			exit();
		}
	}
	
	private void exit() {
		Program.window().dispose();
		running = false;
	}
	
	public void timeEvent(final long delta, final Runnable event) {
		events.computeIfAbsent(tick + delta, (x) -> new ArrayList<>()).add(event);
	}
}
