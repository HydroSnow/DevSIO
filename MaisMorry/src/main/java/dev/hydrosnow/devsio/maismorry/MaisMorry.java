package dev.hydrosnow.devsio.maismorry;

public class MaisMorry {
	private static GameClock clock;
	public static GameClock gameClock() {
		return clock;
	}
	
	public static void main(final String[] args) {
		clock = new GameClock();
		clock.start();
	}
}
