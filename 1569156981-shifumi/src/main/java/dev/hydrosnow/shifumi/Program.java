package dev.hydrosnow.shifumi;

import dev.hydrosnow.shifumi.client.Client;
import dev.hydrosnow.shifumi.server.Server;

import java.util.Arrays;

public class Program {
	public static void main(final String[] args) {
		boolean server = false;
		
		System.out.println("Command arguments: " + Arrays.toString(args));
		for (final String str : args) {
			if (str.equalsIgnoreCase("--server")) {
				server = true;
			} else if (str.equalsIgnoreCase("--client")) {
				server = false;
			} else {
				System.out.println("Unknown argument: " + str);
			}
		}
		
		if (server) {
			Server.pass();
		} else {
			Client.pass();
		}
	}
	
}
