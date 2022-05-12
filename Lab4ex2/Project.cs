using System;

namespace Lab4ex2
{
    public class Po : IComparable
    {

        private string nameprogram;
        private int oc;
        private string programsize;
        private string data;
        

        public override string ToString()
        {
            return $"Назва программи: {nameprogram}, Операційна система: {oc}, Розмір программи: {programsize}, Дата запису: {data}";
        }

        public int CompareTo(object? obj)
        {
            Po other = (Po)obj;
            return Nameprogram.CompareTo(other.Nameprogram);
        }


         public Po()
        {
        }

        public Po(string nameprogram, int oc,  string programsize, string data)
        {
            Nameprogram = nameprogram;
            Oc = oc;
            Programsize = programsize;
            Data = data;
            
        }

        public string Nameprogram
        {
            get => nameprogram;
            set => nameprogram = value;
        }

        public int Oc
    {
            get => oc;
            set => oc = value;
        }

        public string Programsize
        {
            get => programsize;
            set => programsize = value;
        }

        public string Data
    {
            get => data;
            set => data = value;
        }

        
    }
}
