package dev.hydrosnow.devsio.maismorry;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;

public enum TuileType {
	MRGF_1("/mrgf_1_res.png"),
	MRGF_2("/mrgf_2_res.png"),
	MRGF_3("/mrgf_3_res.png"),
	MRGF_4("/mrgf_4_res.png"),
	MRGF_5("/mrgf_5_res.png"),
	MRGF_6("/mrgf_6_res.png"),
	MRGF_7("/mrgf_7_res.png"),
	MRGF_8("/mrgf_8_res.png");
	
	private BufferedImage image = null;
	
	TuileType(final String path) {
		try {
			final URL url = MaisMorry.get().getResource(path);
			image = ImageIO.read(url);
		} catch (final IOException | NullPointerException e) {
			e.printStackTrace();
		}
	}
	
	public BufferedImage getImage() {
		return image;
	}
}
