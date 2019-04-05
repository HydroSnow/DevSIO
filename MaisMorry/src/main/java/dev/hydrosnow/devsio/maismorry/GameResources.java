package dev.hydrosnow.devsio.maismorry;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;

class GameResources {
	private static final Map<String, BufferedImage> images = new HashMap<>();
	public static BufferedImage getImage(final String path) {
		return images.computeIfAbsent(path, (p) -> {
			try {
				final URL url = MaisMorry.class.getResource(p);
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
