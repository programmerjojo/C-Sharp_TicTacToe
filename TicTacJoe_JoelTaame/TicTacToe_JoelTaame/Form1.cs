using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_JoelTaame
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        //GLOBAL VARIABLES
        bool[] blnClicked = { false, false, false, false, false, false, false, false, false };

        bool blnPlayerTurn;
        int difficultyLevel;

        int[] intPlayerMoves = { -100, -100, -100, -100, -100 };
        int[] intCompMoves = { -100, -100, -100, -100, -100 };

        bool whoGoesFirst;  //true means player goes first, false means comp goes first

        int counter = -1;
        int compCounter = -1;
        //--------------------------------------------------------------------------------------------------------------------------------------------


        //PRIMARY METHODS
        public void enableAllBtns()
        {
            if (btn1.Enabled == false)
            {
                btn1.Enabled = true;
            }
            if (btn2.Enabled == false)
            {
                btn2.Enabled = true;
            }
            if (btn3.Enabled == false)
            {
                btn3.Enabled = true;
            }
            if (btn4.Enabled == false)
            {
                btn4.Enabled = true;
            }
            if (btn5.Enabled == false)
            {
                btn5.Enabled = true;
            }
            if (btn6.Enabled == false)
            {
                btn6.Enabled = true;
            }
            if (btn7.Enabled == false)
            {
                btn7.Enabled = true;
            }
            if (btn8.Enabled == false)
            {
                btn8.Enabled = true;
            }
            if (btn9.Enabled == false)
            {
                btn9.Enabled = true;
            }
        }
        private void disableAndClearAllBtns()
        {
            if (btn1.Enabled == true)
            {
                btn1.Enabled = false;
            }
            if (btn2.Enabled == true)
            {
                btn2.Enabled = false;
            }
            if (btn3.Enabled == true)
            {
                btn3.Enabled = false;
            }
            if (btn4.Enabled == true)
            {
                btn4.Enabled = false;
            }
            if (btn5.Enabled == true)
            {
                btn5.Enabled = false;
            }
            if (btn6.Enabled == true)
            {
                btn6.Enabled = false;
            }
            if (btn7.Enabled == true)
            {
                btn7.Enabled = false;
            }
            if (btn8.Enabled == true)
            {
                btn8.Enabled = false;
            }
            if (btn9.Enabled == true)
            {
                btn9.Enabled = false;
            }

            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

        }

        private void resetBlnClicked()
        {
            for (int i = 0; i < blnClicked.Length; i++)
            {
                blnClicked[i] = false;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------






        //CHECK WINNER
        public void winnerCheckPlayer()
        {
            bool blnResult;
            int score = 0;

            int A = intPlayerMoves[0];

            int B = intPlayerMoves[1];

            int C = intPlayerMoves[2];

            int D = intPlayerMoves[3];

            int E = intPlayerMoves[4];

            if (A + B + C == 15)
            {
                blnResult = true;
            }
            else if (A + B + D == 15)
            {
                blnResult = true;
            }
            else if (A + B + E == 15)
            {
                blnResult = true;
            }
            else if (A + C + D == 15)
            {
                blnResult = true;
            }
            else if (A + C + E == 15)
            {
                blnResult = true;
            }
            else if (A + D + E == 15)
            {
                blnResult = true;
            }
            else if (B + C + D == 15)
            {
                blnResult = true;
            }
            else if (B + C + E == 15)
            {
                blnResult = true;
            }
            else if (B + D + E == 15)
            {
                blnResult = true;
            }
            else if (C + D + E == 15)
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }


            if (blnResult)
            {
                score = Int32.Parse(txtBoxPlayerScore.Text);
                score++;
                txtBoxPlayerScore.Text = score.ToString();

                //basically same code as reset method however it doesn't reset the score back to 0
                disableAndClearAllBtns();

                for (int i = 0; i < intPlayerMoves.Length; i++)
                {
                    intPlayerMoves[i] = -100;
                }
                for (int i = 0; i < intCompMoves.Length; i++)
                {
                    intCompMoves[i] = -100;
                }

                counter = -1;
                compCounter = -1;
            }
            else if (blnClicked[0] == true && blnClicked[1] == true && blnClicked[2] == true && blnClicked[3] == true && blnClicked[4] == true && blnClicked[5] == true && blnClicked[6] == true && blnClicked[7] == true && blnClicked[8] == true) //draw
            {
                MessageBox.Show("There was a draw! How you gonna get a draw mane thats foul...");

                for (int i = 0; i < intPlayerMoves.Length; i++)
                {
                    intPlayerMoves[i] = -100;
                }

                disableAndClearAllBtns();
                enableAllBtns();

                counter = -1;
                compCounter = -1;
            }


            if (btn1.Text == "" && btn2.Text == "" && btn3.Text == "" && btn4.Text == "" && btn5.Text == "" && btn6.Text == "" && btn7.Text == "" && btn8.Text == "" && btn9.Text == "" && whoGoesFirst == false)
            {
                if (rdBtnPlayer.Enabled == true)
                {
                    rdBtnPlayer.Enabled = false;
                }
                if (rdBtnComp.Enabled == true)
                {
                    rdBtnComp.Enabled = false;
                }

                if (rdBtnEasy.Enabled == true)
                {
                    rdBtnEasy.Enabled = false;
                }
                if (rdBtnMed.Enabled == true)
                {
                    rdBtnMed.Enabled = false;
                }
                if (rdBtnHard.Enabled == true)
                {
                    rdBtnHard.Enabled = false;
                }

                enableAllBtns();
                resetBlnClicked();
                blnPlayerTurn = false;

                if (difficultyLevel == 1)
                {
                    compCounter++;
                    compMoveEasy();
                }
                else if (difficultyLevel == 2)
                {
                    compCounter++;
                    compMoveMedium();
                }
                else if (difficultyLevel == 3)
                {
                    compCounter++;
                    compMoveHard();
                }
            }
            else if (btn1.Text == "" && btn2.Text == "" && btn3.Text == "" && btn4.Text == "" && btn5.Text == "" && btn6.Text == "" && btn7.Text == "" && btn8.Text == "" && btn9.Text == "" && whoGoesFirst == true)
            {
                if (rdBtnPlayer.Enabled == true)
                {
                    rdBtnPlayer.Enabled = false;
                }
                if (rdBtnComp.Enabled == true)
                {
                    rdBtnComp.Enabled = false;
                }

                if (rdBtnEasy.Enabled == true)
                {
                    rdBtnEasy.Enabled = false;
                }
                if (rdBtnMed.Enabled == true)
                {
                    rdBtnMed.Enabled = false;
                }
                if (rdBtnHard.Enabled == true)
                {
                    rdBtnHard.Enabled = false;
                }

                enableAllBtns();
                resetBlnClicked();
                blnPlayerTurn = true;
            }
            else
            {
                if (difficultyLevel == 1)
                {
                    compCounter++;
                    compMoveEasy();
                }
                else if (difficultyLevel == 2)
                {
                    compCounter++;
                    compMoveMedium();
                }
                else if (difficultyLevel == 3)
                {
                    compCounter++;
                    compMoveHard();
                }
            }
        }
        public void winnerCheckComputer()
        {
            bool blnResult;
            int score = 0;

            int A = intCompMoves[0];

            int B = intCompMoves[1];

            int C = intCompMoves[2];

            int D = intCompMoves[3];

            int E = intCompMoves[4];

            if (A + B + C == 15)
            {
                blnResult = true;
            }
            else if (A + B + D == 15)
            {
                blnResult = true;
            }
            else if (A + B + E == 15)
            {
                blnResult = true;
            }
            else if (A + C + D == 15)
            {
                blnResult = true;
            }
            else if (A + C + E == 15)
            {
                blnResult = true;
            }
            else if (A + D + E == 15)
            {
                blnResult = true;
            }
            else if (B + C + D == 15)
            {
                blnResult = true;
            }
            else if (B + C + E == 15)
            {
                blnResult = true;
            }
            else if (B + D + E == 15)
            {
                blnResult = true;
            }
            else if (C + D + E == 15)
            {
                blnResult = true;
            }
            else
            {
                blnResult = false;
            }


            if (blnResult)
            {
                score = Int32.Parse(txtBoxCompScore.Text);
                score++;
                txtBoxCompScore.Text = score.ToString();

                //basically same code as reset method however it doesn't reset the score back to 0
                disableAndClearAllBtns();

                for (int i = 0; i < intPlayerMoves.Length; i++)
                {
                    intPlayerMoves[i] = -100;
                }
                for (int i = 0; i < intCompMoves.Length; i++)
                {
                    intCompMoves[i] = -100;
                }

                counter = -1;
                compCounter = -1;
            }
            else if (blnClicked[0] == true && blnClicked[1] == true && blnClicked[2] == true && blnClicked[3] == true && blnClicked[4] == true && blnClicked[5] == true && blnClicked[6] == true && blnClicked[7] == true && blnClicked[8] == true)
            {
                MessageBox.Show("There was a draw! How you gonna get a draw mane thats foul...");

                for (int i = 0; i < intCompMoves.Length; i++)
                {
                    intCompMoves[i] = -100;
                }

                disableAndClearAllBtns();
                enableAllBtns();

                counter = -1;
                compCounter = -1;
            }

            if (btn1.Text == "" && btn2.Text == "" && btn3.Text == "" && btn4.Text == "" && btn5.Text == "" && btn6.Text == "" && btn7.Text == "" && btn8.Text == "" && btn9.Text == "" && whoGoesFirst == false)
            {
                if (rdBtnPlayer.Enabled == true)
                {
                    rdBtnPlayer.Enabled = false;
                }
                if (rdBtnComp.Enabled == true)
                {
                    rdBtnComp.Enabled = false;
                }

                if (rdBtnEasy.Enabled == true)
                {
                    rdBtnEasy.Enabled = false;
                }
                if (rdBtnMed.Enabled == true)
                {
                    rdBtnMed.Enabled = false;
                }
                if (rdBtnHard.Enabled == true)
                {
                    rdBtnHard.Enabled = false;
                }

                enableAllBtns();
                resetBlnClicked();
                blnPlayerTurn = false;

                if (difficultyLevel == 1)
                {
                    compCounter++;
                    compMoveEasy();
                }
                else if (difficultyLevel == 2)
                {
                    compCounter++;
                    compMoveMedium();
                }
                else if (difficultyLevel == 3)
                {
                    compCounter++;
                    compMoveHard();
                }
            }
            else if (btn1.Text == "" && btn2.Text == "" && btn3.Text == "" && btn4.Text == "" && btn5.Text == "" && btn6.Text == "" && btn7.Text == "" && btn8.Text == "" && btn9.Text == "" && whoGoesFirst == true)
            {
                if (rdBtnPlayer.Enabled == true)
                {
                    rdBtnPlayer.Enabled = false;
                }
                if (rdBtnComp.Enabled == true)
                {
                    rdBtnComp.Enabled = false;
                }

                if (rdBtnEasy.Enabled == true)
                {
                    rdBtnEasy.Enabled = false;
                }
                if (rdBtnMed.Enabled == true)
                {
                    rdBtnMed.Enabled = false;
                }
                if (rdBtnHard.Enabled == true)
                {
                    rdBtnHard.Enabled = false;
                }

                enableAllBtns();
                resetBlnClicked();
                blnPlayerTurn = true;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------


        //EXIT AND RESET
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxPlayerScore.Text = "0";
            txtBoxCompScore.Text = "0";

            resetBlnClicked();

            for (int i = 0; i < intPlayerMoves.Length; i++)
            {
                intPlayerMoves[i] = -100;
            }
            for (int i = 0; i < intCompMoves.Length; i++)
            {
                intCompMoves[i] = -100;
            }

            counter = -1;
            compCounter = -1;

            rdBtnEasy.Checked = false;
            rdBtnMed.Checked = false;
            rdBtnHard.Checked = false;

            rdBtnPlayer.Checked = false;
            rdBtnComp.Checked = false;

            if (rdBtnEasy.Enabled == false)
            {
                rdBtnEasy.Enabled = true;
            }
            if (rdBtnMed.Enabled == false)
            {
                rdBtnMed.Enabled = true;
            }
            if (rdBtnHard.Enabled == false)
            {
                rdBtnHard.Enabled = true;
            }

            if (rdBtnPlayer.Enabled == true)
            {
                rdBtnPlayer.Enabled = false;
            }
            if (rdBtnComp.Enabled == true)
            {
                rdBtnComp.Enabled = false;
            }

            disableAndClearAllBtns();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------






        //DIFFICULTY LEVEL
        private void rdBtnEasy_CheckedChanged(object sender, EventArgs e)
        {
            difficultyLevel = 1;

            if (rdBtnMed.Enabled == true)
            {
                rdBtnMed.Enabled = false;   //turn off medium level checkbox
            }
            if (rdBtnHard.Enabled == true)
            {
                rdBtnHard.Enabled = false;  //turn off hard level checkbox
            }

            if (rdBtnPlayer.Enabled == false)   //turns on checkboxes for next section
            {
                rdBtnPlayer.Enabled = true;
            }
            if (rdBtnComp.Enabled == false)
            {
                rdBtnComp.Enabled = true;
            }
        }
        private void rdBtnMed_CheckedChanged(object sender, EventArgs e)
        {
            difficultyLevel = 2;

            if (rdBtnEasy.Enabled == true)
            {
                rdBtnEasy.Enabled = false;  //turn off easy level checkboxes
            }
            if (rdBtnHard.Enabled == true)
            {
                rdBtnHard.Enabled = false;  //turn off hard level checkboxes
            }

            if (rdBtnPlayer.Enabled == false)   //turns on checkboxes for next section
            {
                rdBtnPlayer.Enabled = true;
            }
            if (rdBtnComp.Enabled == false)
            {
                rdBtnComp.Enabled = true;
            }
        }
        private void rdBtnHard_CheckedChanged(object sender, EventArgs e)
        {
            difficultyLevel = 3;

            if (rdBtnMed.Enabled == true)
            {
                rdBtnEasy.Enabled = false;  //turns off easy level checkbox
            }
            if (rdBtnMed.Enabled == true)
            {
                rdBtnMed.Enabled = false;  //turn off medium level checkbox
            }

            if (rdBtnPlayer.Enabled == false)   //turns on checkboxes for next section
            {
                rdBtnPlayer.Enabled = true;
            }
            if (rdBtnComp.Enabled == false)
            {
                rdBtnComp.Enabled = true;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------


        //WHO GOES FIRST
        private void rdBtnPlayer_CheckedChanged(object sender, EventArgs e)
        {
            whoGoesFirst = true;
            blnPlayerTurn = true;
            if (rdBtnComp.Enabled == true)
            {
                rdBtnComp.Enabled = false;
            }

            enableAllBtns();
        }
        private void rdBtnComp_CheckedChanged(object sender, EventArgs e)
        {
            whoGoesFirst = false;
            blnPlayerTurn = false;
            if (rdBtnComp.Enabled == true)
            {
                rdBtnComp.Enabled = false;
            }

            enableAllBtns();

            if (difficultyLevel == 1)
            {
                compCounter++;
                compMoveEasy();
            }
            else if (difficultyLevel == 2)
            {
                compCounter++;
                compMoveMedium();
            }
            else if (difficultyLevel == 3)
            {
                compCounter++;
                compMoveHard();
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------






        // BUTTONS CLICKED 
        public void btn1_Click(object sender, EventArgs e)
        {
            if (blnClicked[0] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 2;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn1.Text = "X";   //displays picture

                    blnClicked[0] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }
        public void btn2_Click(object sender, EventArgs e)
        {
            if (blnClicked[1] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 9;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn2.Text = "X";   //displays value of turned button

                    blnClicked[1] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }
        public void btn3_Click(object sender, EventArgs e)
        {
            if (blnClicked[2] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 4;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn3.Text = "X";   //displays value of turned button

                    blnClicked[2] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }

        public void btn4_Click(object sender, EventArgs e)
        {
            if (blnClicked[3] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 7;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn4.Text = "X";   //displays value of turned button

                    blnClicked[3] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }
        public void btn5_Click(object sender, EventArgs e)
        {
            if (blnClicked[4] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn
                    int intBtnVal = 5;

                    this.btn5.Text = "X";   //displays value of turned button
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    blnPlayerTurn = false;
                    blnClicked[4] = true;   //making sure nothing happens when button is clicked again

                    winnerCheckPlayer();
                }
            }
        }
        public void btn6_Click(object sender, EventArgs e)
        {
            if (blnClicked[5] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 3;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn6.Text = "X";   //displays value of turned button

                    blnClicked[5] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }

        public void btn7_Click(object sender, EventArgs e)
        {
            if (blnClicked[6] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 6;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn7.Text = "X";   //displays value of turned button

                    blnClicked[6] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }
        public void btn8_Click(object sender, EventArgs e)
        {
            if (blnClicked[7] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn

                    int intBtnVal = 1;
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    this.btn8.Text = "X";   //displays value of turned button

                    blnClicked[7] = true;   //making sure nothing happens when button is clicked again
                    blnPlayerTurn = false;

                    winnerCheckPlayer();
                }
            }
        }
        public void btn9_Click(object sender, EventArgs e)
        {
            if (blnClicked[8] == false)
            {
                if (blnPlayerTurn == true)
                {
                    counter++;          //adds 1 to counter, player # turn
                    int intBtnVal = 8;

                    this.btn9.Text = "X";   //displays value of turned button
                    intPlayerMoves[counter] = intBtnVal;    //inputs value that will be used to check for winner

                    blnPlayerTurn = false;
                    blnClicked[8] = true;   //making sure nothing happens when button is clicked again

                    winnerCheckPlayer();
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------


        //COMPUTER MOVES
        public void compMoveEasy()      //selects random buttons
        {
            Random rndNum = new Random();

            while (true)
            {
                int randomBtn = rndNum.Next(1, 10);
                if (blnClicked[randomBtn - 1] == false)
                {
                    if (blnPlayerTurn == false)
                    {
                        if (randomBtn == 1)
                        {
                            int intBtnValComp = Int32.Parse(btn1.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn1.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[0] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 2)
                        {
                            int intBtnValComp = Int32.Parse(btn2.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn2.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[1] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 3)
                        {
                            int intBtnValComp = Int32.Parse(btn3.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn3.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[2] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 4)
                        {
                            int intBtnValComp = Int32.Parse(btn4.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn4.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[3] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 5)
                        {
                            int intBtnValComp = Int32.Parse(btn5.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn5.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[4] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 6)
                        {
                            int intBtnValComp = Int32.Parse(btn6.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn6.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[5] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 7)
                        {
                            int intBtnValComp = Int32.Parse(btn7.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn7.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[6] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 8)
                        {
                            int intBtnValComp = Int32.Parse(btn8.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn8.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[7] = true;

                            winnerCheckComputer();
                            break;
                        }
                        else if (randomBtn == 9)
                        {
                            int intBtnValComp = Int32.Parse(btn9.Tag.ToString());
                            intCompMoves[compCounter] = intBtnValComp;

                            this.btn9.Text = "O";

                            blnPlayerTurn = true;
                            blnClicked[8] = true;

                            winnerCheckComputer();
                            break;
                        }
                    }
                }
            }
        }
        public void compMoveMedium()    //selects middle and corner buttons
        {
            if (blnPlayerTurn == false)
            {
                if (blnClicked[4] == false)     //if 5/middle is available           
                {
                    int intBtnValComp = Int32.Parse(btn5.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn5.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[4] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[4] == true && blnClicked[0] == false || blnClicked[4] == true && blnClicked[2] == false || blnClicked[4] == true && blnClicked[6] == false || blnClicked[4] == true && blnClicked[8] == false)
                {
                    while (true)
                    {
                        Random rndNum = new Random();
                        int rndCorner = rndNum.Next(1, 5);    //randomly selects one of the corners

                        if (rndCorner == 1)
                        {
                            if (blnClicked[0] == false)     //if 1/topleftcorner is available           
                            {
                                int intBtnValComp = Int32.Parse(btn1.Tag.ToString());
                                intCompMoves[compCounter] = intBtnValComp;

                                this.btn1.Text = "O";

                                blnPlayerTurn = true;
                                blnClicked[0] = true;

                                winnerCheckComputer();
                                break;
                            }
                        }
                        else if (rndCorner == 2)
                        {
                            if (blnClicked[2] == false)     //if 3/toprightcorner is available           
                            {
                                int intBtnValComp = Int32.Parse(btn3.Tag.ToString());
                                intCompMoves[compCounter] = intBtnValComp;

                                this.btn3.Text = "O";

                                blnPlayerTurn = true;
                                blnClicked[2] = true;

                                winnerCheckComputer();
                                break;
                            }
                        }
                        else if (rndCorner == 3)
                        {
                            if (blnClicked[6] == false)     //if 7/bottomleftcorner is available           
                            {
                                int intBtnValComp = Int32.Parse(btn7.Tag.ToString());
                                intCompMoves[compCounter] = intBtnValComp;

                                this.btn7.Text = "O";

                                blnPlayerTurn = true;
                                blnClicked[6] = true;

                                winnerCheckComputer();
                                break;
                            }
                        }
                        else if (rndCorner == 4)
                        {
                            if (blnClicked[8] == false)     //if 9/toprightcorner is available           
                            {
                                int intBtnValComp = Int32.Parse(btn9.Tag.ToString());
                                intCompMoves[compCounter] = intBtnValComp;

                                this.btn9.Text = "O";

                                blnPlayerTurn = true;
                                blnClicked[8] = true;

                                winnerCheckComputer();
                                break;
                            }
                        }
                    }
                }
                else    //in case all middle and corners are taken it'll just do a random button
                {
                    compMoveEasy();
                }
            }
        }
        public void compMoveHard()      //selects middle and corner buttons but also blocks winner moves
        {
            if (blnPlayerTurn == false)
            {
                //attacking mode
                //first row
                if (blnClicked[0] == false && btn2.Text == "O" && btn3.Text == "O" || blnClicked[0] == false && btn5.Text == "O" && btn9.Text == "O" || blnClicked[0] == false && btn4.Text == "O" && btn7.Text == "O")           //select btn 1 IF (btn 2 and 3 are Sasuke OR btn 5 and 9 are Sasuke OR btn 4 and 7 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn1.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn1.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[0] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[1] == false && btn1.Text == "O" && btn3.Text == "O" || blnClicked[1] == false && btn5.Text == "O" && btn8.Text == "O")      //select btn 2 IF (btn 1 and 3 are Sasuke OR btn 5 and 8 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn2.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn2.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[1] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[2] == false && btn1.Text == "O" && btn2.Text == "O" || blnClicked[2] == false && btn5.Text == "O" && btn7.Text == "O" || blnClicked[2] == false && btn6.Text == "O" && btn9.Text == "O")      //select btn 3 IF (btn 1 and 2 are Sasuke OR btn 5 and 7 are Sasuke OR btn 6 and 9 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn3.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn3.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[2] = true;

                    winnerCheckComputer();
                }
                //second row
                else if (blnClicked[3] == false && btn1.Text == "O" && btn7.Text == "O" || blnClicked[3] == false && btn5.Text == "O" && btn6.Text == "O")      //select btn 4 IF (btn 1 and 7 are Sasuke OR btn 5 and 6 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn4.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn4.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[3] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[4] == false && btn1.Text == "O" && btn9.Text == "O" || blnClicked[4] == false && btn3.Text == "O" && btn7.Text == "O" || blnClicked[4] == false && btn2.Text == "O" && btn8.Text == "O" || blnClicked[4] == false && btn4.Text == "O" && btn6.Text == "O")      //select btn 5 IF (btn 1 and 9 are Sasuke OR btn 3 and 7 are Sasuke OR btn 2 and 8 are Sasuke OR btn 4 and 6 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn5.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn5.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[4] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[5] == false && btn3.Text == "O" && btn9.Text == "O" || blnClicked[5] == false && btn4.Text == "O" && btn5.Text == "O")      //select btn 6 IF (btn 3 and 9 are Sasuke OR btn 4 and 5 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn6.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn6.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[5] = true;

                    winnerCheckComputer();
                }
                //third row
                else if (blnClicked[6] == false && btn1.Text == "O" && btn4.Text == "O" || blnClicked[6] == false && btn5.Text == "O" && btn3.Text == "O" || blnClicked[6] == false && btn8.Text == "O" && btn9.Text == "O")      //select btn 7 IF (btn 1 and 4 are Sasuke OR btn 5 and 3 are Sasuke OR btn 8 and 9 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn7.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn7.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[6] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[7] == false && btn7.Text == "O" && btn9.Text == "O" || blnClicked[7] == false && btn2.Text == "O" && btn5.Text == "O")      //select btn 8 IF (btn 7 and 9 are Sasuke OR btn 2 and 5 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn8.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn8.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[7] = true;

                    winnerCheckComputer();
                }
                else if (blnClicked[8] == false && btn7.Text == "O" && btn8.Text == "O" || blnClicked[8] == false && btn5.Text == "O" && btn1.Text == "O" || blnClicked[8] == false && btn3.Text == "O" && btn6.Text == "O")      //select btn 9 IF (btn 7 and 8 are Sasuke OR btn 5 and 1 are Sasuke OR btn 3 and 6 are Sasuke)
                {
                    int intBtnValComp = Int32.Parse(btn9.Tag.ToString());
                    intCompMoves[compCounter] = intBtnValComp;

                    this.btn9.Text = "O";

                    blnPlayerTurn = true;
                    blnClicked[8] = true;

                    winnerCheckComputer();
                }
                else    // blocking mode
                {
                    //first row
                    if (blnClicked[0] == false && btn2.Text == "X" && btn3.Text == "X" || blnClicked[0] == false && btn5.Text == "X" && btn9.Text == "X" || blnClicked[0] == false && btn4.Text == "X" && btn7.Text == "X")           //select btn 1 IF (btn 2 and 3 are Sasuke OR btn 5 and 9 are Sasuke OR btn 4 and 7 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn1.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn1.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[0] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[1] == false && btn1.Text == "X" && btn3.Text == "X" || blnClicked[1] == false && btn5.Text == "X" && btn8.Text == "X")      //select btn 2 IF (btn 1 and 3 are Sasuke OR btn 5 and 8 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn2.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn2.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[1] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[2] == false && btn1.Text == "X" && btn2.Text == "X" || blnClicked[2] == false && btn5.Text == "X" && btn7.Text == "X" || blnClicked[2] == false && btn6.Text == "X" && btn9.Text == "X")      //select btn 3 IF (btn 1 and 2 are Sasuke OR btn 5 and 7 are Sasuke OR btn 6 and 9 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn3.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn3.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[2] = true;

                        winnerCheckComputer();
                    }
                    //second row
                    else if (blnClicked[3] == false && btn1.Text == "X" && btn7.Text == "X" || blnClicked[3] == false && btn5.Text == "X" && btn6.Text == "X")      //select btn 4 IF (btn 1 and 7 are Sasuke OR btn 5 and 6 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn4.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn4.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[3] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[4] == false && btn1.Text == "X" && btn9.Text == "X" || blnClicked[4] == false && btn3.Text == "X" && btn7.Text == "X" || blnClicked[4] == false && btn2.Text == "X" && btn8.Text == "X" || blnClicked[4] == false && btn4.Text == "X" && btn6.Text == "X")      //select btn 5 IF (btn 1 and 9 are Sasuke OR btn 3 and 7 are Sasuke OR btn 2 and 8 are Sasuke OR btn 4 and 6 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn5.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn5.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[4] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[5] == false && btn3.Text == "X" && btn9.Text == "X" || blnClicked[5] == false && btn4.Text == "X" && btn5.Text == "X")      //select btn 6 IF (btn 3 and 9 are Sasuke OR btn 4 and 5 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn6.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn6.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[5] = true;

                        winnerCheckComputer();
                    }
                    //third row
                    else if (blnClicked[6] == false && btn1.Text == "X" && btn4.Text == "X" || blnClicked[6] == false && btn5.Text == "X" && btn3.Text == "X" || blnClicked[6] == false && btn8.Text == "X" && btn9.Text == "X")      //select btn 7 IF (btn 1 and 4 are Sasuke OR btn 5 and 3 are Sasuke OR btn 8 and 9 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn7.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn7.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[6] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[7] == false && btn7.Text == "X" && btn9.Text == "X" || blnClicked[7] == false && btn2.Text == "X" && btn5.Text == "X")      //select btn 8 IF (btn 7 and 9 are Sasuke OR btn 2 and 5 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn8.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn8.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[7] = true;

                        winnerCheckComputer();
                    }
                    else if (blnClicked[8] == false && btn7.Text == "X" && btn8.Text == "X" || blnClicked[8] == false && btn5.Text == "X" && btn1.Text == "X" || blnClicked[8] == false && btn3.Text == "X" && btn6.Text == "X")      //select btn 9 IF (btn 7 and 8 are Sasuke OR btn 5 and 1 are Sasuke OR btn 3 and 6 are Sasuke)
                    {
                        int intBtnValComp = Int32.Parse(btn9.Tag.ToString());
                        intCompMoves[compCounter] = intBtnValComp;

                        this.btn9.Text = "O";

                        blnPlayerTurn = true;
                        blnClicked[8] = true;

                        winnerCheckComputer();
                    }
                    else
                    {
                        compMoveMedium();
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
    }
}