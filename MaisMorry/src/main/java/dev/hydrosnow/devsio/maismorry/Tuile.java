package dev.hydrosnow.devsio.maismorry;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;

import javax.imageio.ImageIO;

public class Tuile extends JPanel {
	
	private BufferedImage imageUnknown = null;
	private TuileType type;
	
	private BufferedImage current = null;
	
	private boolean activated = true;
	
	public Tuile(final TuileType type) {
		try {
			final URL url = MaisMorry.get().getResource("/mystery.png");
			imageUnknown = ImageIO.read(url);
		} catch (final IOException | NullPointerException e) {
			e.printStackTrace();
		}
		
		current = imageUnknown;
		
		this.type = type;
		
		final Tuile tuile = this;
		
		addMouseListener(new MouseListener() {
			@Override
			public void mouseClicked(final MouseEvent e) { }
			
			@Override
			public void mousePressed(final MouseEvent e) {
				if (activated) {
					TuileClickManager.click(tuile);
				}
			}
			
			@Override
			public void mouseReleased(final MouseEvent e) { }
			
			@Override
			public void mouseEntered(final MouseEvent e) { }
			
			@Override
			public void mouseExited(final MouseEvent e) { }
		});
	}
	
	public TuileType getType() {
		return type;
	}
	
	public void putTypeImage() {
		current = type.getImage();
		repaint();
	}
	
	public void putUnknownImage() {
		current = imageUnknown;
		repaint();
	}
	
	public void grenadeFlash() {
		imageUnknown = null;
		putUnknownImage();
		activated = false;
	}
	
	@Override
	protected void paintComponent(final Graphics g) {
		super.paintComponent(g);
		if (current != null) {
			g.drawImage(current, 0, 0, this);
		}
	}
}
