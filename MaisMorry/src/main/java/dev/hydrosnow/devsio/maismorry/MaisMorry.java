package dev.hydrosnow.devsio.maismorry;

public class MaisMorry {
	private static final int TICKS_PER_SECOND = 60;
	private static final int DURATION_OF_TICK = 1_000_000_000 / TICKS_PER_SECOND;
	
	private static MaisMorry instance;
	
	public static MaisMorry getInstance() {
		return instance;
	}
	
	public static void main(final String[] args) {
		instance = new MaisMorry();
	}
	
	private final Window window;
	private boolean running = true;
	
	private MaisMorry() {
		window = new Window();
		long time = 0;
		while (running) {
			time = System.nanoTime();
			
			loop();
			
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
		}
	}
	
	private void loop() {
		if (!window.isVisible()) {
			running = false;
		}
	}
}
