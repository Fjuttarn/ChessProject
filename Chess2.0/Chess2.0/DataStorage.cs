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

        //reads data from xmlfile, creates a chessboard and returns it.
        public ChessPiece[,] LoadData()
        {
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

            string[] posxlist = posx.ToArray() as string[];
            string[] posylist = posy.ToArray() as string[];
            string[] colorlist = color.ToArray() as string[];
            string[] typelist = type.ToArray() as string[];

            foreach (string str in posx)
            {
                System.Console.WriteLine("hejhej" + str);
            }


            ChessPiece[,] board = new ChessPiece[8,8];
            for (int i = 0; i < posxlist.Length; i++)
            {
                switch (typelist[i])
                {
                    case "Chess2._0.King":
                        ChessPiece king = new King(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = king;
                        break;
                    case "Chess2._0.Queen":
                        ChessPiece queen = new Queen(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = queen;
                        break;
                    case "Chess2._0.Runner":
                        ChessPiece runner = new Runner(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = runner;
                        break;
                    case "Chess2._0.Horse":
                        ChessPiece horse = new Horse(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = horse;
                        break;
                    case "Chess2._0.Tower":
                        ChessPiece tower = new Tower(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = tower;
                        break;
                    case "Chess2._0.Farmer":
                        ChessPiece farmer = new Farmer(colorlist[i], int.Parse(posxlist[i]), int.Parse(posylist[i]));
                            board[int.Parse(posxlist[i]), int.Parse(posylist[i])] = farmer;
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
                        System.Console.WriteLine("inne i posx lista: " + posxlist[0]);
                    }
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

        
        select new XElement("ChessPiece", new XElement("posX", ChessPiece.posX),
                                          new XElement("posY", ChessPiece.posY), 
                                          new XElement("color", ChessPiece.Color), 
                                          new XElement("type", ChessPiece.GetType())

        )));
            xmlDoc.Save(@".\chessdata\chessdata.xml");
        }

        public Player LoadPlayerBlack()
        {
            Player pleyer = new HumanPlayer("white");

            return pleyer;
        }
        public void removeFile()
        {
            File.Delete(@".\chessdata\chessdata.xml");
        }
    }
}
