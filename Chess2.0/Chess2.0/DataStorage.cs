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
            //Läser data
            IEnumerable<string> posx = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPiece")
                                    select chesspiece.Element("posX").Value;
            IEnumerable<string> posy = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPiece")
                                       select chesspiece.Element("posY").Value;
            IEnumerable<string> color = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPiece")
                                       select chesspiece.Element("color").Value;

            IEnumerable<string> type = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPiece")
                                       select chesspiece.Element("type").Value;


            //Skapar tvådimensionell array av inläst data
            ChessPiece[,] board = new ChessPiece[8,8];
            for (int i = 0; i < posx.Count(); i++)
            {
                switch (type.ElementAt(i))
                {
                    case "Chess2._0.King":
                        ChessPiece king = new King(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = king;
                        break;
                    case "Chess2._0.Queen":
                        ChessPiece queen = new Queen(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = queen;
                        break;
                    case "Chess2._0.Runner":
                        ChessPiece runner = new Runner(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = runner;
                        break;
                    case "Chess2._0.Horse":
                        ChessPiece horse = new Horse(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = horse;
                        break;
                    case "Chess2._0.Tower":
                        ChessPiece tower = new Tower(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = tower;
                        break;
                    case "Chess2._0.Farmer":
                        ChessPiece farmer = new Farmer(color.ElementAt(i), int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i)));
                            board[int.Parse(posx.ElementAt(i)), int.Parse(posy.ElementAt(i))] = farmer;
                        break;
                }
            }

            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                { 
                    if(board[x, y] != null)
                    {
                        ChessPiece temp = board[x, y];
                    }
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
