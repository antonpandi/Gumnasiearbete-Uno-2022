using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Gumnasiearbete___Uno
{
    class Player
    {
        string _username;
        List<PlayingCard> _kortLista;
        TcpClient _tcpClient;
        int
            _wins,
            _losses;
        Color _markedColor;

        public Player() { }
        public Player(TcpClient tcpClient)
        {
            this._tcpClient = tcpClient;
        }
        public Player(string username, int wins, int losses,Color markedColor)
        {
            this._username = username;
            this._wins = wins;
            this._losses = losses;
            this._markedColor = markedColor;
        }
        public override string ToString()
        {
            return "User:" + _username + ":wins:" + _wins + ":losses: " +_losses +":markedColor:" + _markedColor;
        }

        public int GetCardAmount() => this._kortLista.Count;

        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        public Color MarkedColor
        {
            get { return this._markedColor; }
            set { this._markedColor = value; }
        }


        public int Wins
        {
            get { return this._wins; }
            set { this._wins = value; }
        }
        public int Losses
        {
            get { return this._losses; }
            set { this._losses = value; }
        }

        public TcpClient Client
        {
            get { return this._tcpClient; }
            set { this._tcpClient = value; }
        }

    }

   
    
    
}
