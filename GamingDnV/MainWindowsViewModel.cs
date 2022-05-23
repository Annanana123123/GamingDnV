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
            RecrutBtn = new RelayCommand(() => Recrutirivanie());
            TrackSound = new RelayCommand(() => PlayAndStop(CurrEvent));
            ComboOk = new RelayCommand(() => LoadHystory());
            CloseVersus = new RelayCommand(() => CloseVersusWin());
            BtnL = new RelayCommand(() => CurrentV(1));
            BtnR = new RelayCommand(() => CurrentV(2));
            ExportBtn = new RelayCommand(() => Export());
            ExportShopBtn = new RelayCommand(() => ExportShop());
            Logo = new RelayCommand(() => VisibilitzLogo());
            Transfer = new RelayCommand(() => TransferItem(false));
            Delete = new RelayCommand(() => DeleteItem());
            Shop = new RelayCommand(() => ShopItem());
            Garbage = new RelayCommand(() => GarbageItem());
            ShowNote = new RelayCommand(() => ViewNote());
            EditNoteBtn = new RelayCommand(() => EditNote());
            WriteNodeText = new RelayCommand(() => WriteEditNote());
            CanсelNode = new RelayCommand(() => EditNote());
            DbConnectBtn = new RelayCommand(() => ConnectDB());
            SaveBtn = new RelayCommand(() => SaveDb());
            ArmorItemBtn = new RelayCommand(() => FilterShop(TypeItem.Armor));
            EqipItemBtn = new RelayCommand(() => FilterShop(TypeItem.Eqip));
            MuniItemBtn = new RelayCommand(() => FilterShop(TypeItem.Muni));
            VersItemBtn = new RelayCommand(() => FilterShop(TypeItem.Vers));
            UnieItemBtn = new RelayCommand(() => FilterShop(TypeItem.Unie));
            BladItemBtn = new RelayCommand(() => FilterShop(TypeItem.Blad));
            WaterItemBtn = new RelayCommand(() => FilterShop(TypeItem.Water));
            TransferPrice = new RelayCommand(() => TransferItem(true));
            CloseShopBtn = new RelayCommand(() => CloseShop());
            MinusBtn = new RelayCommand(() => MinusItem("-"));
            PlusBtn = new RelayCommand(() => MinusItem("+"));
            VisibilityInfo = Visibility.Hidden;
            VisibilityLoad = Visibility.Visible;
            VisibilityVersus = Visibility.Hidden;
            VisibilityShop = Visibility.Hidden;
            VisibilityPrintI = Visibility.Hidden;
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
            DbConnect = "Подключение";
            BackSEn = false;
            AtacSEn = false;
            TrackSEn = false;
    }

        #endregion

        #region Свойства
        public bool logo = false;
        public bool versus = true;
        public bool shop = false;
        public string History = "";
        public PreViewModel PreVeiwWindow { get; set; }
        public LoaderViewModel Loader { get; } = new LoaderViewModel();
        List < NoteModel > ListNote = new List<NoteModel>();
        List<HistoryModel> ListHistory = new List<HistoryModel>();
        //ObservableCollection<UsersModel> Users = new ObservableCollection<UsersModel>();
        //ObservableCollection<NPCModel> NPC = new ObservableCollection<NPCModel>();


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

        private string _dbConnect;
        public string DbConnect
        {
            get { return _dbConnect; }
            set
            {
                _dbConnect = value;

                RaisePropertyChanged(nameof(DbConnect));
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

        private string _print;
        public string Print
        {
            get { return _print; }
            set
            {
                _print = value;

                RaisePropertyChanged(nameof(Print));
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
        private ComboBoxBD _selectBD;
        public ComboBoxBD SelectBD
        {
            get { return _selectBD; }
            set
            {
                _selectBD = value;
                RaisePropertyChanged(nameof(SelectBD));
                ConnectBD();
            }
        }
        private List<ComboBoxBD> _comboBoxBDItem;
        public List<ComboBoxBD> ComboBoxBDItem
        {
            get { return _comboBoxBDItem; }
            set
            {
                _comboBoxBDItem = value;

                RaisePropertyChanged(nameof(ComboBoxBDItem));
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
        private Visibility _visibilityShop;
        public Visibility VisibilityShop
        {
            get { return _visibilityShop; }
            set
            {
                _visibilityShop = value;
                RaisePropertyChanged(nameof(VisibilityShop));
            }
        }
        private Visibility _visibilityPrintI;
        public Visibility VisibilityPrintI
        {
            get { return _visibilityPrintI; }
            set
            {
                _visibilityPrintI = value;
                RaisePropertyChanged(nameof(VisibilityPrintI));
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

        private ObservableCollection<PersonModel> _versusTable;
        public ObservableCollection<PersonModel> VersusTable
        {
            get { return _versusTable; }
            set
            {
                _versusTable = value;

                RaisePropertyChanged(nameof(VersusTable));
            }
        }

        private ObservableCollection<PersonModel> _npcTable;
        public ObservableCollection<PersonModel> NPCTable
        {
            get { return _npcTable; }
            set
            {
                _npcTable = value;

                RaisePropertyChanged(nameof(NPCTable));
            }
        }

        private ObservableCollection<PersonModel> _herosTable;
        public ObservableCollection<PersonModel> HerosTable
        {
            get { return _herosTable; }
            set
            {
                _herosTable = value;
        
                RaisePropertyChanged(nameof(HerosTable));
            }
        }

        private List<ItemsModel> _itemShopTable;
        public List<ItemsModel> ItemShopTable
        {
            get { return _itemShopTable; }
            set
            {
                _itemShopTable = value;

                RaisePropertyChanged(nameof(ItemShopTable));
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

        private string _imageItem;
        public string ImageItem
        {
            get { return _imageItem; }
            set
            {
                _imageItem = value;

                RaisePropertyChanged(nameof(ImageItem));
            }
        }

        private string _itemTextPrint;
        public string ItemTextPrint
        {
            get { return _itemTextPrint; }
            set
            {
                _itemTextPrint = value;

                RaisePropertyChanged(nameof(ItemTextPrint));
            }
        }

        private string _abTextPrint;
        public string AbTextPrint
        {
            get { return _abTextPrint; }
            set
            {
                _abTextPrint = value;

                RaisePropertyChanged(nameof(AbTextPrint));
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
                CurrentI();
            }
        }

        private PersonModel _currentNPC;
        public PersonModel CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                ViewNPC();
            }
        }

        private PersonModel _currentUser;
        public PersonModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                ViewUser();
            }
        }

        private PersonModel _currentVerusu;
        public PersonModel CurrentVersus
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
        ObservableCollection<AbilitiesModel> ListAbilities = new ObservableCollection<AbilitiesModel>();
        ObservableCollection<AbilitiesModel> ListUlta = new ObservableCollection<AbilitiesModel>();
        ObservableCollection<PersonModel> ListNpc = new ObservableCollection<PersonModel>();
        ObservableCollection<PersonModel> ListHero = new ObservableCollection<PersonModel>();
        ObservableCollection<PersonModel> ListHeroProof = new ObservableCollection<PersonModel>();
        ObservableCollection<PersonModel> ListPerson= new ObservableCollection<PersonModel>();
        ObservableCollection<PersonModel> Versus = new ObservableCollection<PersonModel>();
        List<ItemsModel> ListShop = new List<ItemsModel>();
        public PersonModel LCurr = new PersonModel();
        public PersonModel RCurr = new PersonModel();

        public static string constr = "provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
        public string constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        //public static string constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";

        #endregion

        #region Методы

        public void ConnectBD()
        {
            if (SelectBD is null)
            {
                constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
            }
            else
            {
                if (SelectBD.BD == "Бой")
                {
                    constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";
                }
                else
                {
                    constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
                }
            }
        }

        public void ConnectDB()
        {
            if (UpdataBD.TestConnect(constrInt) == TypeResult.Ok)
            {
                DbConnect = "Готово";
            }
            else
            {
                DbConnect = "Повтор";
            }
        }

        #region Команда Экспорт

        public async void Export()
        {
            try
            {
                Loader.LoaderVisibility = Visibility.Visible;
                int CountOperation = 0;
                int prog = 0;
                PersonModel CurrHeroProof = ListHeroProof.First(x => x.Id == CurrentUser.Id);
                CountOperation += ListAbilities.Where(x => x.IdPerson == CurrHeroProof.Id).Count();
                CountOperation += ListUlta.Where(x => x.IdPerson == CurrHeroProof.Id).Count();
                CountOperation += ListItems.Where(x => x.IdPerson == CurrHeroProof.Id && x.Person == 1).Count();
                Loader.ProgressView(0, CountOperation);
                
                if (await ExportHero(CurrHeroProof) == TypeResult.Ok)
                {
                    prog++;
                    Loader.ProgressView(prog, CountOperation);
                }

                foreach (AbilitiesModel a in ListAbilities.Where(x => x.IdPerson == CurrHeroProof.Id).ToList())
                {
                    if (await ExportAbil(a, "wp_abilities", CurrHeroProof.Id) == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                foreach (AbilitiesModel a in ListUlta.Where(x => x.IdPerson == CurrHeroProof.Id).ToList())
                {
                    if (await ExportAbil(a, "wp_ulta", CurrHeroProof.Id) == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                await ExportItem("wp_items", CurrHeroProof.Id);
                foreach (ItemsModel a in ListItems.Where(x => x.IdPerson == CurrHeroProof.Id && x.Person == 1).ToList())
                {
                    if (await ExportItem(a, "wp_items", CurrHeroProof.Id) == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                Loader.LoaderVisibility = Visibility.Hidden;
                UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1", constrInt);
            }
            catch
            {
                MessageBox.Show("Что-то не так!");
                Loader.LoaderVisibility = Visibility.Hidden;
            }
        }

        public async Task<TypeResult> ExportItem(string table, int IdHero)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateItem_0(table, IdHero, constrInt);
            });
            return result;
        }

        public async Task<TypeResult> ExportItem(ItemsModel CurrItem, string table, int IdHero)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateItem(CurrItem, table, IdHero, constrInt);
            });
            return result;
        }

        public async Task<TypeResult> ExportAbil(AbilitiesModel CurrAbil, string table, int IdHero)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateAbil(CurrAbil, table, IdHero, constrInt);
            });
            return result;
        }

        public async Task<TypeResult> ExportHero(PersonModel CurrHeroProof)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result =  await UpdataBD.UpdateHero(CurrHeroProof, constrInt);
            });
            return result;
        }
        #endregion

        #region Команда Экспорта магазина

        public async void ExportShop()
        {
            ShopItem();
            try
            {
                Loader.LoaderVisibility = Visibility.Visible;
                int CountOperation = -1;
                int prog = 0;
                CountOperation += ListShop.Count();
                CountOperation += ListItems.Where(x => x.IdPerson == 0 || x.Person != 1).Count();
                Loader.ProgressView(0, CountOperation);

                foreach (ItemsModel a in ListShop)
                {
                    if (await ExportShop(a, "wp_shop") == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                foreach (ItemsModel a in ListItems.Where(x => x.IdPerson == 0 || x.Person != 1).ToList())
                {
                    if (await ExportItem(a, "wp_items") == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                Loader.LoaderVisibility = Visibility.Hidden;
            }
            catch
            {
                MessageBox.Show("Что-то не так!");
                Loader.LoaderVisibility = Visibility.Hidden;
            }
        }

        public async Task<TypeResult> ExportItem(ItemsModel CurrItem, string table)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateItem(CurrItem, table, constrInt);
            });
            return result;
        }

        public async Task<TypeResult> ExportShop(ItemsModel CurrItem, string table)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateShop(CurrItem, table, constrInt);
            });
            return result;
        }

        #endregion

        #region Команда сохранить

        public async void SaveDb()
        {
            try
            {
                Loader.LoaderVisibility = Visibility.Visible;

                int CountOperation = -1;
                int prog = 0;
                CountOperation += ListHero.Count();
                Loader.ProgressView(0, CountOperation);
                foreach (var d in ListHero)
                {
                    d.Ervaring += d.PlusErvaring;
                    d.PlusErvaring = 0;
                    d.LevelUp = LevelMath(d.Ervaring);
                    UpdataBD.UpdataInDb("UPDATE `theros` SET `Defence`=" + d.Defence + ",`Health`=" + d.Health + ",`Power`=" + d.Power + ",`Dexterity`=" + d.Dexterity + ",`Endurance`=" + d.Endurance + ",`Wisdom`=" + d.Wisdom + ",`Intelligence`=" + d.Intelligence + ",`Charisma`=" + d.Charisma + ", `Gold`=" + d.Gold + ", `Ervaring`=" + d.Ervaring + " WHERE `Id`=" + d.Id, constr);
                    if (await SaveHero(d, "wp_hero") == TypeResult.Ok)
                    {
                        prog++;
                        Loader.ProgressView(prog, CountOperation);
                    }
                }
                UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1", constrInt);
                Loader.LoaderVisibility = Visibility.Hidden;
            }
            catch
            {
                Loader.LoaderVisibility = Visibility.Hidden;
            }
        }

        public async Task<TypeResult> SaveHero(PersonModel CurrHer, string table)
        {
            TypeResult result = new TypeResult();
            await Task.Run(async () =>
            {
                result = await UpdataBD.UpdateHero(CurrHer, table, constrInt);
            });
            return result;
        }
        #endregion

        public void Recrutirivanie()
        {
            if (CurrentNPC != null)
            {
                ListHero.Add(CurrentNPC);
                HerosTable = ListHero;
                ReadBD.WriteBD("UPDATE `tNPC` SET `Person` = 1 WHERE `Id` = " + CurrentNPC.Id + ";");
            }
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
                PreVeiwWindow.VisibilityLogo(History, ListHistory[0].Imag);
                logo = true;
            }
        }
        public void CloseVersusWin()
        {
            VisibilityVersus = Visibility.Hidden;
            VisibilityPrintI = Visibility.Hidden;
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
                
                ListHistory = ReadBD.ReadHistoryInDb("SELECT Name, Imag FROM tHistorys WHERE Id = " + SelectItem.Id + ";");
                History = ListHistory[0].Name;
                Rooms = ReadBD.ReadRoomsInDb("SELECT Id, Name, TextRoom, Images, Sounts FROM tRooms WHERE HistoryId = " + SelectItem.Id + " ORDER BY tRooms.Order;");
                ListEvent = ReadBD.ReadEventInDb("SELECT Id, Name, TextEvent, Images, Sounds, Order, RoomId FROM tEvents WHERE RoomId in (" + WhereIn() + ");");

                ListPerson = ReadBD.ReadPersonInDb(" SELECT a.Id, a.Name, a.RoomId, a.Notee, a.Defence, a.Health, a.Power, a.Dexterity, a.Endurance, a.Wisdom, a.Intelligence, a.Charisma, a.Passiv, a.Species, a.Class, a.Abilities, a.Ulta, a.History, a.Imag, a.Arms, a.Equip, a.Description, a.Sound, a.Person, a.Gold, b.Id, a.Ervaring, a.P, a.D, a.E, a.W, a.I, a.C FROM tHeros as a inner join tErvaring as b on a.Ervaring >= b.Ervaring and a.Ervaring < b.ErvaringUp WHERE HistoryId =" + SelectItem.Id +
                                                   " union all" +
                                                   " SELECT Id, Name, RoomId, Notee, Defence, Health, Power, Dexterity, Endurance, Wisdom, Intelligence, Charisma, Passiv, Species, Class, Abilities, Ulta, History, Imag, Arms, Equip, Description, Sound, Person, Gold, LevelUp, Ervaring, P, D, E, W, I, C FROM tNPC WHERE HistoryId =" + SelectItem.Id);
                ListNpc = new ObservableCollection<PersonModel>(ListPerson.Where(x => x.Person == 2).ToList());
                ListHeroProof = new ObservableCollection<PersonModel>(ListPerson.Where(x => x.Person == 1).ToList());
                ListAbilities = ReadBD.ReadAbilitiesInDb("SELECT Id, Name, Notee, IdPerson, Enabled, Order FROM tAbilities WHERE IdPerson in (" + WhereInHeros(ListHeroProof) + ") order by `Order`;");
                ListUlta = ReadBD.ReadAbilitiesInDb("SELECT Id, Name, Notee, IdPerson, Enabled, Order FROM tUlta WHERE IdPerson in (" + WhereInHeros(ListHeroProof) + ");");
                ListHero = HeroEdit(ListHeroProof);
                ListNpc = HeroEdit(ListNpc);
                HerosTable = ListHero;
                ListItems = WhereItems();
                ListNote = ReadBD.ReadNoteInDb("SELECT Id, Name, Notee, HistoryId FROM tNote WHERE HistoryId in (0, " + SelectItem.Id + ");");
                TextNote = Note(ListNote);
                TextWriteNode = ReadBD.ReadWriteNoteInDb("SELECT Text FROM tWriteNode WHERE id = 1");
            }
        }

        public ObservableCollection<PersonModel> HeroEdit(ObservableCollection<PersonModel> heroProof)
        {
            foreach (var h in heroProof)
            {
                h.Po = ConvertorSpecificatie(h.Power, h.P);
                h.De = ConvertorSpecificatie(h.Dexterity, h.D);
                h.En = ConvertorSpecificatie(h.Endurance, h.E);
                h.Wi = ConvertorSpecificatie(h.Wisdom, h.W);
                h.In = ConvertorSpecificatie(h.Intelligence, h.I);
                h.Ch = ConvertorSpecificatie(h.Charisma, h.C);
            }

            return heroProof;
        }

        public int ConvertorSpecificatie(int s, int d)
        {
            int spec = 0;
            if (s == 1) { spec = -5; }
            if (s == 2 || s == 3) { spec = -4; }
            if (s == 4 || s == 5) { spec = -3; }
            if (s == 6 || s == 7) { spec = -2; }
            if (s == 8 || s == 9) { spec = -1; }
            if (s == 10 || s == 11) { spec = 0; }
            if (s == 12 || s == 13) { spec = 1; }
            if (s == 14 || s == 15) { spec = 2; }
            if (s == 16 || s == 17) { spec = 3; }
            if (s == 18 || s == 19) { spec = 4; }
            if (s == 20 || s == 21) { spec = 5; }
            if (s == 22 || s == 23) { spec = 6; }
            if (s == 24 || s == 25) { spec = 7; }
            if (s == 26 || s == 27) { spec = 8; }
            if (s == 28 || s == 29) { spec = 9; }
            if (s == 30) { spec = 10; }
            spec += d;
            return spec;
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

        public void ShopItem()
        {
            VisibilityShop = Visibility.Visible;
            shop = true;
            ListShop = ReadBD.ReadItemsInDb("SELECT Id, Name, Notee, IdPerson, Person, Count, Imag, Type, Price, Id FROM tShop;");
            ItemShopTable = ListShop.OrderBy(c => c.Name).ToList();
        }

        public void CloseShop()
        {
            VisibilityShop = Visibility.Hidden;
            shop = false;
        }

        public void FilterShop(TypeItem type)
        {
            switch(type)
            {
                case TypeItem.Armor:
                    ItemShopTable = ListShop.Where(x => x.Type == 1).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Eqip:
                    ItemShopTable = ListShop.Where(x => x.Type == 2).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Muni:
                    ItemShopTable = ListShop.Where(x => x.Type == 3).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Vers:
                    ItemShopTable = ListShop.Where(x => x.Type == 0).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Unie:
                    ItemShopTable = ListShop.Where(x => x.Type == 4).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Blad:
                    ItemShopTable = ListShop.Where(x => x.Type == 5).OrderBy(c => c.Name).ToList();
                    break;
                case TypeItem.Water:
                    ItemShopTable = ListShop.Where(x => x.Type == 6).OrderBy(c => c.Name).ToList();
                    break;
            }
        }

        public void MinusItem(string p)
        {
            if (CurrentUser != null && CurrentItems != null)
            {
                if (CurrentItems.Count > 1)
                {
                    if (p == "-")
                        CurrentItems.Count--;
                    else
                        CurrentItems.Count++;
                    ReadBD.WriteBD("UPDATE tItems SET `Count` = " + CurrentItems.Count + " WHERE Id = " + CurrentItems.Id);
                    UpdataBD.Update("UPDATE `wp_items` SET `Count` = " + CurrentItems.Count + " WHERE Id = " + CurrentItems.Id, constrInt);
                    UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1", constrInt);
                    Items = ListItems.Where(x => x.IdPerson == CurrentUser.Id && x.Person == 1).ToList();
                }
                else
                {
                    ReadBD.WriteBD("DELETE FROM tItems WHERE Id = " + CurrentItems.Id);
                    UpdataBD.Update("DELETE FROM `wp_items` WHERE Id = " + CurrentItems.Id, constrInt);
                    UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1", constrInt);
                    int t = 0;
                    foreach (var n in ListItems)
                    {
                        if (n.Id == CurrentItems.Id)
                        {
                            break;
                        }
                        t++;
                    }
                    ListItems.RemoveAt(t);
                    Items = ListItems.Where(x => x.IdPerson == CurrentUser.Id && x.Person == 1).ToList();
                }
                //if (ReadBD.GetId("SELECT `Id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.IdItemShop + " AND IdPerson = " + CurrentUser.Id + ";") > 0)
                //{
                //    int IdEdit = ReadBD.GetId("SELECT `id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.IdItemShop + " AND IdPerson = " + CurrentUser.Id + ";");
                //    int CountEdit = ReadBD.GetId("SELECT `Count` FROM `tItems` WHERE Id = " + IdEdit + ";");
                //    CountEdit++;
                //    ReadBD.WriteBD("UPDATE tItems SET `Count` = " + CountEdit + " WHERE Id = " + IdEdit);
                //    var Edit = ListItems.Where(x => x.Id == IdEdit).ToList();
                //    Edit[0].Count = CountEdit;
                //}
                //else
                //{
                //    ReadBD.WriteBD("INSERT INTO `tItems` (`IdItemShop`, `IdPerson`, `Person`, `Count`) VALUES (" + CurrentItems.Id + ", " + CurrentUser.Id + ", '1', " + CurrentItems.Count + ")");
                //    int MaxId = ReadBD.GetMaxId("SELECT max(id) FROM `tItems`");
                //    ListItems.Add(new ItemsModel()
                //    {
                //        Id = MaxId,
                //        Name = CurrentItems.Name,
                //        Notee = CurrentItems.Notee,
                //        IdPerson = CurrentUser.Id,
                //        Person = 1,
                //        Count = CurrentItems.Count,
                //        Imag = CurrentItems.Imag,
                //        Type = CurrentItems.Type,
                //        Price = CurrentItems.Price,
                //        IdItemShop = CurrentItems.IdItemShop
                //    });
                //}
            }
        }

        public void TransferItem(bool prise)
        {
            if (CurrentUser != null && CurrentItems != null)
            {
                if (shop)
                {
                    int currPer = CurrentItems.Person;
                    int currId = CurrentItems.IdPerson;
                    if (ReadBD.GetId("SELECT `Id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.Id + " AND IdPerson = "+ CurrentUser.Id +";") > 0)
                    {
                        int IdEdit = ReadBD.GetId("SELECT `id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.Id + " AND IdPerson = " + CurrentUser.Id + ";");
                        int CountEdit = ReadBD.GetId("SELECT `Count` FROM `tItems` WHERE Id = " + IdEdit + ";");
                        CountEdit++;
                        ReadBD.WriteBD("UPDATE tItems SET `Count` = " + CountEdit + " WHERE Id = " + IdEdit);
                        var Edit = ListItems.Where(x => x.Id == IdEdit).ToList();
                        Edit[0].Count = CountEdit;
                        if (prise)
                        {
                            int GoldEdit = ReadBD.GetId("SELECT `Gold` FROM `tHeros` WHERE Id = " + CurrentUser.Id + ";");
                            GoldEdit -= CurrentItems.Price;
                            ReadBD.WriteBD("UPDATE tHeros SET `Gold` = " + GoldEdit + " WHERE Id = " + CurrentUser.Id);
                            HerosTable.First(x => x.Id == CurrentUser.Id).Gold = GoldEdit;
                        }
                    }
                    else
                    {
                        ReadBD.WriteBD("INSERT INTO `tItems` (`IdItemShop`, `IdPerson`, `Person`, `Count`) VALUES (" + CurrentItems.Id + ", " + CurrentUser.Id + ", '1', "+ CurrentItems.Count + ")");
                        int MaxId = ReadBD.GetMaxId("SELECT max(id) FROM `tItems`");
                        ListItems.Add(new ItemsModel()
                        {
                            Id = MaxId,
                            Name = CurrentItems.Name,
                            Notee = CurrentItems.Notee,
                            IdPerson = CurrentUser.Id,
                            Person = 1,
                            Count = CurrentItems.Count,
                            Imag = CurrentItems.Imag,
                            Type = CurrentItems.Type,
                            Price = CurrentItems.Price,
                            IdItemShop = CurrentItems.IdItemShop
                        });
                        if (prise)
                        {
                            int GoldEdit = ReadBD.GetId("SELECT `Gold` FROM `tHeros` WHERE Id = " + CurrentUser.Id + ";");
                            GoldEdit -= CurrentItems.Price;
                            ReadBD.WriteBD("UPDATE tHeros SET `Gold` = " + GoldEdit + " WHERE Id = " + CurrentUser.Id);
                            HerosTable.First(x => x.Id == CurrentUser.Id).Gold = GoldEdit;
                        }
                    }
                }
                else
                {
                    if (ReadBD.GetId("SELECT `Id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.IdItemShop + " AND IdPerson = " + CurrentUser.Id + ";") > 0)
                    {
                        int IdEdit = ReadBD.GetId("SELECT `id` FROM `tItems` WHERE IdItemShop = " + CurrentItems.IdItemShop + " AND IdPerson = " + CurrentUser.Id + ";");
                        int CountEdit = ReadBD.GetId("SELECT `Count` FROM `tItems` WHERE Id = " + IdEdit + ";");
                        CountEdit++;
                        ReadBD.WriteBD("UPDATE tItems SET `Count` = " + CountEdit + " WHERE Id = " + IdEdit);
                        var Edit = ListItems.Where(x => x.Id == IdEdit).ToList();
                        Edit[0].Count = CountEdit;
                    }
                    else
                    {
                        ReadBD.WriteBD("INSERT INTO `tItems` (`IdItemShop`, `IdPerson`, `Person`, `Count`) VALUES (" + CurrentItems.Id + ", " + CurrentUser.Id + ", '1', " + CurrentItems.Count + ")");
                        int MaxId = ReadBD.GetMaxId("SELECT max(id) FROM `tItems`");
                        ListItems.Add(new ItemsModel()
                        {
                            Id = MaxId,
                            Name = CurrentItems.Name,
                            Notee = CurrentItems.Notee,
                            IdPerson = CurrentUser.Id,
                            Person = 1,
                            Count = CurrentItems.Count,
                            Imag = CurrentItems.Imag,
                            Type = CurrentItems.Type,
                            Price = CurrentItems.Price,
                            IdItemShop = CurrentItems.IdItemShop
                        });
                        //int currPer = CurrentItems.Person;
                        //int currId = CurrentItems.IdPerson;
                        //ReadBD.WriteBD("UPDATE tItems SET IdPerson = " + CurrentUser.Id + ", Person = 1 WHERE Id = " + CurrentItems.Id);
                        //UpdataBD.Update("UPDATE wp_items SET IdPerson = " + CurrentUser.Id + " WHERE Id = " + CurrentItems.Id);
                        //UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1 WHERE `IpPerson`= " + CurrentUser.Id);
                        //CurrentItems.IdPerson = CurrentUser.Id;
                        //CurrentItems.Person = 1;
                        //Items = ListItems.Where(x => x.IdPerson == currId && x.Person == currPer).ToList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выбери героя или вещь!");
            }
        }
        

        public int LevelMath(int erv)
        {
            int lvl = 1;

            if (erv >= 0 && erv <= 299)
                lvl = 1;
            if (erv >= 300 && erv <= 899)
                lvl = 2;
            if (erv >= 900 && erv <= 2699)
                lvl = 3;
            if (erv >= 2700 && erv <= 6499)
                lvl = 4;
            if (erv >= 6500 && erv <= 13999)
                lvl = 5;
            if (erv >= 14000 && erv <= 22999)
                lvl = 6;
            if (erv >= 23000 && erv <= 33999)
                lvl = 7;
            if (erv >= 34000 && erv <= 47999)
                lvl = 8;

            return lvl;
        }

        public void DeleteItem()
        {
            if (CurrentItems != null)
            {
                int currPer = CurrentItems.Person;
                int currId = CurrentItems.IdPerson;
                ReadBD.WriteBD("UPDATE tItems SET IdPerson = 0, Person = 0 WHERE Id = " + CurrentItems.Id);
                UpdataBD.Update("UPDATE wp_items SET IdPerson = 0 WHERE Id = " + CurrentItems.Id, constrInt);
                UpdataBD.Update("UPDATE `wp_updata` SET `Item`=1", constrInt);
                CurrentItems.IdPerson = 0;
                CurrentItems.Person = 0;
                Items = ListItems.Where(x => x.IdPerson == currId && x.Person == currPer).ToList();
            }
        }

        public List<ItemsModel> WhereItems()
        {
            List<ItemsModel> item = new List<ItemsModel>();
            List<ItemsModel> item1 = new List<ItemsModel>();
            List<ItemsModel> item2 = new List<ItemsModel>();
            List<ItemsModel> item3 = new List<ItemsModel>();
            List<ItemsModel> item4 = new List<ItemsModel>();
            string id = "";
            foreach (var n in HerosTable)
            {
                id += n.Id + ", "; 
            }
            if (id != "")
                item1 = ReadBD.ReadItemsInDb("SELECT t.Id, s.Name, s.Notee, t.IdPerson, t.Person, t.Count, s.Imag, s.Type, s.Price, s.Id FROM tItems as t inner join tShop as s on t.IdItemShop = s.Id WHERE t.IdPerson in (" + id + ") and t.Person = 1;");

            id = "";
            foreach (var n in ListNpc)
            {
                id += n.Id + ", ";
            }
            if (id != "")
                item2 = ReadBD.ReadItemsInDb("SELECT s.Id, s.Name, s.Notee, s.IdPerson, s.Person, s.Count, s.Imag, s.Type, s.Price, s.Id FROM tShop as s WHERE s.IdPerson in (" + id + ") and s.Person = 2;");

            id = "";
            foreach (var n in Rooms)
            {
                id += n.Id + ", ";
            }
            if (id != "")
                item3 = ReadBD.ReadItemsInDb("SELECT s.Id, s.Name, s.Notee, s.IdPerson, s.Person, s.Count, s.Imag, s.Type, s.Price, s.Id FROM tShop as s WHERE s.IdPerson in (" + id + ") and s.Person = 3;");

            item4 = ReadBD.ReadItemsInDb("SELECT t.Id, s.Name, s.Notee, t.IdPerson, t.Person, t.Count, s.Imag, s.Type, s.Price, s.Id FROM tItems as t inner join tShop as s on t.IdItemShop = s.Id WHERE t.IdPerson = 0 and t.Person = 0;");
            item = new List<ItemsModel>(item1.Concat(item2.Concat(item3.Concat(item4))));
            return item;
        }

        public string WhereInHeros(ObservableCollection<PersonModel> hero)
        {
            string str = "";
            foreach (var d in hero)
            {
                str += d.Id + ", ";
            }
            return str;
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
                        Sound += CurrentNPC.Sound;
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
            VersusTable = new ObservableCollection<PersonModel>();
            Versus = new ObservableCollection<PersonModel>();
            
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
            ObservableCollection<PersonModel> VSs = new ObservableCollection<PersonModel>();
            if (versus)
            {
                foreach (var e in HerosTable)
                {
                    if (e.Atac != null)
                    {
                        Versus.Add(new PersonModel()
                        {
                            Id = e.Id,
                            Atac = e.Atac,
                            Person = 1,
                            RoomId = e.RoomId,
                            Name = e.Name,
                            Notee = e.Notee,
                            Defence = e.Defence,
                            Health = e.Health,
                            Po = e.Po,
                            De = e.De,
                            En = e.En,
                            Wi = e.Wi,
                            In = e.In,
                            Ch = e.Ch,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                            Arms = e.Arms,
                            Equip = e.Equip,
                            Passiv = e.Passiv,
                            Description = e.Description,
                        });
                    }
                }
                if (NPCTable != null)
                {
                    foreach (var e in NPCTable)
                    {
                        if (e.Atac != null)
                        {
                            Versus.Add(new PersonModel()
                            {
                                Id = e.Id,
                                Atac = e.Atac,
                                Person = 2,
                                RoomId = e.RoomId,
                                Name = e.Name,
                                Notee = e.Notee,
                                Defence = e.Defence,
                                Health = e.Health,
                                Arms = e.Arms,
                                Po = e.Po,
                                De = e.De,
                                En = e.En,
                                Wi = e.Wi,
                                In = e.In,
                                Ch = e.Ch,
                                Abilities = e.Abilities,
                                Ulta = e.Ulta,
                                Imag = e.Imag,
                                Equip = e.Equip
                            });
                        }
                    }
                }
                foreach (var e in Versus)
                {
                    if (e.Atac != null)
                    {
                        VSs.Add(new PersonModel()
                        {
                            Id = e.Id,
                            Atac = e.Atac,
                            Person = e.Person,
                            RoomId = e.RoomId,
                            Name = e.Name,
                            Notee = e.Notee,
                            Defence = e.Defence,
                            Health = e.Health,
                            Po = e.Po,
                            De = e.De,
                            En = e.En,
                            Wi = e.Wi,
                            In = e.In,
                            Ch = e.Ch,
                            Charisma = e.Charisma,
                            Abilities = e.Abilities,
                            Ulta = e.Ulta,
                            Imag = e.Imag,
                            Equip = e.Equip
                        });
                    }
                }
                Versus = new ObservableCollection<PersonModel>(VSs.OrderByDescending(e => e.Atac)); //Надо разобраться почему не работает сортировка

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
                            if (Versus[i].Atac != Versus[i + 1].Atac)
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
                foreach (var w in Versus.Where(x => x.Person == 1))
                {
                    HerosTable.First(x => x.Id == w.Id).Atac = w.Order;
                }
                foreach (var w in Versus.Where(x => x.Person == 2))
                {
                    NPCTable.First(x => x.Id == w.Id).Atac = w.Order;
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
                            case 1:
                                Versus.First(x => x.Id == w.Id).Order = Convert.ToInt32(HerosTable.First(x => x.Id == w.Id).Atac);
                                break;
                            case 2:
                                Versus.First(x => x.Id == w.Id).Order = Convert.ToInt32(NPCTable.First(x => x.Id == w.Id).Atac);
                                break;
                        }
                       
                    }
                }
                versus = true;
            }
            if (versus)
            {
                //Versus = HeroEdit(Versus);
                VersusTable = new ObservableCollection<PersonModel>(Versus.OrderByDescending(x => x.Atac).ToList());
                if (Versus[0].Person == 1)
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
                //string sql = "";
                string table = "";
                int result = 0;
                //int id = 0;
                if (NpcStep == false)
                {
                    //Ход Героя
                    if (VisibilityVersus == Visibility.Visible)
                    {
                        result = RCurr.Health - dam;
                        if (RCurr.Person == 1)
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
                        if (LCurr.Person == 1)
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
                PreVeiwWindow.LeftInBattleVeiw(CurrentUser.Imag, CurrentUser.Name, CurrentUser.Defence.ToString(), CurrentUser.Health.ToString(), CurrentUser.Person, CurrentUser.RoomId);
                PreVeiwWindow.EditShit(0);
            }
        }
        public void NPCInBattle()
        {
            if (CurrentNPC != null)
            {
                PreVeiwWindow.RightInBattleVeiw(CurrentNPC.Imag, CurrentNPC.Name, CurrentNPC.Defence.ToString(), CurrentNPC.Health.ToString(), CurrentNPC.Person, CurrentNPC.RoomId);
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
            summa = 0;
        }

        public void OnLoad()
        {
            List<ComboBoxModel> Combo = ReadBD.ReadHistory("SELECT Id, Name FROM tHistorys WHERE Visibility = 1;");
            ComboBoxItem = Combo;
            List<ComboBoxBD> BD = new List<ComboBoxBD>();
            BD.Add(new ComboBoxBD()
            {
                BD = "Тест"
            });
            BD.Add(new ComboBoxBD()
            {
                BD = "Бой"
            });
            ComboBoxBDItem = BD;
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
                        if (CurrentVersus.RoomId == 0)
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
                        PreVeiwWindow.LeftInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person, CurrentVersus.RoomId);
                        PreVeiwWindow.EditShit(0);
                        break;
                    case 2:
                        if (CurrentVersus.RoomId == 0)
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
                        PreVeiwWindow.RightInBattleVeiw(CurrentVersus.Imag, CurrentVersus.Name, CurrentVersus.Defence.ToString(), CurrentVersus.Health.ToString(), CurrentVersus.Person, CurrentVersus.RoomId);
                        PreVeiwWindow.EditShit(0);
                        break;
                }
            }
        }

        public void CurrentI()
        {
            if (CurrentItems != null)
            {
                UserInfo = CurrentItems.Notee;
                ImageItem = AppDomain.CurrentDomain.BaseDirectory + "Media\\Items\\" + CurrentItems.Imag;
            }
        }

        public void CurrentR()
        {
            ImageItem = "";
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
            NPCTable = new ObservableCollection<PersonModel>(ListNpc.Where(x => x.RoomId == CurrentRoom.Id).ToList());
            Items = ListItems.Where(x => x.IdPerson == CurrentRoom.Id && x.Person == 3).ToList();
        }

        public void CurrentE()
        {
            ImageItem = "";
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
                shop = false;
                BackSEn = false;
                AtacSEn = false;
                TrackSEn = false;
                ToolTipN = "id = " + CurrentNPC.Id.ToString();
                HP = CurrentNPC.Health.ToString();
                TextNPC = CurrentNPC.History + "\r\n\rСпособности:\r\n" + CurrentNPC.Abilities + "\r\n\rЗаклинание:\r\n" + CurrentNPC.Ulta;
                ItemText = "Инвентарь:\r\n" + ListViewItem(CurrentNPC);
                TollTipNPS = CurrentNPC.Notee;
                ImageInfo = PathNPC + CurrentNPC.Imag;
                CurrEvent = TypeEven.NPC;
                if (CurrentNPC.Sound != "")
                    BackSEn = true;
                Items = ListItems.Where(x => x.IdPerson == CurrentNPC.Id && x.Person == 2).ToList();
            };
        }
        public string ListViewItem(PersonModel use)
        {
            string str = "";
            foreach (var d in ListItems.Where(x => x.IdPerson == use.Id && x.Person == 1))
            {
                str += d.Name + " (x" + d.Count + ") " + " - " + d.Notee + "\r\n\r";
            }
            return str;
        }
        public void ViewUser()
        {
            ImageItem = "";
            if (CurrentUser != null)
            {
                shop = false;
                ToolTipU = "id = " + CurrentUser.Id.ToString();
                UserInfo = "Оружие:\r\n" + CurrentUser.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentUser.Equip + "\r\n\r\nСпособности:\r\n" + AbilitiesText(CurrentUser.Id, ListAbilities) + "\r\n\r\nЗаклинания:\r\n" + AbilitiesText(CurrentUser.Id, ListUlta);

                if (CurrentUser.RoomId == 0)
                {
                    UserIcon = PathHero + CurrentUser.Imag;
                }
                else
                {
                    UserIcon = PathNPC + CurrentUser.Imag;
                }
                Items = ListItems.Where(x => x.IdPerson == CurrentUser.Id && x.Person == 1).ToList();
            }
        }

        public string AbilitiesText(int id, ObservableCollection<AbilitiesModel> abil)
        {
            string text = "";
            // + CurrentUser.Abilities + "\r\n\r\nЗаклинания:\r\n" + CurrentUser.Ulta + "\r\n\r\nОписание:\r\n" + CurrentUser.Description;
            foreach (var d in abil.Where(x => x.IdPerson == id))
            {
                text += d.Name + " Ур." + d.Enabled + " - " + d.Notee + "\r\n\r\n";
            }
            return text;
        }

        public void ViewVersus()
        {
            if (CurrentVersus != null)
            {
                if (CurrentVersus.Person != 1)
                {
                    UserInfo = "Оружие:\r\n" + CurrentVersus.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentVersus.Equip + "\r\n\r\nСпособности:\r\n" + CurrentVersus.Abilities + "\r\n\r\nЗаклинания:\r\n" + CurrentVersus.Ulta;
                }
                else
                {
                    UserInfo = "Оружие:\r\n" + CurrentVersus.Arms + "\r\n\r\nЭкипировка:\r\n" + CurrentVersus.Equip + "\r\n\r\nИнвинтарь:\r\n" + ListViewItem(CurrentVersus) + "\r\n\r\nСпособности:\r\n" + AbilitiesText(CurrentVersus.Id, ListAbilities) + "\r\n\r\nЗаклинания:\r\n" + AbilitiesText(CurrentVersus.Id, ListUlta);
                }
                    if (CurrentVersus.RoomId == 0)
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
        public ICommand DbConnectBtn { get; set; }
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
        public ICommand RecrutBtn { get; set; }
        public ICommand TrackSound { get; set; }
        public ICommand CloseVersus { get; set; }
        public ICommand BtnL { get; set; }
        public ICommand BtnR { get; set; }
        public ICommand ExportBtn { get; set; }
        public ICommand ExportShopBtn { get; set; }
        public ICommand Logo { get; set; }
        public ICommand Transfer { get; set; }
        public ICommand Garbage { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Shop { get; set; }
        public ICommand ShowNote { get; set; }
        public ICommand EditNoteBtn { get; set; }
        public ICommand WriteNodeText { get; set; }
        public ICommand CanсelNode { get; set; }
        public ICommand SaveBtn { get; set; }
        public ICommand ArmorItemBtn { get; set; }
        public ICommand EqipItemBtn { get; set; }
        public ICommand MuniItemBtn { get; set; }
        public ICommand VersItemBtn { get; set; }
        public ICommand UnieItemBtn { get; set; }
        public ICommand BladItemBtn { get; set; }
        public ICommand WaterItemBtn { get; set; }
        public ICommand CloseShopBtn { get; set; }
        public ICommand TransferPrice { get; set; }
        public ICommand MinusBtn { get; set; }
        public ICommand PlusBtn { get; set; }
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
