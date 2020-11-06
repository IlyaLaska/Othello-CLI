using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class Game
{
    public Board gameBoard;
    public IPlayer black;
    public IPlayer white;
    public int[][] validMovesAndDirsForThisTurn;
    public int moveCounter = 0;
    public bool gameIsOver = false;
    public IPlayer currentPlayer;
    bool playerSkippedMove = false;

    public delegate void GetValidMovesListEvent();
    public static event GetValidMovesListEvent getValidMovesListEvent;
    public delegate void GameEndEvent();
    public static event GameEndEvent gameEnded;
    public delegate void NextMoveEvent();
    public static event NextMoveEvent nextMove;
    public delegate void ScoreUpdatedEvent();
    public static event ScoreUpdatedEvent scoreUpdatedEvent;

    public Game(IPlayer first, IPlayer second)
    {
        black = first;
        white = second;
        gameBoard = new Board();
        currentPlayer = black;
    }

    public void InitGame()
    {
        gameBoard.InitBoard();
        UpdateValidMovesList();
    }

    public void PlayRound()
    {
        //get coordinates of next move
        List<int[]> takenCoordsAndDirections = GetMoveFromPlayer();
        if (takenCoordsAndDirections == null) return;
        int beatPiecesCount = gameBoard.UpdateBeatPieces(takenCoordsAndDirections, currentPlayer);
        UpdateScore(beatPiecesCount);

        ChangePlayer();
        UpdateValidMovesList();

        nextMove?.Invoke();
    }

    public void UpdateValidMovesList()//uncomment
    {
        //get valid moves list
        this.validMovesAndDirsForThisTurn = gameBoard.GetValidMovesList(currentPlayer);
        if (getValidMovesListEvent != null)
        {
            getValidMovesListEvent();
        }

        if (this.validMovesAndDirsForThisTurn.Length < 1)
        {
            if (IsMaxScore())
            {
                gameEnded();
                return;
            }
            // game might be over, no available turns
            if(!playerSkippedMove)//first time a player skips
            {
                playerSkippedMove = true;
                ChangePlayer();
                UpdateValidMovesList();
            } else
            {
                gameEnded();
                return;
            }
        }
        playerSkippedMove = false;
    }

    private bool IsMaxScore()
    {
        return black.score + white.score == 64;
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

    private List<int[]> GetMoveFromPlayer()
    {
        int[] selectedSquare = currentPlayer.currentTurnCoords;
        List<int[]> takenCoordsAndDirections = new List<int[]>();

        //list of taken moves (coordinates same, direction different)
        for (int i = 0; i < validMovesAndDirsForThisTurn.Length; i++)
        {
            if (validMovesAndDirsForThisTurn[i][0] == selectedSquare[0] && validMovesAndDirsForThisTurn[i][1] == selectedSquare[1])//one of valids
            {
                takenCoordsAndDirections.Add(validMovesAndDirsForThisTurn[i]);
            }
        }
        if (takenCoordsAndDirections.Count == 0)//no allowed moves
        {
            return null;
        }
        return takenCoordsAndDirections;
    }

    public void SetBlackHole(int[] blackHoleCoords)
    {
        this.gameBoard.board[blackHoleCoords[1], blackHoleCoords[0]].belongsToPlayer = PlayerEnum.blackHole;
    }
}
