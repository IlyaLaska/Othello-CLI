using System;
using System.Collections.Generic;

public class Game
{
    public Board gameBoard;
    public IPlayer black;
    public IPlayer white;
    public int[][] validMovesAndDirsForThisTurn;
    public int moveCounter = 0;
    public bool gameIsOver = false;
    public IPlayer currentPlayer;
    public bool playerSkippedMove = false;

    public delegate void GetValidMovesListEvent();
    public static event GetValidMovesListEvent getValidMovesListEvent;
    public delegate void GameEndEvent();
    public static event GameEndEvent gameEndEvent;
    public delegate void NextMoveEvent();
    public static event NextMoveEvent nextMoveEvent;
    public delegate void ScoreUpdatedEvent();
    public static event ScoreUpdatedEvent scoreUpdatedEvent;
    //public delegate void SendPassEvent(PieceEnum player);
    //public static event SendPassEvent sendPassEvent;

    public Game(IPlayer first, IPlayer second)
    {
        black = first;
        white = second;
        gameBoard = new Board();
        currentPlayer = black;
    }

    public void InitGame(int[] blackHoleCoords)
    {
        gameBoard.InitBoard();
        SetBlackHole(blackHoleCoords);
        UpdateValidMovesList();
        currentPlayer.UpdateMoves(this.validMovesAndDirsForThisTurn, gameBoard);
    }

    public void PlayRound()
    {
        //get coordinates of next move
        //List<int[]> takenCoordsAndDirections = GetMoveFromPlayer();
        int beatPiecesCount = gameBoard.MakeMoveGetScore(currentPlayer, validMovesAndDirsForThisTurn);
        //gameBoard.PrintBoard();
        //Console.WriteLine("COUNT: " + beatPiecesCount);
        if (beatPiecesCount == 0) //skipped move
        {
            ChangePlayer();
            UpdateValidMovesList();

            nextMoveEvent?.Invoke();
            return;
        }
        //int beatPiecesCount = gameBoard.UpdateBeatPieces(takenCoordsAndDirections, currentPlayer);
        UpdateScore(beatPiecesCount);

        ChangePlayer();
        UpdateValidMovesList();

        nextMoveEvent?.Invoke();
    }

    public void UpdateValidMovesList()//uncomment
    {
        //get valid moves list
        this.validMovesAndDirsForThisTurn = gameBoard.GetValidMovesList(currentPlayer.color);

        getValidMovesListEvent?.Invoke();


        if (this.validMovesAndDirsForThisTurn.Length < 1)
        {
            if (IsMaxScore())
            {
                gameEndEvent?.Invoke();
                return;
            }
            // game might be over, no available turns
            if(!playerSkippedMove)//first time a player skips
            {
                //sendPassEvent?.Invoke(currentPlayer.color);
                playerSkippedMove = true;
                //ChangePlayer();
                //UpdateValidMovesList();
            } else
            {
                gameEndEvent?.Invoke();
                return;
            }
        }
        playerSkippedMove = false;
    }

    private bool IsMaxScore()
    {
        return black.score + white.score == 63;
    }

    private void ChangePlayer()
    {
        currentPlayer = currentPlayer == white ? black : white;
    }

    private void UpdateScore(int beatPiecesCount)
    {
        currentPlayer.score += beatPiecesCount + 1;

        if (currentPlayer == black)
        {
            white.score -= beatPiecesCount;
        }
        else black.score -= beatPiecesCount;

        scoreUpdatedEvent?.Invoke();
    }

    //private List<int[]> GetMoveFromPlayer()
    //{
    //    int[] selectedSquare = currentPlayer.currentTurnCoords;

    //}

    public void SetBlackHole(int[] blackHoleCoords)
    {
        this.gameBoard.board[blackHoleCoords[1], blackHoleCoords[0]] = PieceEnum.blackHole;
        this.gameBoard.blackHoleCoords = new int[] { blackHoleCoords[0], blackHoleCoords[1] };
    }
}
