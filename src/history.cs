/*
 * history.cs
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

using System.Collections.Generic;


class History{
	public List<Date> date = new List<Date>();
	
	public Date recent(){
		Date outer = new Date();
		foreach(Date ds in date){
			if(outer.date < ds.date || outer.price ==0){
				outer = ds;
			}
		}
		return outer;
	}
	
	public bool addDate(Date _date){
		date.Add(_date);
		return true;
	}
	public bool removeDate(Date _date){
		return false;
	}
	public bool editDate(Date _date){
		return false;
	}
	
	public override string ToString(){
		string output = "";
		foreach(Date day in date){
			output += day.ToString() + "\n";
		}
		return output;
	}
}
