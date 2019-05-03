package fr.hydrosnow.flappybread.utils;

import java.util.ArrayList;
import java.util.Iterator;

import fr.hydrosnow.flappybread.modeling.Model;

public class SafeModelList implements Iterable<Model> {
	private final ArrayList<Model> list;
	private Model[] cache;
	
	public SafeModelList() {
		list = new ArrayList<>();
		cache = new Model[0];
	}
	
	public synchronized void add(final Model t) {
		list.add(t);
	}
	
	public synchronized void remove(final Model t) {
		list.remove(t);
	}
	
	public synchronized void update() {
		cache = new Model[list.size()];
		for (int a = 0; a < list.size(); a++) {
			cache[a] = list.get(a);
		}
	}
	
	@Override
	public Iterator<Model> iterator() {
		return new Iterator<Model>() {
			private final Model[] a = cache;
			private int pos = 0;
			
			public boolean hasNext() {
				return a.length > pos;
			}
			
			public Model next() {
				return a[pos++];
			}
		};
	}
}
