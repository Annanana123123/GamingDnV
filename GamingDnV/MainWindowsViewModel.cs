using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamingDnV.Views;
using GamingDnV.ViewModels;
using GamingDnV.Services;
using GamingDnV.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Media;
using GamingDnV.Enums;

namespace GamingDnV
{
    public class MainWindowsViewModel : ViewModelBase
    {
        #region Конструктор

        public MainWindowsViewModel()
        {
            PreVeiwWindow = new PreViewModel();
            ShowWindow = new RelayCommand(() => ShowWindowVS());
            StartSql = new RelayCommand(() => RunSql());
            ViewImag = new RelayCommand(() => ViewImagIn());
            IntoBattleR = new RelayCommand(() => NPCInBattle());
            IntoBattleL = new RelayCommand(() => HeroInBattle());
            ClianTextBox = new RelayCommand(() => ClianTextBoxVeiw());
            B1 = new RelayCommand(() => SummaCh(1,0));
            B2 = new RelayCommand(() => SummaCh(2,0));
            B3 = new RelayCommand(() => SummaCh(3,0));
            B4 = new RelayCommand(() => SummaCh(4,0));
            B5 = new RelayCommand(() => SummaCh(5,0));
            B6 = new RelayCommand(() => SummaCh(6,0));
            B7 = new RelayCommand(() => SummaCh(7,0));
            B8 = new RelayCommand(() => SummaCh(8,0));
            B9 = new RelayCommand(() => SummaCh(9,0));
            B10 = new RelayCommand(() => SummaCh(10,0));
            B11 = new RelayCommand(() => SummaCh(11,0));
            B12 = new RelayCommand(() => SummaCh(12,0));
            B13 = new RelayCommand(() => SummaCh(13,0));
            B14 = new RelayCommand(() => SummaCh(14,0));
            B15 = new RelayCommand(() => SummaCh(15,0));
            B16 = new RelayCommand(() => SummaCh(16,0));
            B17 = new RelayCommand(() => SummaCh(17,0));
            B18 = new RelayCommand(() => SummaCh(18,0));
            B19 = new RelayCommand(() => SummaCh(19,0));
            B20 = new RelayCommand(() => SummaCh(20,0));
            D4 = new RelayCommand(() => RandomIze(4));
            D6 = new RelayCommand(() => RandomIze(6));
            D8 = new RelayCommand(() => RandomIze(8));
            D10 = new RelayCommand(() => RandomIze(10));
            D12 = new RelayCommand(() => RandomIze(12));
            D20 = new RelayCommand(() => RandomIze(20));
            D100 = new RelayCommand(() => RandomIze(100));
            Power = new RelayCommand(() => SummaCh(1, 1));
            Dexterity = new RelayCommand(() => SummaCh(2, 1));
            Endurance = new RelayCommand(() => SummaCh(3, 1));
            Wisdom = new RelayCommand(() => SummaCh(4, 1));
            Intelligence = new RelayCommand(() => SummaCh(5, 1));
            Charisma = new RelayCommand(() => SummaCh(6, 1));
            ResultDefence = new RelayCommand(() => SummaCh(0, 2));
            ResultHealth = new RelayCommand(() => SummaCh(0, 3));
            NPCStep = new RelayCommand(() => EditStep());
            ActionBtn = new RelayCommand(() => CalcAction());
            CleanActionBtn = new RelayCommand(() => CleanAct());
            ViewInfo = new RelayCommand(() => VisibleInfo(CurrEvent));
            CloseInfoBtn = new RelayCommand(() => NoVisibleInfo());
            ImagBtn1 = new RelayCommand(() => ShowImag(0));
            ImagBtn2 = new RelayCommand(() => ShowImag(1));
            ImagBtn3 = new RelayCommand(() => ShowImag(2));
            ImagBtn4 = new RelayCommand(() => ShowImag(3));
            ImagBtn5 = new RelayCommand(() => ShowImag(4));
            ImagBtn6 = new RelayCommand(() => ShowImag(5));
            BackSound = new RelayCommand(() => PlayAndStop(TypeSound.Back, CurrEvent));
            AtacSound = new RelayCommand(() => PlayAndStop(TypeSound.Atac, CurrEvent));
            TrackSound = new RelayCommand(() => PlayAndStop(TypeSound.Track, CurrEvent));
            ComboOk = new RelayCommand(() => LoadHystory(SelectItem.Id));
            CloseVersus = new RelayCommand(() => VisibilityVersus = Visibility.Hidden);
            BtnL = new RelayCommand(() => CurrentV(1));
            BtnR = new RelayCommand(() => CurrentV(2));
            VisibilityInfo = Visibility.Hidden;
            VisibilityLoad = Visibility.Visible;
            VisibilityVersus = Visibility.Visible;
            VR = Visibility.Hidden;
            VL = Visibility.Visible;
            TextButton = "Ход Героя";
            ViewImagText = "Показать";
            ViewBattle = "Показать";
            BackSEn = false;
            AtacSEn = false;
            TrackSEn = false;
    }

