using mis_221_pa_5_casherman3;

const int MAX_PEOPLE = 100;
Member[] members = new Member[MAX_PEOPLE];
Trainer[] trainers = new Trainer[MAX_PEOPLE];
Booking[] bookings = new Booking[MAX_PEOPLE];
Listing[] listings = new Listing[MAX_PEOPLE];

MemberUtility memberUtility = new MemberUtility(members);
TrainerUtility trainerUtility = new TrainerUtility(memberUtility, members, trainers);
ListingUtility listingUtility = new ListingUtility(memberUtility, members, listings, trainerUtility, trainers);
Menu mainMenu = new Menu(memberUtility, members, trainerUtility, listingUtility);

mainMenu.MainMenu();

// flow of control
// main menu
//      user
//          returning member
//              check if email exists
//          new member
//              add member to members.txt
//              confirm email
//
//          become trainer
//              move information to trainers.txt
//              ask for available day, time, cost, and set taken to false
//          book appointment
//              list all available training sessions
//              select one (based on id) and change taken to true
//              add cost to transactions.txt
//      admin
//          print all reports
//          individual customer sessions
//              provide an email address and print all sessions
//          historical customer sessions
//              all sessions sorted by customer then by date
//          revenue
//              by month and by year