package dev.hydrosnow.memorygame;

import javax.swing.*;
import java.util.Collections;
import java.util.ArrayList;
import java.util.List;
import java.awt.*;

public class GameWindow extends JFrame {
	private final static Color backgroundColor = new Color(52, 52, 52);
	private final static Color panelBackgroundColor = new Color(62, 62, 62);
	private final static Color foregroundColor = new Color(210, 210, 210);
	private final static Dimension textSize = new Dimension(500, 30);
	private final static Font textFont = new Font(Font.SANS_SERIF, Font.BOLD, 20);
	private final static Cursor tuileCursor = Cursor.getPredefinedCursor(Cursor.HAND_CURSOR);
	private final static Dimension tuileSize = new Dimension(100, 100);
	
	private final List<Tuile> tuiles;
	private JTextArea text;
	
	public GameWindow() {
		tuiles = new ArrayList<>();
	}
	
	public List<Tuile> getTuiles() {
		return tuiles;
	}
	
	public void build() {
		setTitle("MrGF's Battlegrounds");
		setSize(600, 600);
		setLocationRelativeTo(null);
		setResizable(false);
		
		getContentPane().setBackground(backgroundColor);
		setContainerLayout(getContentPane(), BoxLayout.Y_AXIS);
		
		final JPanel textPanel = new JPanel();
		textPanel.setBackground(backgroundColor);
		setContainerLayout(textPanel, BoxLayout.X_AXIS);
		
		text = new JTextArea();
		text.setBackground(backgroundColor);
		text.setForeground(foregroundColor);
		text.setPreferredSize(textSize);
		text.setMaximumSize(textSize);
		text.setFont(textFont);
		text.setEditable(false);
		text.setText("Bienvenue au jeu le plus cool !");
		
		textPanel.add(Box.createHorizontalGlue());
		textPanel.add(text);
		textPanel.add(Box.createHorizontalGlue());
		
		final List<Tuile.Type> typeList = new ArrayList<>();
		for (final Tuile.Type t : Tuile.Type.values()) {
			typeList.add(t);
			typeList.add(t);
		}
		Collections.shuffle(typeList);
		
		getContentPane().add(Box.createVerticalGlue());
		getContentPane().add(textPanel);
		getContentPane().add(Box.createVerticalGlue());
		getContentPane().add(createPanel(typeList));
		getContentPane().add(Box.createVerticalGlue());
		getContentPane().add(createPanel(typeList));
		getContentPane().add(Box.createVerticalGlue());
		getContentPane().add(createPanel(typeList));
		getContentPane().add(Box.createVerticalGlue());
		getContentPane().add(createPanel(typeList));
		getContentPane().add(Box.createVerticalGlue());
		
		setVisible(true);
	}
	
	private JPanel createPanel(final List<Tuile.Type> typeList) {
		final JPanel panel = new JPanel();
		panel.setBackground(backgroundColor);
		setContainerLayout(panel, BoxLayout.X_AXIS);
		
		panel.add(Box.createHorizontalGlue());
		panel.add(createTuile(typeList));
		panel.add(Box.createHorizontalGlue());
		panel.add(createTuile(typeList));
		panel.add(Box.createHorizontalGlue());
		panel.add(createTuile(typeList));
		panel.add(Box.createHorizontalGlue());
		panel.add(createTuile(typeList));
		panel.add(Box.createHorizontalGlue());
		
		return panel;
	}
	
	private void setContainerLayout(final Container cont, final int axis) {
		cont.setLayout(new BoxLayout(cont, axis));
	}
	
	private Tuile createTuile(final List<Tuile.Type> typeList) {
		final Tuile.Type type = typeList.get(0);
		typeList.remove(0);
		
		final Tuile tuile = new Tuile(type);
		tuiles.add(tuile);
		tuile.setBackground(panelBackgroundColor);
		tuile.setCursor(tuileCursor);
		tuile.setPreferredSize(tuileSize);
		tuile.setMaximumSize(tuileSize);
		
		return tuile;
	}
	
	public void setText(final String str) {
		text.setText(str);
	}
	
}
