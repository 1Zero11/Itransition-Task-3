using System.Security.Cryptography;
using ConsoleTables;

if (args.Length >= 3 && args.Length%2==1 && args.Distinct().Count() == args.Length)
{
    //Тут был код, но он весь ушёл в while...
}
else
{
    Console.WriteLine("You should call the app with uneven (more than one) number of arguments");
    Console.WriteLine("All of the args should be different");
    Console.WriteLine("Ex: ./Itransition rock paper scissors");
    return;
}


//Console.WriteLine(crypto.key);
//Console.WriteLine(crypto.text);


while (true)
{
    menu();
    Random r = new Random();

    int compchose = r.Next(0, args.Length);
    var item = args[compchose];

    Crypto crypto = new Crypto(item);
    Rules rules = new Rules(args, compchose);


    Console.WriteLine("HMAC: " + crypto.HMAC);

    Console.Write("Enter your move: ");
    string yourAnswer = Console.ReadLine();

    if(yourAnswer=="?"){
        TableBuilder builder = new TableBuilder(args);
        ConsoleTable table = builder.BuildTable();
        Console.WriteLine("Your moves are headers, computer moves are on the left");
        table.Write();

    }else if(yourAnswer == "0"){
        break;
    }else
    {
        int yourindex = 0;
        if(int.TryParse(yourAnswer,out yourindex)){
            Console.WriteLine("Your move: " + args[yourindex-1]);
            Console.WriteLine("Computer move: " + crypto.text);
            Console.WriteLine(rules.IsWon(yourindex - 1));
            Console.WriteLine("KEY: " + crypto.key);
        }else{
            Console.WriteLine("Wrong answer");
            help();
        }
        
    }

    Console.WriteLine();
}


void help(){
    Console.WriteLine($"Write number 1 to {args.Length} to answer");
    Console.WriteLine("Write number 0 to exit");
    Console.WriteLine("Write ? to show this help ");
}

void menu(){
    Console.WriteLine("Available moves:");
    int i = 1;
    foreach (var arg in args)
    {
        Console.WriteLine($"{i} - {arg}");
        i++;
    }

    Console.WriteLine($"0 - exit");
    Console.WriteLine($"? - help");
}
