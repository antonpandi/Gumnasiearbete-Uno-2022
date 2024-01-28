using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Gumnasiearbete___Uno
{

    public partial class Form1 : Form
    {
        List<PlayingCard>
            playingCardList = new List<PlayingCard>(),
            selectedCardList = new List<PlayingCard>();

        List<PictureBox> pictureboxList = new List<PictureBox>();


        ListBox
            lbxTestBox = new ListBox(),
            lbxUser = new ListBox(),
            lbxPlayers = new ListBox(),
            clickedCards = new ListBox();

        PictureBox pbxPlacedCard = new PictureBox();

        Button
            btnPlaceCard = new Button(),
            btnDrawACard = new Button();

        Label lblUsername = new Label();
        TextBox tbxUsername = new TextBox();


        Player player = new Player();

        Session gameSession = new Session();

        PlayingCard
            tempCard,
            placedCard;

        TcpClient
            client,
            serverClient;


        TcpListener listener;


        static int
            cardPositionX = 20,
            cardPositionY = 200,
            cardWidth = 29 * 2,
            cardHeight = 44 * 2,
            border = 6,
            cardId = 0,
            spacer,
            port = 42069,
            numberOfPlayeyCards,
            messagesFoewarded = 0;

        bool
            testMode = false;

        static Color defaultColor = Color.IndianRed;

        Color SelectedColor = new Color();

        Size
            sizeBtn = new Size(75, 50),
            sizePbxPlayerCard = new Size(cardWidth + border, cardHeight + border);

        string
            filePathSettings = AppDomain.CurrentDomain.BaseDirectory + "/temp",
            defaultUsername = "DefaultUsername",
            baseIpAdress = "127.0.0.1";



        Random slump = new Random();


        public Form1()
        {
            InitializeComponent();
            GetSavedSettings();
            //Checks if test mode is active
            if (testMode) { CreateTestObjects(); }
            else { StartProgram(); }
            SetSpacer();
            this.Resize += new EventHandler(ResizeSortCards);

        }

        //Sets the spacer between the cards
        void SetSpacer()
        {
            spacer = (this.Width % 200) / 2 + cardWidth / 2;
            Console.WriteLine("107 spacer: " + spacer.ToString());
        }



        //Here starts all methods 
        protected Color GiveColor(int colorValue)
        {
            Color color = new Color();
            switch (colorValue)
            {
                case 1:
                    color = Color.Red;
                    break;

                case 2:
                    color = Color.Yellow;
                    break;
                case 3:
                    color = Color.Blue;
                    break;
                case 4:
                    color = Color.Green;
                    break;
            }

            return color;
        }
        Color GetColorFromString(string colorString)
        {

            string[] colorArray = colorString.Split('[');
            Console.WriteLine("139 colorArray: " + colorArray);

            string[] pureColorArray = colorArray[1].Split(']');
            Console.WriteLine("142 pureColorArray: " + pureColorArray[0]);

            return Color.FromName(pureColorArray[0]);
        }




        public void checkWidth()
        {
            if (cardPositionX > this.Width - cardWidth - spacer)
            {
                cardPositionX = spacer;
                cardPositionY += cardHeight + 4;
            }
        }
        //Gets corresponding picture to the PictureBox
        public Image GetPicture(int value, Color color)
        {
            Image picture = Properties.Resources.Static;

            if (color == Color.Blue)
            {
                switch (value)
                {
                    case 0:
                        picture = Properties.Resources.Blue_0;
                        break;
                    case 1:
                        picture = Properties.Resources.Blue_1;
                        break;
                    case 2:
                        picture = Properties.Resources.Blue_2;
                        break;
                    case 3:
                        picture = Properties.Resources.Blue_3;
                        break;
                    case 4:
                        picture = Properties.Resources.Blue_4;
                        break;
                    case 5:
                        picture = Properties.Resources.Blue_5;
                        break;
                    case 6:
                        picture = Properties.Resources.Blue_6;
                        break;
                    case 7:
                        picture = Properties.Resources.Blue_7;
                        break;
                    case 8:
                        picture = Properties.Resources.Blue_8;
                        break;
                    case 9:
                        picture = Properties.Resources.Blue_9;
                        break;
                    case 10:
                        picture = Properties.Resources.Blue_Reverse;
                        break;
                    case 11:
                        picture = Properties.Resources.Blue_Stop;
                        break;
                    case 12:
                        picture = Properties.Resources.Blue_Take_Two;
                        break;

                }
            }
            else if (color == Color.Green)
            {
                switch (value)
                {
                    case 0:
                        picture = Properties.Resources.Green_0;
                        break;
                    case 1:
                        picture = Properties.Resources.Green_1;
                        break;
                    case 2:
                        picture = Properties.Resources.Green_2;
                        break;
                    case 3:
                        picture = Properties.Resources.Green_3;
                        break;
                    case 4:
                        picture = Properties.Resources.Green_4;
                        break;
                    case 5:
                        picture = Properties.Resources.Green_5;
                        break;
                    case 6:
                        picture = Properties.Resources.Green_6;
                        break;
                    case 7:
                        picture = Properties.Resources.Green_7;
                        break;
                    case 8:
                        picture = Properties.Resources.Green_8;
                        break;
                    case 9:
                        picture = Properties.Resources.Green_9;
                        break;
                    case 10:
                        picture = Properties.Resources.Green_Reverse;
                        break;
                    case 11:
                        picture = Properties.Resources.Green_Stop;
                        break;
                    case 12:
                        picture = Properties.Resources.Green_Take_Two;
                        break;

                }

            }
            else if (color == Color.Yellow)
            {
                switch (value)
                {
                    case 0:
                        picture = Properties.Resources.Yellow_0;
                        break;
                    case 1:
                        picture = Properties.Resources.Yellow_1;
                        break;
                    case 2:
                        picture = Properties.Resources.Yellow_2;
                        break;
                    case 3:
                        picture = Properties.Resources.Yellow_3;
                        break;
                    case 4:
                        picture = Properties.Resources.Yellow_4;
                        break;
                    case 5:
                        picture = Properties.Resources.Yellow_5;
                        break;
                    case 6:
                        picture = Properties.Resources.Yellow_6;
                        break;
                    case 7:
                        picture = Properties.Resources.Yellow_7;
                        break;
                    case 8:
                        picture = Properties.Resources.Yellow_8;
                        break;
                    case 9:
                        picture = Properties.Resources.Yellow_9;
                        break;
                    case 10:
                        picture = Properties.Resources.Yellow_Reverse;
                        break;
                    case 11:
                        picture = Properties.Resources.Yellow_Stop;
                        break;
                    case 12:
                        picture = Properties.Resources.Yellow_Take_Two;
                        break;

                }

            }
            else if (color == Color.Red)
            {
                switch (value)
                {
                    case 0:
                        picture = Properties.Resources.Red_0;
                        break;
                    case 1:
                        picture = Properties.Resources.Red_1;
                        break;
                    case 2:
                        picture = Properties.Resources.Red_2;
                        break;
                    case 3:
                        picture = Properties.Resources.Red_3;
                        break;
                    case 4:
                        picture = Properties.Resources.Red_4;
                        break;
                    case 5:
                        picture = Properties.Resources.Red_5;
                        break;
                    case 6:
                        picture = Properties.Resources.Red_6;
                        break;
                    case 7:
                        picture = Properties.Resources.Red_7;
                        break;
                    case 8:
                        picture = Properties.Resources.Red_8;
                        break;
                    case 9:
                        picture = Properties.Resources.Red_9;
                        break;
                    case 10:
                        picture = Properties.Resources.Red_Reverse;
                        break;
                    case 11:
                        picture = Properties.Resources.Red_Stop;
                        break;
                    case 12:
                        picture = Properties.Resources.Red_Take_Two;
                        break;

                }

            }
            else if (color == Color.Black)
            {
                switch (value)
                {
                    case 13:
                        picture = Properties.Resources.Color;
                        break;
                    case 14:
                        picture = Properties.Resources.Color_Take_Four;
                        break;
                }
            }

            return picture;
        }
        //Start program
        void StartProgram()
        {
            Console.WriteLine("168StartProgram");
            Console.WriteLine("169" + player.Username);

            if (player.Username != defaultUsername)
            {
                RenderNormalStartup();
            }
            else
            {
                RenderNewStartup();
            }
        }

        void ChooseColor(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                player.MarkedColor = colorDialog1.Color;

                Console.WriteLine("388 " + player.MarkedColor.ToString());


            }

            DeSelectCards();

        }


        private void DeSelectCards()
        {
            foreach (PlayingCard PlayingCard in playingCardList)
            {
                PlayingCard.GetPictureBox().BackColor = Color.Black;
                PlayingCard.GetPictureBox().Padding = new Padding(2);
                PlayingCard.GetPictureBox().Size = new Size(cardWidth, cardHeight);
                PlayingCard.GetPictureBox().SendToBack();
            }

            foreach (PlayingCard PlayingCard in selectedCardList)
            {
                PlayingCard.GetPictureBox().BackColor = player.MarkedColor;
                PlayingCard.GetPictureBox().Size = sizePbxPlayerCard;
                PlayingCard.GetPictureBox().Padding = new Padding(5);
            }

        }
        private void removeCard()
        {
            numberOfPlayeyCards = selectedCardList.Count();

            foreach (PlayingCard clickedCard in selectedCardList)
            {
                PictureBox picturecard = clickedCard.GetPictureBox();

                Console.WriteLine("424 picturecard.location: " + picturecard.Location.ToString());

                int id = (int)picturecard.Tag;

                foreach (PlayingCard a in playingCardList)
                {
                    Console.WriteLine("430 test");
                    Console.WriteLine("431 a.GetId(): " + a.GetId());
                    if (clickedCard == a)
                    {
                        tempCard = a;

                    }
                }

                Controls.Remove(picturecard);
                pictureboxList.Remove(picturecard);
                clickedCards.Items.Remove(picturecard);

                playingCardList.Remove(tempCard);
                lbxTestBox.Items.Remove(tempCard);

                Console.WriteLine("446 Card som tars bort: " + tempCard.ToString() + "\r\n");




                sortCards();



                foreach (Control a in Controls) { Console.WriteLine("455 " + a.ToString()); }

                playingCardList.ForEach(i => Console.WriteLine("458 Card som finns kvar" + "{0}\t", i));
                Console.WriteLine("Antal card som kvarstår i Listn: " + playingCardList.Count);

            }

            Console.WriteLine("462 tempcard: " + tempCard);
            selectedCardList.Clear();

        }

        bool selectedCardLength()
        {
            if (selectedCardList.Count > 0) { return true; }
            return false;
        }


        List<PlayingCard> sortList(List<PlayingCard> List)
        {
            for (int i = 0; i < List.Count - 1; i++)
            {
                for (int t = 0; t < List.Count - 1; t++)
                {
                    PlayingCard
                        a = List[t],
                        b = List[t + 1],
                        placeholder;

                    if (a.GetValue() > b.GetValue())
                    {
                        placeholder = a;
                        List[t] = b;
                        List[t + 1] = placeholder;
                    }


                }
            }

            return List;
        }
        void SaveAllSettings(object sender, EventArgs e)
        {
            SaveCurrentSettings();
        }
        void SaveCurrentSettings()
        {
            Console.WriteLine("504 Save Current Settings");

            string Settings = GetCurrentSettings();
            Console.WriteLine("507 Settings:    " + Settings);
            FileStream outStream = new FileStream(
                    filePathSettings,
                    FileMode.OpenOrCreate,
                    FileAccess.Write);

            StreamWriter writer = new StreamWriter(outStream);

            writer.Write(Settings);
            writer.Dispose();
        }
        void GetSettings(object sender, EventArgs e)
        {
            GetSavedSettings();
        }
        void GetSavedSettings()
        {
            Console.WriteLine("524 Get Saved Settings");

            try
            {
                FileStream inStream = new FileStream(
                    filePathSettings,
                    FileMode.Open,
                    FileAccess.Read);
                StreamReader reader = new StreamReader(inStream);

                string Settings = reader.ReadToEnd();
                reader.Dispose();
                Console.WriteLine("536 Settings: " + Settings);

                createUser(Settings);

            }
            catch
            {
                string baseSettings = defaultUsername + "|" + defaultColor.ToArgb().ToString() + "|0|0";
                createUser(baseSettings);
                Console.WriteLine("545 Settings: " + baseSettings);
            }

            lbxUser.Items.Add(player);
        }
        string GetCurrentSettings()
        {
            Console.WriteLine("552 Get Current Settings: " + player.ToString());
            string
                username = player.Username,
                color = player.MarkedColor.ToArgb().ToString(),
                wins = player.Wins.ToString(),
                losses = player.Losses.ToString();

            //player.GetColor() = Color.FromArgb(color);

            Console.WriteLine("561 " + player.MarkedColor.ToString());

            string Settings = username + "|" + color + "|" + wins + "|" + losses;
            
            Console.WriteLine("565 Settings:    " + Settings);


            return Settings;



        }

        void ClearScreen()
        {
            Controls.Clear();
            Console.WriteLine("577 Screen cleared");
            RenderUserLabel();
        }


        //Create methods

        string GetPlayingCardInfo(PlayingCard playedCard)
        {
            string
                type,
                color,
                player,
                value;

            type = playedCard.GetType();
            //color = playedCard.GetColor().ToArgb().ToString();
            color = playedCard.GetColor().ToString();
            player = playedCard.Player.ToString();
            value = playedCard.GetValue().ToString();

            return type + "|" + color + "|" + value + "|" + player + "|" + numberOfPlayeyCards.ToString();
        }

        //Geterate test objects for testermode 
        private void CreateTestObjects()
        {

            Button btnCreate = new Button();
            btnCreate.Location = new Point(515, 60);
            btnCreate.Size = sizeBtn;
            btnCreate.Text = "Create card";

            btnCreate.Click += btnSkapaCard_Click;
            Controls.Add(btnCreate);

            Button btnRemove = new Button();
            btnRemove.Location = new Point(515, 120);
            btnRemove.Size = sizeBtn;
            btnRemove.Text = "Remove card";

            btnRemove.Click += btnTaBort_Click;
            Controls.Add(btnRemove);

            Button btnChoose = new Button();
            btnChoose.Location = new Point(635, 60);
            btnChoose.Size = sizeBtn;
            btnChoose.Text = "Choose color";

            btnChoose.Click += new EventHandler(ChooseColor);
            Controls.Add(btnChoose);


            Button btnSaveSettings = new Button();
            btnSaveSettings.Location = new Point(735, 60);
            btnSaveSettings.Size = sizeBtn;
            btnSaveSettings.Text = "Save Settings";

            btnSaveSettings.Click += new EventHandler(SaveAllSettings);
            Controls.Add(btnSaveSettings);

            Button btnGetSettings = new Button();
            btnGetSettings.Location = new Point(735, 120);
            btnGetSettings.Size = sizeBtn;
            btnGetSettings.Text = "Get Settings";

            btnGetSettings.Click += new EventHandler(GetSettings);
            Controls.Add(btnGetSettings);


            lbxUser.Location = new Point(850, 60);
            lbxUser.Size = new Size(500, 100);
            Controls.Add(lbxUser);

            lbxTestBox.Location = new Point(0, 60);
            lbxTestBox.Size = new Size(500, 110);
            Controls.Add(lbxTestBox);


            clickedCards.Location = new Point(750, 500);
            clickedCards.Size = new Size(500, 110);
            Controls.Add(clickedCards);

        }

        void createUser(string Settings)
        {
            Console.WriteLine("664 Create User");
            string[] SettingsArray = Settings.Split('|');
            for (int i = 0; i < SettingsArray.Length; i++)
            {
                Console.WriteLine("668 SettingsArray: " + SettingsArray[i]);
            }
            //The try cath is only if the document does not exist or have no content inside of it
            try { player.Username = SettingsArray[0]; }
            catch { player.Username = defaultUsername; }

            try { player.MarkedColor = Color.FromArgb(int.Parse(SettingsArray[1])); }
            catch { player.MarkedColor = defaultColor; }

            try { player.Wins = int.Parse(SettingsArray[2]); }
            catch { player.Wins = 0; }

            try { player.Losses = int.Parse(SettingsArray[3]); }
            catch { player.Losses = 0; }

        }


        //Create a new card
        void CreateCard()
        {
            PlayingCard newPlayingCard = CreateNewPlayingCard();
            Console.WriteLine("690 New playing card: " + newPlayingCard);

            playingCardList.Add(newPlayingCard);
            lbxTestBox.Items.Add(newPlayingCard);

            sortCards();

        }

        PlayingCard CreateNewPlayingCard()
        {
            cardId++;
            //Generates an int to determan what color the card should be
            int colorValue = slump.Next(1, 5);

            Console.WriteLine("705 Colorvalue: " + colorValue.ToString());

            Color color = GiveColor(colorValue);



            //Generates a value for the card
            int cardValue = slump.Next(0, 15);

            if (cardValue >= 13) { color = Color.Black; }

            PictureBox pictureCard = CreatePicturecard(cardValue, cardId, color);

            //Create a card
            return CreatePlayingCard(color, cardValue, pictureCard);

        }

        PlayingCard CreatePlayingCard(Color color, int cardValue, PictureBox pictureCard)
        {


            Console.WriteLine("726 Cardvalue: " + cardValue.ToString());

            String picturePath = GetPicture(cardValue, color).ToString();


            //NummerCard
            if (cardValue <= 9)
            {
                NumberCard numberCard = CreateNumberCard(color, picturePath, player, pictureCard, cardValue, cardId);
                Console.WriteLine("735 nummerCard Created");
                return numberCard as PlayingCard;
            }

            //ReverseCard
            else if (cardValue == 10)
            {

                ReverseCard reverseCard = CreateReverseCard(color, picturePath, player, pictureCard, cardValue, cardId);

                Console.WriteLine("745 VändCard Created");
                return reverseCard as PlayingCard;
            }

            //StopCard
            else if (cardValue == 11)
            {

                StopCard stopCard = CreateStopCard(color, picturePath, player, pictureCard, cardValue, cardId);

                Console.WriteLine("755 stopCard Created");
                return stopCard as PlayingCard;
            }

            //TakeTwoCard
            else if (cardValue == 12)
            {
                TakeTwoCard takeTwoCard = CreateTakeTwoCard(color, picturePath, player, pictureCard, cardValue, cardId);

                Console.WriteLine("764 takeTwoCard Created");
                return takeTwoCard as PlayingCard;
            }

            //ColorCard
            else if (cardValue == 13)
            {

                ColorCard colorCard = CreateColorCard(color, picturePath, player, pictureCard, cardValue, cardId);

                Console.WriteLine("774 colorCard Created");
                return colorCard as PlayingCard;
            }

            //ColorCardTakeFour
            else if (cardValue == 14)
            {
                ColorTakeFourCard colorTakeFourCard = new ColorTakeFourCard(color, picturePath, player, pictureCard, cardValue, cardId);

                Console.WriteLine("783 ColorTakeFourCard Created");
                return colorTakeFourCard as PlayingCard;
            }
            else if (cardValue >= 15)
            {
                Console.WriteLine("788 Det skapade cardet ska ej finnas");
                CreateCard();
            }
            return new PlayingCard();

        }
        //Create methods

        NumberCard CreateNumberCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            NumberCard numberCard = new NumberCard(color, picturePath, player, pictureCard, value, id);

            return numberCard;
        }
        ReverseCard CreateReverseCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            ReverseCard reverseCard = new ReverseCard(color, picturePath, player, pictureCard, value, id);
            return reverseCard;
        }
        StopCard CreateStopCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            StopCard stopCard = new StopCard(color, picturePath, player, pictureCard, value, id);
            return stopCard;
        }
        TakeTwoCard CreateTakeTwoCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            TakeTwoCard takeTwoCard = new TakeTwoCard(color, picturePath, player, pictureCard, value, id);
            return takeTwoCard;
        }
        ColorCard CreateColorCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            ColorCard colorCard = new ColorCard(color, picturePath, player, pictureCard, value, id);
            return colorCard;
        }
        ColorTakeFourCard CreateColorTakeFourCard(
            Color color,
            string picturePath,
            Player player,
            PictureBox pictureCard,
            int value,
            int id)
        {
            ColorTakeFourCard colorTakeFourCard = new ColorTakeFourCard(color, picturePath, player, pictureCard, value, id);
            return colorTakeFourCard;

        }

        //Create a corresponding PictureBox 
        public PictureBox CreatePicturecard(int cardValue, int cardId, Color color)
        {

            var pictureLänk = GetPicture(cardValue, color);

            checkWidth();

            PictureBox picture = new PictureBox();
            picture.Image = pictureLänk;
            picture.Size = new Size(cardWidth, cardHeight);
            picture.Location = new Point(cardPositionX, cardPositionY);

            Console.WriteLine("878 x-position: " + cardPositionX.ToString());

            picture.Visible = true;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.BackColor = Color.Black;
            picture.Padding = new Padding(2);
            picture.Tag = cardId;

            picture.MouseEnter += new EventHandler(PlayingCard_MouseHover);
            picture.MouseHover += new EventHandler(PlayingCard_MouseHover);
            picture.MouseLeave += new EventHandler(PlayingCard_MouseLeave);
            picture.Click += new EventHandler(PlayingCard_Select);
            Controls.Add(picture);

            pictureboxList.Add(picture);


            return picture;
        }

        //Resize methods
        public void sortCards()
        {
            List<PlayingCard> tempList = new List<PlayingCard>();

            List<PlayingCard> blueTempList = new List<PlayingCard>();
            List<PlayingCard> redTempList = new List<PlayingCard>();
            List<PlayingCard> greenTempList = new List<PlayingCard>();
            List<PlayingCard> yellowTempList = new List<PlayingCard>();
            List<PlayingCard> blackTempList = new List<PlayingCard>();

            Console.WriteLine("909 playingCardList: " + playingCardList.Count.ToString());

            foreach (PlayingCard tempPlayingCard in playingCardList)
            {
                try
                {
                    Controls.Remove(tempPlayingCard.GetPictureBox());
                }
                catch { Console.WriteLine("917 No cards in list"); }

                Console.WriteLine("919" + tempPlayingCard.GetColor().ToString());

                if (tempPlayingCard.GetColor() == Color.Blue) { blueTempList.Add(tempPlayingCard); }
                else if (tempPlayingCard.GetColor() == Color.Red) { redTempList.Add(tempPlayingCard); }
                else if (tempPlayingCard.GetColor() == Color.Yellow) { yellowTempList.Add(tempPlayingCard); }
                else if (tempPlayingCard.GetColor() == Color.Green) { greenTempList.Add(tempPlayingCard); }
                else if (tempPlayingCard.GetColor() == Color.Black) { blackTempList.Add(tempPlayingCard); }
            }
            //Sort blue card list
            blueTempList = sortList(blueTempList);
            tempList.AddRange(blueTempList);

            //Sort red card list
            redTempList = sortList(redTempList);
            tempList.AddRange(redTempList);

            //Sort green card list
            greenTempList = sortList(greenTempList);
            tempList.AddRange(greenTempList);

            //Sort yellow card list
            yellowTempList = sortList(yellowTempList);
            tempList.AddRange(yellowTempList);

            //Sort black card list
            blackTempList = sortList(blackTempList);
            tempList.AddRange(blackTempList);

            Console.WriteLine("947 TempList: " + tempList);



            SetSpacer();

            cardPositionX = spacer;
            if (testMode)
            {
                cardPositionY = 200;
            }
            else
            {
                cardPositionY = (int)(this.Height - cardHeight * 3);
            }

            foreach (PlayingCard tempPlayingCard in tempList)
            {
                Console.WriteLine("965 Location: " + tempPlayingCard.GetColor().ToString());
                PictureBox tempPictureBox = tempPlayingCard.GetPictureBox();

                if (cardPositionX > this.Size.Width - cardWidth - spacer)
                {
                    cardPositionX = spacer;
                    cardPositionY += cardHeight;
                }
                tempPictureBox.Location = new Point(cardPositionX, cardPositionY);
                cardPositionX += cardWidth;

                Controls.Add(tempPictureBox);

            }
        }

        //Render methods

        void RenderUserLabel()
        {
            lblUsername.Location = new Point(40, 40);
            lblUsername.Text = player.Username + "| Wins: " + player.Wins + " Losses: " + player.Losses;
            Console.WriteLine("987 Username: " + player.Username);
            lblUsername.Size = new Size(400, 40);
            lblUsername.Font = new Font("Comic Sans", 14, FontStyle.Regular);


            Controls.Add(lblUsername);
        }
        void RenderNormalStartup()
        {
            RenderUserLabel();

            Button btnCreateNewGame = new Button();
            btnCreateNewGame.Location = new Point(this.Width / 2 - 350, this.Height / 2);
            btnCreateNewGame.Text = "Create new game";
            btnCreateNewGame.Size = new Size(300, 40);
            btnCreateNewGame.BackColor = Color.LightGray;
            btnCreateNewGame.Click += new EventHandler(CreateNewGame_Click);

            Controls.Add(btnCreateNewGame);

            Button btnJoinGame = new Button();
            btnJoinGame.Location = new Point(this.Width / 2, this.Height / 2);
            btnJoinGame.Text = "Join game";
            btnJoinGame.Size = new Size(300, 40);
            btnJoinGame.BackColor = Color.LightGray;
            btnJoinGame.Click += new EventHandler(JoinGame_Click);

            Controls.Add(btnJoinGame);


            Button btnChooseColor = new Button();
            btnChooseColor.Location = new Point(40, 80);
            btnChooseColor.Size = new Size(200,30);
            btnChooseColor.Text = "Choose selected color";

            btnChooseColor.Click += new EventHandler(ChooseColor);
            Controls.Add(btnChooseColor);
        }

        void RenderNewStartup()
        {

            tbxUsername.Size = new Size(400, 40);
            tbxUsername.Location = new Point(this.Width / 2 - (tbxUsername.Width / 2), this.Height / 2);
            tbxUsername.Text = player.Username;
            Controls.Add(tbxUsername);

            Button btnSetUsername = new Button();
            btnSetUsername.Location = new Point(this.Width / 2 - (tbxUsername.Width / 2), this.Height / 2 + 50);
            btnSetUsername.Size = new Size(400, 40);
            btnSetUsername.Text = "Create user";
            btnSetUsername.Click += btnSetUsername_Click;

            Controls.Add(btnSetUsername);


        }

        void RenderCreateNewGame()
        {
            RenderJoinedGame();
            Button btnStartGame = new Button();
            btnStartGame.Location = new Point((this.Width / 4 * 3), this.Height / 2);
            btnStartGame.Size = sizeBtn;
            btnStartGame.BackColor = Color.LightGray;
            btnStartGame.Text = "Start Game";
            btnStartGame.Click += new EventHandler(btnStartGame_Click);
            Controls.Add(btnStartGame);
        }

        void RenderConnectToGame()
        {
            TextBox tbxIpAdress = new TextBox();
            tbxIpAdress.Text = baseIpAdress;
            tbxIpAdress.TextAlign = HorizontalAlignment.Center;
            tbxIpAdress.BackColor = Color.LightGray;
            tbxIpAdress.Location = new Point(this.Width / 2 - 200, this.Height / 2);
            tbxIpAdress.Size = new Size(400, 60);
            Controls.Add(tbxIpAdress);

            Button btnConnect = new Button();
            btnConnect.Text = "Connect";
            btnConnect.Location = new Point(this.Width / 2 - tbxIpAdress.Width / 2, this.Height / 2 + tbxIpAdress.Height);
            btnConnect.Size = tbxIpAdress.Size;
            btnConnect.BackColor = Color.LightGray;
            btnConnect.Click += new EventHandler(BtnConnect_Click);
            Controls.Add(btnConnect);
        }
        void RenderJoinedGame()
        {
            lbxPlayers = new ListBox();
            lbxPlayers.Location = new Point(this.Width / 2 - 400, this.Height / 2);
            lbxPlayers.Size = new Size(400, 150);
            lbxPlayers.BackColor = Color.LightGray;
            Controls.Add(lbxPlayers);
        }
        
        void RenderGame()
        {
            //Render the 7 starting cards
            for (int i = 0; i < 7; i++)
            {
                CreateCard();
            }

            btnPlaceCard.Size = sizeBtn;
            btnPlaceCard.Location = new Point((int)(this.Width * 0.2), (int)(this.Height * 0.2));
            btnPlaceCard.Text = "Place card";
            btnPlaceCard.BackColor = Color.LightGray;
            btnPlaceCard.Click += new EventHandler(btnPlaceCards);
            Controls.Add(btnPlaceCard);

            btnDrawACard.Size = sizeBtn;
            btnDrawACard.Location = new Point((int)(this.Width * 0.2), (int)(this.Height * 0.2) + 60);
            btnDrawACard.Text = "Draw a card";
            btnDrawACard.BackColor = Color.LightGray;
            btnDrawACard.Click += new EventHandler(btnDrawCard_Click);
            Controls.Add(btnDrawACard);

            placedCard = CreateNewPlayingCard();
            pbxPlacedCard = placedCard.GetPictureBox();
            pbxPlacedCard.Location = new Point(this.Width / 2, this.Height / 2 - pbxPlacedCard.Height);
            pbxPlacedCard.MouseEnter -= new EventHandler(PlayingCard_MouseHover);
            pbxPlacedCard.MouseHover -= new EventHandler(PlayingCard_MouseHover);
            pbxPlacedCard.MouseLeave -= new EventHandler(PlayingCard_MouseLeave);
            pbxPlacedCard.Click -= new EventHandler(PlayingCard_Select);


        }
        void RenderColorSelectionForm()
        {
            Form3 colorSelectionForm = new Form3();
            DialogResult r = colorSelectionForm.ShowDialog();
            if (r == DialogResult.OK)
            {
                SelectedColor = colorSelectionForm._selectedColor;
            }
            else
            {
                RenderColorSelectionForm();
            }
            Console.WriteLine("1117 SelectedColor: " + SelectedColor.ToString());

        }

        //Server/Client operation

        private void SendMessage(string data)
        {
            Console.WriteLine("1125 Client sent Message: " + data);
            if (client.Connected == true)
            {
                byte[] utData = Encoding.Unicode.GetBytes(data);
                client.GetStream().Write(utData, 0, utData.Length);
                Console.WriteLine("1130 Message was sent to server");
            }
        }
        void MessageConnecting(string[] messageArray)
        {
            Console.WriteLine("1135 Message: Connecting");
            Player newPlayer = new Player();
            newPlayer.Username = messageArray[1];
            newPlayer.Wins = int.Parse(messageArray[3]);
            newPlayer.Losses = int.Parse(messageArray[4]);
            lbxPlayers.Items.Add(player);
        }
        //Server
        public void CreateNewGame()
        {
            Console.WriteLine("1145 Creating new game");
            RenderCreateNewGame();

            StartServer();

        }


        void StartServer()
        {
            Console.WriteLine("1154 Trying to start server");
            try
            {
                Console.WriteLine("1157 Starting server");
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                StartServerReseption();
                this.Text = "Uno Server";
                ConnectToServer("1162 server");
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }
        }
        async void StartServerReseption()
        {

            Console.WriteLine("1170 Start Server Reseption");
            try
            {
                TcpClient newClient = await listener.AcceptTcpClientAsync();
                //newClient.NoDelay = true;
                if (!UserMaximum())
                {
                    Console.WriteLine("1176 Check: " + FirstUser().ToString());
                    if (FirstUser())
                    {
                        Console.WriteLine("1178 ServerCliet");
                        serverClient = newClient;
                    }
                    Player connectedPlayer = new Player(newClient);

                    gameSession.AddPlayer(connectedPlayer);

                    Console.WriteLine("1186 Client added");
                    StartServerReading(newClient);
                }

                StartServerReseption();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }
        }
        async void StartServerReading(TcpClient c)
        {

            //c.NoDelay = true;

            Console.WriteLine("1196 Start Server Reading");
            byte[] buffert = new byte[1080];

            int n = 0;

            try
            {
                n = await c.GetStream().ReadAsync(buffert, 0, buffert.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            string message = Encoding.Unicode.GetString(buffert, 0, n);
            Console.WriteLine("1208 Server recived Message: " + message);

            string[] allMessageArray = message.Split('§');
            for (int i = 0; i < allMessageArray.Length; i++)
            {
                Console.WriteLine("1218 allMessageArray: " + allMessageArray[i]+ "\r\n" + "1220 messages forwarded: " + messagesFoewarded.ToString());
            }

            for (int i = 0; i < allMessageArray.Length; i++)
            {
                string[] messageArray = allMessageArray[i].Split('|');
                string
                    method = messageArray[0],
                    type = messageArray[(messageArray.Length - 1)];

                if (method == "Connecting")
                {
                    MessageConnecting(messageArray);
                    DistributeMessage(message);
                }
                else
                {
                    DistributeMessage(allMessageArray[i]);
                }

            }
            StartServerReading(c);
        }
        async void DistributeMessage(string message)
        {
            Console.WriteLine("1244 Message to distribute: " + message);

            string[] splitMessageArray = message.Split('§');

            Console.WriteLine("1248 SplitMessageArray length: " + splitMessageArray.Length.ToString());

            for (int i = 0; i < splitMessageArray.Length; i++)
            {
                string[] messageArray = splitMessageArray[i].Split('|');


                for (int j = 0; j < messageArray.Length; j++)
                {
                    Console.WriteLine("1255 messageArray: " + messageArray[j]);
                }

                string
                    method = messageArray[0],
                    type = messageArray[(messageArray.Length - 1)];

                Console.WriteLine("1235 Method server recived is: " + method);
                int length = messageArray.Length;


                //This is to remove enable/disable from the message if the card is a +2 or +4 card

                Console.WriteLine("1254 Player count: " + gameSession.GetPlayerCount().ToString());


                if (method == "PlaceCard")
                {

                    Console.WriteLine("1258 Distributing PlaceCard message");

                    Console.WriteLine("1260 PlaceCard message: " + message);

                    int
                    value = int.Parse(messageArray[3]),
                    numberOfCards = int.Parse(messageArray[5]);

                    Console.WriteLine("1290 Vaslue is: " + value.ToString());
                    Console.WriteLine("1291 Number of cards are: " + numberOfCards.ToString());

                    //If the card is a reverse card

                    if (value == 10)
                    {
                        Console.WriteLine("1290 Card was a reverse card");
                        for (int j = 0; j < numberOfCards; j++)
                        {
                            gameSession.ReverseOrder();
                        }
                    }

                    //If the card is a stop card11

                    if (value == 11)
                    {
                        Console.WriteLine("1301 Card was a stop card");
                        for (int j = 0; j < numberOfCards; j++)
                        {
                            gameSession.NextPlayer();
                        }
                    }


                    

                    //Skips to next player in line
                    gameSession.NextPlayer();
                    Console.WriteLine("1275 Player count: " + gameSession.GetPlayerCount().ToString());

                    foreach (Player player in gameSession.GetPlayerList())
                    {
                        Console.WriteLine("1279 Check if it is players turn");
                        TcpClient tempClient = player.Client;
                        //tempClient.NoDelay = true;

                        string newMessage = message;

                        if (tempClient.Connected == true)
                        {
                            Console.WriteLine("1284 Client was connected");
                            Console.WriteLine("1298 newMessage: " + newMessage);
                            if (tempClient == gameSession.GetTurnsPlayer().Client)
                            {
                                Console.WriteLine("1287 It was the clients turn");

                                Console.WriteLine("1289 Message: " + newMessage);
                                newMessage += "|enable§";
                                byte[] utData = Encoding.Unicode.GetBytes(newMessage);
                                await tempClient.GetStream().WriteAsync(utData, 0, utData.Length);
                                Console.WriteLine("1292 Status was enable");
                                Console.WriteLine("1293 Message forwarded by server: " + newMessage);
                            }
                            else
                            {
                                Console.WriteLine("1297 It was not the clients turn");
                                Console.WriteLine("1298 Message: " + newMessage);
                                newMessage += "|disable§";
                                byte[] utData = Encoding.Unicode.GetBytes(newMessage);
                                await tempClient.GetStream().WriteAsync(utData, 0, utData.Length);
                                Console.WriteLine("1301 Status was disable");
                                Console.WriteLine("1302 Message forwarded by server: " + newMessage);

                            }
                        }
                        else Console.WriteLine("1306 Client was not connected");

                    }
                    //If the card being placed is a color or color take four card
                    if (value == 12 || value == 14)
                    {
                        Console.WriteLine("1312 Card was a +two or +four card" + "\r\n" + "1313 Value: " + value);


                        Console.WriteLine("1311 Distributing ExtraCards message" + "\r\n" + "1316 message was: " + message);

                        string[] userArray = messageArray[4].Split(':');

                        Player tempPlayer = new Player();
                        tempPlayer.Username = userArray[1];
                        tempPlayer.Wins = int.Parse(userArray[3]);
                        tempPlayer.Losses = int.Parse(userArray[5]);
                        tempPlayer.MarkedColor = GetColorFromString(userArray[7]);

                        int extraCards = 0;
                        Console.WriteLine("1321 Check if recive extra card");

                        if (value == 12) extraCards = 2;
                        if (value == 14) extraCards = 4;
                        Console.WriteLine("1325 Value: " + value.ToString());

                        int numberOfExtraCards = extraCards * numberOfCards;

                        Console.WriteLine("1359 numberOfExtraCards " + numberOfExtraCards.ToString());

                        string newMessage = "";

                        Console.WriteLine("1326 Recive extra card");
                        for (int j = 0; j < (numberOfExtraCards); j++)
                        {
                            //the newMessage is so not to over right the original message when sending the card in the next prosses
                            newMessage += "ExtraCards§";
                        }

                        Console.WriteLine("1331 newMessage: " + newMessage);
                        byte[] utData = Encoding.Unicode.GetBytes(newMessage);
                        await gameSession.GetTurnsPlayer().Client.GetStream().WriteAsync(utData, 0, utData.Length);
                        Console.WriteLine("1333 Sent message: " + newMessage);
                        Console.WriteLine("1335 Message forwarded");
                        Console.WriteLine("1353 messages forwarded:" + messagesFoewarded.ToString());
                        Console.WriteLine("1373 " + numberOfCards.ToString() + " extra cards have been added");

                    }
                    Console.WriteLine("1398 messages forwarded: " + messagesFoewarded.ToString());
                }
                else if (method == "NewColor")
                {
                    //The Thread.Sleep is to make sure that the NewColor does not get sent to befor the server has sent out the placed card message
                    Thread.Sleep(200);

                    foreach (Player tempPlayer in gameSession.GetPlayerList())
                    {
                        //The "§" is so that the receving client can split the message due to it beeing merged with extra cards when getting transfered via TCP
                        message = message + "§";
                        Console.WriteLine("1289 Message: " + message);
                        byte[] utData = Encoding.Unicode.GetBytes(message);
                        await tempPlayer.Client.GetStream().WriteAsync(utData, 0, utData.Length);
                        Console.WriteLine("1293 Message forwarded by server: " + message);
                    }
                }
                else if (method == "ZeroCardsLeft")
                {
                    Player winningPlayer = gameSession.GetTurnsPlayer();

                    foreach (Player player in gameSession.GetPlayerList())
                    {
                        if (player == winningPlayer) message = "Win";
                        else message = "Loss";
                        //The "§" is so that the receving client can split the message due to it beeing merged with extra cards when getting transfered via TCP
                        message = message + "§";
                        Console.WriteLine("1289 Message: " + message);
                        byte[] utData = Encoding.Unicode.GetBytes(message);
                        await player.Client.GetStream().WriteAsync(utData, 0, utData.Length);
                        Console.WriteLine("1293 Message forwarded by server: " + message);
                    }
                }

                else
                {
                    Console.WriteLine("1354 Distributing else message: " + message);
                    foreach (Player player in gameSession.GetPlayerList())
                    {
                        TcpClient tempClient = player.Client;
                        //tempClient.NoDelay = true;

                        if (tempClient.Connected == true)
                        {
                            message = message + "§";
                            Console.WriteLine("1361 Distributing else message: " + message);
                            byte[] utData = Encoding.Unicode.GetBytes(message);
                            await tempClient.GetStream().WriteAsync(utData, 0, utData.Length);
                            Console.WriteLine("1364 Message forwarded");
                        }
                    }
                }

            }
            Console.WriteLine("1447 messages forwarded:" + messagesFoewarded.ToString());
            messagesFoewarded++;
        }


        bool UserMaximum()
        {
            bool temp = true;
            if (gameSession.GetPlayerCount() < 4) { temp = false; }
            Console.WriteLine("1379 UserMax: " + temp.ToString());
            return temp;
        }
        bool FirstUser()
        {
            bool temp = false;
            Console.WriteLine("1385 Player Count: " + gameSession.GetPlayerCount().ToString());
            if (gameSession.GetPlayerCount() == 0)
            {
                temp = true;
            }
            Console.WriteLine("1390 First player: " + temp.ToString());
            return temp;
        }
        //Client

        void JoinGame()
        {
            RenderConnectToGame();
        }
        void ConnectToServer(string type)
        {
            Console.WriteLine("1401 Trying connecting to server");
            try
            {
                IPAddress adress = IPAddress.Parse(baseIpAdress);
                client = new TcpClient();
               // client.NoDelay = true;
                client.Connect(adress, port);
                string message = "Connecting" + "|" + GetCurrentSettings() + "|" + type;
                //Gör en SendClientMessage och en SenderServerMessage
                SendMessage(message);
                Console.WriteLine("1411 Message was sent");
                StartClientReading();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }
        }
        async void StartClientReading()
        {
            //client.NoDelay = true;
            Console.WriteLine("1418 Start Client Reading");
            byte[] buffert = new byte[1024];

            int n = 0;

            try
            {
                n = await client.GetStream().ReadAsync(buffert, 0, buffert.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            string message = Encoding.Unicode.GetString(buffert, 0, n);
            Console.WriteLine("1430 " + message);

            string[] allMessageArray = message.Split('§');
            for (int i = 0; i < allMessageArray.Length; i++)
            {
                Console.WriteLine("SplitClientRecivedMessage: " + allMessageArray[i]);
            }

            for (int i = 0; i < allMessageArray.Length; i++)
            {

                string[] messageArray = allMessageArray[i].Split('|');

                for (int j = 0; j < messageArray.Length; j++)
                {
                    Console.WriteLine("1434 Recived messageArray: " + messageArray[j]);
                }

                int
                    length = messageArray.Length;
                string
                    method = messageArray[0],
                    messageEnd = messageArray[length - 1];

                Console.WriteLine("1440 Method: " + method + "\r\n" + "1441 MessageEnd: " + messageEnd);

                if (method == "Win" || method == "Loss")
                {
                    try
                    {
                        if (client == serverClient)
                        {
                            serverClient.Close();
                        }
                    }
                    catch { Console.WriteLine("Client was not the server"); }

                    if (method == "Win")
                    {
                        MessageBox.Show("You have won the game!!");


                        player.Wins += 1;

                    }
                    else if (method == "Loss")
                    {
                        MessageBox.Show("You have lost the game");


                        player.Losses += 1;

                    }
                    ClearScreen();
                    RenderNormalStartup();
                    playingCardList.Clear();
                    selectedCardList.Clear();
                    SaveCurrentSettings();
                }

                else if (method == "PlaceCard")
                {
                    //If the player has selected cards while it was not the players turn, this will clear all the cards
                    selectedCardList.Clear();
                    DeSelectCards();


                    int
                        numberOfCards = int.Parse(messageArray[5]),
                        value = int.Parse(messageArray[3]);
                    //Check if it is the clients turn to place a card
                    bool status;
                    if (messageEnd == "enable") status = true;
                    else status = false;

                    Console.WriteLine("2047 Status was: " + status.ToString());

                    btnPlaceCard.Enabled = status;
                    btnDrawACard.Enabled = status;


                    Color color = GetColorFromString(messageArray[2]);



                    Console.WriteLine("1459 Color: " + color);
                    Console.WriteLine("1460 Number of cards: " + numberOfCards.ToString());




                    placedCard = CreatePlayingCard(color, value, placedCard.GetPictureBox());
                    Console.WriteLine("1588 New placedCard is: " + placedCard.ToString());

                    pbxPlacedCard.Image = GetPicture(value, color);


                    pbxPlacedCard.Size = new Size(Convert.ToInt32((cardWidth + border) * 1.25), Convert.ToInt32((cardHeight + border) * 1.25));


                    pbxPlacedCard.Padding = new Padding(2);
                    pbxPlacedCard.BackColor = Color.Black;

                }
                else if (method == "ExtraCards")
                {
                    Console.WriteLine("1479 Method was " + method);
                    CreateCard();
                }
                else if (method == "NewColor")
                {
                    Console.WriteLine("1491 NewColorMessage: " + message);
                    placedCard.GetPictureBox().BackColor = GetColorFromString(messageArray[1]);
                    placedCard.GetPictureBox().Padding = new Padding(5);
                }
                else if (method == "Connecting")
                {
                    string type = messageEnd;

                    Console.WriteLine("1498 Type: " + type);
                    if (type == "server")
                    {
                        Console.WriteLine("1501 Type was server");
                        RenderCreateNewGame();
                    }
                    else
                    {
                        Console.WriteLine("1506 Type was not server");
                        RenderJoinedGame();
                    }
                    Console.WriteLine("1509 Message : " + message);
                    lbxPlayers.Items.Add(messageArray[1]);
                }
                else if (method == "Leave")
                {

                }
                else if (method == "StartGame")
                {
                    ClearScreen();
                    RenderGame();
                }
            }

            StartClientReading();
        }

        void PlaceCard()
        {
            if (selectedCardLength())
            {
                try
                {
                    Console.WriteLine("1531 Trying to place card");
                    removeCard();
                    string message = GetPlayingCardInfo(tempCard);
                    Console.WriteLine("1535 PlaceCard message: " + message);

                    if (playingCardList.Count == 0)
                    {
                        SendMessage("ZeroCardsLeft§");
                    }

                    else if (tempCard is ColorCard || tempCard is ColorTakeFourCard)
                    {
                        RenderColorSelectionForm();

                        string newMessage = "PlaceCard|" + message + "§NewColor|" + SelectedColor.ToString() + "§";
                        Console.WriteLine("2099 new message: " + newMessage);
                        SendMessage(newMessage);
                    }
                    else if (tempCard is TakeTwoCard)
                    {
                        string newMessage = "PlaceCard|" + message + "§";

                        Console.WriteLine("2134 new message: " + newMessage);
                        SendMessage(newMessage);

                    }
                    else
                    {

                        SendMessage("PlaceCard|" + message + "§");
                    }

                }
                catch (Exception error) { MessageBox.Show(error.Message, Text); return; }
            }
            else
            {
                MessageBox.Show("You did not select one or more cards", "Selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Custom evnthandelers 

        private void btnSkapaCard_Click(object sender, EventArgs e)
        {
            CreateCard();
        }
        void btnDrawCard_Click(object sender, EventArgs e)
        {
            bool containsColor = false;
            //Checks all cards to check if the player has a card of the same color
            foreach (PlayingCard card in playingCardList)
            {
                //Continues to check all cards if it has not found a card of the same color
                if (!containsColor)
                {
                    if (card.GetColor() == placedCard.GetColor() || card.GetColor() == placedCard.GetPictureBox().BackColor || card.GetValue() == placedCard.GetValue() || card.GetColor() == Color.Black)
                    {
                        containsColor = true;
                    }
                }
            }

            if (!containsColor) { CreateCard(); }
            else { MessageBox.Show("You alerady have a card of the same color or type as the one on the table", "Draw card error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnTaBort_Click(object sender, EventArgs e)
        {
            removeCard();
            sortCards();
        }
        void btnStartGame_Click(object sender, EventArgs e)
        {
            ClearScreen();
            DistributeMessage("StartGame");
            PlayingCard firstCard = CreateNewPlayingCard();
            string firstCardInfo = GetPlayingCardInfo(firstCard);
            DistributeMessage("PlaceCard|" + firstCardInfo);

            if (firstCard is ColorCard || firstCard is ColorTakeFourCard)
            {
                int colorValue = slump.Next(1, 5);
                Color color = GiveColor(colorValue);
                DistributeMessage("NewColor|" + color.ToString());
            }
        }
        void btnPlaceCards(object sender, EventArgs e)
        {
            PlaceCard();

        }
        private void ResizeSortCards(object sender, EventArgs e)
        {
            sortCards();
        }

        private void PlayingCard_MouseHover(object sender, EventArgs e)
        {
            PictureBox PlayingCard = (PictureBox)sender;
            PlayingCard.BackColor = player.MarkedColor;
            PlayingCard.Padding = new Padding(5);
            PlayingCard.Size = new Size(cardWidth + border, cardHeight + border);
            PlayingCard.BringToFront();

        }
        private void PlayingCard_MouseLeave(object sender, EventArgs e)
        {
            DeSelectCards();

        }

        private void PlayingCard_Select(object sender, EventArgs e)
        {
            PictureBox tempPbx = (PictureBox)sender;


            foreach (PlayingCard card in playingCardList)
            {
                Console.WriteLine("1652 ClickedCardList: " + selectedCardList.Count.ToString());

                //SelectedCardLength checks if there are cards that are selected
                if (selectedCardLength())
                {
                    PlayingCard firstCardInList = selectedCardList[0] as PlayingCard;
                    //Checks if the card is the same color or the same value as the one placed, or is the same value as the first selected card
                    if (SelectedCardEvaluation(card) || card.GetValue() == firstCardInList.GetValue())
                    {
                        if (card.GetValue() == firstCardInList.GetValue())
                        {
                            if (card.GetPictureBox() == tempPbx)
                            {
                                selectedCardList.Add(card);
                                tempPbx.Click -= new EventHandler(PlayingCard_Select);
                                tempPbx.Click += new EventHandler(PlayingCard_Deselect);
                                clickedCards.Items.Add(card);
                            }
                        }
                    }
                }
                //The else function is to make shure that you can select a card even if there are no cards selected
                else
                {
                    if (SelectedCardEvaluation(card))
                    {
                        if (card.GetPictureBox() == tempPbx)
                        {
                            selectedCardList.Add(card);
                            tempPbx.Click -= new EventHandler(PlayingCard_Select);
                            tempPbx.Click += new EventHandler(PlayingCard_Deselect);
                            clickedCards.Items.Add(card);
                        }
                    }
                }
            }

            DeSelectCards();
        }

        bool SelectedCardEvaluation(PlayingCard card)
        {
            if (card.GetColor() == placedCard.GetColor() || card.GetColor() == Color.Black || card.GetValue() == placedCard.GetValue() || card.GetColor() == placedCard.GetPictureBox().BackColor) { return true; }
            else { return false; }
        }

        private void PlayingCard_Deselect(object sender, EventArgs e)
        {

            PictureBox pictureCard = sender as PictureBox;

            for (int i = 0; i < selectedCardList.Count; i++)
            {
                if (pictureCard == selectedCardList[i].GetPictureBox())
                {
                    selectedCardList.RemoveAt(i);
                    clickedCards.Items.Remove(pictureCard);
                }
            }

            pictureCard.BackColor = Color.Black;
            pictureCard.Padding = new Padding(2);
            pictureCard.Size = new Size(cardWidth, cardHeight);
            pictureCard.SendToBack();


            selectedCardList.Remove(sender as PlayingCard);

            pictureCard.Click -= new EventHandler(PlayingCard_Select);
            pictureCard.Click += new EventHandler(PlayingCard_Select);
        }

        private void CreateNewGame_Click(object sender, EventArgs e)
        {
            ClearScreen();
            CreateNewGame();
        }
        private void JoinGame_Click(object sender, EventArgs e)
        {
            ClearScreen();
            JoinGame();
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            ClearScreen();
            ConnectToServer("client");
        }
        void btnSetUsername_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1741 Set username");
            string userString = tbxUsername.Text;
            createUser(userString);
            ClearScreen();
            SaveCurrentSettings();
            RenderNormalStartup();
        }

    }

}
