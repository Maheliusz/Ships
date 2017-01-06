using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ships
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game application;
        Mapper mapper;
        public MainWindow()
        {
            mapper = new Mapper();
            application = new Game();
            
            InitializeComponent();
            if (application.getCounter() >= 15)
                textBlock.Text = "GRACZ 2 USTAWIA\n";
            else
                textBlock.Text = "GRACZ 1 USTAWIA\n";
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            shootButton.IsEnabled = false;
            xTextBox.IsEnabled = false;
            yTextBox.IsEnabled = false;
            textBlock1.Text = Mapper.noMap();
            textBlock2.Text = Mapper.noMap();
            startButton.IsEnabled = true;
            endButton.IsEnabled = false;
            application.setPlayer();
            xTextBox.Text = "";
            yTextBox.Text = "";
            labelPlayer1.Content = "";
            labelPlayer2.Content = "";
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            shootButton.IsEnabled = true;
            xTextBox.IsEnabled = true;
            yTextBox.IsEnabled = true;
            startButton.IsEnabled = false;
            endButton.IsEnabled = true;
            if(application.getPlayer() == 1)
            {
                textBlock1.Text = mapper.drawShips(application.player1.ships, application.player2.shotMap);
                textBlock2.Text = mapper.drawShots(application.player2.ships, application.player1.shotMap);
                labelPlayer1.Content = "TWOJA KOLEJ!";
            }
            else
            {
                textBlock1.Text = mapper.drawShots(application.player1.ships, application.player2.shotMap);
                textBlock2.Text = mapper.drawShips(application.player2.ships, application.player1.shotMap);
                labelPlayer2.Content = "TWOJA KOLEJ!";
            }

        }

        private void shootButton_Click(object sender, RoutedEventArgs e)
        {
            if (xTextBox.Text == "" || yTextBox.Text == "") return;
            int x;
            int y;
            if (!int.TryParse(xTextBox.Text, out x))
            {
                textBlock.Text += "ZAKRES PÓL: [0,9]\n";
                return;
            }
            if (!int.TryParse(yTextBox.Text, out y))
            {
                textBlock.Text += "ZAKRES PÓL: [0,9]\n";
                return;
            }
            bool error = false;
            if (x < 0 || x > 9)
            {
                xLabel.Content = "0<=x<=9";
                error = true;
            }
            if (y < 0 || y > 9)
            {
                yLabel.Content = "0<=y<=9";
                error = true;
            }
            if (error) return;
            shoot(x, y);
            checkWin();
            shootButton.IsEnabled = false;
        }

        private void checkWin()
        {
            if (application.getPlayer() == 1)
            {
                bool win = true;
                foreach(Ship ship in application.player2.ships)
                {
                    if (!application.player1.shotMap[ship.x, ship.y]) win = false;
                }
                if (win)
                {
                    textBlock.Text = "GRACZ 1 ZWYCIĘŻA!";
                    startButton.IsEnabled = false;
                    endButton.IsEnabled = false;
                }
            }
            else
            {
                bool win = true;
                foreach (Ship ship in application.player1.ships)
                {
                    if (!application.player2.shotMap[ship.x, ship.y]) win = false;
                }
                if (win)
                {
                    textBlock.Text = "GRACZ 2 ZWYCIĘŻA!";
                    startButton.IsEnabled = false;
                    endButton.IsEnabled = false;
                }
            }
        }

        private void shoot (int x, int y)
        {
            if (application.getPlayer() == 1)
            {
                bool hit = false;
                application.player1.shootAt(x, y);
                foreach (Ship ship in application.player2.ships)
                {
                    if (ship.x == x && ship.y == y)
                    {
                        textBlock.Text = "ZATOPIONY: " + ship.name + "\n";
                        hit = true;
                        break;
                    }
                }
                if (!hit)
                {
                    textBlock.Text = "PUDLO";
                }
            }
            else
            {
                bool hit = false;
                application.player2.shootAt(x, y);
                foreach (Ship ship in application.player1.ships)
                {
                    if (ship.x == x && ship.y == y)
                    {
                        textBlock.Text = "ZATOPIONY: " + ship.name + "\n";
                        hit = true;
                        break;
                    }
                }
                if (!hit)
                {
                    textBlock.Text = "PUDLO";
                }
            }
        }
        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            if (xSetTextBox.Text == "" || ySetTextBox.Text == "")
            {
                textBlock.Text = "POTRZEBA DWÓCH ARGUMENTÓW\n";
                if (application.getCounter() >= 15)
                    textBlock.Text += "GRACZ 2 USTAWIA\n";
                else
                    textBlock.Text += "GRACZ 1 USTAWIA\n";
                return;
            }
            int x;
            int y;
            if (!int.TryParse(xSetTextBox.Text, out x))
            {
                textBlock.Text += "ZAKRES PÓL: [0,9]\n";
                return;
            }
            if (!int.TryParse(ySetTextBox.Text, out y))
            {
                textBlock.Text += "ZAKRES PÓL: [0,9]\n";
                return;
            }
            if (x < 0 || x > 9 || y < 0 || y > 9)
            {
                textBlock.Text += "ZAKRES PÓL: [0,9]\n";
                return;
            }
            bool taken = false;
            if (application.getCounter() >= 29)
            {
                buttonSet.IsEnabled = false;
                xSetTextBox.IsEnabled = false;
                ySetTextBox.IsEnabled = false;
                xSetTextBox.Text = "";
                ySetTextBox.Text = "";
                startButton.IsEnabled = true;
                textBlock.Text = "GRA START!";
            }
            else if (application.getCounter() >= 15)
            {
                foreach(Ship ship in application.player2.ships)
                {
                    if (ship.x == x && ship.y == y)
                    {
                        taken = true;
                        break;
                    }
                }
                if (taken)
                {
                    textBlock.Text = "TO POLE JEST ZAJĘTE!\n";
                    if (application.getCounter() >= 15)
                        textBlock.Text += "GRACZ 2 USTAWIA\n";
                    else
                        textBlock.Text += "GRACZ 1 USTAWIA\n";
                }
                else
                {
                    if (nazwaSetTextBox.Text == "")
                        application.player2.ships.Add(new Ship(x, y));
                    else
                        application.player2.ships.Add(new Ship(x, y, nazwaSetTextBox.Text));
                    textBlock.Text = "USTAWIONO STATEK\n";
                    xSetTextBox.Text = "";
                    ySetTextBox.Text = "";
                    nazwaSetTextBox.Text = "";
                    application.count();
                    if (application.getCounter() >= 15)
                        textBlock.Text += "GRACZ 2 USTAWIA\n";
                    else
                        textBlock.Text += "GRACZ 1 USTAWIA\n";
                }
            }
            else
            {
                foreach (Ship ship in application.player1.ships)
                {
                    if (ship.x == x && ship.y == y)
                    {
                        taken = true;
                        break;
                    }
                }
                if (taken)
                {
                    textBlock.Text = "TO POLE JEST ZAJĘTE!\n";
                    if (application.getCounter() >= 15)
                        textBlock.Text += "GRACZ 2 USTAWIA\n";
                    else
                        textBlock.Text += "GRACZ 1 USTAWIA\n";
                }
                else
                {
                    if (nazwaSetTextBox.Text == "")
                        application.player1.ships.Add(new Ship(x, y));
                    else
                        application.player1.ships.Add(new Ship(x, y, nazwaSetTextBox.Text));
                    textBlock.Text = "USTAWIONO STATEK\n";
                    xSetTextBox.Text = "";
                    ySetTextBox.Text = "";
                    nazwaSetTextBox.Text = "";
                    application.count();
                    if (application.getCounter() >= 15)
                        textBlock.Text += "GRACZ 2 USTAWIA\n";
                    else
                        textBlock.Text += "GRACZ 1 USTAWIA\n";
                }
            }
        }
    }
}
