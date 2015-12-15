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

        public void LoadData()
        {

        }

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
        select new XElement("ChessPiece", new XAttribute("posX", ChessPiece.posX), new XAttribute("posY", ChessPiece.posY), new XAttribute("color", ChessPiece.Color)

        )));
            xmlDoc.Save(@".\chessdata\chessdata.xml");
        }

        public Player LoadPlayerBlack()
        {
            Player pleyer = new HumanPlayer("white");

            return pleyer;
        }
    }
}
