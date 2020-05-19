package blackjack.domain;

import java.util.List;
import java.util.ArrayList;
import java.util.Collections;

public class Deck {
	
	private List<Card> cards;
	
	
	public Deck() {
		cards = new ArrayList<>();
		for(CardSuits suit : CardSuits.values())
			for(CardShapes shape : CardShapes.values())
				cards.add(new Card(suit, shape));
		
		Collections.shuffle(cards);
	}
	
	public Card draw() {
		if(cards.isEmpty()) 
			return null;
		
		return cards.remove(cards.size()-1);
	}
	
}
