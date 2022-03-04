using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingDnV.Views;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace GamingDnV.ViewModels
{
    public class PreViewModel : ViewModelBase
    {
        #region Свойства
        string PathHero = "";
        string PathNPC = "";
        string PathInterface = "";
        #endregion

        #region Конструктор

        public PreViewModel()
        {
            PathInterface = AppDomain.CurrentDomain.BaseDirectory + "/Media/Interface/";
            CloseWindow = new RelayCommand(() => Close());
            RightVisibility = Visibility.Hidden;
            LeftVisibility = Visibility.Hidden;
            VersusVisibility = Visibility.Hidden;
            RShitImg = PathInterface + "Shit0.png";
            LShitImg = PathInterface + "Shit0.png";
            L0 = PathInterface + "layer_0.png";
            L1 = PathInterface + "layer_1.png";
            H = PathInterface + "Hard.png";
            Cen = PathInterface + "CenterPanel.png";
            ScratchesR = PathInterface + "scratchesR.png";
            ScratchesL = PathInterface + "scratchesL.png";
            VisibilityR = Visibility.Hidden;
            VisibilityL = Visibility.Hidden;
            OpacityR = 1;
            OpacityL = 1;
            StartTimer();
        }

        #endregion

        #region Свойства

        public DispatcherTimer Timer = new DispatcherTimer();

        public PreView pv { get; set; }

        private Visibility _visibilityR;
        public Visibility VisibilityR
        {
            get { return _visibilityR; }
            set
            {
                _visibilityR = value;
                RaisePropertyChanged(nameof(VisibilityR));
            }
        }

        private Visibility _visibilityL;
        public Visibility VisibilityL
        {
            get { return _visibilityL; }
            set
            {
                _visibilityL = value;
                RaisePropertyChanged(nameof(VisibilityL));
            }
        }

        private Visibility _visibilityImageView;
        public Visibility VisibilityImageView
        {
            get { return _visibilityImageView; }
            set
            {
                _visibilityImageView = value;
                RaisePropertyChanged(nameof(VisibilityImageView));
            }
        }

        private Visibility _leftVisibility;
        public Visibility LeftVisibility
        {
            get { return _leftVisibility; }
            set
            {
                _leftVisibility = value;
                RaisePropertyChanged(nameof(LeftVisibility));
            }
        }
        private Visibility _rightVisibility;
        public Visibility RightVisibility
        {
            get { return _rightVisibility; }
            set
            {
                _rightVisibility = value;
                RaisePropertyChanged(nameof(RightVisibility));
            }
        }
        private Visibility _versusVisibility;
        public Visibility VersusVisibility
        {
            get { return _versusVisibility; }
            set
            {
                _versusVisibility = value;
                RaisePropertyChanged(nameof(VersusVisibility));
            }
        }
        
        private string _avaLeft;
        public string AvaLeft
        {
            get { return _avaLeft; }
            set
            {
                _avaLeft = value;

                RaisePropertyChanged(nameof(AvaLeft));
            }
        }

        private string _l0;
        public string L0
        {
            get { return _l0; }
            set
            {
                _l0 = value;

                RaisePropertyChanged(nameof(L0));
            }
        }

        private string _cen;
        public string Cen
        {
            get { return _cen; }
            set
            {
                _cen = value;

                RaisePropertyChanged(nameof(Cen));
            }
        }

        private string _h;
        public string H
        {
            get { return _h; }
            set
            {
                _h = value;

                RaisePropertyChanged(nameof(H));
            }
        }

        private string _l1;
        public string L1
        {
            get { return _l1; }
            set
            {
                _l1 = value;

                RaisePropertyChanged(nameof(L1));
            }
        }
        
        private string _scratchesR;
        public string ScratchesR
        {
            get { return _scratchesR; }
            set
            {
                _scratchesR = value;

                RaisePropertyChanged(nameof(ScratchesR));
            }
        }

        private double _opacityR;
        public double OpacityR
        {
            get { return _opacityR; }
            set
            {
                _opacityR = value;

                RaisePropertyChanged(nameof(OpacityR));
            }
        }

        private double _opacityL;
        public double OpacityL
        {
            get { return _opacityL; }
            set
            {
                _opacityL = value;

                RaisePropertyChanged(nameof(OpacityL));
            }
        }

        private string _scratchesL;
        public string ScratchesL
        {
            get { return _scratchesL; }
            set
            {
                _scratchesL = value;

                RaisePropertyChanged(nameof(ScratchesL));
            }
        }

        private string _avaRight;
        public string AvaRight
        {
            get { return _avaRight; }
            set
            {
                _avaRight = value;

                RaisePropertyChanged(nameof(AvaRight));
            }
        }

        private string _shitL;
        public string ShitL
        {
            get { return _shitL; }
            set
            {
                _shitL = value;

                RaisePropertyChanged(nameof(ShitL));
            }
        }
        private string _shitR;
        public string ShitR
        {
            get { return _shitR; }
            set
            {
                _shitR = value;

                RaisePropertyChanged(nameof(ShitR));
            }
        }

        private string _rShitImg;
        public string RShitImg
        {
            get { return _rShitImg; }
            set
            {
                _rShitImg = value;

                RaisePropertyChanged(nameof(RShitImg));
            }
        }
        private string _lShitImg;
        public string LShitImg
        {
            get { return _lShitImg; }
            set
            {
                _lShitImg = value;

                RaisePropertyChanged(nameof(LShitImg));
            }
        }

        private string _healthL;
        public string HealthL
        {
            get { return _healthL; }
            set
            {
                _healthL = value;

                RaisePropertyChanged(nameof(HealthL));
            }
        }
        private string _healthR;
        public string HealthR
        {
            get { return _healthR; }
            set
            {
                _healthR = value;

                RaisePropertyChanged(nameof(HealthR));
            }
        }

        private string _imageView;
        public string ImageView
        {
            get { return _imageView; }
            set
            {
                _imageView = value;

                RaisePropertyChanged(nameof(ImageView));
            }
        }

        private string _versusCH;
        public string VersusCH
        {
            get { return _versusCH; }
            set
            {
                _versusCH = value;

                RaisePropertyChanged(nameof(VersusCH));
            }
        }

        private string _nameLeft;
        public string NameLeft
        {
            get { return _nameLeft; }
            set
            {
                _nameLeft = value;

                RaisePropertyChanged(nameof(NameLeft));
            }
        }
        private string _nameRight;
        public string NameRight
        {
            get { return _nameRight; }
            set
            {
                _nameRight = value;

                RaisePropertyChanged(nameof(NameRight));
            }
        }
        #endregion
       
        #region Методы
        public void StartTimer()
        {
            Timer.Tick += new EventHandler(TimerTick);
            Timer.Interval = new TimeSpan( 0, 0, 0, 0, 500);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            OpacityR -= 0.1; 
            OpacityL -= 0.1;
            if (OpacityR == 0)
            {
                VisibilityR = Visibility.Hidden;
                Timer.Stop();
            }
            if (OpacityL == 0)
            {
                VisibilityL = Visibility.Hidden;
                Timer.Stop();
            }
        }

        public void CrashR()
        {
            OpacityR = 1;
            VisibilityR = Visibility.Visible;
            Timer.Start();
        }
        public void CrashL()
        {
            OpacityL = 1;
            VisibilityL = Visibility.Visible;
            Timer.Start();
        }

        public void EditShit(bool npsStep, int dem)
        {
            if (npsStep)
            {
                LShitImg = PathInterface + "Shit" + dem + ".png";
            }
            else
            {
                RShitImg = PathInterface + "Shit" + dem + ".png";
            }
        }

        public void EditShit(int dem)
        {
                LShitImg = PathInterface + "Shit" + dem + ".png";
                RShitImg = PathInterface + "Shit" + dem + ".png";
        }

        public void EditHP(bool npsStep, int hp)
        {
            if (npsStep)
            {
                HealthL = hp.ToString();
            }
            else
            {
                HealthR = hp.ToString();
            }
        }

        public void ViewVersus(string text)
        {
            VersusCH += text;
        }

        public void LeftInBattleVeiw(string imag, string name, string _shit, string _health)
        {
            AvaLeft = PathHero + imag;
            NameLeft = name;
            ShitL = _shit;
            HealthL = _health;
            //LeftVisibility = Visibility.Visible;
        }
        public void RightInBattleVeiw(string imag, string name, string _shit, string _health)
        {
            AvaRight = PathNPC + imag;
            NameRight = name;
            ShitR = _shit;
            HealthR = _health;
            //RightVisibility = Visibility.Visible;
        }
        public void EndBattle()
        {
            RightVisibility = Visibility.Hidden;
            LeftVisibility = Visibility.Hidden;
            VersusVisibility = Visibility.Hidden;
        }
        public void Clien()
        {
            LeftInBattleVeiw("", "", "", "");
            RightInBattleVeiw("", "", "", "");
        }
        public void StartBattle()
        {
            RightVisibility = Visibility.Visible;
            VersusVisibility = Visibility.Visible;
            LeftVisibility = Visibility.Visible;
        }
        public void ShowImag(string name)
        {
            ImageView = PathNPC + name;
            //ImageView = "../Images/NPC/" +name;
            VisibilityImageView = Visibility.Visible;
        }
        public void NoShowImag()
        {
            VisibilityImageView = Visibility.Hidden;
        }

        public void ShowWindowVS(int n)
        {
            pv = new PreView(this);
            pv.Show();
            PathHero = AppDomain.CurrentDomain.BaseDirectory + "/Media/Heros/";
            PathNPC = AppDomain.CurrentDomain.BaseDirectory + "/Media/Histotys_" + n + "/NPC/";
            
            VersusVisibility = Visibility.Visible;
        }
        public void Close()
        {
            pv.Close();
        }
        #endregion

        #region Команды

        public ICommand CloseWindow { get; set; }

        #endregion
    }
}
