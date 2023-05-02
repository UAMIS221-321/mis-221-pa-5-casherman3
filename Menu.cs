using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{
    public class Menu
    {
        private int menuSelection;
        private MemberUtility memberUtility;
        private Member[] members;
        private TrainerUtility trainerUtility;
        private ListingUtility listingUtility;

        public Menu()
        {}

        public Menu(MemberUtility memberUtility, Member[] members, TrainerUtility trainerUtility, ListingUtility listingUtility)
        {
            this.memberUtility = memberUtility;
            this.members = members;
            this.trainerUtility = trainerUtility;
            this.listingUtility = listingUtility;
        }

        public void MainMenu()
        {
            int menuSelection = GetMenuSelection();
            while(menuSelection != 3)
            {
                Route(menuSelection);
                menuSelection = GetMenuSelection();
            }
        }

        public int GetMenuSelection()
        {
            DisplayMenu();
            Console.Write("Selection: ");
            int menuSelection = int.Parse(Console.ReadLine());
            if(IsValidChoice(menuSelection))
            {
                return menuSelection;
            }
            else return -1;
        }

        public void DisplayMenu()
        {
            Console.Clear();
            System.Console.WriteLine("1) User\n2) Admin\n3) Exit");
        }

        public bool IsValidChoice(int menuSelection)
        {
            if(menuSelection == 1 || menuSelection == 2 || menuSelection == 3)
            {
                return true;
            }
            else return false;
        }

        public void Route(int menuSelection)
        {
            if(menuSelection == 1)
            {
                User();
            }
            else if(menuSelection == 2)
            {
                Admin();
            }
            else if(menuSelection != 3)
            {
                Invalid();
            }
        }

        public void User()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Are you a returning member?\n1) Yes\n2) No");
            int userSelection = int.Parse(Console.ReadLine());
            switch(userSelection)
            {
                case 1:
                    System.Console.WriteLine();
                    System.Console.WriteLine("What is your name?");
                    string searchVal = Console.ReadLine();
                    int i = memberUtility.CheckMember(searchVal);
                    UserOptions(i);
                    break;
                case 2:
                    int j = memberUtility.AddMember();
                    memberUtility.Save();
                    UserOptions(j);
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    User();
                    break;
            }
        }

        public void UserOptions(int i)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("What would you like to do?\n1) Become a trainer\n2) Sign up for a booking");
            int userSelection = int.Parse(Console.ReadLine());
            switch(userSelection)
            {
                case 1:
                    listingUtility.BecomeTrainer(i);
                    Pause();
                    break;
                case 2:
                    listingUtility.RegisterForSession(i);
                    Pause();
                    break;
                default:
                    Invalid();
                    UserOptions(i);
                    break;
            }
        }

        public void Admin()
        {
            // extra, ask for password
            // print reports
        }


        public void Invalid()
        {
            System.Console.WriteLine("Invalid Choice");
            Pause();
        }

        public void Pause()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}