# README
**NOTICE:** This application is in early development and is not ready
for persistent use. 


## Description
This program is to keep track of stock over a period of time.

### Requirements
- Mono JIT compiler version 6.8.X
- Mono C# compiler  version 6.8.X
- SQLite version 3.28.X
- GNU Make version 4.2.X

#### DLLs
- System.Data.dll
- Mono.Data.Sqlite.dll
### Compile
Run `make` in the project directory to compile the program.
### Run
Enter `mono SimpleStock.exe` to run the program.

## License
This program uses the GNU GPL v2.
 
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



v2: Data sources and csv import.
v1: Proper Data Transactions. Program Arguments to add and get data.
v0: Development work. Proof on concept.
### PDS
The persistent data storgage being used is sqlite3. There are currently
two types of tables, configuration data table to maintian consistency, and
the stocklist tables. 

The configuration table is referred to as `prog` and the version of the
table format is stored in it. This will hopefully be used for backwards 
compatibility when such issues arise in the future.

## Database Versions
When the program runs, it creates a file called 'Simple.db'. The structure
of this

| Version | Format |
|---------|--------|
| 0.1     | (name text, ticker text, price float, date datetime)|
