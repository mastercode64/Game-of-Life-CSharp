using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridTest
{


    class Cell
    {
        /*
        Regras do Jogo da vida - Conway
        Qualquer celula viva com MENOS QUE DOIS vizinhos vivos morrem
        Qualquer celula viva com DOIS OU TRES vizinhos vivos vivem na proxima geração
        Qualquer celula viva com MAIS QUE TRES vizinhos vivos morrem
        Qualquer celula morta com TRES vizinhos vivos se tornam vivos na proxima geração
        */
        public Cell(int x, int y, bool alive)
        {
            this.x = x;
            this.y = y;
            this.alive = alive;
        }
        public int x { get; set; }
        public int y { get; set; }
        public bool alive { get; set; }


        public void ChangeCellValue()
        {
            //Alterna o estado da celula de vivo para morto e vice versa
            if (this.alive == true)
                this.alive = false;
            else
                this.alive = true;
        }

        public void ChangeCellValue(bool cellState)
        {
            //Insere o estado da celula desejado 
            this.alive = cellState;
        }
    }
}
