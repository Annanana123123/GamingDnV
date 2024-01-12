using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Models
{
    public class PersonModel : ViewModelBase
    {
        //Номер заказа
        public int Id { get; set; }
        //Имя героя
        public string Name { get; set; }
        //Имя игрока
        public string UserName { get; set; }
        //Комната
        public int RoomId { get; set; }
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
        public int P { get; set; }
        public int Po { get; set; }
        //Ловкость
        public int Dexterity { get; set; }
        public int D { get; set; }
        public int De { get; set; }
        //Выносливость
        public int Endurance { get; set; }
        public int E { get; set; }
        public int En { get; set; }
        //Мудрость
        public int Wisdom { get; set; }
        public int W { get; set; }
        public int Wi { get; set; }
        //Интелект
        public int Intelligence { get; set; }
        public int I { get; set; }
        public int In { get; set; }
        //Харизма
        public int Charisma { get; set; }
        public int C { get; set; }
        public int Ch { get; set; }
        //Зассивное внимание
        public int Passiv { get; set; }
        //Раса
        public string Species { get; set; }
        //Класс
        public string Class { get; set; }
        //Способности
        public string Abilities { get; set; }
        //Заклинания
        public string Ulta { get; set; }
        //История
        public string History { get; set; }
        //Ава
        public string Imag { get; set; }
        //Инициатива
        private int? _atac;
        public int? Atac
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
        //Описание
        public string Description { get; set; }
        //Звук
        public string Sound { get; set; }
        //Персона, Герой или НПС
        public int Person { get; set; }
        //Очередь
        public int Order { get; set; }
        //Золото
        private int _gold;
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;

                RaisePropertyChanged(nameof(Gold));
            }
        }
        //Уровень
        private int _levelUp;
        public int LevelUp
        {
            get { return _levelUp; }
            set
            {
                _levelUp = value;

                RaisePropertyChanged(nameof(LevelUp));
            }
        }
        //Опыт
        private int _ervaring;
        public int Ervaring
        {
            get { return _ervaring; }
            set
            {
                _ervaring = value;

                RaisePropertyChanged(nameof(Ervaring));
            }
        }
        //+Опыт
        private int _plusErvaring;
        public int PlusErvaring
        {
            get { return _plusErvaring; }
            set
            {
                _plusErvaring = value;

                RaisePropertyChanged(nameof(PlusErvaring));
            }
        }
    }
}
