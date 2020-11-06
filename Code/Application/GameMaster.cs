//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GameMaster : MonoBehaviour
//{
//    public IPlayer playerWhite;
//    public IPlayer playerBlack;
//    public Game gameO;
//    public BoardUpdate boardUpdateO;
//    public BoardSquareProperties boardSquarePropertiesO;
//    bool escPressed = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        playerBlack = createPlayer(PlayerEnum.black, GameProperties.playerBlackIsHuman);
//        playerWhite = createPlayer(PlayerEnum.white, GameProperties.playerWhiteIsHuman);
//        gameO = new Game(playerBlack, playerWhite);
//        boardUpdateO = GameObject.FindObjectOfType<BoardUpdate>();
//        boardUpdateO.setBoard(gameO.gameBoard);
//        boardUpdateO.game = this.gameO;
//        boardSquarePropertiesO = GameObject.FindObjectOfType<BoardSquareProperties>();
//        gameO.InitGame();
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown("escape"))
//        {
//           if(escPressed)
//           {
//                SceneManager.LoadScene("MainMenu");
//           } else
//            {
//                escPressed = true;
//            }
//        }
//    }

//    private void OnEnable()
//    {
//        Game.gameEnded += gameEndHandler;
//    }

//    private void OnDisable()
//    {
//        Game.gameEnded -= gameEndHandler;
//    }

//    IPlayer createPlayer(PlayerEnum color, bool isHuman)
//    {
//        if(isHuman)
//            return new HumanPlayer(color);
//        else return new CPUPlayer(color);
//    }

//    public void gameEndHandler()
//    {
//        GameProperties.blackScore = playerBlack.score;
//        GameProperties.whiteScore = playerWhite.score;
//        SceneManager.LoadScene("MainMenu");
//    }

//}


using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

class GameMaster
{
    static Game game;
    //public IPlayer playerWhite;
    static public void Main(string[] args)
    {
        int[] blackHoleCoords = GetBlackHoleCoords();
        PlayerEnum testerColour = GetTesterColour();
        IPlayer tester = new HumanPlayer(testerColour);
        IPlayer bot = new CPUPlayer(GetOpponentColour(testerColour));
        //Game game;
        if (testerColour == PlayerEnum.black)
        {
            game = new Game(tester, bot);
        } else
        {
            game = new Game(bot, tester);
        }
        Game.gameEnded += gameEndHandler;
        Game.nextMove += nextMoveHandler;
        game.InitGame();
        //Can reference game from here
        game.SetBlackHole(blackHoleCoords);
        //Ask player to select next move
        //
        //make game calculate it
        if(testerColour == PlayerEnum.black)
        {
            //Console.WriteLine("Hole: [{0}]", string.Join(", ", game.validMovesAndDirsForThisTurn));
            tester.UpdateMoves(game.validMovesAndDirsForThisTurn);
        } else if (testerColour == PlayerEnum.white)
        {
            bot.UpdateMoves(game.validMovesAndDirsForThisTurn);
        }
        game.PlayRound();
    }

    public static void gameEndHandler()
    {
        //WHAT TO DO
        Environment.Exit(1);
    }

    static int[] GetBlackHoleCoords()
    {
        //Console.WriteLine("Please input black hole position: ");
        string holePos = Console.ReadLine();

        return getCoordsFromString(holePos);
    }

    static int[] getCoordsFromString(string position)
    {
        int yPos = (int)Char.GetNumericValue(position, 1) - 1;
        int xPos = (int)position[0] - 65;
        //Console.WriteLine("Hole: [{0}]", string.Join(", ", new int[] { xPos, yPos }));
        return new int[] { xPos, yPos };
    }

    static PlayerEnum GetTesterColour()
    {
        string notTesterColour = Console.ReadLine();
        if (notTesterColour == "white")
        {
            //Console.WriteLine("I am white");
            return PlayerEnum.black;
        } else if (notTesterColour == "black")
        {
            //Console.WriteLine("I am black");
            return PlayerEnum.white;
        } else
        {
            //Console.WriteLine(notTesterColour);
            return PlayerEnum.none;//SHOULD NEVER HAPPEN
        }

    }
    static PlayerEnum GetOpponentColour(PlayerEnum colour)
    {
        if (colour == PlayerEnum.white) return PlayerEnum.black;
        else if (colour == PlayerEnum.black) return PlayerEnum.white;
        else return PlayerEnum.none;
    }

    static public void nextMoveHandler()
    {
        game.currentPlayer.UpdateMoves(game.validMovesAndDirsForThisTurn);
        game.PlayRound();
    }

    //    public void boardSquareClickHandler(int xPos, int yPos)
    //    {
    //        //SEND TO MODEL
    //        //gameMaster.gameO.currentPlayer.currentTurnCoords = new int[] { xPos, yPos };

    //        int[][] a = { new int[] { xPos, yPos } };
    //        gameMaster.gameO.currentPlayer.UpdateMoves(a);
    //        gameMaster.gameO.PlayRound();
    //    }
}