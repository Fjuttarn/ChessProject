using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Chess2._0
{
    class DataStorage
    {
        public DataStorage(){}

        //reads data from xmlfile, creates a chessboard and returns it.
        public ChessPiece[,] LoadData()
        {
            IEnumerable<string> posx = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                                .Descendants("ChessPieces")
                                    select chesspiece.Element("posX").Value;
            IEnumerable<string> posy = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPieces")
                                       select chesspiece.Element("posY").Value;
            IEnumerable<string> color = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPieces")
                                       select chesspiece.Element("color").Value;

            IEnumerable<string> type = from chesspiece in XDocument.Load(@".\chessdata\chessdata.xml")
                                                               .Descendants("ChessPieces")
                                       select chesspiece.Element("type").Value;

            string[] posxlist = posx.ToArray() as string[];
            string[] posylist = posy.ToArray() as string[];
            string[] colorlist = color.ToArray() as string[];
            string[] typelist = type.ToArray() as string[];

            ChessPiece[,] board = new ChessPiece[8,8];
            for (int i = 0; i < posxlist.Length; i++)
            {
                switch (typelist[i])
                {
                    case "King":
                        ChessPiece king = new King(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = king;
                        break;
                    case "Queen":
                        ChessPiece queen = new Queen(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = queen;
                        break;
                    case "Runner":
                        ChessPiece runner = new Runner(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = runner;
                        break;
                    case "Horse":
                        ChessPiece horse = new Horse(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = horse;
                        break;
                    case "Tower":
                        ChessPiece tower = new Tower(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = tower;
                        break;
                    case "Farmer":
                        ChessPiece farmer = new Farmer(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i]] = farmer;
                        break;
                }
            }
            return board;
        }

        //writes the current gamefield to a xmlfile
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
            ChessPiece[] listan = list.ToArray(typeof(ChessPiece)) as ChessPiece[]; //gör om arraylist till array

            XDocument xmlDoc = new XDocument(
        new XDeclaration("1.0", "UTF-8", "yes"),

        new XComment("Nils och Fridens coola xml doc!"),

        new XElement("ChessPieces",
        from ChessPiece in listan
        select new XElement("ChessPiece", new XAttribute("posX", ChessPiece.posX),
                                          new XAttribute("posY", ChessPiece.posY), 
                                          new XAttribute("color", ChessPiece.getPlayer.getColour), 
                                          new XAttribute("type", ChessPiece.GetType())

        )));
            xmlDoc.Save(@".\chessdata\chessdata.xml");
        }
    }
}
