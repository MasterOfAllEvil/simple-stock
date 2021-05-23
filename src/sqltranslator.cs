/*
 * sqltranslator.cs
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
using System.Data;
using Mono.Data.Sqlite;

class SQLTranslator{
	public string activeList = "main";
	const string table_format = 
		"(name text, ticker text, price float, date datetime)";
	
	 string execute(string _sql){
	 string outs = "";
	 string cs = "URI=file:Simple.db";
	 IDbConnection dbcon = new SqliteConnection(cs);
	 dbcon.Open();
	 IDbCommand dbcmd = dbcon.CreateCommand();
	 dbcmd.CommandText = _sql;
	 IDataReader reader = dbcmd.ExecuteReader();
	  while(reader.Read()){
		  outs+= reader.GetString(0);
		
	 }
	 reader.Dispose();
	 dbcmd.Dispose();
	 dbcon.Dispose();
	 return outs;
 }
 
 string getVersion(string _sql){
	 string outs = "";
	 string cs = "URI=file:Simple.db";
	 IDbConnection dbcon = new SqliteConnection(cs);
	 dbcon.Open();
	 IDbCommand dbcmd = dbcon.CreateCommand();
	 dbcmd.CommandText = _sql;
	 IDataReader reader = dbcmd.ExecuteReader();
	  while(reader.Read()){
		  outs+= reader.GetFloat(0);
		
	 }
	 reader.Dispose();
	 dbcmd.Dispose();
	 dbcon.Dispose();
	 return outs;
 }
 string Query(string _sql){
	 string outs = "";
	 string cs = "URI=file:Simple.db";
	 IDbConnection dbcon = new SqliteConnection(cs);
	 dbcon.Open();
	 IDbCommand dbcmd = dbcon.CreateCommand();
	 dbcmd.CommandText = _sql;
	 IDataReader reader = dbcmd.ExecuteReader();
	  while(reader.Read()){
		  outs+= reader.GetString(0) + ", " + reader.GetString(1) 
		  + ", " + reader.GetFloat(2) + ", " + reader.GetDateTime(3) + "\n";
	 }
	 reader.Dispose();
	 dbcmd.Dispose();
	 dbcon.Dispose();
	 return outs;
 }
 public void config(){
	 
 }
 
 public void save(StockList _stocklist){
     string sql = "DELETE FROM " + activeList + ";";
     sql+="INSERT INTO " + activeList + " VALUES ";
     bool notFirst = false;
     foreach(Stock stock in _stocklist.stock){

		
		 foreach(Date day in stock.date){
		if(notFirst){
			 sql+=", ";
		 }
		 notFirst = true;
		 sql += "( '" + stock.name + "', '" + stock.token + "', "+ day.price + ", datetime('"
		 + day.date.ToString("yyyy-MM-dd HH:mm:ss") + "')) ";
	 }
	 }
	 sql+=";";
	
	 execute(sql);
 }
 bool rename(string _old, string _new){
	 try{
		 
	 }catch{
		 
	 }
	 return false;
 }
 
 public void setup(){
	 string conf = "prog";
	 string sql ="SELECT name FROM sqlite_master WHERE type='table' and name='"+conf+"';";
	 string result = execute(sql);

	 if(result == ""){
		 Console.WriteLine("Creating Prog Table");
		 sql = "CREATE TABLE " + conf + " (name string, val string);";
		 execute(sql);
		 sql = " INSERT INTO " + conf + " VALUES ('version', '0.1');";
		 Console.WriteLine(sql);
		 execute(sql);
	 }else{
		 Console.WriteLine("Checking Version");
		 sql = "SELECT val FROM " + conf + " WHERE name = \"version\";";
		 Console.WriteLine(sql);
		 string ot = getVersion(sql);
		 if(ot != "0.1"){
			 Console.WriteLine("Bad Version");
		 }
		 Console.WriteLine("Table Version: "+ ot);
	 }
	 
 }

 public StockList load(){
	 bool found = false;
	 string cs = "URI=file:Simple.db";
	 // Drops Table and searches for table
	 // ^ For Testing     ^ For Error Prevention
	 string sql ="SELECT name FROM sqlite_master WHERE type='table' and name='"+activeList+"';";
	 string results = execute(sql);
	 found = results != "";

	  StockList prim = new StockList();
	 if(!found){
		 sql = "CREATE TABLE " + activeList + table_format + ";";
		 execute(sql);
	 }else{
		 sql = "SELECT * FROM " + activeList + ";";
		 string list = Query(sql);
		 
		 Stock temp = new Stock("", "");
		 bool notIn = true;
		 foreach(string record in list.Split("\n")){
			 if(record !=""){
			
			 string[] cols = record.Split(",");
			 notIn = true;
			 foreach(Stock st in prim.stock){
				 if(st.token == cols[1]){
				 notIn = false;
				 temp = st;
				 break;
			 }
			 }
			 
			 if(notIn){
			 temp = new Stock(cols[0],cols[1]);
			}
			
			 
			 Date tt = new Date();
			 tt.date = DateTime.Parse(cols[3]);
			 tt.price = float.Parse(cols[2]);
			 temp.addDate(tt);
			 if(notIn)
			 prim.add_stock(temp);
		 
		 }
		 }
	 }
	 
     prim.name = activeList;
     return prim;
 }
 public bool createList(string name){
	 bool passed = false;
	 string sql = "CREATE TABLE " + name + table_format + ";";
   
	 try{
		 execute(sql);
	 passed = true;
	}catch{
		
	}
	return passed;
 }
    
}
