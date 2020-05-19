package blackjack.domain;

public enum CardSuits {

	CLUB("♣"), DIAMOND("♦"), HEART("♥"), SPADE("♠");
	
	private String symbol;

	private CardSuits(String symbol) {
		this.symbol = symbol;
	}
	
	public String toString() {
		return symbol;
	}
	
}
