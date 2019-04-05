package dev.hydrosnow.devsio.memory;

class Program {
	private static GameLogic logic;
	public static GameLogic logic() {
		return logic;
	}
	
	private static GameResources resources;
	public static GameResources resources() {
		return resources;
	}
	
	private static GameClock clock;
	public static GameClock clock() {
		return clock;
	}
	
	private static GameWindow window;
	public static GameWindow window() {
		return window;
	}
	
	public static void main(final String[] args) {
		logic = new GameLogic();
		
		resources = new GameResources();
		
		window = new GameWindow();
		
		clock = new GameClock();
		clock.start();
	}
}
