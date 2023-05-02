using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{
    public class Trainer
    {
        private int id;
        private string name;
        private string address;
        private string email;
        public static int count;

        public Trainer()
        {}

        public Trainer(int id, string name, string address, string email)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
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

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        static public void SetCount(int count)
        {
            Trainer.count = count;
        }

        static public int GetCount()
        {
            return Trainer.count;
        }
        
        static public void IncCount()
        {
            count++;
        }

        public string ToFile()
        {
            return $"{id}#{name}#{address}#{email}";
        }
    }
}