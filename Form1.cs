using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Black_Jack
{
    public partial class BlackJack : Form
    {
        public BlackJack()
        {
            InitializeComponent();
        }

        bool player1Here = false;
        bool player2Here = false;
        bool player3Here = false;
        bool player4Here = false;
        bool player1HasBet = false;
        bool player2HasBet = false;
        bool player3HasBet = false;
        bool player4HasBet = false;
        int Player1Money = 500;
        int Player2Money = 500;
        int Player3Money = 500;
        int Player4Money = 500;
        int Player1BetAmount;
        int Player2BetAmount;
        int Player3BetAmount;
        int Player4BetAmount;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txbPlayer1.Text == "" && txbPlayer2.Text == "" && txbPlayer3.Text == "" && txbPlayer4.Text == "")
            {
                MessageBox.Show("Is no one playing?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Player1Name();
                Player2Name();
                Player3Name();
                Player4Name();
                btnStart.Enabled = false;
                btnStart.Visible = false;

                lblTextMoney1.Visible = true;
                lblTextMoney2.Visible = true;
                lblTextMoney3.Visible = true;
                lblTextMoney4.Visible = true;

                btnRestart.Enabled = true;
                btnRestart.Visible = true;
            }

        }

        private void Player1Name()
        {
            if (txbPlayer1.Text != "")
            {
                gbPlayer1.Text = txbPlayer1.Text;
                txbPlayer1.Text = "";
                lblPlayer1.Text = "Amount:";
                player1Here = true;
                lblPlayer1Money.Text = Convert.ToString(Player1Money);
                btnPlayer1Ready.Visible = true;
                btnPlayer1Ready.Enabled = true;
            }
            else
            {
                gbPlayer1.Visible = false;
                gbPlayer1.Enabled = false;

                player1Here = false;
            }
        }

        private void Player2Name()
        {
            if (txbPlayer2.Text != "")
            {
                gpPlayer2.Text = txbPlayer2.Text;
                txbPlayer2.Text = "";
                lblPlayer2.Text = "Amount:";
                player2Here = true;
                lblPlayer2Money.Text = Convert.ToString(Player2Money);
                btnPlayer2Ready.Visible = true;
                btnPlayer2Ready.Enabled = true;
            }
            else
            {
                gpPlayer2.Visible = false;
                gpPlayer2.Enabled = false;

                player2Here = false;
            }
        }

        private void Player3Name()
        {
            if (txbPlayer3.Text != "")
            {
                gpPlayer3.Text = txbPlayer3.Text;
                txbPlayer3.Text = "";
                lblPlayer3.Text = "Amount:";
                player3Here = true;
                lblPlayer3Money.Text = Convert.ToString(Player3Money);
                btnPlayer3Ready.Visible = true;
                btnPlayer3Ready.Enabled = true;
            }
            else
            {
                gpPlayer3.Visible = false;
                gpPlayer3.Enabled = false;

                player3Here = false;
            }
        }

        private void Player4Name()
        {
            if (txbPlayer4.Text != "")
            {
                gpPlayer4.Text = txbPlayer4.Text;
                txbPlayer4.Text = "";
                lblPlayer4.Text = "Amount:";
                player4Here = true;
                lblPlayer4Money.Text = Convert.ToString(Player4Money);
                btnPlayer4Ready.Visible = true;
                btnPlayer4Ready.Enabled = true;
            }
            else
            {
                gpPlayer4.Visible = false;
                gpPlayer4.Enabled = false;

                player4Here = false;
            }
        }

        private void btnPlayer1Ready_Click(object sender, EventArgs e)
        {
            if(txbPlayer1.Text != "")
            { 
                if(Regex.IsMatch(txbPlayer1.Text, @"^\d+$"))
                {
                    if (Convert.ToInt32(txbPlayer1.Text) > 0 && Convert.ToInt32(txbPlayer1.Text) < Player1Money + 1)
                    {
                        Player1BetAmount = Convert.ToInt32(txbPlayer1.Text);
                        int Player1Bet = Convert.ToInt32(txbPlayer1.Text);
                        txbPlayer1.Enabled = false;
                        Player1Money = Player1Money - Player1Bet;
                        lblPlayer1Money.Text = Convert.ToString(Player1Money);
                        btnPlayer1Ready.Visible = false;
                        btnPlayer1Ready.Enabled = false;
                        player1HasBet = true;
                        EverybodyReady();
                    }
                    else if (Convert.ToInt32(txbPlayer1.Text) <= 0)
                    {
                        MessageBox.Show("You can't bet 0 or > money", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (Convert.ToInt32(txbPlayer1.Text) > Player1Money)
                    {
                        MessageBox.Show("You don't got that much money!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("You have to put in a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPlayer2Ready_Click(object sender, EventArgs e)
        {
            if (txbPlayer2.Text != "")
            {
                if (Regex.IsMatch(txbPlayer2.Text, @"^\d+$"))
                {
                    if (Convert.ToInt32(txbPlayer2.Text) > 0 && Convert.ToInt32(txbPlayer2.Text) < Player2Money + 1)
                    {
                        Player2BetAmount = Convert.ToInt32(txbPlayer2.Text);
                        int Player2Bet = Convert.ToInt32(txbPlayer2.Text);
                        txbPlayer2.Enabled = false;
                        Player2Money = Player2Money - Player2Bet;
                        lblPlayer2Money.Text = Convert.ToString(Player2Money);
                        btnPlayer2Ready.Visible = false;
                        btnPlayer2Ready.Enabled = false;
                        player2HasBet = true;
                        EverybodyReady();
                    }
                    else if (Convert.ToInt32(txbPlayer2.Text) <= 0)
                    {
                        MessageBox.Show("You can't bet 0 or > money", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (Convert.ToInt32(txbPlayer2.Text) > Player2Money)
                    {
                        MessageBox.Show("You don't got that much money!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (txbPlayer2.Text == "")
                    {
                        MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You have to put in a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPlayer3Ready_Click(object sender, EventArgs e)
        {
            if (txbPlayer3.Text != "") 
            {
                if (Regex.IsMatch(txbPlayer3.Text, @"^\d+$"))
                {
                    if (Convert.ToInt32(txbPlayer3.Text) > 0 && Convert.ToInt32(txbPlayer3.Text) < Player3Money + 1)
                    {
                        Player3BetAmount = Convert.ToInt32(txbPlayer3.Text);
                        int Player3Bet = Convert.ToInt32(txbPlayer3.Text);
                        txbPlayer3.Enabled = false;
                        Player3Money = Player3Money - Player3Bet;
                        lblPlayer3Money.Text = Convert.ToString(Player3Money);
                        btnPlayer3Ready.Visible = false;
                        btnPlayer3Ready.Enabled = false;
                        player3HasBet = true;
                        EverybodyReady();
                    }
                    else if (Convert.ToInt32(txbPlayer3.Text) <= 0)
                    {
                        MessageBox.Show("You can't bet 0 or > money", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (Convert.ToInt32(txbPlayer3.Text) > Player3Money)
                    {
                        MessageBox.Show("You don't got that much money!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (txbPlayer3.Text == "")
                    {
                        MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You have to put in a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPlayer4Ready_Click(object sender, EventArgs e)
        {
            if (txbPlayer4.Text != "")
            {
                if (Regex.IsMatch(txbPlayer4.Text, @"^\d+$"))
                {
                    if (Convert.ToInt32(txbPlayer4.Text) > 0 && Convert.ToInt32(txbPlayer4.Text) < Player4Money + 1)
                    {
                        Player4BetAmount = Convert.ToInt32(txbPlayer4.Text);
                        int Player4Bet = Convert.ToInt32(txbPlayer4.Text);
                        txbPlayer4.Enabled = false;
                        Player4Money = Player4Money - Player4Bet;
                        lblPlayer4Money.Text = Convert.ToString(Player4Money);
                        btnPlayer4Ready.Visible = false;
                        btnPlayer4Ready.Enabled = false;
                        player4HasBet = true;

                        EverybodyReady();
                    }
                    else if (Convert.ToInt32(txbPlayer4.Text) <= 0)
                    {
                        MessageBox.Show("You can't bet 0 or > money", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (Convert.ToInt32(txbPlayer4.Text) > Player4Money)
                    {
                        MessageBox.Show("You don't got that much money!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (txbPlayer4.Text == "")
                    {
                        MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You have to put in a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("You have to bet something", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        int playingPlayer;
        int Player1Cards;
        int Player2Cards;
        int Player3Cards;
        int Player4Cards;
        int ComputerCards;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        string ogPcCards;

        private void EverybodyReady()
        {
            if (player1Here == true && player1HasBet == true)
            {
                if (player2Here == true && player2HasBet == true)
                {
                    if (player3Here == true && player3HasBet == true)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Pleyer: 1 2 3 4

                            playingPlayer = 1;

                            Player1Random();
                            Player2Random();
                            Player3Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 2;
                                b = 3;
                                c = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 1 2 3

                            playingPlayer = 1;

                            Player1Random();
                            Player2Random();
                            Player3Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 2;
                                b = 3;
                                c = 5;
                            }
                        }
                    }
                    else if (player3Here == false)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 1 2 4

                            playingPlayer = 1;

                            Player1Random();
                            Player2Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 2;
                                b = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 1 2

                            playingPlayer = 1;

                            Player1Random();
                            Player2Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 2;
                                b = 5;
                            }
                        }
                    }
                }
                else if (player2Here == false)
                {
                    if (player3Here == true && player3HasBet == true)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 1 3 4

                            playingPlayer = 1;

                            Player1Random();
                            Player3Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 3;
                                c = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 1 3

                            playingPlayer = 1;

                            Player1Random();
                            Player3Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 3;
                                c = 5;
                            }
                        }
                    }
                    else if (player3Here == false)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 1 4

                            playingPlayer = 1;

                            Player1Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 1

                            playingPlayer = 1;

                            Player1Random();
                            ComputerRandom();


                            lblValue1.Text = Convert.ToString(Player1Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 1)
                            {
                                btnHit1.Visible = true;
                                btnHit1.Enabled = true;
                                btnPlayer1Stand.Visible = true;
                                btnPlayer1Stand.Enabled = true;
                                a = 5;
                            }
                        }
                    }
                }
            }
            else if (player1Here == false)
            {
                if (player2Here == true && player2HasBet == true)
                {
                    if (player3Here == true && player3HasBet == true)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 2 3 4

                            playingPlayer = 2;

                            Player2Random();
                            Player3Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 2)
                            {
                                btnHit2.Visible = true;
                                btnHit2.Enabled = true;
                                btnPlayer2Stand.Visible = true;
                                btnPlayer2Stand.Enabled = true;
                                b = 3;
                                c = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 2 3

                            playingPlayer = 2;

                            Player2Random();
                            Player3Random();
                            ComputerRandom();


                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 2)
                            {
                                btnHit2.Visible = true;
                                btnHit2.Enabled = true;
                                btnPlayer2Stand.Visible = true;
                                btnPlayer2Stand.Enabled = true;
                                b = 3;
                                c = 5;
                            }
                        }
                    }
                    else if (player3Here == false)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 2 4

                            playingPlayer = 2;

                            Player2Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 2)
                            {
                                btnHit2.Visible = true;
                                btnHit2.Enabled = true;
                                btnPlayer2Stand.Visible = true;
                                btnPlayer2Stand.Enabled = true;
                                b = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 2

                            playingPlayer = 2;

                            Player2Random();
                            ComputerRandom();


                            lblValue2.Text = Convert.ToString(Player2Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 2)
                            {
                                btnHit2.Visible = true;
                                btnHit2.Enabled = true;
                                btnPlayer2Stand.Visible = true;
                                btnPlayer2Stand.Enabled = true;
                                b = 5;
                            }
                        }
                    }
                }
                else if (player2Here == false)
                {
                    if (player3Here == true && player3HasBet == true)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 3 4

                            playingPlayer = 3;

                            Player3Random();
                            Player4Random();
                            ComputerRandom();


                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 3)
                            {
                                btnHit3.Visible = true;
                                btnHit3.Enabled = true;
                                btnPlayer3Stand.Visible = true;
                                btnPlayer3Stand.Enabled = true;
                                c = 4;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //Player: 3

                            playingPlayer = 3;

                            Player3Random();
                            ComputerRandom();


                            lblValue3.Text = Convert.ToString(Player3Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 3)
                            {
                                btnHit3.Visible = true;
                                btnHit3.Enabled = true;
                                btnPlayer3Stand.Visible = true;
                                btnPlayer3Stand.Enabled = true;
                                c = 5;
                            }
                        }
                    }
                    else if (player3Here == false)
                    {
                        if (player4Here == true && player4HasBet == true)
                        {
                            //Player: 4

                            playingPlayer = 4;

                            Player4Random();
                            ComputerRandom();


                            lblValue4.Text = Convert.ToString(Player4Cards);
                            lblValuePC.Text = Convert.ToString(ComputerCards);

                            if (playingPlayer == 4)
                            {
                                btnHit4.Visible = true;
                                btnHit4.Enabled = true;
                                btnPlayer4Stand.Visible = true;
                                btnPlayer4Stand.Enabled = true;
                                d = 5;
                            }
                        }
                        else if (player4Here == false)
                        {
                            //no one here
                            MessageBox.Show("How did this happen then?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        Random random = new Random();
        private void Player1Random()
        {
            int random1 = random.Next(2, 15);
            switch (random1)
            {
                case 2:
                    Player1Cards = 2;
                    lblPleyer1Cards.Text = "Two";
                    break;
                case 3:
                    Player1Cards = 3;
                    lblPleyer1Cards.Text = "Three";
                    break;
                case 4:
                    Player1Cards = 4;
                    lblPleyer1Cards.Text = "Four";
                    break;
                case 5:
                    Player1Cards = 5;
                    lblPleyer1Cards.Text = "Five";
                    break;
                case 6:
                    Player1Cards = 6;
                    lblPleyer1Cards.Text = "Six";
                    break;
                case 7:
                    Player1Cards = 7;
                    lblPleyer1Cards.Text = "Seven";
                    break;
                case 8:
                    Player1Cards = 8;
                    lblPleyer1Cards.Text = "Eight";
                    break;
                case 9:
                    Player1Cards = 9;
                    lblPleyer1Cards.Text = "Nine";
                    break;
                case 10:
                    Player1Cards = 10;
                    lblPleyer1Cards.Text = "Ten";
                    break;
                case 11:
                    Player1Cards = 10;
                    lblPleyer1Cards.Text = "Jack";
                    break;
                case 12:
                    Player1Cards = 10;
                    lblPleyer1Cards.Text = "Queen";
                    break;
                case 13:
                    Player1Cards = 10;
                    lblPleyer1Cards.Text = "King";
                    break;
                case 14:
                    Player1Cards = 11;
                    lblPleyer1Cards.Text = "Ace";
                    break;
            }
            random1 = random.Next(2, 15);
            switch (random1)
            {
                case 2:
                    Player1Cards = Player1Cards + 2;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Two";
                    break;
                case 3:
                    Player1Cards = Player1Cards + 3;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Three";
                    break;
                case 4:
                    Player1Cards = Player1Cards + 4;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Four";
                    break;
                case 5:
                    Player1Cards = Player1Cards + 5;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Five";
                    break;
                case 6:
                    Player1Cards = Player1Cards + 6;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Six";
                    break;
                case 7:
                    Player1Cards = Player1Cards + 7;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Seven";
                    break;
                case 8:
                    Player1Cards = Player1Cards + 8;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Eight";
                    break;
                case 9:
                    Player1Cards = Player1Cards + 9;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Nine";
                    break;
                case 10:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Ten";
                    break;
                case 11:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Jack";
                    break;
                case 12:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Queen";
                    break;
                case 13:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   King";
                    break;
                case 14:
                    Player1Cards = Player1Cards + 11;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Ace";
                    break;
            }
            if (Player1Cards > 21)
            {
                Player1Cards = Player1Cards - 10;
            }
        }
        private void Player2Random()
        {
            int random2 = random.Next(2, 15);
            switch (random2)
            {
                case 2:
                    Player2Cards = 2;
                    lblPleyer2Cards.Text = "Two";
                    break;
                case 3:
                    Player2Cards = 3;
                    lblPleyer2Cards.Text = "Three";
                    break;
                case 4:
                    Player2Cards = 4;
                    lblPleyer2Cards.Text = "Four";
                    break;
                case 5:
                    Player2Cards = 5;
                    lblPleyer2Cards.Text = "Five";
                    break;
                case 6:
                    Player2Cards = 6;
                    lblPleyer2Cards.Text = "Six";
                    break;
                case 7:
                    Player2Cards = 7;
                    lblPleyer2Cards.Text = "Seven";
                    break;
                case 8:
                    Player2Cards = 8;
                    lblPleyer2Cards.Text = "Eight";
                    break;
                case 9:
                    Player2Cards = 9;
                    lblPleyer2Cards.Text = "Nine";
                    break;
                case 10:
                    Player2Cards = 10;
                    lblPleyer2Cards.Text = "Ten";
                    break;
                case 11:
                    Player2Cards = 10;
                    lblPleyer2Cards.Text = "Jack";
                    break;
                case 12:
                    Player2Cards = 10;
                    lblPleyer2Cards.Text = "Queen";
                    break;
                case 13:
                    Player2Cards = 10;
                    lblPleyer2Cards.Text = "King";
                    break;
                case 14:
                    Player2Cards = 11;
                    lblPleyer2Cards.Text = "Ace";
                    break;
            }
            random2 = random.Next(2, 15);
            switch (random2)
            {
                case 2:
                    Player2Cards = Player2Cards + 2;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Two";
                    break;
                case 3:
                    Player2Cards = Player2Cards + 3;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Three";
                    break;
                case 4:
                    Player2Cards = Player2Cards + 4;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Four";
                    break;
                case 5:
                    Player2Cards = Player2Cards + 5;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Five";
                    break;
                case 6:
                    Player2Cards = Player2Cards + 6;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Six";
                    break;
                case 7:
                    Player2Cards = Player2Cards + 7;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Seven";
                    break;
                case 8:
                    Player2Cards = Player2Cards + 8;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Eight";
                    break;
                case 9:
                    Player2Cards = Player2Cards + 9;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Nine";
                    break;
                case 10:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Ten";
                    break;
                case 11:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Jack";
                    break;
                case 12:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Queen";
                    break;
                case 13:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   King";
                    break;
                case 14:
                    Player2Cards = Player2Cards + 11;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Ace";
                    break;
            }
            if (Player2Cards > 21)
            {
                Player2Cards = Player2Cards - 10;
            }
        }
        private void Player3Random()
        {
            int random3 = random.Next(2, 15);
            switch (random3)
            {
                case 2:
                    Player3Cards = 2;
                    lblPleyer3Cards.Text = "Two";
                    break;
                case 3:
                    Player3Cards = 3;
                    lblPleyer3Cards.Text = "Three";
                    break;
                case 4:
                    Player3Cards = 4;
                    lblPleyer3Cards.Text = "Four";
                    break;
                case 5:
                    Player3Cards = 5;
                    lblPleyer3Cards.Text = "Five";
                    break;
                case 6:
                    Player3Cards = 6;
                    lblPleyer3Cards.Text = "Six";
                    break;
                case 7:
                    Player3Cards = 7;
                    lblPleyer3Cards.Text = "Seven";
                    break;
                case 8:
                    Player3Cards = 8;
                    lblPleyer3Cards.Text = "Eight";
                    break;
                case 9:
                    Player3Cards = 9;
                    lblPleyer3Cards.Text = "Nine";
                    break;
                case 10:
                    Player3Cards = 10;
                    lblPleyer3Cards.Text = "Ten";
                    break;
                case 11:
                    Player3Cards = 10;
                    lblPleyer3Cards.Text = "Jack";
                    break;
                case 12:
                    Player3Cards = 10;
                    lblPleyer3Cards.Text = "Queen";
                    break;
                case 13:
                    Player3Cards = 10;
                    lblPleyer3Cards.Text = "King";
                    break;
                case 14:
                    Player3Cards = 11;
                    lblPleyer3Cards.Text = "Ace";
                    break;
            }
            random3 = random.Next(2, 15);
            switch (random3)
            {
                case 2:
                    Player3Cards = Player3Cards + 2;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Two";
                    break;
                case 3:
                    Player3Cards = Player3Cards + 3;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Three";
                    break;
                case 4:
                    Player3Cards = Player3Cards + 4;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Four";
                    break;
                case 5:
                    Player3Cards = Player3Cards + 5;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Five";
                    break;
                case 6:
                    Player3Cards = Player3Cards + 6;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Six";
                    break;
                case 7:
                    Player3Cards = Player3Cards + 7;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Seven";
                    break;
                case 8:
                    Player3Cards = Player3Cards + 8;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Eight";
                    break;
                case 9:
                    Player3Cards = Player3Cards + 9;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Nine";
                    break;
                case 10:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Ten";
                    break;
                case 11:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Jack";
                    break;
                case 12:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Queen";
                    break;
                case 13:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   King";
                    break;
                case 14:
                    Player3Cards = Player3Cards + 11;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Ace";
                    break;
            }
            if (Player3Cards > 21)
            {
                Player3Cards = Player3Cards - 10;
            }
        }
        private void Player4Random()
        {
            int random4 = random.Next(2, 15);
            switch (random4)
            {
                case 2:
                    Player4Cards = 2;
                    lblPleyer4Cards.Text = "Two";
                    break;
                case 3:
                    Player4Cards = 3;
                    lblPleyer4Cards.Text = "Three";
                    break;
                case 4:
                    Player4Cards = 4;
                    lblPleyer4Cards.Text = "Four";
                    break;
                case 5:
                    Player4Cards = 5;
                    lblPleyer4Cards.Text = "Five";
                    break;
                case 6:
                    Player4Cards = 6;
                    lblPleyer4Cards.Text = "Six";
                    break;
                case 7:
                    Player4Cards = 7;
                    lblPleyer4Cards.Text = "Seven";
                    break;
                case 8:
                    Player4Cards = 8;
                    lblPleyer4Cards.Text = "Eight";
                    break;
                case 9:
                    Player4Cards = 9;
                    lblPleyer4Cards.Text = "Nine";
                    break;
                case 10:
                    Player4Cards = 10;
                    lblPleyer4Cards.Text = "Ten";
                    break;
                case 11:
                    Player4Cards = 10;
                    lblPleyer4Cards.Text = "Jack";
                    break;
                case 12:
                    Player4Cards = 10;
                    lblPleyer4Cards.Text = "Queen";
                    break;
                case 13:
                    Player4Cards = 10;
                    lblPleyer4Cards.Text = "King";
                    break;
                case 14:
                    Player4Cards = 11;
                    lblPleyer4Cards.Text = "Ace";
                    break;
            }
            random4 = random.Next(2, 15);
            switch (random4)
            {
                case 2:
                    Player4Cards = Player4Cards + 2;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Two";
                    break;
                case 3:
                    Player4Cards = Player4Cards + 3;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Three";
                    break;
                case 4:
                    Player4Cards = Player4Cards + 4;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Four";
                    break;
                case 5:
                    Player4Cards = Player4Cards + 5;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Five";
                    break;
                case 6:
                    Player4Cards = Player4Cards + 6;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Six";
                    break;
                case 7:
                    Player4Cards = Player4Cards + 7;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Seven";
                    break;
                case 8:
                    Player4Cards = Player4Cards + 8;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Eight";
                    break;
                case 9:
                    Player4Cards = Player4Cards + 9;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Nine";
                    break;
                case 10:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Ten";
                    break;
                case 11:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Jack";
                    break;
                case 12:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Queen";
                    break;
                case 13:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   King";
                    break;
                case 14:
                    Player4Cards = Player4Cards + 11;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Ace";
                    break;
            }
            if (Player4Cards > 21)
            {
                Player4Cards = Player4Cards - 10;
            }
        }
        private void ComputerRandom()
        {
            int randomPC = random.Next(2, 15);
            switch (randomPC)
            {
                case 2:
                    ComputerCards = 2;
                    lblPcCards.Text = "Two";
                    break;
                case 3:
                    ComputerCards = 3;
                    lblPcCards.Text = "Three";
                    break;
                case 4:
                    ComputerCards = 4;
                    lblPcCards.Text = "Four";
                    break;
                case 5:
                    ComputerCards = 5;
                    lblPcCards.Text = "Five";
                    break;
                case 6:
                    ComputerCards = 6;
                    lblPcCards.Text = "Six";
                    break;
                case 7:
                    ComputerCards = 7;
                    lblPcCards.Text = "Seven";
                    break;
                case 8:
                    ComputerCards = 8;
                    lblPcCards.Text = "Eight";
                    break;
                case 9:
                    ComputerCards = 9;
                    lblPcCards.Text = "Nine";
                    break;
                case 10:
                    ComputerCards = 10;
                    lblPcCards.Text = "Ten";
                    break;
                case 11:
                    ComputerCards = 10;
                    lblPcCards.Text = "Jack";
                    break;
                case 12:
                    ComputerCards = 10;
                    lblPcCards.Text = "Queen";
                    break;
                case 13:
                    ComputerCards = 10;
                    lblPcCards.Text = "King";
                    break;
                case 14:
                    ComputerCards = 11;
                    lblPcCards.Text = "Ace";
                    break;
            }
            ogPcCards = lblPcCards.Text;
            lblPcCards.Text = lblPcCards.Text + "   ?";
        }

        private void btnHit1_Click(object sender, EventArgs e)
        {
            playingPlayer = a;
            int random1 = random.Next(2, 15);
            switch (random1)
            {
                case 2:
                    Player1Cards = Player1Cards + 2;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Two";
                    break;
                case 3:
                    Player1Cards = Player1Cards + 3;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Three";
                    break;
                case 4:
                    Player1Cards = Player1Cards + 4;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Four";
                    break;
                case 5:
                    Player1Cards = Player1Cards + 5;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Five";
                    break;
                case 6:
                    Player1Cards = Player1Cards + 6;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Six";
                    break;
                case 7:
                    Player1Cards = Player1Cards + 7;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Seven";
                    break;
                case 8:
                    Player1Cards = Player1Cards + 8;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Eight";
                    break;
                case 9:
                    Player1Cards = Player1Cards + 9;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Nine";
                    break;
                case 10:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Ten";
                    break;
                case 11:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Jack";
                    break;
                case 12:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Queen";
                    break;
                case 13:
                    Player1Cards = Player1Cards + 10;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   King";
                    break;
                case 14:
                    Player1Cards = Player1Cards + 11;
                    lblPleyer1Cards.Text = lblPleyer1Cards.Text + "   Ace";
                    break;
            }

            lblValue1.Text = Convert.ToString(Player1Cards);
            if(Player1Cards > 21)
            {
                lblPleyer1Cards.Text = "Bust";
                btnHit1.Visible = false;
                btnHit1.Enabled = false;
                btnPlayer1Stand.Visible = false;
                btnPlayer1Stand.Enabled = false;
                if (playingPlayer == 2)
                {
                    btnHit2.Visible = true;
                    btnHit2.Enabled = true;
                    btnPlayer2Stand.Visible = true;
                    btnPlayer2Stand.Enabled = true;
                }
                if (playingPlayer == 3)
                {
                    btnHit3.Visible = true;
                    btnHit3.Enabled = true;
                    btnPlayer3Stand.Visible = true;
                    btnPlayer3Stand.Enabled = true;
                }
                if (playingPlayer == 4)
                {
                   btnHit4.Visible = true;
                    btnHit4.Enabled = true;
                    btnPlayer4Stand.Visible = true;
                    btnPlayer4Stand.Enabled = true;
                }
                if (playingPlayer == 5)
                {
                    ComputerFinal();
                }
            }
        }

        private void btnPlayer1Stand_Click(object sender, EventArgs e)
        {
            playingPlayer = a;
            btnHit1.Visible = false;
            btnHit1.Enabled = false;
            btnPlayer1Stand.Visible = false;
            btnPlayer1Stand.Enabled = false;
            if (playingPlayer == 2)
            {
                btnHit2.Visible = true;
                btnHit2.Enabled = true;
                btnPlayer2Stand.Visible = true;
                btnPlayer2Stand.Enabled = true;
            }
            if (playingPlayer == 3)
            {
                btnHit3.Visible = true;
                btnHit3.Enabled = true;
                btnPlayer3Stand.Visible = true;
                btnPlayer3Stand.Enabled = true;
            }
            if (playingPlayer == 4)
            {
                btnHit4.Visible = true;
                btnHit4.Enabled = true;
                btnPlayer4Stand.Visible = true;
                btnPlayer4Stand.Enabled = true;
            }
            if (playingPlayer == 5)
            {
                ComputerFinal();
            }
        }

        private void btnHit2_Click(object sender, EventArgs e)
        {
            playingPlayer = b;
            int random2 = random.Next(2, 15);
            switch (random2)
            {
                case 2:
                    Player2Cards = Player2Cards + 2;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Two";
                    break;
                case 3:
                    Player2Cards = Player2Cards + 3;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Three";
                    break;
                case 4:
                    Player2Cards = Player2Cards + 4;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Four";
                    break;
                case 5:
                    Player2Cards = Player2Cards + 5;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Five";
                    break;
                case 6:
                    Player2Cards = Player2Cards + 6;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Six";
                    break;
                case 7:
                    Player2Cards = Player2Cards + 7;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Seven";
                    break;
                case 8:
                    Player2Cards = Player2Cards + 8;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Eight";
                    break;
                case 9:
                    Player2Cards = Player2Cards + 9;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Nine";
                    break;
                case 10:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Ten";
                    break;
                case 11:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Jack";
                    break;
                case 12:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Queen";
                    break;
                case 13:
                    Player2Cards = Player2Cards + 10;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   King";
                    break;
                case 14:
                    Player2Cards = Player2Cards + 11;
                    lblPleyer2Cards.Text = lblPleyer2Cards.Text + "   Ace";
                    break;
            }

            lblValue2.Text = Convert.ToString(Player2Cards);
            if (Player2Cards > 21)
            {
                lblPleyer2Cards.Text = "Bust";
                btnHit2.Visible = false;
                btnHit2.Enabled = false;
                btnPlayer2Stand.Visible = false;
                btnPlayer2Stand.Enabled = false;
                if (playingPlayer == 3)
                {
                    btnHit3.Visible = true;
                    btnHit3.Enabled = true;
                    btnPlayer3Stand.Visible = true;
                    btnPlayer3Stand.Enabled = true;
                }
                if (playingPlayer == 4)
                {
                    btnHit4.Visible = true;
                    btnHit4.Enabled = true;
                    btnPlayer4Stand.Visible = true;
                    btnPlayer4Stand.Enabled = true;
                }
                if (playingPlayer == 5)
                {
                    ComputerFinal();
                }
            }
        }

        private void btnPlayer2Stand_Click(object sender, EventArgs e)
        {
            btnHit2.Visible = false;
            btnHit2.Enabled = false;
            btnPlayer2Stand.Visible = false;
            btnPlayer2Stand.Enabled = false;
            playingPlayer = b;
            if (playingPlayer == 3)
            {
                btnHit3.Visible = true;
                btnHit3.Enabled = true;
                btnPlayer3Stand.Visible = true;
                btnPlayer3Stand.Enabled = true;
            }
            if (playingPlayer == 4)
            {
                btnHit4.Visible = true;
                btnHit4.Enabled = true;
                btnPlayer4Stand.Visible = true;
                btnPlayer4Stand.Enabled = true;
            }
            if (playingPlayer == 5)
            {
                ComputerFinal();
            }
        }

        private void btnHit3_Click(object sender, EventArgs e)
        {
            playingPlayer = c;
            int random3 = random.Next(2, 15);
            switch (random3)
            {
                case 2:
                    Player3Cards = Player3Cards + 2;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Two";
                    break;
                case 3:
                    Player3Cards = Player3Cards + 3;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Three";
                    break;
                case 4:
                    Player3Cards = Player3Cards + 4;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Four";
                    break;
                case 5:
                    Player3Cards = Player3Cards + 5;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Five";
                    break;
                case 6:
                    Player3Cards = Player3Cards + 6;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Six";
                    break;
                case 7:
                    Player3Cards = Player3Cards + 7;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Seven";
                    break;
                case 8:
                    Player3Cards = Player3Cards + 8;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Eight";
                    break;
                case 9:
                    Player3Cards = Player3Cards + 9;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Nine";
                    break;
                case 10:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Ten";
                    break;
                case 11:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Jack";
                    break;
                case 12:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Queen";
                    break;
                case 13:
                    Player3Cards = Player3Cards + 10;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   King";
                    break;
                case 14:
                    Player3Cards = Player3Cards + 11;
                    lblPleyer3Cards.Text = lblPleyer3Cards.Text + "   Ace";
                    break;
            }

            lblValue3.Text = Convert.ToString(Player3Cards);
            if (Player3Cards > 21)
            {
                lblPleyer3Cards.Text = "Bust";
                btnHit3.Visible = false;
                btnHit3.Enabled = false;
                btnPlayer3Stand.Visible = false;
                btnPlayer3Stand.Enabled = false;
                if (playingPlayer == 4)
                {
                    btnHit4.Visible = true;
                    btnHit4.Enabled = true;
                    btnPlayer4Stand.Visible = true;
                    btnPlayer4Stand.Enabled = true;
                }
                if (playingPlayer == 5)
                {
                    ComputerFinal();
                }
            }
        }

        private void btnPlayer3Stand_Click(object sender, EventArgs e)
        {
            btnHit3.Visible = false;
            btnHit3.Enabled = false;
            btnPlayer3Stand.Visible = false;
            btnPlayer3Stand.Enabled = false;
            playingPlayer = c;
            if (playingPlayer == 4)
            {
                btnHit4.Visible = true;
                btnHit4.Enabled = true;
                btnPlayer4Stand.Visible = true;
                btnPlayer4Stand.Enabled = true;
            }
            if (playingPlayer == 5)
            {
                ComputerFinal();
            }
        }

        private void btnHit4_Click(object sender, EventArgs e)
        {
            playingPlayer = d;
            int random4 = random.Next(2, 15);
            switch (random4)
            {
                case 2:
                    Player4Cards = Player4Cards + 2;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Two";
                    break;
                case 3:
                    Player4Cards = Player4Cards + 3;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Three";
                    break;
                case 4:
                    Player4Cards = Player4Cards + 4;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Four";
                    break;
                case 5:
                    Player4Cards = Player4Cards + 5;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Five";
                    break;
                case 6:
                    Player4Cards = Player4Cards + 6;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Six";
                    break;
                case 7:
                    Player4Cards = Player4Cards + 7;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Seven";
                    break;
                case 8:
                    Player4Cards = Player4Cards + 8;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Eight";
                    break;
                case 9:
                    Player4Cards = Player4Cards + 9;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Nine";
                    break;
                case 10:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Ten";
                    break;
                case 11:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Jack";
                    break;
                case 12:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Queen";
                    break;
                case 13:
                    Player4Cards = Player4Cards + 10;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   King";
                    break;
                case 14:
                    Player4Cards = Player4Cards + 11;
                    lblPleyer4Cards.Text = lblPleyer4Cards.Text + "   Ace";
                    break;
            }

            lblValue4.Text = Convert.ToString(Player4Cards);
            if (Player4Cards > 21)
            {
                lblPleyer4Cards.Text = "Bust";
                btnHit4.Visible = false;
                btnHit4.Enabled = false;
                btnPlayer4Stand.Visible = false;
                btnPlayer4Stand.Enabled = false;
                if (playingPlayer == 5)
                {
                    ComputerFinal();
                }
            }
        }

        private void btnPlayer4Stand_Click(object sender, EventArgs e)
        {
            btnHit4.Visible = false;
            btnHit4.Enabled = false;
            btnPlayer4Stand.Visible = false;
            btnPlayer4Stand.Enabled = false;
            playingPlayer = d;
            if (playingPlayer == 5)
            {
                ComputerFinal();
            }
        }

        private void ComputerFinal()
        {
            lblPcCards.Text = ogPcCards;
            while (ComputerCards <= 17)
            {
                int randomPC = random.Next(2, 15);
                switch (randomPC)
                {
                    case 2:
                        ComputerCards = ComputerCards + 2;
                        lblPcCards.Text = lblPcCards.Text + "   Two";
                        break;
                    case 3:
                        ComputerCards = ComputerCards + 3;
                        lblPcCards.Text = lblPcCards.Text + "   Three";
                        break;
                    case 4:
                        ComputerCards = ComputerCards + 4;
                        lblPcCards.Text = lblPcCards.Text + "   Four";
                        break;
                    case 5:
                        ComputerCards = ComputerCards + 5;
                        lblPcCards.Text = lblPcCards.Text + "   Five";
                        break;
                    case 6:
                        ComputerCards = ComputerCards + 6;
                        lblPcCards.Text = lblPcCards.Text + "   Six";
                        break;
                    case 7:
                        ComputerCards = ComputerCards + 7;
                        lblPcCards.Text = lblPcCards.Text + "   Seven";
                        break;
                    case 8:
                        ComputerCards = ComputerCards + 8;
                        lblPcCards.Text = lblPcCards.Text + "   Eight";
                        break;
                    case 9:
                        ComputerCards = ComputerCards + 9;
                        lblPcCards.Text = lblPcCards.Text + "   Nine";
                        break;
                    case 10:
                        ComputerCards = ComputerCards + 10;
                        lblPcCards.Text = lblPcCards.Text + "   Ten";
                        break;
                    case 11:
                        ComputerCards = ComputerCards + 10;
                        lblPcCards.Text = lblPcCards.Text + "   Jack";
                        break;
                    case 12:
                        ComputerCards = ComputerCards + 10;
                        lblPcCards.Text = lblPcCards.Text + "   Queen";
                        break;
                    case 13:
                        ComputerCards = ComputerCards + 10;
                        lblPcCards.Text = lblPcCards.Text + "   King";
                        break;
                    case 14:
                        ComputerCards = ComputerCards + 11;
                        lblPcCards.Text = lblPcCards.Text + "   Ace";
                        break;
                }
                lblValuePC.Text = Convert.ToString(ComputerCards);
            }
            if(ComputerCards > 17)
            {
                PriceCheck();
            }
        }

        private void PriceCheck()
        {
            if(player1Here == true && player1HasBet == true)
            {
                if (Player1Cards <= 21 && ComputerCards <=21 && Player1Cards > ComputerCards)
                {
                    Player1BetAmount = Player1BetAmount * 2;
                    Player1Money = Player1Money + Player1BetAmount;
                    lblPlayer1Money.Text = Convert.ToString(Player1Money);
                    lblDifference1.Text = "Difference:  +"+Convert.ToString(Player1BetAmount);
                }
                else if (Player1Cards <= 21 && ComputerCards <= 21 && Player1Cards == ComputerCards)
                {
                    Player1Money = Player1Money + Player1BetAmount;
                    lblPlayer1Money.Text = Convert.ToString(Player1Money);
                    lblDifference1.Text = "Difference:  +- 0";
                }
                else if (Player1Cards <= 21 && ComputerCards > 21)
                {
                    Player1BetAmount = Player1BetAmount * 2;
                    Player1Money = Player1Money + Player1BetAmount;
                    lblPlayer1Money.Text = Convert.ToString(Player1Money);
                    lblDifference1.Text = "Difference:  +" + Convert.ToString(Player1BetAmount);
                }
                else if (Player1Cards > 21 && ComputerCards > 21)   
                {
                    Player1Money = Player1Money + Player1BetAmount;
                    lblPlayer1Money.Text = Convert.ToString(Player1Money);
                    lblDifference1.Text = "Difference:  +- 0";
                }
                else if (Player1Cards > 21 && ComputerCards <= 21)
                {
                    lblDifference1.Text = "Difference:  -" + Convert.ToString(Player1BetAmount);
                }
                else if (Player1Cards <= 21 && ComputerCards <= 21 && ComputerCards > Player1Cards)
                {
                    lblDifference1.Text = "Difference:  -" + Convert.ToString(Player1BetAmount);
                }
            }
            if (player2Here == true && player2HasBet == true)
            {
                if (Player2Cards <= 21 && ComputerCards <= 21 && Player2Cards > ComputerCards)
                {
                    Player2BetAmount = Player2BetAmount * 2;
                    Player2Money = Player2Money + Player2BetAmount;
                    lblPlayer2Money.Text = Convert.ToString(Player2Money);
                    lblDifference2.Text = "Difference:  +" + Convert.ToString(Player2BetAmount);
                }
                else if (Player2Cards <= 21 && ComputerCards <= 21 && Player2Cards == ComputerCards)
                {
                    Player2Money = Player2Money + Player2BetAmount;
                    lblPlayer2Money.Text = Convert.ToString(Player2Money);
                    lblDifference2.Text = "Difference:  +- 0";
                }
                else if (Player2Cards <= 21 && ComputerCards > 21)
                {
                    Player2BetAmount = Player2BetAmount * 2;
                    Player2Money = Player2Money + Player2BetAmount;
                    lblPlayer2Money.Text = Convert.ToString(Player2Money);
                    lblDifference2.Text = "Difference:  +" + Convert.ToString(Player2BetAmount);
                }
                else if (Player2Cards > 21 && ComputerCards > 21)
                {
                    Player2Money = Player2Money + Player2BetAmount;
                    lblPlayer2Money.Text = Convert.ToString(Player2Money);
                    lblDifference2.Text = "Difference:  +- 0";
                }
                else if (Player1Cards > 21 && ComputerCards <= 21)
                {
                    lblDifference2.Text = "Difference:  -" + Convert.ToString(Player2BetAmount);
                }
                else if (Player1Cards <= 21 && ComputerCards <= 21 && ComputerCards > Player1Cards)
                {
                    lblDifference2.Text = "Difference:  -" + Convert.ToString(Player2BetAmount);
                }
            }
            if (player3Here == true && player3HasBet == true)
            {
                if (Player3Cards <= 21 && ComputerCards <= 21 && Player3Cards > ComputerCards)
                {
                    Player3BetAmount = Player3BetAmount * 2;
                    Player3Money = Player3Money + Player3BetAmount;
                    lblPlayer3Money.Text = Convert.ToString(Player3Money);
                    lblDifference3.Text = "Difference:  +" + Convert.ToString(Player3BetAmount);
                }
                else if (Player3Cards <= 21 && ComputerCards <= 21 && Player3Cards == ComputerCards)
                {
                    Player3Money = Player3Money + Player3BetAmount;
                    lblPlayer3Money.Text = Convert.ToString(Player3Money);
                    lblDifference3.Text = "Difference:  +- 0";
                }
                else if (Player3Cards <= 21 && ComputerCards > 21)
                {
                    Player3BetAmount = Player3BetAmount * 2;
                    Player3Money = Player3Money + Player3BetAmount;
                    lblPlayer3Money.Text = Convert.ToString(Player3Money);
                    lblDifference3.Text = "Difference:  +" + Convert.ToString(Player3BetAmount);
                }
                else if (Player3Cards > 21 && ComputerCards > 21)
                {
                    Player3Money = Player3Money + Player3BetAmount;
                    lblPlayer3Money.Text = Convert.ToString(Player3Money);
                    lblDifference3.Text = "Difference:  +- 0";
                }
                else if (Player1Cards > 21 && ComputerCards <= 21)
                {
                    lblDifference3.Text = "Difference:  -" + Convert.ToString(Player3BetAmount);
                }
                else if (Player1Cards <= 21 && ComputerCards <= 21 && ComputerCards > Player1Cards)
                {
                    lblDifference3.Text = "Difference:  -" + Convert.ToString(Player3BetAmount);
                }
            }
            if (player4Here == true && player4HasBet == true)
            {
                if (Player4Cards <= 21 && ComputerCards <= 21 && Player4Cards > ComputerCards)
                {
                    Player4BetAmount = Player4BetAmount * 2;
                    Player4Money = Player4Money + Player4BetAmount;
                    lblPlayer4Money.Text = Convert.ToString(Player4Money);
                    lblDifference4.Text = "Difference:  +" + Convert.ToString(Player4BetAmount);
                }
                else if (Player4Cards <= 21 && ComputerCards <= 21 && Player4Cards == ComputerCards)
                {
                    Player4Money = Player4Money + Player4BetAmount;
                    lblPlayer4Money.Text = Convert.ToString(Player4Money);
                    lblDifference4.Text = "Difference:  +- 0";
                }
                else if (Player4Cards <= 21 && ComputerCards > 21)
                {
                    Player4BetAmount = Player4BetAmount * 2;
                    Player4Money = Player4Money + Player4BetAmount;
                    lblPlayer4Money.Text = Convert.ToString(Player4Money);
                    lblDifference4.Text = "Difference:  +" + Convert.ToString(Player4BetAmount);
                }
                else if (Player4Cards > 21 && ComputerCards > 21)
                {
                    Player4Money = Player4Money + Player4BetAmount;
                    lblPlayer4Money.Text = Convert.ToString(Player4Money);
                    lblDifference4.Text = "Difference:  +- 0";
                }
                else if (Player1Cards > 21 && ComputerCards <= 21)
                {
                    lblDifference4.Text = "Difference:  -" + Convert.ToString(Player4BetAmount);
                }
                else if (Player1Cards <= 21 && ComputerCards <= 21 && ComputerCards > Player1Cards)
                {
                    lblDifference4.Text = "Difference:  -" + Convert.ToString(Player4BetAmount);
                }
            }
            btnAgain.Enabled = true;
            btnAgain.Visible = true;
            btnRestart.Enabled = false;
            btnRestart.Visible = false;
        }
        private void semiRestart()
        {
            lblPcCards.Text = "";
            lblValuePC.Text = "";
            lblPleyer1Cards.Text = "";
            lblPleyer2Cards.Text = "";
            lblPleyer3Cards.Text = "";
            lblPleyer4Cards.Text = "";
            lblValue1.Text = "";
            lblValue2.Text = "";
            lblValue3.Text = "";
            lblValue4.Text = "";
            txbPlayer1.Text = "";
            txbPlayer2.Text = "";
            txbPlayer3.Text = "";
            txbPlayer4.Text = "";
            txbPlayer1.Enabled = true;
            txbPlayer2.Enabled = true;
            txbPlayer3.Enabled = true;
            txbPlayer4.Enabled = true;
            txbPlayer1.Visible = true;
            txbPlayer2.Visible = true;
            txbPlayer3.Visible = true;
            txbPlayer4.Visible = true;
            btnPlayer1Ready.Enabled = true;
            btnPlayer2Ready.Enabled = true;
            btnPlayer3Ready.Enabled = true;
            btnPlayer4Ready.Enabled = true;
            btnPlayer1Ready.Visible = true;
            btnPlayer2Ready.Visible = true;
            btnPlayer3Ready.Visible = true;
            btnPlayer4Ready.Visible = true;
            player1HasBet = false;
            player2HasBet = false;
            player3HasBet = false;
            player4HasBet = false;
            btnRestart.Enabled = true;
            btnRestart.Visible = true;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            btnAgain.Enabled = false;
            btnAgain.Visible = false;
            lblDifference1.Text = "";
            lblDifference2.Text = "";
            lblDifference3.Text = "";
            lblDifference4.Text = "";
            semiRestart();
        }

        private void BlackJack_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnRestart.Enabled = false;
            btnRestart.Visible = false;
            player1Here = false;
            player2Here = false;
            player3Here = false;
            player4Here = false;
            player1HasBet = false;
            player2HasBet = false;
            player3HasBet = false;
            player4HasBet = false;
            Player1Money = 500;
            Player2Money = 500;
            Player3Money = 500;
            Player4Money = 500;
            btnStart.Enabled = true;
            btnStart.Visible = true;
            lblTextMoney1.Visible = false;
            lblTextMoney2.Visible = false;
            lblTextMoney3.Visible = false;
            lblTextMoney4.Visible = false;
            gbPlayer1.Visible = true;
            gbPlayer1.Enabled = true;
            gpPlayer2.Visible = true;
            gpPlayer2.Enabled = true;
            gpPlayer3.Visible = true;
            gpPlayer3.Enabled = true;
            gpPlayer4.Visible = true;
            gpPlayer4.Enabled = true;
            gbPlayer1.Text = "Player 1";
            gpPlayer2.Text = "Player 2";
            gpPlayer3.Text = "Player 3";
            gpPlayer4.Text = "Player 4";
            lblPlayer1.Text = "Name:";
            lblPlayer2.Text = "Name:";
            lblPlayer3.Text = "Name:";
            lblPlayer4.Text = "Name:";
            lblPlayer1Money.Text = "";
            lblPlayer2Money.Text = "";
            lblPlayer3Money.Text = "";
            lblPlayer4Money.Text = "";
            btnPlayer1Ready.Visible = false;
            btnPlayer1Ready.Enabled = false;
            btnPlayer2Ready.Visible = false;
            btnPlayer2Ready.Enabled = false;
            btnPlayer3Ready.Visible = false;
            btnPlayer3Ready.Enabled = false;
            btnPlayer4Ready.Visible = false;
            btnPlayer4Ready.Enabled = false;
        }
    }
}
