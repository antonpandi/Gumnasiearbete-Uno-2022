using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gumnasiearbete___Uno
{
    class NumberCard : PlayingCard
    {
        Color _color;

        string _picturePath,
            _type = "number";

        Player _player;

        PictureBox _pictureCard;

        int _value,
            _position,
            _id;

        public NumberCard()
        {

        }

        public NumberCard(
            Color color,
            string picturePah,
            Player player,
            PictureBox pictureCard,
            int value,
            int id) : base(color, picturePah, player, pictureCard, value, id)
        {
            this._color = color;
            this._picturePath = picturePah;
            this._player = player;
            this._pictureCard = pictureCard;
            this._value = value;
            this._id = id;
        }

        //public override void skapaSpelkort(Spelare spelare)
        //{
        //    Random
        //        slumpVärde = new Random(),
        //        slumpFärg = new Random();


        //    int
        //        värde = slumpVärde.Next(0, 9);
        //    Color
        //        färg = geFärg(slumpFärg.Next(1, 4));

        //    NummerKort spelkort = new NummerKort(färg, "test", spelare, värde);




        //}
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
    }


}
