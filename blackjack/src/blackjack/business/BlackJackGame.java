package blackjack.business;

import blackjack.domain.Deck;
import blackjack.domain.Hand;

public class BlackJackGame {

	private Deck deck = new Deck();
	private Hand player = new Hand();
	private Hand dealer = new Hand();
	
	private GameStatus status = GameStatus.ONGOING;
	
	public BlackJackGame() {
		player.take(deck.draw());
		player.take(deck.draw());
		
		dealer.take(deck.draw());
		dealer.take(deck.draw());
	}
	
	
	
	public Hand getPlayer() {
		return player;
	}


	public Hand getDealer() {
		return dealer;
	}
	
	public GameStatus getStatus() {
		return status;
	}


	public void hit() {
		if(status != GameStatus.ONGOING)
			throw new IllegalStateException("Game already finished.");
		
		player.take(deck.draw());
		if(player.getScore() > 21)
			dealerActs();		
	}
	
	public void stand() {
		if(status != GameStatus.ONGOING)
			throw new IllegalStateException("Game already finished.");
		dealerActs();
	}

	private void dealerActs() {
		if(player.getScore() > 21) {
			status = GameStatus.DEALER_WON;
			return;
		}
		
		while(dealer.getScore() < player.getScore() && dealer.getScore() < 21) {
			dealer.take(deck.draw());
			
			if(dealer.getScore() > 21) {
				status = GameStatus.PLAYER_WON;
				return;
			}
		}
		
		status = player.getScore() >= dealer.getScore() ? GameStatus.PLAYER_WON : GameStatus.DEALER_WON;
		
	}
	
	
}
