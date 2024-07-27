using System;

///week 7 constructors and public and private methods with some validation inside setter methods.
public class BankUser
{
    string fName;
    string lName;
    string longNo;             //attributes in the class
    int pinNo;
    int balance;
    // using constructer to establish the objects from my class
    private BankUser(string fName, string lName, string longNo, int pinNo, int balance)
    {
        this.fName = fName;
        this.lName = lName;
        this.longNo = longNo;
        this.pinNo = pinNo;
        this.balance = balance;
    }
    // Adds security by encapsulation. better for banks imo
    public string getFName()

    { return fName; }

    public string getLName()

    { return lName; }

    public string getLongNo()

    { return longNo; }

    public int getPinNo()

    { return pinNo; }

    public int getBalance()

    { return balance; }

    //setters writes the values when needed and adds a type of security (if added). setters would store 

    public void setfName(string newFName)
    {
        fName = newFName;
    }
    public void setlName(string newLName)
    {
        lName = newLName;
    }
    public void setlongNo(string newLongNo)
    {
        //if (getLongNo.Length(17 || 15))
            //Console.WriteLine("Please re-enter your long number");
        //else
        { longNo = newLongNo; }
    }
    public void setpinNo(int newPinNo)
    {
        if (pinNo > 4)
            Console.WriteLine("Please re-enter your pin number");
        else
        { pinNo = newPinNo; }
    }
    public void setBalance(int newBalance)
    {
        balance = newBalance;
    }

    //Tells your main method has to run without any access restrictions. It's public to avoid compile time error.
    public static void Main(String[] args)
    {
        //USER "GUI"
        Console.WriteLine("TSB Bank");
        Console.WriteLine("Enter Bank Card 16 digit number:");
        string bankCardno = "";
        BankUser activeUser;
        // ^ These are just blank inputs that will be filled in later on. I had help from my cousin with this bit.

        //"DATABASE"
        List<BankUser> bankUsers = new List<BankUser>();
        bankUsers.Add(new BankUser("Tasnim", "Begum", "4111111111111111", 1234, 1305));
        bankUsers.Add(new BankUser("Lafifa", "Sultana", "4222222222222222", 4321, 1300));

        //I would use a while loop to continuosly check the data until its true. For my case it was checking if bankCardno was right.
        while (true)
        {
            bankCardno = Console.ReadLine();
            activeUser = bankUsers.FirstOrDefault(a => a.longNo == bankCardno); // https://stackoverflow.com/questions/1024559/when-to-use-first-and-when-to-use-firstordefault-with-linq)
            if (activeUser != null) //https://stackoverflow.com/questions/444798/case-insensitive-containsstring/444818#444818 //(all good no faults)
            {
                break;
            }
            else
            {
                Console.WriteLine("The card 16 digit bank number is incorrect. Please try Again.");
            }
            // i used if/else to check if my pin was enetered corectly.
            Console.WriteLine("Enter your Pin");
            int userPin = 0;

            userPin = Convert.ToInt32(Console.ReadLine());
            if (activeUser.getPinNo() == userPin)
            {
                break;
            }
            else
            {
                Console.WriteLine("The Pin Number is Wrong. Please try Again.");
            }
        }

        //function about withdraw
        void withdraw(BankUser activeUser)
        {
            Console.WriteLine("Type in the amount you would like to withdraw: ");
            int withdraw = Convert.ToInt32(Console.ReadLine());
            if (activeUser.getBalance() < withdraw) //dont take out what you dont have
            {
                Console.WriteLine("You dont have enough money");
            }
            else//the newBalance is going to be te current balance minus the withdraw.
            {
                int withdrawn = activeUser.getBalance() - withdraw;
                activeUser.setBalance(withdrawn);
                Console.WriteLine("You have withdrawn");

            }
        }
        //This would pass the BankUser Info (object) into the activeUser.(function)
        //the try and catch would find errors when the user inputs a wrong vaule without disturbing the code when ran.
        void deposit(BankUser activeUser)
        {
            try
            {
                Console.WriteLine("Type in the amount you would like to deposit: ");
                int deposit = Convert.ToInt32(Console.ReadLine());
                activeUser.setBalance(activeUser.getBalance() + deposit);
                Console.WriteLine("New Balance:" + activeUser.getBalance());
            }//im getting the current balance and adding my deposit to it. Which is then getting displayed with activeUser.getBalance (the new balance).
            catch (FormatException e)
            {
                Console.WriteLine("Only type in numbers please");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured");
            }
        }
        //shows user their balance
        void balance(BankUser activeUser)
        {
            Console.WriteLine("Your Balance: " + activeUser.getBalance());
        }

    }
}

//wwek 8 inheritance,polymorphism protected,virtual and override
//class Program
//{
//    static void Main(string[] args)
//    {
//        Car car = new Car();
//        Bicycle bicycle = new Bicycle();
//        Boat boat = new Boat();
//        Airplane airplane = new Airplane();  

//        Vehicle[] vehicles = { car, bicycle, boat, airplane };

//        foreach (Vehicle vehicle in vehicles)
//        {
//            vehicle.Go();
//        }

//        Console.ReadKey();
//    }
//}
//class Vehicle
//{
//    public virtual void Go()
//    {

//    }
//}
//class Car : Vehicle
//{
//    public override void Go()
//    {
//        Console.WriteLine("The car is accelerating!");
//    }
//}
//class Bicycle : Vehicle
//{
//    public override void Go()
//    {
//        Console.WriteLine("The bicycle is accelerating!");
//    }
//}
//class Boat : Vehicle
//{
//    public override void Go()
//    {
//        Console.WriteLine("The boat is accelerating!");
//    }
//}
//class Airplane : Vehicle
//{
//    protected void TakeOff()  // New method with protected access
//    {
//        Console.WriteLine("The airplane is taking off!");
//    }

//    public override void Go()  // Overriding base class method
//    {
//        TakeOff();  // Using the protected method within the derived class
//        Console.WriteLine("The airplane is flying!");
//    }
//}






