/**
 * Simple Stock 
 * 
 * 2021 &copy; Devin M. O'Brien
 * 
 * A simple application for keeping track
 * of changes in stock value over time.
 * 
 */
using System;
 
 public class SimpleStock
 {
    public static void Main()
    {
	   bool exit = false;
	   SQLTranslator sql = new SQLTranslator();
       StockList primary = sql.load();
       string input;
       sql.setup();
       Console.WriteLine("Simple Stock\n==========");
       while(!exit){
		   input = Console.ReadLine();
		   
		   if(input =="add"){
			   Console.WriteLine("Enter Name:");
			   string name = Console.ReadLine();
			   Console.WriteLine("Enter Ticker:");
			   string token = Console.ReadLine();
			   Stock temp = new Stock(name, token);
			   primary.add_stock(temp);
		   }
		   if(input == "edit"){
			   Console.WriteLine("Stocks");
			   int counter = 0;
			   foreach(Stock stock in primary.stock){
				  Console.WriteLine(++counter + "). " + stock.name + "\n");
			   }
			   int sel = Int16.Parse(Console.ReadLine());
			   
			   Stock current = primary.stock[sel-1];
			   Console.WriteLine(current.ToString());
			   Console.WriteLine("Edit:\n1). Name\n2). Ticker\n3). Price");
			   sel = Int16.Parse(Console.ReadLine());
			   if(sel == 1){
				   Console.WriteLine("Enter Name");
				   current.name = Console.ReadLine();
			   }else{
				   if(sel == 2){
					   Console.WriteLine("Enter Ticker:");
					   current.token = Console.ReadLine();
				   }else{
					      Date temp = new Date();
					      Console.WriteLine("Enter Price:");
						  temp.price = float.Parse(Console.ReadLine());
						  current.date.Add(temp);
				
				   }
			   }
			   sql.save(primary);
		   }
		   // Print Active List
		   if(input == "print"){
			   Console.WriteLine(primary.ToString());
		   }
		   // Print Active List Name
		   if(input == "active"){
			   Console.WriteLine(primary.name);
		   }
		   if(input == "clear"){
			   Console.Clear();
		   }
		   if(input == "switch"){
			   Console.WriteLine("Enter List Name:");
			   string newList = Console.ReadLine();
			   if(newList != ""){
				   sql.save(primary);
				   sql.activeList = newList;
				   primary = sql.load();
			   }
		   }
		   // Creates New List
		   if(input == "create"){
			   Console.WriteLine("Enter Name:");
			   input = Console.ReadLine();
			   sql.createList(input);
		   }
		   // Exits
		   if(input == "exit"){
			   exit = true;
		   }
	   }
       
       
       
 }
}
