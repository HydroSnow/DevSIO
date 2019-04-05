package dev.hydrosnow.devsio.maismorry;

import java.util.Collections;
import java.util.List;
import java.util.ArrayList;
import javax.swing.*;
import java.awt.*;

public class GameWindow extends JFrame {
	private final JPanel[][] panels;
	
	public GameWindow() {
		setTitle("MaisMorry (MrGF edition)");
		setSize(600, 600);
		setLocationRelativeTo(null);
		setResizable(false);
		
		final Color backgroundColor = new Color(52, 52, 52);
		final Color panelBackgroundColor = new Color(62, 62, 62);
		
		getContentPane().setBackground(backgroundColor);
		getContentPane().setLayout(new BoxLayout(getContentPane(), BoxLayout.Y_AXIS));
		
		panels = new Tuile[4][4];
		
		final List<TuileType> typeList = new ArrayList<>();
		for (final TuileType t : TuileType.values()) {
			typeList.add(t);
			typeList.add(t);
		}
		Collections.shuffle(typeList);
		
		getContentPane().add(Box.createVerticalGlue());
		for (int a = 0; a < panels.length; a++) {
			final JPanel panel = new JPanel();
			panel.setBackground(backgroundColor);
			panel.setLayout(new BoxLayout(panel, BoxLayout.X_AXIS));
			panel.setBorder(null);
			getContentPane().add(panel);
			getContentPane().add(Box.createVerticalGlue());
			
			panel.add(Box.createHorizontalGlue());
			for (int b = 0; b < panels[a].length; b++) {
				final TuileType type = typeList.get(0);
				typeList.remove(0);
				
				final Tuile image = new Tuile(type);
				image.setBackground(panelBackgroundColor);
				image.setCursor(Cursor.getPredefinedCursor(Cursor.HAND_CURSOR));
				final Dimension size = new Dimension(100, 100);
				image.setPreferredSize(size);
				image.setMaximumSize(size);
				image.setBorder(null);
				panel.add(image);
				panel.add(Box.createHorizontalGlue());
				panels[a][b] = image;
			}
			
		}
		
		setVisible(true);
	}
	
}
