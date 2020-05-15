package dev.hydrosnow.shifumi.server;

public class Session {
	public static void start(final User user1, final User user2) {
		new Session(user1, user2);
	}
	
	private final User user1;
	private Choice user1c;
	
	private final User user2;
	private Choice user2c;
	
	public Session(final User user1, final User user2) {
		this.user1 = user1;
		user1c = null;
		user1.session(this);
		
		this.user2 = user2;
		user2c = null;
		user2.session(this);
	}
	
	public void handle(final User user, final Choice c) {
		if (user == user1) {
			if (user1c != null) {
				throw new IllegalStateException("user shouldn't modify his choice");
			}
			
			user1c = c;
			user1.write(0x30);
			user2.write(0x31);
			
		} else if (user == user2) {
			if (user2c != null) {
				throw new IllegalStateException("user shouldn't modify his choice");
			}
			
			user2c = c;
			user2.write(0x30);
			user1.write(0x31);
			
		} else {
			throw new IllegalArgumentException("this user is not located in this session");
		}
		
		if (user1c != null && user2c != null) {
			
			if (user1c == Choice.PIERRE) {
				user2.write(0x40);
			} else if (user1c == Choice.FEUILLE) {
				user2.write(0x41);
			} else if (user1c == Choice.CISEAUX) {
				user2.write(0x42);
			} else {
				throw new IllegalStateException("we shouldn't be here");
			}
			
			if (user2c == Choice.PIERRE) {
				user1.write(0x40);
			} else if (user2c == Choice.FEUILLE) {
				user1.write(0x41);
			} else if (user2c == Choice.CISEAUX) {
				user1.write(0x42);
			} else {
				throw new IllegalStateException("we shouldn't be here");
			}
			
			if (user1c.win(user2c)) {
				user1.write(0x50);
				user2.write(0x52);
				
			} else if (user1c.draw(user2c)) {
				user1.write(0x51);
				user2.write(0x51);
				
			} else if (user1c.lose(user2c)) {
				user1.write(0x52);
				user2.write(0x50);
				
			} else {
				throw new IllegalStateException("we shouldn't be here");
			}
			
			terminate();
		}
	}
	
	public void terminate() {
		if (user1.isValid()) {
			user1.session(null);
			Server.get().getManager().put(user1);
		}
		
		if (user2.isValid()) {
			user2.session(null);
			Server.get().getManager().put(user2);
		}
	}
}
