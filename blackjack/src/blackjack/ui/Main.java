package blackjack.ui;

import java.util.Scanner;

import blackjack.business.BlackJackGame;
import blackjack.business.GameStatus;

public class Main {

	public static void main(String[] args) {
		
		BlackJackGame game = new BlackJackGame();
		displayDealerHand(game);
		displayPlayerHand(game);
		
		Scanner scanner = new Scanner(System.in);
		while(game.getStatus() == GameStatus.ONGOING) {
			System.out.println("Hit or stand?");
			String cmd = scanner.nextLine();
			switch(cmd) {
				case "hit":
					game.hit();
					displayPlayerHand(game);
					break;
				case "stand":
					game.stand();
			} 
		}
		
		System.out.println("Dealer's turn...");
		displayDealerHand(game);
		displayPlayerHand(game);
		System.out.println(game.getStatus() == GameStatus.PLAYER_WON ? "You won!" : "You lost!");

	}
	
	private static void displayDealerHand(BlackJackGame game) {
		System.out.println("Dealer's hand: " + game.getDealer());
	}
		

	private static void displayPlayerHand(BlackJackGame game) {
		System.out.println("Your hand: " + game.getPlayer());
	}

}
