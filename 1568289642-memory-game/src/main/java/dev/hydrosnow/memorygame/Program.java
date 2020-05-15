package dev.hydrosnow.memorygame;

class Program {
	private static GameLogic logic;
	private static GameResources resources;
	private static GameClock clock;
	private static GameWindow window;
	
	public static GameLogic logic() {
		return logic;
	}
	
	public static GameResources resources() {
		return resources;
	}
	
	public static GameWindow window() {
		return window;
	}
	
	public static GameClock clock() {
		return clock;
	}
	
	public static void main(final String[] args) {
		logic = new GameLogic();
		resources = new GameResources();
		window = new GameWindow();
		clock = new GameClock();
		clock.start();
	}
}
