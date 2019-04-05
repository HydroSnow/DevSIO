package dev.hydrosnow.devsio.maismorry;

import javax.swing.*;
import java.awt.*;

public class Window extends JFrame {
	private static final long serialVersionUID = 8134190588761760725L;
	
	public Window() {
		setTitle("Mais, Morry !");
		setSize(350, 170);
		setLocationRelativeTo(null);
		setResizable(false);
		
		final Color backgroundColor = new Color(52, 52, 52);
		
		getContentPane().setBackground(backgroundColor);
		getContentPane().setLayout(new BoxLayout(getContentPane(), BoxLayout.PAGE_AXIS));
		
		final JPanel buttonPanel = new JPanel();
		buttonPanel.setBackground(backgroundColor);
		buttonPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));
		buttonPanel.setLayout(new BoxLayout(buttonPanel, BoxLayout.LINE_AXIS));
		
		getContentPane().add(buttonPanel);
		
		setVisible(true);
	}
}
