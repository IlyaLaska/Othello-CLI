//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class BoardUpdate : MonoBehaviour
//{
//    public GameObject boardO;
//    public BoardSquareProperties boardOProps;
//    public GameObject[,] squares;
//    public GameObject[,] pieces;
//    public GameObject[,] highlights;
//    public Board board;
//    public Game game;
//    public GameObject whiteScoreO;
//    public GameObject blackScoreO;
//    public GameObject whiteTurnSignO;
//    public GameObject blackTurnSignO;

//    void Start()
//    {
//    }
//    private void Awake()
//    {
//        squares = new GameObject[8, 8];
//        pieces = new GameObject[8, 8];
//        highlights = new GameObject[8, 8];
//        boardOProps = boardO.GetComponent<BoardSquareProperties>();
//        instantiateBoard();
//    }
//    // Update is called once per frame
//    void Update()
//    {

//    }
//    private void OnEnable()
//    {
//        Board.boardUpdateEvent += boardUpdateHandler;
//        Game.scoreUpdatedEvent += scoreUpdatedHandler;
//        Game.getValidMovesListEvent += getValidMovesListHandler;

//    }
//    private void OnDisable()
//    {
//        Board.boardUpdateEvent -= boardUpdateHandler;
//        Game.scoreUpdatedEvent -= scoreUpdatedHandler;
//        Game.getValidMovesListEvent -= getValidMovesListHandler;
//    }

//    public void scoreUpdatedHandler()
//    {
//        whiteScoreO.GetComponent<TextMeshProUGUI>().text = game.white.score.ToString();
//        blackScoreO.GetComponent<TextMeshProUGUI>().text = game.black.score.ToString();
//        if(game.currentPlayer.color == PlayerEnum.white)
//        {
//            whiteTurnSignO.GetComponent<TextMeshProUGUI>().text = "";
//            blackTurnSignO.GetComponent<TextMeshProUGUI>().text = "▲";
//        } else
//        {
//            whiteTurnSignO.GetComponent<TextMeshProUGUI>().text = "▲";
//            blackTurnSignO.GetComponent<TextMeshProUGUI>().text = "";
//        }
//    }

//    public void getValidMovesListHandler()
//    {
//        foreach (var XYDirection in game.validMovesAndDirsForThisTurn)
//        {
            
//            boardOProps = squares[XYDirection[1], XYDirection[0]].GetComponent<BoardSquareProperties>();
//            if(!highlights[XYDirection[1], XYDirection[0]])
//            {
//                //Debug.Log("VALID MOVE X and Y: " + XYDirection[0] + " , " + XYDirection[1]);
//                highlights[XYDirection[1], XYDirection[0]] = (GameObject)Instantiate(boardOProps.Highlight, boardOProps.transform.position, boardOProps.PieceOWhite.transform.rotation);
//            }              
//        }
//    }


//    public void boardUpdateHandler()
//    {
//        for (int y = 0; y < 8; y++)
//        {
//            for (int x = 0; x < 8; x++)
//            {
//                boardOProps = squares[y, x].GetComponent<BoardSquareProperties>();


//                // clear highlights
//                if (highlights[y, x])
//                {
//                    //Debug.Log("----------------------------------REMOVE highlight at X and Y: " + x + ", " + y);
//                    DestroyImmediate(highlights[y, x], true);
//                }


//                if (board.board[y, x].belongsToPlayer != boardOProps.pieceColor)
//                {

//                    //Update Piece - Destroy old
//                    if (boardOProps.pieceColor == PlayerEnum.white && pieces[y, x])
//                    {
//                        //Debug.Log("------------------DELETE Black");
//                        Destroy(pieces[y, x]);
//                    }
//                    else if (boardOProps.pieceColor == PlayerEnum.black && pieces[y, x])
//                    {
//                        //Debug.Log("------------------DELETE Black");
//                        Destroy(pieces[y, x]);
//                    }

//                    //Update Piece - Create New
//                    if (board.board[y, x].belongsToPlayer == PlayerEnum.white)
//                    {
//                        pieces[y, x] = (GameObject)Instantiate(boardOProps.PieceOWhite, boardOProps.transform.position, boardOProps.PieceOWhite.transform.rotation);
//                        //Debug.Log("------------------Create New WHITE \n" + pieces[y, x]);
//                    }
//                    else if (board.board[y, x].belongsToPlayer == PlayerEnum.black)
//                    {
//                        pieces[y, x] = (GameObject)Instantiate(boardOProps.PieceOBlack, boardOProps.transform.position, boardOProps.PieceOBlack.transform.rotation);
//                        //Debug.Log(" ------------------Create New BLACK \n" + pieces[y, x]);
//                    }

//                    //change to correct value
//                    boardOProps.pieceColor = board.board[y, x].belongsToPlayer;
//                }
//            }
//        }
//    }

//    public void instantiateBoard()
//    {
//        int xPosition = 0, yPosition = 0;
//        //Instantiate(boardO, new Vector2(-3.5f, 3.5f), boardO.rotation);
//        for (float y = 3.5f; y >= -3.5f; y--)
//        {
//            for (float x = -3.5f; x <= 3.5f; x++)
//            {
//                boardOProps.xPos = xPosition;
//                boardOProps.yPos = yPosition;
//                squares[yPosition, xPosition] = (GameObject)Instantiate(boardO, new Vector2(x, y), Quaternion.identity);
//                xPosition++;
//            }
//            yPosition++;
//            xPosition = 0;
//        }
//    }

//    public void setBoard(Board board)
//    {
//        this.board = board;
//    }
//}