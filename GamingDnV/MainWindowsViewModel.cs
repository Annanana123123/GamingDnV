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
            D4 = new RelayCommand(() => RandomIze(4));
            D6 = new RelayCommand(() => RandomIze(6));
            D8 = new RelayCommand(() => RandomIze(8));
            D10 = new RelayCommand(() => RandomIze(10));
            D12 = new RelayCommand(() => RandomIze(12));
            D20 = new RelayCommand(() => RandomIze(20));
            D100 = new RelayCommand(() => RandomIze(100));
            ResultDefence = new RelayCommand(() => PreVeiwWindow.EditShit(NpcStep));
            ResultHealth1 = new RelayCommand(() => SummaCh(1));
            ResultHealth2 = new RelayCommand(() => SummaCh(2));
            ResultHealth3 = new RelayCommand(() => SummaCh(3));
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
            BackSound = new RelayCommand(() => PlayAndStop(CurrEvent));
            AtacSound = new RelayCommand(() => PlayAndStop(CurrEvent));
            TrackSound = new RelayCommand(() => PlayAndStop(CurrEvent));
            ComboOk = new RelayCommand(() => LoadHystory());
            CloseVersus = new RelayCommand(() => CloseVersusWin());
            BtnL = new RelayCommand(() => CurrentV(1));
            BtnR = new RelayCommand(() => CurrentV(2));
            IntoBattlePrint = new RelayCommand(() => Print());
            Logo = new RelayCommand(() => VisibilitzLogo());
            Transfer = new RelayCommand(() => TransferItem());
            Delete = new RelayCommand(() => DeleteItem());
            Garbage = new RelayCommand(() => GarbageItem());
            ShowNote = new RelayCommand(() => ViewNote());
            EditNoteBtn = new RelayCommand(() => EditNote());
            WriteNodeText = new RelayCommand(() => WriteEditNote());
            CanсelNode = new RelayCommand(() => EditNote());
            VisibilityInfo = Visibility.Hidden;
            VisibilityLoad = Visibility.Visible;
            VisibilityVersus = Visibility.Hidden;
            VisibilityPrint = Visibility.Hidden;
            VisibilityWriteNote = Visibility.Hidden;
            DColorL = "#1C1C25";
            DColorR = "#1C1C25";
            HColorL = "#1C1C25";
            HColorR = "#1C1C25";
            VR = Visibility.Hidden;
            VL = Visibility.Visible;
            VisibilityNote = Visibility.Hidden;
            TextButton = "Ход Героя";
            ViewImagText = "Показать";
            ViewBattle = "Показать";
            BackSEn = false;
            AtacSEn = false;
            TrackSEn = false;
    }

        #endregion

        #region Свойства
        public bool logo = false;
        public bool versus = true;
        public string History = "";
        public PreViewModel PreVeiwWindow { get; set; }

        List<NoteModel> ListNote = new List<NoteModel>();
        ObservableCollection<UsersModel> Users = new ObservableCollection<UsersModel>();
        ObservableCollection<NPCModel> NPC = new ObservableCollection<NPCModel>();


        private string _textWriteNode;
        public string TextWriteNode
        {
            get { return _textWriteNode; }
            set
            {
                _textWriteNode = value;

                RaisePropertyChanged(nameof(TextWriteNode));
            }
        }

        private string _damag;
        public string Damag
        {
            get { return _damag; }
            set
            {
                _damag = value;

                RaisePropertyChanged(nameof(Damag));
            }
        }

        private string _toolTipU;
        public string ToolTipU
        {
            get { return _toolTipU; }
            set
            {
                _toolTipU = value;

                RaisePropertyChanged(nameof(ToolTipU));
            }
        }
        private string _toolTipN;
        public string ToolTipN
        {
            get { return _toolTipN; }
            set
            {
                _toolTipN = value;

                RaisePropertyChanged(nameof(ToolTipN));
            }
        }

        private string _dColorL;
        public string DColorL
        {
            get { return _dColorL; }
            set
            {
                _dColorL = value;

                RaisePropertyChanged(nameof(DColorL));
            }
        }
        private string _dColorR;
        public string DColorR
        {
            get { return _dColorR; }
            set
            {
                _dColorR = value;

                RaisePropertyChanged(nameof(DColorR));
            }
        }
        private string _hColorL;
        public string HColorL
        {
            get { return _hColorL; }
            set
            {
                _hColorL = value;

                RaisePropertyChanged(nameof(HColorL));
            }
        }
        private string _hColorR;
        public string HColorR
        {
            get { return _hColorR; }
            set
            {
                _hColorR = value;

                RaisePropertyChanged(nameof(HColorR));
            }
        }

        private string _imagPrint;
        public string ImagPrint
        {
            get { return _imagPrint; }
            set
            {
                _imagPrint = value;

                RaisePropertyChanged(nameof(ImagPrint));
            }
        }

        private string _namePrint;
        public string NamePrint
        {
            get { return _namePrint; }
            set
            {
                _namePrint = value;

                RaisePropertyChanged(nameof(NamePrint));
            }
        }

        private string _classPrint;
        public string ClassPrint
        {
            get { return _classPrint; }
            set
            {
                _classPrint = value;

                RaisePropertyChanged(nameof(ClassPrint));
            }
        }

        private string _dFPrint;
        public string DFPrint
        {
            get { return _dFPrint; }
            set
            {
                _dFPrint = value;

                RaisePropertyChanged(nameof(DFPrint));
            }
        }

        private string _hPPrint;
        public string HPPrint
        {
            get { return _hPPrint; }
            set
            {
                _hPPrint = value;

                RaisePropertyChanged(nameof(HPPrint));
            }
        }

        private string _pPrint;
        public string PPrint
        {
            get { return _pPrint; }
            set
            {
                _pPrint = value;

                RaisePropertyChanged(nameof(PPrint));
            }
        }

        private string _dPrint;
        public string DPrint
        {
            get { return _dPrint; }
            set
            {
                _dPrint = value;

                RaisePropertyChanged(nameof(DPrint));
            }
        }

        private string _ePrint;
        public string EPrint
        {
            get { return _ePrint; }
            set
            {
                _ePrint = value;

                RaisePropertyChanged(nameof(EPrint));
            }
        }

        private string _wPrint;
        public string WPrint
        {
            get { return _wPrint; }
            set
            {
                _wPrint = value;

                RaisePropertyChanged(nameof(WPrint));
            }
        }

        private string _iPrint;
        public string IPrint
        {
            get { return _iPrint; }
            set
            {
                _iPrint = value;

                RaisePropertyChanged(nameof(IPrint));
            }
        }

        private string _cPrint;
        public string CPrint
        {
            get { return _cPrint; }
            set
            {
                _cPrint = value;

                RaisePropertyChanged(nameof(CPrint));
            }
        }

        private string _eqPrint;
        public string EqPrint
        {
            get { return _eqPrint; }
            set
            {
                _eqPrint = value;

                RaisePropertyChanged(nameof(EqPrint));
            }
        }

        private string _abPrint;
        public string AbPrint
        {
            get { return _abPrint; }
            set
            {
                _abPrint = value;

                RaisePropertyChanged(nameof(AbPrint));
            }
        }

        private string _hiPrint;
        public string HiPrint
        {
            get { return _hiPrint; }
            set
            {
                _hiPrint = value;

                RaisePropertyChanged(nameof(HiPrint));
            }
        }

        private string _iL;
        public string IL
        {
            get { return _iL; }
            set
            {
                _iL = value;

                RaisePropertyChanged(nameof(IL));
            }
        }

        private string _iR;
        public string IR
        {
            get { return _iR; }
            set
            {
                _iR = value;

                RaisePropertyChanged(nameof(IR));
            }
        }

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
        private Visibility _visibilityPrint;
        public Visibility VisibilityPrint
        {
            get { return _visibilityPrint; }
            set
            {
                _visibilityPrint = value;
                RaisePropertyChanged(nameof(VisibilityPrint));
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

        private Visibility _visibilityWriteNote;
        public Visibility VisibilityWriteNote
        {
            get { return _visibilityWriteNote; }
            set
            {
                _visibilityWriteNote = value;
                RaisePropertyChanged(nameof(VisibilityWriteNote));
            }
        }

        private Visibility _visibilityNote;
        public Visibility VisibilityNote
        {
            get { return _visibilityNote; }
            set
            {
                _visibilityNote = value;
                RaisePropertyChanged(nameof(VisibilityNote));
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

        private string _textNote;
        public string TextNote
        {
            get { return _textNote; }
            set
            {
                _textNote = value;

                RaisePropertyChanged(nameof(TextNote));
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

        private List<ItemsModel> _listitems;
        public List<ItemsModel> ListItems
        {
            get { return _listitems; }
            set
            {
                _listitems = value;

                RaisePropertyChanged(nameof(ListItems));
            }
        }

        private List<ItemsModel> _items;
        public List<ItemsModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;

                RaisePropertyChanged(nameof(Items));
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

        private string _dL;
        public string DL
        {
            get { return _dL; }
            set
            {
                _dL = value;

                RaisePropertyChanged(nameof(DL));
            }
        }
        private string _hL;
        public string HL
        {
            get { return _hL; }
            set
            {
                _hL = value;

                RaisePropertyChanged(nameof(HL));
            }
        }
        private string _dR;
        public string DR
        {
            get { return _dR; }
            set
            {
                _dR = value;

                RaisePropertyChanged(nameof(DR));
            }
        }
        private string _hR;
        public string HR
        {
            get { return _hR; }
            set
            {
                _hR = value;

                RaisePropertyChanged(nameof(HR));
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

        private ItemsModel _currentItems;
        public ItemsModel CurrentItems
        {
            get { return _currentItems; }
            set
            {
                _currentItems = value;
                //CurrentI();
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

        private ActionModel _currentVerusu;
        public ActionModel CurrentVersus
        {
            get { return _currentVerusu; }
            set
            {
                _currentVerusu = value;
                ViewVersus();
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

        public ActionModel LCurr = new ActionModel();
        public ActionModel RCurr = new ActionModel();

        #endregion

        #region Методы

        public void Print()
        {
            ImagPrint = PathHero + CurrentUser.Imag;
            NamePrint = CurrentUser.HeroName;
            ClassPrint = CurrentUser.Species + " " + CurrentUser.Class;
            DFPrint = CurrentUser.Defence.ToString();
            HPPrint = CurrentUser.Health.ToString();
            PPrint = CurrentUser.Power.ToString();
            DPrint = CurrentUser.Dexterity.ToString();
            EPrint = CurrentUser.Endurance.ToString();
            WPrint = CurrentUser.Wisdom.ToString();
            IPrint = CurrentUser.Intelligence.ToString();
            CPrint = CurrentUser.Charisma.ToString();
            EqPrint = "Оружие:\n" + CurrentUser.Arms + "\n\rСнаряжение:\n" + CurrentUser.Equip;
            AbPrint = "Способности:\n" + CurrentUser.Abilities + "\n\rЗаклинания:\n" + CurrentUser.Ulta;
            HiPrint = "История: Я "+ CurrentUser.Species + " " + CurrentUser.Class + " по имени " + CurrentUser.HeroName + ". " + CurrentUser.History + "\n\rОписание способностей:\n" + CurrentUser.Description;
            VisibilityPrint = Visibility.Visible;
        }

        public void WriteEditNote()
        {
            string sql = "UPDATE `tWriteNode` SET `Text` = '" + TextWriteNode + "' WHERE `Id` = 1";
            ReadBD.WriteBD(sql);
            EditNote();
        }

        public void ViewNote()
        {
            if (VisibilityNote == Visibility.Hidden)
            {
                VisibilityNote = Visibility.Visible;
            }
            else
            {
                VisibilityNote = Visibility.Hidden;
            }
        }
        public void EditNote()
        {
            if (VisibilityWriteNote == Visibility.Hidden)
            {
                VisibilityWriteNote = Visibility.Visible;
            }
            else
            {
                VisibilityWriteNote = Visibility.Hidden;
            }
        }

        public void VisibilitzLogo()
        {
            if (logo)
            {
                PreVeiwWindow.NoVisibilityLogo();
                logo = false;
            }
            else
            {
                PreVeiwWindow.VisibilityLogo(History);
                logo = true;
            }
        }
        public void CloseVersusWin()
        {
            VisibilityVersus = Visibility.Hidden;
            VisibilityPrint = Visibility.Hidden;
        }

        public void LoadHystory()
        {
            if (SelectItem is null)
            {
                MessageBox.Show("Выбери историю");
            }
            else
            {
                VisibilityLoad = Visibility.Hidden;
                PathHero = AppDomain.CurrentDomain.BaseDirectory + "Media\\Heros\\";
                PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItem.Id + "\\NPC\\";
                PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItem.Id + "\\Images\\";
                PathInterface = AppDomain.CurrentDomain.BaseDirectory + "Media\\Interface\\";
                PathMedia = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItem.Id + "\\Sounds\\";
                History = ReadBD.ReadHistoryInDb("SELECT Name FROM tHistorys WHERE Id = " + SelectItem.Id + ";");
                Rooms = ReadBD.ReadRoomsInDb("SELECT Id, Name, TextRoom, Images, Sounts FROM tRooms WHERE HistoryId = " + SelectItem.Id + " ORDER BY tRooms.Order;");
                ListEvent = ReadBD.ReadEventInDb("SELECT Id, Name, TextEvent, Images, Sounds, Order, RoomId FROM tEvents WHERE RoomId in (" + WhereIn() + ");");
                ListNpc = ReadBD.ReadNPCInDb("SELECT Id, Name, Notee, Defence, Health, Power, Dexterity, Endurance, Wisdom, Intelligence, Charisma, Species, Class, Arms, Item, Abilities, Ulta, History, Imag, Equip, Sounds, RoomId FROM tNpc WHERE tNpc.RoomId in (" + WhereIn() + ");");
                HerosTable = ReadBD.ReadUsersInDb("SELECT Id, HeroName, Notee, Defence, Health, Power, Dexterity, Endurance, Wisdom, Intelligence ,Charisma , Species, Class, Item, Abilities, Ulta, History, Imag, Arms, Equip, Description, Passiv FROM tHeros WHERE HistoryId =" + SelectItem.Id);
                ListItems = WhereItems();
                ListNote = ReadBD.ReadNoteInDb("SELECT Id, Name, Notee, HistoryId FROM tNote WHERE HistoryId in (0, " + SelectItem.Id + ");");
                TextNote = Note(ListNote);
                TextWriteNode = ReadBD.ReadWriteNoteInDb("SELECT Text FROM tWriteNode WHERE id = 1");
            }
        }

        public string Note (List<NoteModel> s)
        {
            string text = "";
            foreach (var n in s)
            {
                text += n.Name + " - " + n.Notee + "\r\n\r\n";
            }
            return text;
        }

        public void GarbageItem()
        {
            Items = ListItems.Where(x => x.IdPerson == 0 && x.Person == 0).ToList();
        }

        public void TransferItem()
        {
            if (CurrentUser != null)
            {
                int currPer = CurrentItems.Person;
                int currId = CurrentItems.IdPerson;
                ReadBD.WriteBD("UPDATE tItems SET IdPerson = " + CurrentUser.Id + ", Person = " + 1 + " WHERE Id = " + CurrentItems.Id);
                CurrentItems.IdPerson = CurrentUser.Id;
                CurrentItems.Person = 1;
                Items = ListItems.Where(x => x.IdPerson == currId && x.Person == currPer).ToList();
            }
            else
            {
                MessageBox.Show("Выбери героя!");
            }
        }

        public void DeleteItem()
        {
            int currPer = CurrentItems.Person;
            int currId = CurrentItems.IdPerson;
            ReadBD.WriteBD("UPDATE tItems SET IdPerson = 0, Person = 0 WHERE Id = " + CurrentItems.Id);
            CurrentItems.IdPerson = 0;
            CurrentItems.Person = 0;
            //Items = ListItems;
            Items = ListItems.Where(x => x.IdPerson == currId && x.Person == currPer).ToList();
        }

        public List<ItemsModel> WhereItems()
        {
            List<ItemsModel> item = new List<ItemsModel>();
            List<ItemsModel> item1 = new List<ItemsModel>();
            List<ItemsModel> item2 = new List<ItemsModel>();
            List<ItemsModel> item3 = new List<ItemsModel>();
            string id = "";
            foreach (var n in HerosTable)
            {
                id += n.Id + ", "; 
            }
            if (id != "")
                item1 = ReadBD.ReadItemsInDb("SELECT Id, Name, Notee, IdPerson, Person, Count FROM tItems WHERE IdPerson in (" + id + ") and Person = 1;");

            id = "";
            foreach (var n in ListNpc)
            {
                id += n.Id + ", ";
            }
            if (id != "")
                item2 = ReadBD.ReadItemsInDb("SELECT Id, Name, Notee, IdPerson, Person, Count FROM tItems WHERE IdPerson in (" + id + ") and Person = 2;");

            id = "";
            foreach (var n in Rooms)
            {
                id += n.Id + ", ";
            }
            if (id != "")
                item3 = ReadBD.ReadItemsInDb("SELECT Id, Name, Notee, IdPerson, Person, Count FROM tItems WHERE IdPerson in (" + id + ") and Person = 3;");
            item = new List<ItemsModel>(item1.Concat(item2.Concat(item3)));
            return item;
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

        public void PlayAndStop(TypeEven eventT)
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
                        Sound += CurrentNPC.Sounds;
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
                PreVeiwWindow.ShowImag(arr[i], TypeEven.Event);
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
            ObservableCollection<ActionModel> VSs = new ObservableCollection<ActionModel>();
            if (versus)
            {
                foreach (var e in HerosTable)
                {
                    //if (e.Atac != null)
                    //{
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
                            Description = e.Description,
                        });
                    //}
                }
                if (NPCTable != null)
                {
                    foreach (var e in NPCTable)
                    {
                        //if (e.Atac != null)
                        //{
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
                            Arms = e.Arms,
                            Wisdom = e.Wisdom,
                            Intelligence = e.Intelligence,
                            Charisma = e.Charisma,
                            Item = e.Item,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                            Equip = e.Equip
                        });
                        //}
                    }
                }
                foreach (var e in Versus)
                {
                    if (e.Action != 0)
                    {
                        VSs.Add(new ActionModel()
                        {
                            Id = e.Id,
                            Action = e.Action,
                            Person = e.Person,
                            Name = e.Name,
                            Notee = e.Notee,
                            Defence = e.Defence,
                            Health = e.Health,
                            Power = e.Power,
                            Dexterity = e.Dexterity,
                            Endurance = e.Endurance,
                            Wisdom = e.Wisdom,
                            Arms = e.Arms,
                            Intelligence = e.Intelligence,
                            Charisma = e.Charisma,
                            Item = e.Item,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                            Equip = e.Equip
                        });
                    }
                }
                Versus = new ObservableCollection<ActionModel>(VSs.OrderByDescending(x => x.Action).ToList());
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
                if (Versus[0].Person == "Hero")
                {

                    TextButton = "Ход Героя";
                    PreVeiwWindow.EditShit(0);
                    NpcStep = false;
                    ClianTextBoxVeiw();
                    VR = Visibility.Hidden;
                    VL = Visibility.Visible;
                    ClianColor();
                    DColorL = "#2b4c00";
                    HColorL = "#2b4c00";
                }
                else
                {
                    TextButton = "Ход NPC";
                    PreVeiwWindow.EditShit(0);
                    NpcStep = true;
                    ClianTextBoxVeiw();
                    VR = Visibility.Visible;
                    VL = Visibility.Hidden;
                    ClianColor();
                    DColorR = "#2b4c00";
                    HColorR = "#2b4c00";
                }
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

        public int WhoVS(int n)
        {
            int res = 0;
            if (NpcStep == false)
            {
                switch (n)
                {
                    case 1:
                        res = LCurr.Power;
                        break;
                    case 2:
                        res = LCurr.Dexterity;
                        break;
                    case 3:
                        res = LCurr.Endurance;
                        break;
                    case 4:
                        res = LCurr.Wisdom;
                        break;
                    case 5:
                        res = LCurr.Intelligence;
                        break;
                    case 6:
                        res = LCurr.Charisma;
                        break;
                }
            }
            else
            {
                switch (n)
                {
                    case 1:
                        res = RCurr.Power;
                        break;
                    case 2:
                        res = RCurr.Dexterity;
                        break;
                    case 3:
                        res = RCurr.Endurance;
                        break;
                    case 4:
                        res = RCurr.Wisdom;
                        break;
                    case 5:
                        res = RCurr.Intelligence;
                        break;
                    case 6:
                        res = RCurr.Charisma;
                        break;
                }
            }
            return res;
        }

        public void SummaCh(int s = 0)
        {
            int dam = Convert.ToInt32(Damag);
            if (NpcStep)
            {
                //CurrentUser.Health -= dam;
                if (VisibilityVersus == Visibility.Hidden)
                {
                    CurrentUser.Health -= dam;
                }
                ResultCheckHealth(s, dam);
            }
            else
            {
                
                if (VisibilityVersus == Visibility.Hidden)
                {
                    CurrentNPC.Health -= dam;
                }
                ResultCheckHealth(s, dam);
            }
        }

        public void ResultCheckHealth(int s, int dam = 0)
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
                    if (VisibilityVersus == Visibility.Visible)
                    {
                        result = RCurr.Health - dam;
                        if (RCurr.Person == "Hero")
                        {
                            HerosTable.First(x => x.Id == RCurr.Id).Health = result;
                            HR = result.ToString();
                        }
                        else
                        {
                            NPCTable.First(x => x.Id == RCurr.Id).Health = result;
                            HR = result.ToString();
                        }
                        VersusTable.First(x => x.Id == RCurr.Id).Health = result;
                    }
                    else
                    {
                        result = CurrentNPC.Health;
                        NPCTable.First(x => x.Id == CurrentNPC.Id).Health = result;
                    }
                    HP = result.ToString();
                    table = "tNPC";
                    PreVeiwWindow.CrashR(s);
                }
                else
                {
                    //Ход NPC
                    if (VisibilityVersus == Visibility.Visible)
                    {
                        result = LCurr.Health - dam;
                        if (LCurr.Person == "Hero")
                        {
                            HerosTable.First(x => x.Id == LCurr.Id).Health = result;
                            HL = result.ToString();
                        }
                        else
                        {
                            NPCTable.First(x => x.Id == LCurr.Id).Health = result;
                            HL = result.ToString();
                        }
                        VersusTable.First(x => x.Id == LCurr.Id).Health = result;
                    }
                    else
                    {
                        result = CurrentUser.Health;
                        HerosTable.First(x => x.Id == CurrentUser.Id).Health = result;
                    }
                    table = "tHeros";
                    PreVeiwWindow.CrashL(s);

                }
                PreVeiwWindow.EditHP(NpcStep, result);
                //sql = "UPDATE " + table + " SET Health = '" + result + "' WHERE Id = " + id;
                //UpdataBD.UpdataInDb(sql);
            }
            else
            {
                MessageBox.Show("Выбери соперника в таблице");
            }
        }

        public void ClianColor()
        {
            DColorL = "#1C1C25";
            DColorR = "#1C1C25";
            HColorL = "#1C1C25";
            HColorR = "#1C1C25";
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
                ClianColor();
                DColorL = "#2b4c00";
                HColorL = "#2b4c00";
            }
            else
            {
                TextButton = "Ход NPC";
                PreVeiwWindow.EditShit(0);
                NpcStep = true;
                ClianTextBoxVeiw();
                VR = Visibility.Visible;
                VL = Visibility.Hidden;
                ClianColor();
                DColorR = "#2b4c00";
                HColorR = "#2b4c00";
            }
        }

        public void HeroInBattle()
        {
            if (CurrentUser != null)
            {
                PreVeiwWindow.LeftInBattleVeiw(CurrentUser.Imag, CurrentUser.HeroName, CurrentUser.Defence.ToString(), CurrentUser.Health.ToString(), "Hero");
                PreVeiwWindow.EditShit(0);
            }
        }
        public void NPCInBattle()
        {
            if (CurrentNPC != null)
            {
                PreVeiwWindow.RightInBattleVeiw(CurrentNPC.Imag, CurrentNPC.Name, CurrentNPC.Defence.ToString(), CurrentNPC.Health.ToString(), "NPC");
                PreVeiwWindow.EditShit(0);
            }
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
            TextView = "";
            summa = 0;
        }

        public void OnLoad()
        {
            List<ComboBoxModel> Combo = ReadBD.ReadHistory("SELECT Id, Name FROM tHistorys WHERE Visibility = 1;");
            ComboBoxItem = Combo;
            //LoadHystory(1);
        }
        public void RunSql()
        {
            ReadBD.WriteBD(SqlText);
        }

        public void CurrentV(int n)
        {
            if (CurrentVersus != null)
            {
                switch (n)
                {
                    case 1:
                        if (CurrentVersus.Person == "Hero")
                        {
                            IL = PathHero + CurrentVersus.Imag;
                        }
                        else
                        {
                            IL = PathNPC + CurrentVersus.Imag;
                        }
                        LCurr = CurrentVersus;
                        DL = CurrentVersus.Defence.ToString();
                        HL = CurrentVersus.Health.ToString();
                        PreVeiwWindow.LeftInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person);
                        PreVeiwWindow.EditShit(0);
                        break;
                    case 2:
                        if (CurrentVersus.Person == "Hero")
                        {
                            IR = PathHero + CurrentVersus.Imag;
                        }
                        else
                        {
                            IR = PathNPC + CurrentVersus.Imag;
                        }
                        RCurr = CurrentVersus;
                        DR = CurrentVersus.Defence.ToString();
                        HR = CurrentVersus.Health.ToString();
                        PreVeiwWindow.RightInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person);
                        PreVeiwWindow.EditShit(0);
                        break;
                }
            }
        }

        public void CurrentI()
        {
            //if (CurrentItems != null)
                //MessageBox.Show(CurrentItems.Name);
        }

        public void CurrentR()
        {
            BackSEn = false;
            AtacSEn = false;
            TrackSEn = false;
            arr = null;
            ItemText = "";
            ToolTipN = "id = " + CurrentRoom.Id.ToString();
            arr = CurrentRoom.Images.Split(';');
            TextNPC = CurrentRoom.TextRoom;
            ImageInfo = PathImag + arr[0];
            CurrEvent = TypeEven.Room;
            if (CurrentRoom.Sounds != "")
                BackSEn = true;
            Events = new ObservableCollection<EventsModel>(ListEvent.Where(x => x.RoomId == CurrentRoom.Id).OrderBy(x => x.Order).ToList());
            NPCTable = new ObservableCollection<NPCModel>(ListNpc.Where(x => x.RoomId == CurrentRoom.Id).ToList());
            Items = ListItems.Where(x => x.IdPerson == CurrentRoom.Id && x.Person == 3).ToList();
        }

        public void CurrentE()
        {
            if (CurrentEvent != null)
            {
                BackSEn = false;
                AtacSEn = false;
                TrackSEn = false;
                ItemText = "";
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
                ToolTipN = "id = " + CurrentNPC.Id.ToString();
                HP = CurrentNPC.Health.ToString();
                TextNPC = CurrentNPC.History + "\r\n\rСпособности:\r\n" + CurrentNPC.Abilities + "\r\n\rЗаклинание:\r\n" + CurrentNPC.Ulta;
                ItemText = "Инвентарь:\r\n" + CurrentNPC.Item;
                TollTipNPS = CurrentNPC.Notee;
                ImageInfo = PathNPC + CurrentNPC.Imag;
                CurrEvent = TypeEven.NPC;
                if (CurrentNPC.Sounds != "")
                    BackSEn = true;
                Items = ListItems.Where(x => x.IdPerson == CurrentNPC.Id && x.Person == 2).ToList();
            };
        }
        public void ViewUser()
        {
            if (CurrentUser != null)
            {
                ToolTipU = "id = " + CurrentUser.Id.ToString();
                UserInfo = "Оружие:\r\n" + CurrentUser.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentUser.Equip + "\r\n\r\nИнвинтарь:\r\n" + CurrentUser.Item + "\r\n\r\nСпособности:\r\n" + CurrentUser.Abilities + "\r\n\r\nЗаклинания:\r\n" + CurrentUser.Ulta + "\r\n\r\nОписание:\r\n" + CurrentUser.Description;
                UserIcon = PathHero + CurrentUser.Imag;
                Items = ListItems.Where(x => x.IdPerson == CurrentUser.Id && x.Person == 1).ToList();
            }
        }
        public void ViewVersus()
        {
            if (CurrentVersus != null)
            {
                UserInfo = "Оружие:\r\n" + CurrentVersus.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentVersus.Equip + "\r\n\r\nИнвинтарь:\r\n" + CurrentVersus.Item + "\r\n\r\nСпособности:\r\n" + CurrentVersus.Abilities + "\r\n\r\nЗаклинания:\r\n" + CurrentVersus.Ulta + "\r\n\r\nОписание:\r\n" + CurrentVersus.Description;
                if (CurrentVersus.Person == "Hero")
                {
                    UserIcon = PathHero + CurrentVersus.Imag;
                }
                else
                {
                    UserIcon = PathNPC + CurrentVersus.Imag;
                }
               
            }
        }
        public void ViewImagIn()
        {
            if (CurrentNPC != null)
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
                    PreVeiwWindow.ShowImag(CurrentNPC.Imag, TypeEven.NPC);
                    VisibilityImag = true;
                }
            }
        }

        public bool CheckPushBtn(string x)
        {
            switch(x)
            {
                case "NumPad":
                    if(VisibilityInfo == Visibility.Hidden)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        public void Push(int e)
        {
            switch(e)
            {
                case 0:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
                case 1:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
                case 2:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
                case 3:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
                case 4:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
                case 5:
                    if (CheckPushBtn("NumPad"))
                    {
                        if (arr.Count() >= e+1)
                            ShowImag(e);
                    }
                    break;
            }
        }
        //PlayAndStop(TypeSound.Back, CurrEvent)
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
        public ICommand NPCStep { get; set; }
        public ICommand ResultDefence { get; set; }
        public ICommand ResultHealth1 { get; set; }
        public ICommand ResultHealth2 { get; set; }
        public ICommand ResultHealth3 { get; set; }
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
        public ICommand IntoBattlePrint { get; set; }
        public ICommand Logo { get; set; }
        public ICommand Transfer { get; set; }
        public ICommand Garbage { get; set; }
        public ICommand Delete { get; set; }
        public ICommand ShowNote { get; set; }
        public ICommand EditNoteBtn { get; set; }
        public ICommand WriteNodeText { get; set; }
        public ICommand CanсelNode { get; set; }
        private ICommand _push1Btn;
        public ICommand Push1Btn
        {
            get
            {
                return _push1Btn
                    ?? (_push1Btn = new ActionCommand(() =>
                    {
                        Push(0);
                    }));
            }
        }
        private ICommand _push2Btn;
        public ICommand Push2Btn
        {
            get
            {
                return _push2Btn
                    ?? (_push2Btn = new ActionCommand(() =>
                    {
                        Push(1);
                    }));
            }
        }
        private ICommand _push3Btn;
        public ICommand Push3Btn
        {
            get
            {
                return _push3Btn
                    ?? (_push3Btn = new ActionCommand(() =>
                    {
                        Push(2);
                    }));
            }
        }
        private ICommand _push4Btn;
        public ICommand Push4Btn
        {
            get
            {
                return _push4Btn
                    ?? (_push4Btn = new ActionCommand(() =>
                    {
                        Push(3);
                    }));
            }
        }
        private ICommand _push5Btn;
        public ICommand Push5Btn
        {
            get
            {
                return _push5Btn
                    ?? (_push5Btn = new ActionCommand(() =>
                    {
                        Push(4);
                    }));
            }
        }
        private ICommand _push6Btn;
        public ICommand Push6Btn
        {
            get
            {
                return _push6Btn
                    ?? (_push6Btn = new ActionCommand(() =>
                    {
                        Push(5);
                    }));
            }
        }
        private ICommand _push7Btn;
        public ICommand Push7Btn
        {
            get
            {
                return _push7Btn
                    ?? (_push7Btn = new ActionCommand(() =>
                    {
                        ClianTextBoxVeiw();
                    }));
            }
        }
        private ICommand _push8Btn;
        public ICommand Push8Btn
        {
            get
            {
                return _push8Btn
                    ?? (_push8Btn = new ActionCommand(() =>
                    {
                        PlayAndStop(CurrEvent);
                    }));
            }
        }
        private ICommand _push9Btn;
        public ICommand Push9Btn
        {
            get
            {
                return _push9Btn
                    ?? (_push9Btn = new ActionCommand(() =>
                    {
                        EditStep();
                    }));
            }
        }
        private ICommand _push0Btn;
        public ICommand Push0Btn
        {
            get
            {
                return _push0Btn
                    ?? (_push0Btn = new ActionCommand(() =>
                    {
                        VisibilitzLogo();
                    }));
            }
        }
        private ICommand _pushDivideBtn;
        public ICommand PushDivideBtn
        {
            get
            {
                return _pushDivideBtn
                    ?? (_pushDivideBtn = new ActionCommand(() =>
                    {
                        SummaCh(1);
                    }));
            }
        }
        private ICommand _pushMultiplyBtn;
        public ICommand PushMultiplyBtn
        {
            get
            {
                return _pushMultiplyBtn
                    ?? (_pushMultiplyBtn = new ActionCommand(() =>
                    {
                        SummaCh(2);
                    }));
            }
        }
        private ICommand _pushSubtractBtn;
        public ICommand PushSubtractBtn
        {
            get
            {
                return _pushSubtractBtn
                    ?? (_pushSubtractBtn = new ActionCommand(() =>
                    {
                        SummaCh(3);
                    }));
            }
        }
        private ICommand _pushAddBtn;
        public ICommand PushAddBtn
        {
            get
            {
                return _pushAddBtn
                    ?? (_pushAddBtn = new ActionCommand(() =>
                    {
                        PreVeiwWindow.EditShit(NpcStep);
                    }));
            }
        }
        private ICommand _pushDeleteBtn;
        public ICommand PushDeleteBtn
        {
            get
            {
                return _pushDeleteBtn
                    ?? (_pushDeleteBtn = new ActionCommand(() =>
                    {
                        ShowWindowVS();
                    }));
            }
        }
        #endregion
    }
}
