using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gumnasiearbete___Uno
{
    class ColorCard : PlayingCard
    {
        Color 
            _color,
            _selectedColor;

        string _picturePath,
            _type = "color";

        Player _player;

        PictureBox _puctureCard;

        int _value,
            _position,
            _id;

        public ColorCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox puctureCard,
            int value,
            int id) : base(color, picturePath, player, puctureCard, value, id)
        {
            this._color = color;
            this._picturePath = picturePath;
            this._player = player;
            this._puctureCard = puctureCard;
            this._value = value;
            this._id = id;
        }
        public override string ToString()
        {
            return
                "Type: " + this._type +
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
        public Color SelectedColor
        {
            get { return this._selectedColor; }
            set { this._selectedColor = value; }
        }
    }
}
