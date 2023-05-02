using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{
    public class TrainerUtility
    {

        private Trainer[] trainers;
        private MemberUtility memberUtility;
        private Member[] members;
        

        public TrainerUtility(MemberUtility memberUtility, Member[] members, Trainer[] trainers)
        {
            this.memberUtility = memberUtility;
            this.members = members;
            this.trainers = trainers;
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        public int Find(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}