/*
 * date.cs
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
using System.Collections.Generic;
class Date{
	public DateTime date = DateTime.Now;
	int		 quantity;
	public float	 price = 0.00f;
	double get_value(){
		return this.quantity * this.price;
	}
	public override string  ToString(){
		return this.price.ToString() + " " + date.ToString();
	}
	
} 
