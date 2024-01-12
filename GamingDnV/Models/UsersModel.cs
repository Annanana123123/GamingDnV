using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace GamingDnV.Models
{
    public class UsersModel : ViewModelBase
    {
        //Номер заказа
        public int Id { get; set; }
        //Имя героя
        public string HeroName { get; set; }
        //Имя игрока
        public string UserName { get; set; }
        //Примечание
        public string Notee { get; set; }
        //Броня
        public int Defence { get; set; }
        //Здоровье
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                RaisePropertyChanged(nameof(Health));
            }
        }
        //Сила
        public int Power { get; set; }
        //Ловкость
        public int Dexterity { get; set; }
        //Выносливость
        public int Endurance { get; set; }
        //Мудрость
        public int Wisdom { get; set; }
        //Интелект
        public int Intelligence { get; set; }
        //Харизма
        public int Charisma { get; set; }
        //Раса
        public string Species { get; set; }
        //Класс
        public string Class { get; set; }
        //Инвинтарь
        public string Item { get; set; }
        //Способности
        public string Abilities { get; set; }
        //Заклинания
        public string Ulta { get; set; }
        //История
        public string History { get; set; }
        //Ава
        public string Imag { get; set; }
        //Инициатива
        private string _atac;
        public string Atac
        {
            get { return _atac; }
            set
            {
                _atac = value;

                RaisePropertyChanged(nameof(Atac));
            }
        }
        //Оружие
        public string Arms { get; set; }
        //Экипировка
        public string Equip { get; set; }
        //Пассивное внимание
        public int Passiv { get; set; }
        //Описание
        public string Description { get; set; }
    }
}
