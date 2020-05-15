package dev.hydrosnow.shifumi.client;

import dev.hydrosnow.shifumi.server.Choice;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class Connection {
	private final Socket socket;
	private final InputStream in;
	private final OutputStream out;
	
	private boolean valid;
	
	public Connection(final Socket socket) throws IOException {
		final Thread listenThread = new Thread(this::listen);
		final Thread heartbeatThread = new Thread(this::heartbeat);
		
		this.socket = socket;
		in = socket.getInputStream();
		out = socket.getOutputStream();
		
		out.write(0x01);
		final int conn_start = in.read();
		if (conn_start != 0x01) {
			throw new IOException("Invalid connection start byte");
		}
		
		valid = true;
		
		listenThread.start();
		heartbeatThread.start();
	}
	
	public void write(int b) {
		try {
			out.write(b);
		} catch (final IOException e) {
			e.printStackTrace();
			destroy("write failed");
		}
		
	}
	
	public boolean isValid() {
		return valid;
	}
	
	private void listen() {
		while (valid) {
			try {
				final int id = in.read();
				switch (id) {
					case 0x00:
						break;
					case 0x01:
						System.out.println("Server is maybe drunk");
						break;
					case 0x02:
						destroy("connection end");
						break;
					case 0x20:
						System.out.println("=== Vous êtes entrés dans une session.");
						Client.get().acceptInput = true;
						break;
					case 0x21:
						System.out.println("=== Vous êtes sortis de la session.");
						Client.get().acceptInput = false;
						break;
					case 0x30:
						System.out.println("=== Vous avez envoyé votre choix.");
						break;
					case 0x31:
						System.out.println("=== L'ennemi a envoyé son choix.");
						break;
					case 0x40:
						System.out.println("=== L'ennemi a joué Pierre.");
						break;
					case 0x41:
						System.out.println("=== L'ennemi a joué Feuille.");
						break;
					case 0x42:
						System.out.println("=== L'ennemi a joué Ciseaux.");
						break;
					case 0x50:
						System.out.println("=== Vous avez gagné !");
						break;
					case 0x51:
						System.out.println("=== Vous avez fait une égalité.");
						break;
					case 0x52:
						System.out.println("=== Vous avez perdu.");
						break;
					default:
						destroy("unknown packet " + id);
						break;
				}
				
			} catch (final Exception e) {
				e.printStackTrace();
				destroy("exception");
			}
		}
	}
	
	private void heartbeat() {
		while (valid) {
			try {
				write(0x00);
				Thread.sleep(1000);
			} catch (final InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
	
	private void destroy(final String reason) {
		System.out.println("Destroyed connection for: " + reason);
		
		valid = false;
		try {
			out.write(0x02);
		} catch (final IOException ignored) { }
		
	}
}
