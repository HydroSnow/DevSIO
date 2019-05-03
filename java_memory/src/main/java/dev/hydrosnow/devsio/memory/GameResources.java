package dev.hydrosnow.devsio.memory;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;

class GameResources {
	private final Map<String, BufferedImage> images;
	
	private final BufferedImage imageUnknown;
	private final BufferedImage imageVictory;
	
	public GameResources() {
		images = new HashMap<>();
		imageUnknown = getImage("/mystery.png");
		imageVictory = getImage("/gagnere.png");
	}
	
	public BufferedImage getImageUnknown() {
		return imageUnknown;
	}
	
	public BufferedImage getImageVictory() {
		return imageVictory;
	}
	
	public BufferedImage getImage(final String path) {
		return images.computeIfAbsent(path, (p) -> {
			try {
				final URL url = Program.class.getResource(p);
				BufferedImage image = ImageIO.read(url);
				images.put(p, image);
				return image;
			} catch (final IOException | NullPointerException e) {
				e.printStackTrace();
				return null;
			}
		});
	}
}
