//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{
//    public GameMaster gameMaster;
//    //public Game game;

//    // Start is called before the first frame update
//    void Start()
//    {
//        gameMaster = GameObject.FindObjectOfType<GameMaster>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnEnable()
//    {
//        BoardSquareProperties.BoardSquareClicked += boardSquareClickHandler;
//        Game.nextMove += nextMoveHandler;
//    }

//    private void OnDisable()
//    {
//        BoardSquareProperties.BoardSquareClicked -= boardSquareClickHandler;
//        Game.nextMove -= nextMoveHandler;
//    }

//    public void nextMoveHandler()
//    {
//        gameMaster.gameO.currentPlayer.UpdateMoves(gameMaster.gameO.validMovesAndDirsForThisTurn);
//        gameMaster.gameO.PlayRound();
//    }

//    public void boardSquareClickHandler(int xPos, int yPos)
//    {
//        //SEND TO MODEL
//        //gameMaster.gameO.currentPlayer.currentTurnCoords = new int[] { xPos, yPos };
 
//        int[][] a = { new int[] { xPos, yPos } };
//        gameMaster.gameO.currentPlayer.UpdateMoves(a);
//        gameMaster.gameO.PlayRound();
//    }
//}
