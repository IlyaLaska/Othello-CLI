﻿using System;

namespace Reversi
{
    class GameMaster
    {
        static Game game;

        static public void Main(string[] args)
        {
            int[] blackHoleCoords = GetBlackHoleCoords();
            PieceEnum testerColour = GetTesterColour();
            IPlayer tester = new HumanPlayer(testerColour);
            IPlayer bot = new AIPlayer(GetOpponentColour(testerColour));
            
            if (testerColour == PieceEnum.black)
            {
                game = new Game(tester, bot);
            }
            else
            {
                game = new Game(bot, tester);
            }
            Game.gameEndEvent += gameEndHandler;
            Game.nextMoveEvent += nextMoveHandler;
            game.InitGame(blackHoleCoords);
            game.PlayRound();

  
        }

        public static void gameEndHandler()
        {
            int bs=0, ws=0;
            if (game.currentPlayer.color == PieceEnum.black) bs = game.currentPlayer.score;
            else ws = game.currentPlayer.score;
            if (bs != 0) ws = 63 - bs;
            else bs = 63 - ws;
            Console.WriteLine("B: " + bs + " W: " + ws);
            Console.ReadLine();
            Environment.Exit(1);
        }

        static int[] GetBlackHoleCoords()
        {
            //Console.WriteLine("Please input black hole position: ");
            string holePos = Console.ReadLine();

            return ConvertMoveToArray(holePos);
        }

        public static int[] ConvertMoveToArray(string position)
        {
            int yPos = (int)Char.GetNumericValue(position, 1) - 1;
            int xPos = (int)position[0] - 65;
            return new int[] { xPos, yPos };
        }

        static PieceEnum GetTesterColour()
        {
            //Console.WriteLine("Please input your opponent's colour: ");
            string notTesterColour = Console.ReadLine();
            if (notTesterColour == "white")
            {
                return PieceEnum.black;
            }
            else if (notTesterColour == "black")
            {
                return PieceEnum.white;
            }
            else
            {
                return PieceEnum.none;//SHOULD NEVER HAPPEN
            }

        }
        static PieceEnum GetOpponentColour(PieceEnum colour)
        {
            if (colour == PieceEnum.white) return PieceEnum.black;
            else if (colour == PieceEnum.black) return PieceEnum.white;
            else return PieceEnum.none;
        }

        static public void nextMoveHandler()
        {
            game.currentPlayer.UpdateMoves(game.validMovesAndDirsForThisTurn, game.gameBoard);
            game.PlayRound();
        }
    }
}