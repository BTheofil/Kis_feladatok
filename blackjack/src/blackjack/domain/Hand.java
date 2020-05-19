package blackjack.domain;

import java.util.ArrayList;
import java.util.List;

public class Hand {
	
	private List<Card> cards = new ArrayList<>();
	
	public void take(Card card) {
		cards.add(card);
	}
	
	public int getScore() {
		int sum = 0;
		for (Card card : cards) {
			sum += card.getValue();
		}
		
		if (sum <= 11) {
			for (Card card : cards) {
				if(card.getShape() == CardShapes.ACE) {
					sum += 10;
					break;
				}
			}
		}
		
		return sum;
	}

	@Override
	public String toString() {
		return cards.toString() + " " + getScore();
	}
	
	
}
