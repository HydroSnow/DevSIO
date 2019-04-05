package dev.hydrosnow.devsio.maismorry;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;

public class GameTuile extends JPanel implements MouseListener {
	private final static BufferedImage imageUnknown = GameResources.getImage("/mystery.png");
	private final static BufferedImage imageVictory = GameResources.getImage("/gagnere.png");
	
	private final Type type;
	private State state = State.IDLE;
	
	public GameTuile(final Type type) {
		this.type = type;
		addMouseListener(this);
	}
	
	public Type getType() {
		return type;
	}
	
	public State getState() {
		return state;
	}
	
	public void setState(final State state) {
		this.state = state;
		repaint();
	}
	
	@Override
	protected void paintComponent(final Graphics g) {
		super.paintComponent(g);
		if (state == State.IDLE) {
			g.drawImage(imageUnknown, 0, 0, this);
		} else if (state == State.SELECTED) {
			g.drawImage(type.getImage(), 0, 0, this);
		} else if (state == State.FINISHED) {
			g.drawImage(imageVictory, 0, 0, this);
		}
	}
	
	@Override
	public void mouseClicked(final MouseEvent e) { }
	
	@Override
	public void mousePressed(final MouseEvent e) {
		GameLogic.click(this);
	}
	
	@Override
	public void mouseReleased(final MouseEvent e) { }
	
	@Override
	public void mouseEntered(final MouseEvent e) { }
	
	@Override
	public void mouseExited(final MouseEvent e) { }
	
	public enum State {
		IDLE,
		SELECTED,
		DISABLED,
		FINISHED
	}
	
	public enum Type {
		MRGF_1("/mrgf_1_res.png"),
		MRGF_2("/mrgf_2_res.png"),
		MRGF_3("/mrgf_3_res.png"),
		MRGF_4("/mrgf_4_res.png"),
		MRGF_5("/mrgf_5_res.png"),
		MRGF_6("/mrgf_6_res.png"),
		MRGF_7("/mrgf_7_res.png"),
		MRGF_8("/mrgf_8_res.png");
		
		private final BufferedImage image;
		
		Type(final String path) {
			image = GameResources.getImage(path);
		}
		
		BufferedImage getImage() {
			return image;
		}
	}
	
}
