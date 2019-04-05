package dev.hydrosnow.devsio.maismorry;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;

public class GameTuile extends JPanel {
	
	private BufferedImage imageUnknown;
	private BufferedImage imageCurrent;
	private TuileType type;
	
	private boolean clickable = true;
	
	public GameTuile(final TuileType type) {
		imageUnknown = GameResources.getImage("/mystery.png");
		imageCurrent = imageUnknown;
		
		this.type = type;
		
		final GameTuile tuile = this;
		addMouseListener(new MouseListener() {
			@Override
			public void mouseClicked(final MouseEvent e) { }
			
			@Override
			public void mousePressed(final MouseEvent e) {
				if (clickable) {
					GameLogic.click(tuile);
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
	
	public void putNullImage() {
		imageCurrent = null;
		repaint();
	}
	
	public void putTypeImage() {
		imageCurrent = type.getImage();
		repaint();
	}
	
	public void putUnknownImage() {
		imageCurrent = imageUnknown;
		repaint();
	}
	
	public void setClickable(final boolean c) {
		clickable = c;
	}
	
	@Override
	protected void paintComponent(final Graphics g) {
		super.paintComponent(g);
		if (imageCurrent != null) {
			g.drawImage(imageCurrent, 0, 0, this);
		}
	}
	
	public enum TuileType {
		MRGF_1("/mrgf_1_res.png"),
		MRGF_2("/mrgf_2_res.png"),
		MRGF_3("/mrgf_3_res.png"),
		MRGF_4("/mrgf_4_res.png"),
		MRGF_5("/mrgf_5_res.png"),
		MRGF_6("/mrgf_6_res.png"),
		MRGF_7("/mrgf_7_res.png"),
		MRGF_8("/mrgf_8_res.png");
		
		private final BufferedImage image;
		
		TuileType(final String path) {
			image = GameResources.getImage(path);
		}
		
		public BufferedImage getImage() {
			return image;
		}
	}
	
}
