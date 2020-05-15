package dev.hydrosnow.shifumi.server;

import java.util.ArrayList;
import java.util.List;

public class Manager {
	private final List<User> users;
	
	public Manager() {
		users = new ArrayList<>();
	}
	
	public void put(final User... us) {
		for (final User user : us) {
			if (!user.isValid()) {
				continue;
			}
			
			synchronized (users) {
				users.add(user);
			}
			
			if (users.size() >= 2) {
				final User user1;
				final User user2;
				synchronized (users) {
					user1 = users.get(0);
					user2 = users.get(1);
					users.remove(user1);
					users.remove(user2);
				}
				Session.start(user1, user2);
			}
		}
	}
	
	public void remove(final User user) {
		synchronized (users) {
			users.remove(user);
		}
	}
}
