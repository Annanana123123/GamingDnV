﻿using GalaSoft.MvvmLight;
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
using GamingDnV.Enums;

namespace GamingDnV.ViewModels
{
    public class PreViewModel : ViewModelBase
    {
        #region Свойства
        string PathHero = "";
        string PathNPC = "";
        string PathImag = "";
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
            VisibilityR = Visibility.Hidden;
            VisibilityL = Visibility.Hidden;
            ViB = Visibility.Hidden;
            ViT = Visibility.Hidden;
            OpacityR = 1;
            OpacityL = 1;
            StartTimer();
        }

        #endregion

        #region Свойства

        public DispatcherTimer Timer = new DispatcherTimer();

        public PreView pv { get; set; }

        private Visibility _viB;
        public Visibility ViB
        {
            get { return _viB; }
            set
            {
                _viB = value;
                RaisePropertyChanged(nameof(ViB));
            }
        }
        private Visibility _viT;
        public Visibility ViT
        {
            get { return _viT; }
            set
            {
                _viT = value;
                RaisePropertyChanged(nameof(ViT));
            }
        }

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

        private string _historyName;
        public string HistoryName
        {
            get { return _historyName; }
            set
            {
                _historyName = value;

                RaisePropertyChanged(nameof(HistoryName));
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

        private string _logoImag;
        public string LogoImag
        {
            get { return _logoImag; }
            set
            {
                _logoImag = value;

                RaisePropertyChanged(nameof(LogoImag));
            }
        }
        
        #endregion

        #region Методы
        public void StartTimer()
        {
            Timer.Tick += new EventHandler(TimerTick);
            Timer.Interval = new TimeSpan( 0, 0, 0, 0, 500);
        }

        public void VisibilityLogo(string his, string imag)
        {
            HistoryName = his;
            LogoImag = PathImag + imag;
            ViB = Visibility.Visible;
            ViT = Visibility.Visible;
        }
        public void NoVisibilityLogo()
        {
            ViB = Visibility.Hidden;
            ViT = Visibility.Hidden;
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

        public void CrashR(int s)
        {
            OpacityR = 1;
            switch (s)
            {
                case 1:
                    ScratchesR = PathInterface + "scratches1R.png";
                    ScratchesL = PathInterface + "scratches1L.png";
                    break;
                case 2:
                    ScratchesR = PathInterface + "scratches2R.png";
                    ScratchesL = PathInterface + "scratches2L.png";
                    break;
                case 3:
                    ScratchesR = PathInterface + "scratches3R.png";
                    ScratchesL = PathInterface + "scratches3L.png";
                    break;
            }
            VisibilityR = Visibility.Visible;
            Timer.Start();
        }
        public void CrashL(int s)
        {
            OpacityL = 1;
            switch (s)
            {
                case 1:
                    ScratchesR = PathInterface + "scratches1R.png";
                    ScratchesL = PathInterface + "scratches1L.png";
                    break;
                case 2:
                    ScratchesR = PathInterface + "scratches2R.png";
                    ScratchesL = PathInterface + "scratches2L.png";
                    break;
                case 3:
                    ScratchesR = PathInterface + "scratches3R.png";
                    ScratchesL = PathInterface + "scratches3L.png";
                    break;
            }
            VisibilityL = Visibility.Visible;
            Timer.Start();
        }

        public void EditShit(bool npsStep)
        {
            if (npsStep)
            {
                LShitImg = PathInterface + "Shit2.png";
            }
            else
            {
                RShitImg = PathInterface + "Shit2.png";
            }
        }

        public void EditShit(int dem)
        {
                LShitImg = PathInterface + "Shit0.png";
                RShitImg = PathInterface + "Shit0.png";
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

        public void LeftInBattleVeiw(string imag, string name, string _shit, string _health, int person, int room)
        {
            if (person == 1)
            {
                if (room == 0)
                {
                    AvaLeft = PathHero + imag;
                }
                else
                {
                    AvaLeft = PathNPC + imag;
                }
            }
            else
            {
                AvaLeft = PathNPC + imag;
            }
            NameLeft = name;
            ShitL = _shit;
            HealthL = _health;
        }
        public void RightInBattleVeiw(string imag, string name, string _shit, string _health, int person, int room)
        {
            if (person == 1)
            {
                if (room == 0)
                {
                    AvaRight = PathHero + imag;
                }
                else
                {
                    AvaRight = PathNPC + imag;
                }
            }
            else
            {
                AvaRight = PathNPC + imag;
            }
            
            NameRight = name;
            ShitR = _shit;
            HealthR = _health;
        }
        public void EndBattle()
        {
            RightVisibility = Visibility.Hidden;
            LeftVisibility = Visibility.Hidden;
            VersusVisibility = Visibility.Hidden;
        }
        public void Clien()
        {
            LeftInBattleVeiw("", "", "", "", 0, 0);
            RightInBattleVeiw("", "", "", "", 0, 0);
        }
        public void StartBattle()
        {
            RightVisibility = Visibility.Visible;
            //VersusVisibility = Visibility.Visible;
            LeftVisibility = Visibility.Visible;
        }
        public void ShowImag(string name, TypeEven type)
        {
            switch (type)
            {
                case TypeEven.Event:
                    ImageView = PathImag + name;
                    break;
                case TypeEven.Room:
                    ImageView = PathImag + name;
                    break;
                case TypeEven.NPC:
                    ImageView = PathNPC + name;
                    break;
            }
            //ImageView = PathImag + name;
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
            PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + n + "\\Images\\";
            PathHero = AppDomain.CurrentDomain.BaseDirectory + "Media\\Heros/";
            PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + n + "\\NPC\\";
            
            VersusVisibility = Visibility.Visible;
        }
        public void Close()
        {
            RightVisibility = Visibility.Hidden;
            VersusVisibility = Visibility.Hidden;
            LeftVisibility = Visibility.Hidden;
        }
        #endregion

        #region Команды

        public ICommand CloseWindow { get; set; }

        #endregion
    }
}
