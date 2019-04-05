package dev.hydrosnow.devsio.maismorry;

import javax.swing.*;
import java.util.Collections;
import java.util.ArrayList;
import java.util.List;
import java.awt.*;

public class GameWindow extends JFrame {
	private final static Color backgroundColor = new Color(52, 52, 52);
	private final static Color panelBackgroundColor = new Color(62, 62, 62);
	private final static Color foregroundColor = new Color(210, 210, 210);
	
	private final JTextArea text;
	
	public GameWindow() {
		setTitle("MaisMorry (MrGF edition)");
		setSize(600, 600);
		setLocationRelativeTo(null);
		setResizable(false);
		
		getContentPane().setBackground(backgroundColor);
		getContentPane().setLayout(new BoxLayout(getContentPane(), BoxLayout.Y_AXIS));
		
		getContentPane().add(Box.createVerticalGlue());
		
		final JPanel textPanel = new JPanel();
		textPanel.setBackground(backgroundColor);
		textPanel.setLayout(new BoxLayout(textPanel, BoxLayout.X_AXIS));
		getContentPane().add(textPanel);
		
		text = new JTextArea();
		text.setBackground(backgroundColor);
		text.setForeground(foregroundColor);
		final Dimension textSize = new Dimension(500, 30);
		text.setPreferredSize(textSize);
		text.setMaximumSize(textSize);
		final Font font = new Font(Font.SANS_SERIF, Font.BOLD, 20);
		text.setFont(font);
		text.setEditable(false);
		text.setText("Bienvenue au jeu le plus cool !");
		textPanel.add(text);
		
		final List<GameTuile.Type> typeList = new ArrayList<>();
		for (final GameTuile.Type t : GameTuile.Type.values()) {
			typeList.add(t);
			typeList.add(t);
		}
		Collections.shuffle(typeList);
		
		getContentPane().add(Box.createVerticalGlue());
		for (int a = 0; a < 4; a++) {
			final JPanel panel = new JPanel();
			panel.setBackground(backgroundColor);
			panel.setLayout(new BoxLayout(panel, BoxLayout.X_AXIS));
			getContentPane().add(panel);
			getContentPane().add(Box.createVerticalGlue());
			
			panel.add(Box.createHorizontalGlue());
			for (int b = 0; b < 4; b++) {
				final GameTuile.Type type = typeList.get(0);
				typeList.remove(0);
				
				final GameTuile tuile = new GameTuile(type);
				tuile.setBackground(panelBackgroundColor);
				tuile.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
				final Dimension size = new Dimension(100, 100);
				tuile.setPreferredSize(size);
				tuile.setMaximumSize(size);
				panel.add(tuile);
				panel.add(Box.createHorizontalGlue());
				GameLogic.add(tuile);
			}
		}
		
		setVisible(true);
	}
	
	public void setText(final String str) {
		text.setText(str);
	}
	
}
