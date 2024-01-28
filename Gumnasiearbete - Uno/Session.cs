using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Gumnasiearbete___Uno
{
    class Session
    {
        List<Player> _playerList = new List<Player>();
        int _turnIndex = 0;
        bool _reverseBool = false;

        public Session() { }

        public void AddPlayer(Player player)
        {
            this._playerList.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            this._playerList.Remove(player);
        }
        public Player GetPlayer(int pos)
        {
            return this._playerList[pos];
        }
        public int GetPlayerCount() => this._playerList.Count();  
        public List<Player> GetPlayerList() => this._playerList;
        public void ClearList()
        {
            this._playerList.Clear();
        }
        public void NextPlayer() {
            if (this._reverseBool)
            {
                this._turnIndex--;
                if (this._turnIndex < 0) { this._turnIndex = this._playerList.Count()-1; }
            }
            else
            {
                this._turnIndex++;
                if (this._turnIndex >= this._playerList.Count()) { this._turnIndex = 0; }
            }
        }
        public Player GetTurnsPlayer() => this._playerList.ElementAt(this._turnIndex);

        public void ReverseOrder() => this._reverseBool = !this._reverseBool;


    }
}
