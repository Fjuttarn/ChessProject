using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Chess2._0
{
    class DataStorage
    {
        public DataStorage(){}

        //Läser data från xml-fil, skapar en representation av schackbräädet och returnerar det.
        public ChessPiece[,] LoadData()
        {
            ChessPiece[,] board = new ChessPiece[8, 8];
            XDocument doc = XDocument.Load(@".\chessdata\chessdata.xml");

            var data = from item in doc.Descendants("ChessPiece")
                       select new
                       {
                           posx = item.Element("posX").Value,
                           posy = item.Element("posY").Value,
                           color = item.Element("color").Value,
                           type = item.Element("type").Value
                       };

            foreach (var c in data)
            {
                switch (c.type)
                {
                    case "Chess2._0.King":
                        ChessPiece king = new King(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = king;
                        break;
                    case "Chess2._0.Queen":
                        ChessPiece queen = new Queen(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = queen;
                        break;
                    case "Chess2._0.Runner":
                        ChessPiece runner = new Runner(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = runner;
                        break;
                    case "Chess2._0.Horse":
                        ChessPiece horse = new Horse(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = horse;
                        break;
                    case "Chess2._0.Tower":
                        ChessPiece tower = new Tower(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = tower;
                        break;
                    case "Chess2._0.Farmer":
                        ChessPiece farmer = new Farmer(c.color, int.Parse(c.posx), int.Parse(c.posy));
                        board[int.Parse(c.posx), int.Parse(c.posy)] = farmer;
                        break;
                }
            }
            return board;
        }

        //Skriver schackbrädet i sitt nuvarande tillstånd till en xml-fil
        public void SaveData(ChessPiece[,] board)
        {
            ArrayList list = new ArrayList();
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if(board[x, y] != null)
                    {
                        list.Add(board[x, y]);
                    }
                }
            }
            
            //gör om arraylist till array
            ChessPiece[] listan = list.ToArray(typeof(ChessPiece)) as ChessPiece[]; 

            XDocument xmlDoc = new XDocument(
            new XDeclaration("1.0", "UTF-8", "yes"),

            new XComment("Nils och Fridens coola xml doc!"),

            new XElement("ChessPieces",
            from ChessPiece in listan
   
            select new XElement("ChessPiece", new XElement("posX", ChessPiece.posX),
                                              new XElement("posY", ChessPiece.posY), 
                                              new XElement("color", ChessPiece.Color), 
                                              new XElement("type", ChessPiece.GetType())

        )));
            xmlDoc.Save(@".\chessdata\chessdata.xml");
        }

        //Ta bort xml-filen
        public void removeFile()
        {
            File.Delete(@".\chessdata\chessdata.xml");
        }
    }
}
