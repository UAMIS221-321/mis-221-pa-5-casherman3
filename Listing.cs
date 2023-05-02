using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{

    public class Listing
    {
        private int id;
        private string name;
        private string date;
        private string time;
        private int cost;
        private string taken;
        static private int count;

        public Listing()
        {}

        public Listing(int id, string name, string date, string time, int cost, string taken)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }

        public string GetDate()
        {
            return date;
        }

        public void SetTime(string time)
        {
            this.time = time;
        }

        public string GetTime()
        {
            return time;
        }

        public void SetCost(int cost)
        {
            this.cost = cost;
        }

        public int GetCost()
        {
            return cost;
        }

        public void SetTaken(string taken)
        {
            this.taken = taken;
        }

        public string GetEmail()
        {
            return taken;
        }

        static public void SetCount(int count)
        {
            Listing.count = count;
        }

        static public int GetCount()
        {
            return Listing.count;
        }
        
        static public void IncCount()
        {
            count++;
        }

        public string ToFile()
        {
            return $"{id}#{name}#{date}#{time}#{cost}#{taken}";
        }
    }
}