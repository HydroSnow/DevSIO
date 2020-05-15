package dev.hydrosnow.shifumi.client;

import dev.hydrosnow.shifumi.server.Server;

import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Client {
	private static Client client = null;
	
	public static void pass() {
		if (client == null) {
			client = new Client();
			client.start();
		} else {
			throw new IllegalStateException("Can't init twice.");
		}
	}
	
	public static Client get() {
		if (client == null) {
			throw new IllegalStateException("Client is not initialized.");
		}
		return client;
	}
	
	private Connection connection;
	public boolean acceptInput = false;
	
	private Client() {
		System.out.println("Client init");
	}
	
	private void start() {
		System.out.println("Client start");
		try {
			final Socket socket = new Socket("localhost", 23669);
			connection = new Connection(socket);
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		final Scanner scanner = new Scanner(System.in);
		while (connection.isValid()) {
			final String input = scanner.nextLine();
			if (acceptInput) {
				switch (input.toLowerCase()) {
					case "p":
					case "pierre":
						connection.write(0x10);
						break;
					case "f":
					case "feuille":
						connection.write(0x11);
						break;
					case "c":
					case "ciseaux":
						connection.write(0x12);
						break;
				}
			}
		}
	}
}
