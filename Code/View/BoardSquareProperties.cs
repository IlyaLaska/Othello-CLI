//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BoardSquareProperties : MonoBehaviour
//{
//    public GameObject PieceOWhite;
//    public GameObject PieceOBlack;
//    public GameObject Highlight;
//    //public Game game;
//    public int xPos = 0;
//    public int yPos = 0;
//    //public bool hasPiece = false;
//    public PlayerEnum pieceColor = PlayerEnum.none;
//    public GameObject pieceO;

//    public delegate void MouseDownEvent(int xPos, int yPos);
//    public static event MouseDownEvent BoardSquareClicked;

//    GameMaster gameMaster;
//    // Start is called before the first frame update
//    void Start()
//    {
//        gameMaster = GameObject.FindObjectOfType<GameMaster>();
//        pieceO = null;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    private void OnMouseDown()
//    {
//        //.xPos
//        Debug.Log("Called MouseDownEvent: X = " + xPos + ", Y = " + yPos);
//        //Debug.Log(game);
//        if (BoardSquareClicked != null)
//            BoardSquareClicked(xPos, yPos);
        
//        //Instantiate(PieceOWhite, transform.position, PieceOWhite.rotation);
//        //if (gameMaster.gameO.currentTurn == PlayerEnum.black)
//        //{
//        //    Instantiate(PieceOBlack, transform.position, PieceOBlack.rotation);
//        //}
//        //else if (gameMaster.gameO.currentTurn == PlayerEnum.white)
//        //{
//        //    Instantiate(PieceOWhite, transform.position, PieceOWhite.rotation);
//        //}
//    }

//    //internal void setGame(Game game)
//    //{
//    //    this.game = game;
//    //}
//}