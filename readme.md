# README
**NOTICE:** This application is in early development and is not ready
for persistent use. 


## Description
This program is to help get an idea of the health
of your stocks. This is a personal project written in c#
using mono compiler. 

 
## Development Info
I am not using an IDE for this project. I am using a text editor, Mono C#
compiler, and Mono runtime.

### Roadmap
The goal of this project is to get experience with c#. I came up with 
this idea because of my style of investing is occasional checks and had
made lists on the brokerage site to keep track of changes since previous.
To do this, I had to remove and add each stock. Not bad itself, but 
with loading time and having to look back at the portfolios to get the 
tickers is a waste of time.

This leads to the end goal. I would like to switch from terminal based
to a basic portable gui, but I want functionality done first. This would
basic stock accounting and formalizing structural layout. 
### PDS
The persistent data storgage being used is sqlite3. There are currently
two types of tables, configuration data table to maintian consistency, and
the stocklist tables. 

The configuration table is referred to as `prog` and the version of the
table format is stored in it. This will hopefully be used for backwards 
compatibility when such issues arise in the future.

## Table Versions

| Version | Format |
| 0.1     | (name text, ticker text, price float, date datetime)|
