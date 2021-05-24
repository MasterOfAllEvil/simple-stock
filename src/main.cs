/*
 * main.cs
 * 
 * Copyright 2021 Devin M. O'Brien <demo@BattleForge>
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 * 
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
			   input = "";
		   }
		   if(input == "update"){
			   Console.WriteLine("Stocks");
			   int counter = 0;
			   foreach(Stock stock in primary.stock){
				  Console.WriteLine(++counter + "). " + stock.name + "\n");
			   }
			   int sel = Int16.Parse(Console.ReadLine());
			   
			   Stock current = primary.stock[sel-1];
			   Console.WriteLine(current.ToString());
			   Console.WriteLine("Update:\n1). Name\n2). Ticker\n3). Price");
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
			   input = "";
		   }
		   if(input=="edit"){
			   int counter = 0;
			   foreach(Stock stock in primary.stock){
				   Console.WriteLine(++counter +"). "+ stock.name);
			   }
			   int sel = Int16.Parse(Console.ReadLine());
			   Stock active = primary.stock[--sel];
			   counter = 0;
			   foreach(Date date in active.date){
				   Console.WriteLine(++counter + "). " + date.ToString());
			   }
			   sel = Int16.Parse(Console.ReadLine());
			   Date dte = active.date[--sel];
			   Console.WriteLine("1). Price: " + dte.price +"\n2). Date: " + dte.date);
			   sel = Int16.Parse(Console.ReadLine());
			   if(sel == 1){
				   Console.WriteLine("Enter New Price");
				   dte.price = float.Parse(Console.ReadLine());
			   }else{
				   Console.WriteLine("Enter New Date: (OLD) " + dte.date.ToString());
				   dte.date = DateTime.Parse(Console.ReadLine());
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
		   if(input == "remove"){
			   int counter = 0;
			   foreach(Stock stock in primary.stock){
				Console.WriteLine(++counter + "). " + stock.name +"\n");   
			   }
			   int sel = Int16.Parse(Console.ReadLine());
			   primary.remove_stock(--sel);
			   input = "";
			   sql.save(primary);
		   }
		   if(input == "clear"){
			   Console.Clear();
		   }
		   if(input == "switch"){
			   Console.WriteLine("Enter List Name:");
			   string newList = Console.ReadLine();
			   if(newList != "" && newList != "prog"){
				   sql.save(primary);
				   sql.activeList = newList;
				   primary = sql.load();
			   }
		   }
		   // Creates New List
		   if(input == "create"){
			   Console.WriteLine("Enter Name:");
			   input = Console.ReadLine();
			   if(input != "prog" && input !="")
			   sql.createList(input);
		   }
		   // Exits
		   if(input == "exit"){
			   exit = true;
		   }
	   }
       
       
       
 }
}
