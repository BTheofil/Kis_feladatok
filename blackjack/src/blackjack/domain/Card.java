package blackjack.domain;

public class Card {
	
	private CardSuits suit;
	private CardShapes shape;
	
	public Card(CardSuits suit, CardShapes shape) {
		super();
		this.suit = suit;
		this.shape = shape;
	}

	public CardSuits getSuit() {
		return suit;
	}

	public void setSuit(CardSuits suit) {
		this.suit = suit;
	}

	public CardShapes getShape() {
		return shape;
	}

	public void setShapes(CardShapes shapes) {
		this.shape = shapes;
	}

	@Override
	public String toString() {
		return suit.toString() + shape.toString();
	}
	
	public int getValue() {
		return shape.getValue();
	}
	
	
}
