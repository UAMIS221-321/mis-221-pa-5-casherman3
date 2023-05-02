using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_casherman3
{
    public class ListingUtility
    {
        private Trainer[] trainers;
        private MemberUtility memberUtility;
        private Member[] members;
        private Listing[] listings;
        private TrainerUtility trainerUtility;

        public ListingUtility()
        {}
        public ListingUtility(MemberUtility memberUtility, Member[] members, Listing[] listings, TrainerUtility trainerUtility, Trainer[] trainers)
        {
            this.memberUtility = memberUtility;
            this.members = members;
            this.listings = listings;
            this.trainerUtility = trainerUtility;
            this.trainers = trainers;
        }

        public void BecomeTrainer(int i)
        {

            Trainer newTrainer = new Trainer();
            trainers[Trainer.GetCount()] = newTrainer;
            
            trainers[Trainer.GetCount()].SetName(members[i].GetName());
            trainers[Trainer.GetCount()].SetAddress(members[i].GetAddress());
            trainers[Trainer.GetCount()].SetEmail(members[i].GetEmail());
            trainers[Trainer.GetCount()].SetId(Trainer.GetCount() + 1);
            Trainer.IncCount();
            trainerUtility.Save();

            AddListing(i);
        }

        public void AddListing(int i)
        {
            Listing newListing = new Listing();
            System.Console.WriteLine();
            System.Console.WriteLine("What day of the week are you available?");
            newListing.SetDate(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine("What time do you want your session? (one hour long)");
            newListing.SetTime(Console.ReadLine());
            System.Console.WriteLine();
            System.Console.WriteLine("How much will your listing cost?");
            newListing.SetCost(int.Parse(Console.ReadLine()));
            listings[Listing.GetCount()] = newListing;
            listings[Listing.GetCount()].SetName(members[i].GetName());
            listings[Listing.GetCount()].SetTaken("false");
            listings[Listing.GetCount()].SetId(Listing.GetCount() + 1);

            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();
            Save();
            System.Console.WriteLine($"Your listing has been saved!\n");
            // return Listing.GetCount() - 1;
        }

        public void RegisterForSession(int i)
        {
            GetMembersFromFile(listings);
            PrintSortedListings();
            Console.ReadKey();
        }

        public Listing[] GetMembersFromFile(Listing[] listings)
        {
            // open
            StreamReader inFile = new StreamReader("listings.txt");

            // process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split("#");
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                Member.IncCount();
                line = inFile.ReadLine();
            }

            // close
            inFile.Close();
            return listings;
        }

        public void PrintSortedListings()
        {

            string time = listings[0].GetTime();
            string date = listings[0].GetDate();

            for(int i = 0; i < listings.Length; i++)
            {
                if(listings[i].GetTime() == time)
                {
                    date += listings[i].GetDate();
                }
                else
                {
                    ProcessBreak(ref time, ref date, listings[i]);
                }
            }
            ProcessBreak(time, date);
        }

        public void ProcessBreak(ref string time, ref string date, Listing newListing)
        {
            System.Console.WriteLine($"{time}\t{date}");
            time = newListing.GetTime();
            date = newListing.GetDate();
        }

        public void ProcessBreak(string time, string date)
        {
            System.Console.WriteLine($"{time}\t{date}");
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }
    }
}