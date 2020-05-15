package dev.hydrosnow.shifumi.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
	private static Server server = null;
	
	public static void pass() {
		if (server == null) {
			server = new Server();
			server.start();
		} else {
			throw new IllegalStateException("Can't init twice.");
		}
	}
	
	public static Server get() {
		if (server == null) {
			throw new IllegalStateException("Server is not initialized.");
		}
		return server;
	}
	
	private final Manager manager;
	
	private Server() {
		System.out.println("Server init");
		manager = new Manager();
	}
	
	private void start() {
		System.out.println("Server start");
		try {
			final ServerSocket socket = new ServerSocket(23669);
			
			while (true) {
				try {
					final Socket client = socket.accept();
					final String ip = client.getInetAddress().toString();
					System.out.println("Connection received from " + ip);
					final User user = new User(client);
					System.out.println("Passed init for " + ip);
					manager.put(user);
				} catch (final IOException e) {
					e.printStackTrace();
				}
			}
		} catch (final IOException e) {
			e.printStackTrace();
		}
	}
	
	public Manager getManager() {
		return manager;
	}
}