        #endregion

        #region Свойства

        public bool versus = true;

        public PreViewModel PreVeiwWindow { get; set; }

        ObservableCollection<UsersModel> Users = new ObservableCollection<UsersModel>();
        ObservableCollection<NPCModel> NPC = new ObservableCollection<NPCModel>();

        
        private ComboBoxModel _selectItem;
        public ComboBoxModel SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;

                RaisePropertyChanged(nameof(SelectItem));
            }
        }

        private List<ComboBoxModel> _comboBoxItem;
        public List<ComboBoxModel> ComboBoxItem
        {
            get { return _comboBoxItem; }
            set
            {
                _comboBoxItem = value;

                RaisePropertyChanged(nameof(ComboBoxItem));
            }
        }

        private string _textView;
        public string TextView
        {
            get { return _textView; }
            set
            {
                _textView = value;

                RaisePropertyChanged(nameof(TextView));
            }
        }

        private string _health;
        public string Health
        {
            get { return _health; }
            set
            {
                _health = value;

                RaisePropertyChanged(nameof(Health));
            }
        }

        private string _hP;
        public string HP
        {
            get { return _hP; }
            set
            {
                _hP = value;

                RaisePropertyChanged(nameof(HP));
            }
        }

        private bool _backSEn;
        public bool BackSEn
        {
            get { return _backSEn; }
            set
            {
                _backSEn = value;
                RaisePropertyChanged(nameof(BackSEn));
            }
        }

        private bool _atacSEn;
        public bool AtacSEn
        {
            get { return _atacSEn; }
            set
            {
                _atacSEn = value;
                RaisePropertyChanged(nameof(AtacSEn));
            }
        }

        private bool _tarckSEn;
        public bool TrackSEn
        {
            get { return _tarckSEn; }
            set
            {
                _tarckSEn = value;
                RaisePropertyChanged(nameof(TrackSEn));
            }
        }

        private Visibility _vR;
        public Visibility VR
        {
            get { return _vR; }
            set
            {
                _vR = value;
                RaisePropertyChanged(nameof(VR));
            }
        }

        private Visibility _vL;
        public Visibility VL
        {
            get { return _vL; }
            set
            {
                _vL = value;
                RaisePropertyChanged(nameof(VL));
            }
        }

        private Visibility _visibilityVersus;
        public Visibility VisibilityVersus
        {
            get { return _visibilityVersus; }
            set
            {
                _visibilityVersus = value;
                RaisePropertyChanged(nameof(VisibilityVersus));
            }
        }

        private Visibility _visibilityLoad;
        public Visibility VisibilityLoad
        {
            get { return _visibilityLoad; }
            set
            {
                _visibilityLoad = value;
                RaisePropertyChanged(nameof(VisibilityLoad));
            }
        }

        private Visibility _visibilityInfo;
        public Visibility VisibilityInfo
        {
            get { return _visibilityInfo; }
            set
            {
                _visibilityInfo = value;
                RaisePropertyChanged(nameof(VisibilityInfo));
            }
        }

        private string _sqlText;
        public string SqlText
        {
            get { return _sqlText; }
            set
            {
                _sqlText = value;

                RaisePropertyChanged(nameof(SqlText));
            }
        }
        private string _textNPC;
        public string TextNPC
        {
            get { return _textNPC; }
            set
            {
                _textNPC = value;

                RaisePropertyChanged(nameof(TextNPC));
            }
        }
        private string _historyText;
        public string HistoryText
        {
            get { return _historyText; }
            set
            {
                _historyText = value;

                RaisePropertyChanged(nameof(HistoryText));
            }
        }
        private string _itemText;
        public string ItemText
        {
            get { return _itemText; }
            set
            {
                _itemText = value;

                RaisePropertyChanged(nameof(ItemText));
            }
        }

        private ObservableCollection<RoomsModel> _rooms;
        public ObservableCollection<RoomsModel> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;

                RaisePropertyChanged(nameof(Rooms));
            }
        }

        private ObservableCollection<EventsModel> _events;
        public ObservableCollection<EventsModel> Events
        {
            get { return _events; }
            set
            {
                _events = value;

                RaisePropertyChanged(nameof(Events));
            }
        }

        private ObservableCollection<ActionModel> _versusTable;
        public ObservableCollection<ActionModel> VersusTable
        {
            get { return _versusTable; }
            set
            {
                _versusTable = value;

                RaisePropertyChanged(nameof(VersusTable));
            }
        }

        private ObservableCollection<NPCModel> _npcTable;
        public ObservableCollection<NPCModel> NPCTable
        {
            get { return _npcTable; }
            set
            {
                _npcTable = value;

                RaisePropertyChanged(nameof(NPCTable));
            }
        }

        private ObservableCollection<UsersModel> _herosTable;
        public ObservableCollection<UsersModel> HerosTable
        {
            get { return _herosTable; }
            set
            {
                _herosTable = value;

                RaisePropertyChanged(nameof(HerosTable));
            }
        }

        private string _imageInfo;
        public string ImageInfo
        {
            get { return _imageInfo; }
            set
            {
                _imageInfo = value;

                RaisePropertyChanged(nameof(ImageInfo));
            }
        }

        private string _userIcon;
        public string UserIcon
        {
            get { return _userIcon; }
            set
            {
                _userIcon = value;

                RaisePropertyChanged(nameof(UserIcon));
            }
        }

        private string _tollTipNPS;
        public string TollTipNPS
        {
            get { return _tollTipNPS; }
            set
            {
                _tollTipNPS = value;
                RaisePropertyChanged(nameof(TollTipNPS));
            }
        }

        private string _viewBattle;
        public string ViewBattle
        {
            get { return _viewBattle; }
            set
            {
                _viewBattle = value;

                RaisePropertyChanged(nameof(ViewBattle));
            }
        }
        
        private string _userInfo;
        public string UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;

                RaisePropertyChanged(nameof(UserInfo));
            }
        }

        private string _imag1;
        public string Imag1
        {
            get { return _imag1; }
            set
            {
                _imag1 = value;

                RaisePropertyChanged(nameof(Imag1));
            }
        }

        private string _imag2;
        public string Imag2
        {
            get { return _imag2; }
            set
            {
                _imag2 = value;

                RaisePropertyChanged(nameof(Imag2));
            }
        }

        private string _imag3;
        public string Imag3
        {
            get { return _imag3; }
            set
            {
                _imag3 = value;

                RaisePropertyChanged(nameof(Imag3));
            }
        }

        private string _imag4;
        public string Imag4
        {
            get { return _imag4; }
            set
            {
                _imag4 = value;

                RaisePropertyChanged(nameof(Imag4));
            }
        }

        private string _imag5;
        public string Imag5
        {
            get { return _imag5; }
            set
            {
                _imag5 = value;

                RaisePropertyChanged(nameof(Imag5));
            }
        }

        private string _imag6;
        public string Imag6
        {
            get { return _imag6; }
            set
            {
                _imag6 = value;

                RaisePropertyChanged(nameof(Imag6));
            }
        }

        private string _textButton;
        public string TextButton
        {
            get { return _textButton; }
            set
            {
                _textButton = value;

                RaisePropertyChanged(nameof(TextButton));
            }
        }

        private string _viewImagText;
        public string ViewImagText
        {
            get { return _viewImagText; }
            set
            {
                _viewImagText = value;

                RaisePropertyChanged(nameof(ViewImagText));
            }
        }

        private string _rnd;
        public string Rnd
        {
            get { return _rnd; }
            set
            {
                _rnd = value;

                RaisePropertyChanged(nameof(Rnd));
            }
        }

        private ActionModel _currentVersus;
        public ActionModel CurrentVersus
        {
            get { return _currentVersus; }
            set
            {
                _currentVersus = value;
            }
        }

        private EventsModel _currentEvent;
        public EventsModel CurrentEvent
        {
            get { return _currentEvent; }
            set
            {
                _currentEvent = value;
                CurrentE();
            }
        }

        private RoomsModel _currentRoom;
        public RoomsModel CurrentRoom
        {
            get { return _currentRoom; }
            set
            {
                _currentRoom = value;
                CurrentR();
            }
        }

        private NPCModel _currentNPC;
        public NPCModel CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                ViewNPC();
            }
        }

        private UsersModel _currentUser;
        public UsersModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                ViewUser();
            }
        }

        private bool _enBtn1;
        public bool EnBtn1
        {
            get { return _enBtn1; }
            set
            {
                _enBtn1 = value;
                RaisePropertyChanged(nameof(EnBtn1));
            }
        }

        private bool _enBtn2;
        public bool EnBtn2
        {
            get { return _enBtn2; }
            set
            {
                _enBtn2 = value;
                RaisePropertyChanged(nameof(EnBtn2));
            }
        }

        private bool _enBtn3;
        public bool EnBtn3
        {
            get { return _enBtn3; }
            set
            {
                _enBtn3 = value;
                RaisePropertyChanged(nameof(EnBtn3));
            }
        }

        private bool _enBtn4;
        public bool EnBtn4
        {
            get { return _enBtn4; }
            set
            {
                _enBtn4 = value;
                RaisePropertyChanged(nameof(EnBtn4));
            }
        }

        private bool _enBtn5;
        public bool EnBtn5
        {
            get { return _enBtn5; }
            set
            {
                _enBtn5 = value;
                RaisePropertyChanged(nameof(EnBtn5));
            }
        }

        private bool _enBtn6;
        public bool EnBtn6
        {
            get { return _enBtn6; }
            set
            {
                _enBtn6 = value;
                RaisePropertyChanged(nameof(EnBtn6));
            }
        }

        NPCModel TempNPC = new NPCModel();
        int summa = 0;
        bool NpcStep = false;
        bool ShowWin = false;
        bool VisibilityWin = false;
        bool VisibilityImag = false;
        bool SoundPlay = false;

        string PathHero = "";
        string PathNPC = "";
        string PathImag = "";
        string PathInterface = "";
        string PathMedia = "";

        TypeEven CurrEvent { get; set; }

        string[] arr { get; set; }
        int temp = -1;

        ObservableCollection<EventsModel> ListEvent = new ObservableCollection<EventsModel>();
        ObservableCollection<NPCModel> ListNpc = new ObservableCollection<NPCModel>();
        ObservableCollection<ActionModel> Versus = new ObservableCollection<ActionModel>();

        #endregion

        #region Методы

        public void LoadHystory(int n)
        {
            if (SelectItem is null)
            {
                MessageBox.Show("Выбери историю");
            }
            else
            {
                VisibilityLoad = Visibility.Hidden;
                PathHero = AppDomain.CurrentDomain.BaseDirectory + "Media\\Heros\\";
                PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\Histotys_" + n + "\\NPC\\";
                PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\Histotys_" + n + "\\Images\\";
                PathInterface = AppDomain.CurrentDomain.BaseDirectory + "Media\\Interface\\";
                PathMedia = AppDomain.CurrentDomain.BaseDirectory + "Media\\Histotys_" + n + "\\Sounds\\";
                Health = PathInterface + "Hard.png";
                Rooms = ReadBD.ReadRoomsInDb("SELECT Id, Name, TextRoom, Images, Sounts FROM tRooms WHERE  HistoryId = " + n + " ORDER BY tRooms.Order;");
                ListEvent = ReadBD.ReadEventInDb("SELECT Id, Name, TextEvent, Images, Sounds, Order, RoomId FROM tEvents WHERE RoomId in (" + WhereIn() + ");");
                ListNpc = ReadBD.ReadNPCInDb("SELECT Id, Name, Notee, Defence, Health, Power, Dexterity, Endurance, Wisdom, Intelligence, Charisma, Species, Class, Item, Abilities, Ulta, History, Imag, AtacSound, RoomId FROM tNpc WHERE tNpc.RoomId in (" + WhereIn() + ");");
                HerosTable = ReadBD.ReadUsersInDb("SELECT Id, HeroName, Notee, Defence, Health, Power, Dexterity, Endurance, Wisdom, Intelligence ,Charisma , Species, Class, Item, Abilities, Ulta, History, Imag, Arms, Equip, Description, Passiv FROM tHeros WHERE HistoryId =" + n);
            }
        }

        public string WhereIn()
        {
            string str = "";
            foreach (var d in Rooms)
            {
                str += d.Id + ", ";
            }
            return str;
        }

        public void PlayAndStop(TypeSound type, TypeEven eventT)
        {
            Media media = new Media();
            if (SoundPlay)
            {
                media.Stop();
                SoundPlay = false;
            }
            else
            {
                string Sound = PathMedia;
                switch (eventT)
                {
                    case TypeEven.Room:
                        Sound += CurrentRoom.Sounds;
                        break;
                    case TypeEven.Event:
                        Sound += CurrentEvent.Sounds;
                        break;
                    case TypeEven.NPC:
                        switch (type)
                        {
                            case TypeSound.Atac:
                                Sound += CurrentNPC.AtacSound;
                                break;
                        }
                        break;
                }
                media.Open(Sound);
                media.Play();
                SoundPlay = true;
            }
        }

        public void ShowImag(int i)
        {
            if (temp != i)
            {
                PreVeiwWindow.ShowImag(arr[i]);
                temp = i;
            }
            else
            {
                PreVeiwWindow.NoShowImag();
                temp = -1;
            }
            //PreVeiwWindow.ShowImag(arr[i]);
            //PreVeiwWindow.NoShowImag();
        }

        public void VisibleInfo(TypeEven eventT)
        {
            ClearImages();
            arr = null;
            string s = "";
            switch (eventT)
            {
                case TypeEven.Event:
                    s = CurrentEvent.Images;
                    HistoryText = CurrentEvent.TextEvent;
                    break;
                case TypeEven.NPC:
                    s = CurrentNPC.Imag;
                    HistoryText = CurrentNPC.History;
                    break;
                case TypeEven.Room:
                    s = CurrentRoom.Images;
                    HistoryText = CurrentRoom.TextRoom;
                    break;
            }
            arr = s.Split(';');
            for (int i = 0; i < arr.Length; i++)
            {
                switch(i)
                {
                    case 0:
                        Imag1 = PathImag + arr[i];
                        EnBtn1 = true;
                        break;
                    case 1:
                        Imag2 = PathImag + arr[i];
                        EnBtn2 = true;
                        break;
                    case 2:
                        Imag3 = PathImag + arr[i];
                        EnBtn3 = true;
                        break;
                    case 3:
                        Imag4 = PathImag + arr[i];
                        EnBtn4 = true;
                        break;
                    case 4:
                        Imag5 = PathImag + arr[i];
                        EnBtn5 = true;
                        break;
                    case 5:
                        Imag6 = PathImag + arr[i];
                        EnBtn6 = true;
                        break;
                }
            }
            
            VisibilityInfo = Visibility.Visible;
        }
        public void ClearImages()
        {
            EnBtn1 = false;
            EnBtn2 = false;
            EnBtn3 = false;
            EnBtn4 = false;
            EnBtn5 = false;
            EnBtn6 = false;
            Imag1 = "";
            Imag2 = "";
            Imag3 = "";
            Imag4 = "";
            Imag5 = "";
            Imag6 = "";
        }
        public void NoVisibleInfo()
        {
            VisibilityInfo = Visibility.Hidden;
        }

        public void CleanAct()
        {
            VersusTable = new ObservableCollection<ActionModel>();
            Versus = new ObservableCollection<ActionModel>();
            foreach (var w in HerosTable)
            {
                w.Atac = null;
            }
            foreach (var w in NPCTable)
            {
                w.Atac = null;
            }
        }

        public void RandomIze(int n)
        {
            Random rnd = new Random();
            Rnd = rnd.Next(1, n+1).ToString();
        }
        
        public void CalcAction()
        {
            if (versus)
            {
                foreach (var e in HerosTable)
                {
                    if (e.Atac != null)
                    {
                        Versus.Add(new ActionModel()
                        {
                            Id = e.Id,
                            Action = Convert.ToInt32(e.Atac),
                            Person = "Hero",
                            Name = e.HeroName,
                            Notee = e.Notee,
                            Defence = e.Defence,
                            Health = e.Health,
                            Power = e.Power,
                            Dexterity = e.Dexterity,
                            Endurance = e.Endurance,
                            Wisdom = e.Wisdom,
                            Intelligence = e.Intelligence,
                            Charisma = e.Charisma,
                            Item = e.Item,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                            Arms = e.Arms,
                            Equip = e.Equip,
                            Passiv = e.Passiv,
                            Description = e.Description
                        });
                    }
                }
                foreach (var e in NPCTable)
                {
                    if (e.Atac != null)
                    {
                        Versus.Add(new ActionModel()
                        {
                            Id = e.Id,
                            Action = Convert.ToInt32(e.Atac),
                            Person = "NPC",
                            Name = e.Name,
                            Notee = e.Notee,
                            Defence = e.Defence,
                            Health = e.Health,
                            Power = e.Power,
                            Dexterity = e.Dexterity,
                            Endurance = e.Endurance,
                            Wisdom = e.Wisdom,
                            Intelligence = e.Intelligence,
                            Charisma = e.Charisma,
                            Item = e.Item,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                        });
                    }
                }
                Versus = new ObservableCollection<ActionModel>(Versus.OrderByDescending(x => x.Action).ToList());
                int i = 0;
                int a = -1;
                int ie = 1;
                bool f = true;
                foreach (var w in Versus)
                {
                    if (f)
                    {
                        if (i != Versus.Count - 1)
                        {
                            if (Versus[i].Action != Versus[i + 1].Action)
                            {
                                Versus[i].Order = ie;
                            }
                            else
                            {
                                a = (i + 1) * (-1);
                                Versus[i].Order = a;
                                versus = false;
                                f = false;
                            }
                        }
                        else
                        {
                            Versus[i].Order = ie;
                        }
                    }
                    else
                    {
                        Versus[i].Order = a;
                        f = true;
                    }
                    i++;
                    ie++;
                }
                foreach (var w in Versus.Where(x => x.Person == "Hero"))
                {
                    HerosTable.First(x => x.Id == w.Id).Atac = w.Order.ToString();
                }
                foreach (var w in Versus.Where(x => x.Person == "NPC"))
                {
                    NPCTable.First(x => x.Id == w.Id).Atac = w.Order.ToString();
                }
            }
            else
            {
                foreach (var w in Versus)
                {
                    if (w.Order<0)
                    {
                        switch(w.Person)
                        {
                            case "Hero":
                                Versus.First(x => x.Id == w.Id).Order = Convert.ToInt32(HerosTable.First(x => x.Id == w.Id).Atac);
                                break;
                            case "NPC":
                                Versus.First(x => x.Id == w.Id).Order = Convert.ToInt32(NPCTable.First(x => x.Id == w.Id).Atac);
                                break;
                        }
                       
                    }
                }
                versus = true;
            }
            if (versus)
            {
                VersusTable = new ObservableCollection<ActionModel>(Versus.OrderByDescending(x => x.Action).ToList());
                VisibilityVersus = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Есть пересечения!");
            }
        }

        public void Update (object sender, DataGridRowEditEndingEventArgs e)
        {
            var rr = e.Row.Item;
            var r = e.GetType();
            //string sql = "UPDATE tUsers SET Atac = '"+CurrUser.Atac+"' WHERE Id = "+CurrUser.Id;
            //UpdataBD.UpdataInDb(sql);
            //UPDATE tUsers SET tUsers.Imag = 'Heros\ava3.png' WHERE tUsers.Id = 3
            //string sql1 = "INSERT INTO `Orders` (`Customer`, `Count`, `DateOrder`, `DeidLine`) VALUES ('" + _customerText + "', '" + _count + "', '" + _dateOrder + "', '" + _daidLine + "')";
        }
        public int Who(int n)
        {
            int res = 0;
            if (NpcStep==false)
            {
                switch (n)
                {
                    case 1:
                        res = CurrentUser.Power;
                        break;
                    case 2:
                        res = CurrentUser.Dexterity;
                        break;
                    case 3:
                        res = CurrentUser.Endurance;
                        break;
                    case 4:
                        res = CurrentUser.Wisdom;
                        break;
                    case 5:
                        res = CurrentUser.Intelligence;
                        break;
                    case 6:
                        res = CurrentUser.Charisma;
                        break;
                }
            }
            else
            {
                switch (n)
                {
                    case 1:
                        res = CurrentNPC.Power;
                        break;
                    case 2:
                        res = CurrentNPC.Dexterity;
                        break;
                    case 3:
                        res = CurrentNPC.Endurance;
                        break;
                    case 4:
                        res = CurrentNPC.Wisdom;
                        break;
                    case 5:
                        res = CurrentNPC.Intelligence;
                        break;
                    case 6:
                        res = CurrentNPC.Charisma;
                        break;
                }
            }
            return res;
        }

        public void SummaCh(int n, int type)
        {
            string text = "";
            switch (type)
            {
                case 0:
                    if (summa == 0)
                    {
                        text = n.ToString() + " ";
                    }
                    else
                    {
                        if (n<0)
                        {
                            text = n + " ";
                        }
                        else
                        {
                            text = "+ " + n + " ";
                        }
                    }
                    summa += n;
                    break;
                case 1:
                    int t = Who(n);
                    if (t < 0)
                    {
                        text = t + " ";
                    }
                    else
                    {
                        text = "+ " + t + " ";
                    }
                    
                    summa += t;
                    break;
                case 2:
                    text = "= " + summa;
                    ResultCheckDefence();
                    break;
                case 3:
                    text = "= " + summa;
                    ResultCheckHealth();
                    break;
            }
            PreVeiwWindow.ViewVersus(text);
            TextView = text;
        }

        public void ResultCheckHealth()
        {
            if (CurrentNPC != null && CurrentUser != null)
            {
                string sql = "";
                string table = "";
                int result = 0;
                int id = 0;
                if (NpcStep == false)
                {
                    //Ход Героя
                    id = CurrentNPC.Id;
                    result = CurrentNPC.Health - summa;
                    NPCTable.First(x => x.Id == CurrentNPC.Id).Health = result;
                    HP = result.ToString();
                    table = "tNPC";
                    PreVeiwWindow.CrashR();
                }
                else
                {
                    //Ход NPC
                    id = CurrentUser.Id;
                    result = CurrentUser.Health - summa;
                    HerosTable.First(x => x.Id == CurrentUser.Id).Health = result;
                    table = "tHeros";
                    PreVeiwWindow.CrashL();

                }
                PreVeiwWindow.EditHP(NpcStep, result);
                sql = "UPDATE " + table + " SET Health = '" + result + "' WHERE Id = " + id;
                UpdataBD.UpdataInDb(sql);
            }
            else
            {
                MessageBox.Show("Выбери соперника в таблице");
            }
        }

        public void ResultCheckDefence()
        {
            if (CurrentNPC != null && CurrentUser != null)
            {
                if (NpcStep)
                {
                    //Ход NPC
                    if (CurrentUser.Defence - summa <= 0)
                    {
                        PreVeiwWindow.EditShit(NpcStep, 2);
                    }
                    else
                    {
                        PreVeiwWindow.EditShit(NpcStep, 1);
                    }
                }
                else
                {
                    //Ход Героя
                    if (CurrentNPC.Defence - summa <= 0)
                    {
                        PreVeiwWindow.EditShit(NpcStep, 2);
                    }
                    else
                    {
                        PreVeiwWindow.EditShit(NpcStep, 1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выбери соперника в таблице");
            }
        }

        public void EditStep()
        {
            if (NpcStep)
            {
                TextButton = "Ход Героя";
                PreVeiwWindow.EditShit(0);
                NpcStep = false;
                ClianTextBoxVeiw();
                VR = Visibility.Hidden;
                VL = Visibility.Visible;
            }
            else
            {
                TextButton = "Ход NPC";
                PreVeiwWindow.EditShit(0);
                NpcStep = true;
                ClianTextBoxVeiw();
                VR = Visibility.Visible;
                VL = Visibility.Hidden;
            }
        }

        public void HeroInBattle()
        {
            PreVeiwWindow.LeftInBattleVeiw(CurrentUser.Imag, CurrentUser.HeroName, CurrentUser.Defence.ToString(), CurrentUser.Health.ToString(), "Hero");
            PreVeiwWindow.EditShit(0);
        }
        public void NPCInBattle()
        {
            PreVeiwWindow.RightInBattleVeiw(CurrentNPC.Imag, CurrentNPC.Name, CurrentNPC.Defence.ToString(), CurrentNPC.Health.ToString(), "NPC");
            PreVeiwWindow.EditShit(0);
        }
        public void ShowWindowVS()
        {

            if (ShowWin)
            {
                if (VisibilityWin)
                {
                    PreVeiwWindow.EndBattle();
                    ViewBattle = "Показать";
                    VisibilityWin = false;
                }
                else
                {
                    PreVeiwWindow.StartBattle();
                    VisibilityWin = true;
                    ViewBattle = "Скрыть";
                }
            }
            else
            {
                ShowWin = true;
                VisibilityWin = true;
                PreVeiwWindow.ShowWindowVS(SelectItem.Id);
                //PreVeiwWindow.ShowWindowVS(1);
            }
        }

        public void ClianTextBoxVeiw()
        {
            PreVeiwWindow.VersusCH = "";
            summa = 0;
        }

        public void OnLoad()
        {
            List<ComboBoxModel> Combo = ReadBD.ReadHistory("SELECT Id, Name FROM tHistotys;");
            ComboBoxItem = Combo;
            //LoadHystory(1);
        }
        public void RunSql()
        {
            ReadBD.WriteBD(SqlText);
        }

        public void CurrentV(int n)
        {
            switch (n)
            {
                case 1:
                    PreVeiwWindow.LeftInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person);
                    PreVeiwWindow.EditShit(0);
                    break;
                case 2:
                    PreVeiwWindow.RightInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person);
                    PreVeiwWindow.EditShit(0);
                    break;
            }
        }

        public void CurrentR()
        {
            BackSEn = false;
            AtacSEn = false;
            TrackSEn = false;
            arr = null;
            arr = CurrentRoom.Images.Split(';');
            TextNPC = CurrentRoom.TextRoom;
            ImageInfo = PathImag + arr[0];
            CurrEvent = TypeEven.Room;
            if (CurrentRoom.Sounds != "")
                BackSEn = true;
            Events = new ObservableCollection<EventsModel>(ListEvent.Where(x => x.RoomId == CurrentRoom.Id).OrderBy(x => x.Order).ToList());
            NPCTable = new ObservableCollection<NPCModel>(ListNpc.Where(x => x.RoomId == CurrentRoom.Id).ToList());
        }

        public void CurrentE()
        {
            if (CurrentEvent != null)
            {
                BackSEn = false;
                AtacSEn = false;
                TrackSEn = false;
                arr = null;
                arr = CurrentEvent.Images.Split(';');
                TextNPC = CurrentEvent.TextEvent;
                ImageInfo = PathImag + arr[0];
                CurrEvent = TypeEven.Event;
                if (!String.IsNullOrEmpty(CurrentEvent.Sounds))
                    BackSEn = true;
            }
        }

        public void ViewNPC()
        {
            if (CurrentNPC != null)
            {
                BackSEn = false;
                AtacSEn = false;
                TrackSEn = false;
                HP = CurrentNPC.Health.ToString();
                TextNPC = CurrentNPC.History;
                ItemText = CurrentNPC.Item;
                TollTipNPS = CurrentNPC.Notee;
                ImageInfo = PathNPC + CurrentNPC.Imag;
                if (CurrentNPC.AtacSound != "")
                    AtacSEn = true;
            };
        }
        public void ViewUser()
        {
            if (CurrentUser != null)
            {
                UserInfo = "Оружие:\r\n" + CurrentUser.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentUser.Equip + "\r\n\r\nИнвинтарь:\r\n" + CurrentUser.Item + "\r\n\r\nСпособности:\r\n" + CurrentUser.Abilities + "\r\n\r\nЗаклинания:\r\n" + CurrentUser.Ulta + "\r\n\r\nОписание:\r\n" + CurrentUser.Description;
                UserIcon = PathHero + CurrentUser.Imag;
            }
        }
        public void ViewImagIn()
        {
            if (VisibilityImag)
            {
                ViewImagText = "Показать";
                PreVeiwWindow.NoShowImag();
                VisibilityImag = false;
            }
            else
            {
                ViewImagText = "Скрыть";
                PreVeiwWindow.ShowImag(CurrentNPC.Imag);
                VisibilityImag = true;
            }
            
        }

    #endregion

        #region Команды

        public ICommand ComboOk { get; set; }
        public ICommand ShowWindow { get; set; }
        public ICommand StartSql { get; set; }
        public ICommand ViewImag { get; set; }
        public ICommand IntoBattleR { get; set; }
        public ICommand IntoBattleL { get; set; }
        public ICommand Battle1 { get; set; }
        public ICommand Battle2 { get; set; }
        public ICommand Battle3 { get; set; }
        public ICommand Battle4 { get; set; }
        public ICommand Battle5 { get; set; }
        public ICommand ClianTextBox { get; set; }
        public ICommand B1 { get; set; }
        public ICommand B2 { get; set; }
        public ICommand B3 { get; set; }
        public ICommand B4 { get; set; }
        public ICommand B5 { get; set; }
        public ICommand B6 { get; set; }
        public ICommand B7 { get; set; }
        public ICommand B8 { get; set; }
        public ICommand B9 { get; set; }
        public ICommand B10 { get; set; }
        public ICommand B11 { get; set; }
        public ICommand B12 { get; set; }
        public ICommand B13 { get; set; }
        public ICommand B14 { get; set; }
        public ICommand B15 { get; set; }
        public ICommand B16 { get; set; }
        public ICommand B17 { get; set; }
        public ICommand B18 { get; set; }
        public ICommand B19 { get; set; }
        public ICommand B20 { get; set; }
        public ICommand Power { get; set; }
        public ICommand Dexterity { get; set; }
        public ICommand Endurance { get; set; }
        public ICommand Wisdom { get; set; }
        public ICommand Intelligence { get; set; }
        public ICommand Charisma { get; set; }
        public ICommand NPCStep { get; set; }
        public ICommand ResultDefence { get; set; }
        public ICommand ResultHealth { get; set; }
        public ICommand ActionBtn { get; set; }
        public ICommand D4 { get; set; }
        public ICommand D6 { get; set; }
        public ICommand D8 { get; set; }
        public ICommand D10 { get; set; }
        public ICommand D12 { get; set; }
        public ICommand D20 { get; set; }
        public ICommand D100 { get; set; }
        public ICommand CleanActionBtn { get; set; }
        public ICommand CloseInfoBtn { get; set; }
        public ICommand ImagBtn1 { get; set; }
        public ICommand ImagBtn2 { get; set; }
        public ICommand ImagBtn3 { get; set; }
        public ICommand ImagBtn4 { get; set; }
        public ICommand ImagBtn5 { get; set; }
        public ICommand ImagBtn6 { get; set; }
        public ICommand ViewInfo { get; set; }
        public ICommand BackSound { get; set; }
        public ICommand AtacSound { get; set; }
        public ICommand TrackSound { get; set; }
        public ICommand CloseVersus { get; set; }
        public ICommand BtnL { get; set; }
        public ICommand BtnR { get; set; }

        #endregion
    }
}
