using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms; //Åtkomst till class Picturebox

namespace Gumnasiearbete___Uno
{
    class PlayingCard
    {



        Color
            _color;

        string
            _picturePath,
            _type = "playingCard";

        Player _player;

        PictureBox _pictureCard;

        int _value,
            _position,
            _id;

        public PlayingCard()
        {

        }

         public PlayingCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            this._color = color;
            this._picturePath = picturePath;
            this._player = player;
            this._pictureCard = pictureCard;
            this._value = value;
            this._id = id;
        }

        //abstract public void skapaSpelkort(Spelare player);

        public override string ToString()
        {
            return
                "Color: " + this._color.ToString() +
                "   PicturePath: " + this._picturePath.ToString() +
                "   Player: " + this._player.ToString() +
                "   Value: " + this._value.ToString() +
                "   Type: PlayingCard";
        }

        public int GetId()
        {
            return this._id;
        }
        public Color GetColor()
        {
            return this._color;
        }
        public PictureBox GetPictureBox()
        {
            return _pictureCard;
        }
        public int GetValue()
        {
            return _value;
        }
        public Player Player
        {
            get { return this._player; }
            set { this.Player = value; }
        }

        public string GetType() =>  _type;

    }
}
