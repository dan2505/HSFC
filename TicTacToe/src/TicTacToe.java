import java.util.Random;
import java.util.Scanner;

public class TicTacToe {
    private static String[] gameBoard = new String[10];
    private static int moves;

    public static void main(String[] args) {
        printGameBoard();

        while (true) {
            System.out.println("Where would you like to go? (1-9");
            Scanner scanner = new Scanner(System.in);
            int playerPosition = scanner.nextInt();
            while (checkPlacement(playerPosition)) {
                System.out.println("Position taken! Please choose another!");
                playerPosition = scanner.nextInt();
            }
            placePiece(playerPosition, "player");
            if (checkForWinners()) {
                printGameBoard();
                if (moves >= 9) {
                    System.out.println("It's a draw! Well done!");
                    break;
                }
                System.out.println("You win! Well done!");
                break;
            }

            Random random = new Random();
            int computerPosition = random.nextInt(9) + 1;
            while (checkPlacement(computerPosition)) {
                computerPosition = random.nextInt(9) + 1;
            }
            placePiece(computerPosition, "computer");
            printGameBoard();

            if (checkForWinners()) {
                if (moves >= 9) {
                    System.out.println("It's a draw! Well done!");
                    break;
                }
                System.out.println("The computer wins! Unlucky!");
                break;
            }
        }
    }

    private static void printGameBoard() {
        System.out.println("       |       |       ");
        System.out.println("   " + getPieceFromPosition(1) + "   |   " + getPieceFromPosition(2) + "   |   " + getPieceFromPosition(3) + "   ");
        System.out.println("       |       |       ");

        System.out.println("-----------------------");

        System.out.println("       |       |       ");
        System.out.println("   " + getPieceFromPosition(4) + "   |   " + getPieceFromPosition(5) + "   |   " + getPieceFromPosition(6) + "   ");
        System.out.println("       |       |       ");

        System.out.println("-----------------------");

        System.out.println("       |       |       ");
        System.out.println("   " + getPieceFromPosition(7) + "   |   " + getPieceFromPosition(8) + "   |   " + getPieceFromPosition(9) + "   ");
        System.out.println("       |       |       ");
    }

    private static String getPieceFromPosition(int position) {
        if (gameBoard[position] == null) {
            return " ";
        }
        return gameBoard[position];
    }

    private static void placePiece(int position, String user) {
        String symbol = "X";
        if (user.equals("computer")) {
            symbol = "O";
        }
        gameBoard[position] = symbol;
        moves++;
    }

    private static boolean checkPlacement(int position) {
        if ((position > 9 || position < 1)) {
            return true;
        }

        return !getPieceFromPosition(position).equals(" ");
    }

    private static boolean checkForWinners() {
        return
                // Check if the board is full = draw.
                moves >= 9 ||

                        // Check for horizontal lines.
                        checkLineForWinner(1, 1) ||
                        checkLineForWinner(4, 1) ||
                        checkLineForWinner(7, 1) ||

                        // Check for vertical lines.
                        checkLineForWinner(1, 3) ||
                        checkLineForWinner(2, 3) ||
                        checkLineForWinner(3, 3) ||

                        // Check for diagonal lines.
                        checkLineForWinner(1, 4) ||
                        checkLineForWinner(3, 2);
    }

    private static boolean checkLineForWinner(int location, int jump) {
        String piece = getPieceFromPosition(location);
        return (!piece.equals(" ")) && (getPieceFromPosition(location + jump).equals(piece)) && (getPieceFromPosition(location + (jump * 2)).equals(piece));
    }
}