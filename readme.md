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
I am not using an IDE for this project just a text editor, Mono C#
compiler, and Mono runtime.


## Database Versions
When the program runs, it creates a file called 'Simple.db'. The structure
of this

| Version | Format |
|---------|--------|
| 0.1     | (name text, ticker text, price float, date datetime)|
