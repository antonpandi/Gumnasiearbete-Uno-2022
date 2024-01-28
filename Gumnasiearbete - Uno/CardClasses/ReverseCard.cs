using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gumnasiearbete___Uno
{
    class ReverseCard : PlayingCard
    {
        Color _color;

        string _picturePath,
            _type = "reverse";

        Player _player;

        PictureBox _pictureCard;

        int _value,
            _position,
            _id;

        public ReverseCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id) : base(color, picturePath, player, pictureCard, value, id)
        {
            this._color = color;
            this._picturePath = picturePath;
            this._player = player;
            this._pictureCard = pictureCard;
            this._value = value;
            this._id = id;
        }
        public override string ToString()
        {
            return
                "Type: " + this._type +
                "   Id:" + this._id +
                "   Color: " + this._color.ToString() +
                "   PicturePatj: " + this._picturePath.ToString() +
                "   Player: " + this._player.ToString() +
                "   Value: " + this._value.ToString() ;
        }
        public Player Player
        {
            get { return this._player; }
            set { this.Player = value; }
        }
    }
}
