using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer timerSimulacao = new Timer();
        int timerInterval = 5;
        bool ExibirGradeComLinhas = true;
        int TamanhoCelula = 10;
        int TamanhoGrade = 700;
        double CelulaPosicaoX = 0;
        double CelulaPosicaoY = 0;

        Graphics g;
        Cell[,] Grade;//grade da geração atual
        Cell[,] GradeNext;//grade da proxima geração

        Rectangle myrectangle;
        Pen mypen = new Pen(Color.White, 1);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush greenBrush = new SolidBrush(Color.Green);

        public void AlternarLinhasGrade()
        {
            if (this.chExibirLinhas.Checked)
                this.ExibirGradeComLinhas = true;
            else
                this.ExibirGradeComLinhas = false;

            EraseGrid();
            CreateVisualGrid();

        }

        public void EraseGrid()
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.Gray);
        }

        public void CreateGrid()
        {
            //Essa função cria o vetor e a parte visual
            CreateArrayGrid(this.TamanhoGrade, this.TamanhoCelula);
            CreateVisualGrid();

        }

        private void CreateVisualGrid()
        {
            //Essa função cria SOMENTE a parte visual da grade
            //A altura e largura da grade devem ser iguais ou seja um quadrado

            if (this.Grade == null)
                return;

            g = pictureBox1.CreateGraphics();

            // var timer = new System.Diagnostics.Stopwatch();
            //timer.Start();

            for (int contadorAltura = 0; contadorAltura < this.TamanhoGrade; contadorAltura += this.TamanhoCelula)
            {
                for (int contadorLargura = 0; contadorLargura < this.TamanhoGrade; contadorLargura += this.TamanhoCelula)
                {
                    myrectangle = new Rectangle(contadorLargura, contadorAltura, this.TamanhoCelula, this.TamanhoCelula);

                    int x = contadorLargura / this.TamanhoCelula;
                    int y = contadorAltura / this.TamanhoCelula;

                    if (this.Grade[x, y].alive)
                    {
                        if (this.ExibirGradeComLinhas)
                            g.FillRectangle(greenBrush, contadorLargura + 1, contadorAltura + 1, this.TamanhoCelula - 1, this.TamanhoCelula - 1);
                        else
                            g.FillRectangle(greenBrush, contadorLargura, contadorAltura, this.TamanhoCelula, this.TamanhoCelula);
                    }

                    else
                    {
                        if (this.ExibirGradeComLinhas)
                            g.FillRectangle(blackBrush, contadorLargura + 1, contadorAltura + 1, this.TamanhoCelula - 1, this.TamanhoCelula - 1);
                        else
                            g.FillRectangle(blackBrush, contadorLargura, contadorAltura, this.TamanhoCelula, this.TamanhoCelula);
                    }


                    //g.DrawRectangle(mypen, myrectangle);

                }
            }
            //timer.Stop();
            //MessageBox.Show(timer.ElapsedMilliseconds.ToString());
        }

        public void CreateArrayGrid(int tamanhoGrade, int tamanhoCelula)
        {
            //Essa função cria a grade em um vetor bidimensional
            //Recebe a quantidade de celulas(X e Y) da grade a ser criada
            var x = tamanhoGrade / tamanhoCelula;

            if (x <= 0)
                throw new Exception("Grade deve ter tamanho maior que 0");

            this.Grade = new Cell[x, x];

            for (int ix = 0; ix < x; ix++)
                for (int iy = 0; iy < x; iy++)
                    this.Grade[ix, iy] = new Cell(ix + 1, iy + 1, false);


        }

        public void CreateRandomArrayGrid(int tamanhoGrade, int tamanhoCelula)
        {
            var x = tamanhoGrade / tamanhoCelula;

            if (x <= 0)
                throw new Exception("Grade deve ter tamanho maior que 0");

            this.Grade = new Cell[x, x];

            for (int ix = 0; ix < x; ix++)
                for (int iy = 0; iy < x; iy++)
                    this.Grade[ix, iy] = new Cell(ix + 1, iy + 1, GetRandomBool());
            CreateVisualGrid();
        }

        public bool GetRandomBool()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            if (rand.Next(1, 3) == 1)
                return true;
            else
                return false;
        }

        public void CreateNextGeneration()
        {
            var x = this.TamanhoGrade / this.TamanhoCelula;

            this.GradeNext = new Cell[x, x];

            for (int iy = 0; iy < x; iy++)
                for (int ix = 0; ix < x; ix++)
                    this.GradeNext[ix, iy] = new Cell(ix + 1, iy + 1, CellNextGenState(ix, iy));
        }

        public void RunSimulationAutomatic(int interval)
        {
            if (timerSimulacao.Enabled)
            {
                timerSimulacao.Stop();
                timerSimulacao.Enabled = false;
                chSimulacaoAuto.Checked = false;
            }

            else
            {
                timerSimulacao.Interval = interval;
                timerSimulacao.Start();
                chSimulacaoAuto.Checked = true;
                timerSimulacao.Tick += new EventHandler(timer_tick);
            }
        }

        private void RunSimulation()
        {
            if (this.Grade == null)
                return;
            CreateNextGeneration();
            Grade = GradeNext;
            CreateVisualGrid();
        }

        private void timer_tick(Object sender, EventArgs e)
        {
            RunSimulation();
        }

        public bool RuleNeighbour(int cellsAlive, bool alive)
        {
            //função decide se a celula da proxima geração sera viva ou morta
            //celula morta com 3 vizinhos NASCEM
            if (alive == false && cellsAlive == 3)
                return true;

            //celula viva com MENOS QUE 2 vizinhos MORREM
            if (alive && cellsAlive < 2)
                return false;

            //celula viva com 2 ou 3 vizinhos VIVEM          
            if (alive && (cellsAlive == 2 || cellsAlive == 3))
                return true;

            //celula viva com MAIS QUE 3 vizinhos MORREM
            //if (alive && cellsAlive > 3)
            if (alive && cellsAlive > 3)
                return false;

            else
                return false;
        }

        public bool CellNextGenState(int x, int y)
        {
            //Ira retornar true(vivo) ou false(morto) para a celula da proxima geração com base na celula da geração atual.

            int aliveNeighbours = 0;
            bool currentCellAlive = this.Grade[x, y].alive;

            #region 4 vertices da grade
            if (x == 0 && y == 0)
            {
                //Celula atual é a primeira na esquerda superior
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            else if (x + 1 == this.Grade.GetLength(0) && y == 0)
            {
                //Celula atual é a primeira na direita superior
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            else if (x == 0 && y + 1 == this.Grade.GetLength(1))
            {
                //Celula atual é a primeira na esquerda inferior
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y - 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            else if (x + 1 == this.Grade.GetLength(0) && y + 1 == this.Grade.GetLength(1))
            {
                //Celula atual é a primeira na direita inferior
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y - 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }
            #endregion
            #region 4 arestas da grade
            else if (x != 0 && x + 1 != this.Grade.GetLength(0) && y == 0)
            {
                //Celula atual é a aresta superior
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            else if (x == 0 && y + 1 != this.Grade.GetLength(1) && y != 0)
            {
                //Celula atual é a aresta esquerda
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            else if (x + 1 == this.Grade.GetLength(0) && y + 1 != this.Grade.GetLength(1) && y != 0)
            {
                //Celula atual é a aresta direita
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }



            else if (x != 0 && x != this.Grade.GetLength(0) && y + 1 == this.Grade.GetLength(1))
            {
                //Celula atual é a aresta inferior
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y - 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }
            #endregion
            #region meio da grade
            else
            {
                //a celula atual não esta nas arestas nen nas vertices, portanto esta no "meio" da grade
                if (this.Grade[x - 1, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y - 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y].alive)
                    aliveNeighbours++;
                if (this.Grade[x - 1, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x, y + 1].alive)
                    aliveNeighbours++;
                if (this.Grade[x + 1, y + 1].alive)
                    aliveNeighbours++;

                if (RuleNeighbour(aliveNeighbours, currentCellAlive))
                    return true;
                else
                    return false;
            }

            #endregion

        }

        public void ShowCellPosition()
        {
            txtQuadradoX.Text = Convert.ToString(this.CelulaPosicaoX);
            txtQuadradoY.Text = Convert.ToString(this.CelulaPosicaoY);
        }

        private string AcessarValorCel(int x, int y, Cell[,] grade)
        {
            try
            {
                if (grade[x - 1, y - 1].alive == true)
                    return "Alive";
                else
                    return "Dead";
            }
            catch (NullReferenceException)
            {
                return "Null";
            }

        }

        private void btnDrawMap_Click(object sender, EventArgs e)
        {
            CreateVisualGrid();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            EraseGrid();
        }

        private void btnGenerateGrid_Click(object sender, EventArgs e)
        {
            CreateArrayGrid(this.TamanhoGrade, this.TamanhoCelula);
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            CreateGrid();
        }

        private void ChangeCellValue()
        {
            var x = Convert.ToInt32(this.CelulaPosicaoX);
            var y = Convert.ToInt32(this.CelulaPosicaoY);

            //Se os estado atual da celula for verdadeiro irá mudar para falso e vice versa
            this.Grade[x - 1, y - 1].ChangeCellValue();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            txtCursorPositionX.Text = e.Location.X.ToString();
            txtCursorPositionY.Text = e.Location.Y.ToString();
        }

        private void GetCellPosition(double restoX, double divisaoX, double restoY, double divisaoY)
        {
            //Calculo da posição X
            if (restoX == 0)
                this.CelulaPosicaoX = divisaoX;
            else if (restoX != 0 && restoX < TamanhoCelula)
                this.CelulaPosicaoX = divisaoX - (restoX / TamanhoCelula) + 1;

            //calculo da posição Y
            if (restoY == 0)
                this.CelulaPosicaoY = divisaoY;
            else if (restoY != 0 && restoY < TamanhoCelula)
                this.CelulaPosicaoY = divisaoY - (restoY / TamanhoCelula) + 1;
        }

        private void ShowCellState()
        {
            int x = Convert.ToInt32(this.CelulaPosicaoX);
            int y = Convert.ToInt32(this.CelulaPosicaoY);
            txtEstadoCel.Text = AcessarValorCel(x, y, this.Grade);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double restoX = Convert.ToDouble(e.Location.X.ToString()) % TamanhoCelula;
            double divisaoX = Convert.ToDouble(e.Location.X.ToString()) / TamanhoCelula;

            double restoY = Convert.ToDouble(e.Location.Y.ToString()) % TamanhoCelula;
            double divisaoY = Convert.ToDouble(e.Location.Y.ToString()) / TamanhoCelula;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                GetCellPosition(restoX, divisaoX, restoY, divisaoY);
                ShowCellPosition();
                ShowCellState();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                GetCellPosition(restoX, divisaoX, restoY, divisaoY);
                ChangeCellValue();
                CreateVisualGrid();
            }
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            RunSimulation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRandomArrayGrid(this.TamanhoGrade, this.TamanhoCelula);
        }

        private void chExibirLinhas_CheckedChanged(object sender, EventArgs e)
        {
            AlternarLinhasGrade();
        }

        private void btnRunStopSimulation_Click(object sender, EventArgs e)
        {
            RunSimulationAutomatic(this.timerInterval);
        }
    }
}
