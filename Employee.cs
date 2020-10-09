using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_12
{
    class Employee:Person
    {
        public string Position { get; set; }
        public string WorkUnit { get; set; }

        private string pos;
        private string unit;

        public Employee() : base()
        {
            RandomJob(out pos, out unit);
            Position = pos;
            WorkUnit = unit;
        }

        public Employee(string nm, int a, string pos, string unit) : base(nm, a)
        {
            Position = pos;
            WorkUnit = unit;
        }

        public void RandomJob(out string pos, out string unit)
        {
            string[] positions = { "инженер", "техник", "диспетчер", "программист", "механик", "таксировщик", "нарядчик", "архивариус", "бригадир", "слесарь" };
            string[] units = { "отдел технического обслуживания", "производственно-диспетчерский отдел", "отдел главного конструктора",
                               "финансово-сбытовой отдел", "отдел кооперирования", "плановый отдел", "отдел снабжения", "технологический отдел" };
            pos = positions[rnd.Next(positions.Length)];
            unit = units[rnd.Next(units.Length)];
            return;
        }

        public override void Show()
        {
            Console.WriteLine($"ФИО: {Name} возраст: {Age} должность: {Position} подразделение: {WorkUnit}\n");
        }

        public override string ToString()
        {
            return $"{Name}, {Age} : {Position}, {WorkUnit}";
        }

        public Person GetPerson()
        {
            return new Person(this.Name, this.Age);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && (this.Position == ((Employee)obj).Position) && (this.WorkUnit == ((Employee)obj).WorkUnit);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        new public object Clone()
        {
            return new Employee(this.Name, this.Age, this.Position, this.WorkUnit);
        }

    }
}

