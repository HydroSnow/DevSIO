package dev.hydrosnow.shifumi.server;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class User {
	private final Socket socket;
	private final InputStream in;
	private final OutputStream out;
	
	private boolean valid;
	private Session session;
	
	public User(final Socket socket) throws IOException {
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
	
	public void session(final Session session) {
		this.session = session;
		if (session != null) {
			write(0x20);
		} else {
			write(0x21);
		}
	}
	
	public boolean isValid() {
		return valid;
	}
	
	public void write(int b) {
		try {
			out.write(b);
		} catch (final IOException e) {
			e.printStackTrace();
			destroy("write failed");
		}
		
	}
	
	private void listen() {
		while (valid) {
			try {
				final int id = in.read();
				switch (id) {
					case 0x00:
						break;
					case 0x01:
						final String ip = socket.getInetAddress().toString();
						System.out.println("Client " + ip + " is maybe drunk");
						break;
					case 0x02:
						destroy("connection end");
						break;
					case 0x10:
						if (session != null) {
							session.handle(this, Choice.PIERRE);
						}
						break;
					case 0x11:
						if (session != null) {
							session.handle(this, Choice.FEUILLE);
						}
						break;
					case 0x12:
						if (session != null) {
							session.handle(this, Choice.CISEAUX);
						}
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
		final String ip = socket.getInetAddress().toString();
		System.out.println("Destroyed connection " + ip + " for: " + reason);
		
		valid = false;
		
		try {
			out.write(0x02);
		} catch (final IOException ignored) { }
		
		if (session == null) {
			Server.get().getManager().remove(this);
		} else {
			session.terminate();
		}
	}
}
