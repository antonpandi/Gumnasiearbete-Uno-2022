using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gumnasiearbete___Uno
{
    class TakeTwoCard : PlayingCard
    {
        Color _color;

        string _picturePath,
            _type = "TakeTwo";

        Player _player;

        PictureBox _pictureCard;

        int _value,
            _position,
            _id;

        public TakeTwoCard(
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
                "Type: TakeTwoCard" +
                "   Id:" + this._id + 
                "   Color: " + this._color.ToString() +
                "   PicturePath: " + this._picturePath.ToString() +
                "   Player: " + this._player.ToString() +
                "   Value: " + this._value.ToString();
        }
        public Player Player
        {
            get { return this._player; }
            set { this.Player = value; }
        }
    }
}
