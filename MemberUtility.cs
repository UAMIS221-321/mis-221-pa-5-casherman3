using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{
    public class MemberUtility
    {
        private Member[] members;

        public MemberUtility()
        {}
        public MemberUtility(Member[] members)
        {
            this.members = members;
            members = GetMembersFromFile(members);
        }

        public int CheckMember(string searchVal)
        {
            Member checkMember = new Member();
            members = GetMembersFromFile(members);
            int i = Find(searchVal);
            if(i == -1)
            {
                System.Console.WriteLine("Your name was not found, please enter your name");
                i = Find(searchVal);
            }
            WelcomeMember(i);
            return i;
        }

        public Member[] GetMembersFromFile(Member[] members)
        {
            // open
            StreamReader inFile = new StreamReader("members.txt");

            // process
            Member.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                members[Member.GetCount()] = new Member(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Member.IncCount();
                line = inFile.ReadLine();
            }

            // close
            inFile.Close();
            return members;
        }

        public void PrintAllMembers(Member[] members)
        {
            for(int i = 0; i < Member.GetCount(); i++)
            {
                System.Console.WriteLine(members[i].ToString());
            }
        }

        public int AddMember()
        {
            Member newMember = new Member();
            newMember.SetId(Member.GetCount() + 1);
            System.Console.WriteLine();
            System.Console.WriteLine("What is your name?");
            newMember.SetName(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine("What is your email?");
            newMember.SetEmail(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine("What is your address");
            newMember.SetAddress(Console.ReadLine());

            members[Member.GetCount()] = newMember;
            Member.IncCount();
            return Member.GetCount() - 1;
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("members.txt");

            for(int i = 0; i < Member.GetCount(); i++)
            {
                outFile.WriteLine(members[i].ToFile());
            }

            outFile.Close();
        }

        public void WelcomeMember(int i)
        {
            System.Console.WriteLine($"Welcome back {members[i].GetName()}!");
        }

        public int Find(string searchVal)
        {
            for(int i = 0; i < Member.GetCount(); i++)
            {
                if(members[i].GetName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}