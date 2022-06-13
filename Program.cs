//Creating a new instance of the dictionary .
//Populating Dictionary with coins .
Dictionary<int, int> vendingMachine = new Dictionary<int, int>();
vendingMachine.Add(1, 15);
vendingMachine.Add(2, 15);
vendingMachine.Add(5, 15);
vendingMachine.Add(10, 15);
vendingMachine.Add(20, 15);


//Function that represent the Complete vending method , it takes a Vending machine dictionary,price integer and money inserted integer as parameters. 
Dictionary<int, int > Operation (Dictionary<int,int> vendingMachine, int price , int moneyinput)
{
    Dictionary<int , int> getChange = new Dictionary<int, int> ();
    int change = 0;
    //checking if money inserted is greater than the price of the item.
    if ( moneyinput >= price)
    {
        //Mathamatical operation to find how much money is to be returend. 
        change = moneyinput - price; 
        int number = 0;
        // loop to iterate over key value pairs in vendingMachine dictionary
        for (int i = vendingMachine.Count - 1; i >= 0; i--)
        {
            //storing values of vendingMachine Dictionary as 'coins'
            int coins = vendingMachine.ElementAt(i).Value;
            
            //checking keys of VendingMachine dictionary to make sure its denomination is less than change to be return and number of values of vendingMachine Dictionary is greater than 0 (Check if machine has coins)
            if (vendingMachine.ElementAt(i).Key <= change && coins > 0)
            {
                //To store how many coins of each denomiation has to be returned.
                int NumberofCoins = 0;
                if (moneyinput / vendingMachine.ElementAt(i).Key >=2)
                {
                    number = change / vendingMachine.ElementAt(i).Key;
                    NumberofCoins = NumberofCoins + number;
                }
                change = change - vendingMachine.ElementAt(i).Key * NumberofCoins;
                //populating the getChange dictionary with the ouptut 
                getChange.Add(vendingMachine.ElementAt(i).Key, NumberofCoins);
            }
        }
    }
    //case if money inserted is less than the price of the item.
    else
    {
        Console.WriteLine("Money inserted is not Enough ");
    }

    Console.WriteLine($"Money Inserted : {moneyinput} \nItem cost : {price}");

    foreach (KeyValuePair<int, int> coin in getChange)
    {
        Console.WriteLine($"\n{coin.Value} coin of ${coin.Key}.");
    }

    return getChange;
}


//Example Input
Operation(vendingMachine, 10, 100);
