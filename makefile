SimpleStock.exe: src/*.cs
	mcs src/*.cs -out:SimpleStock.exe -r:System.Data.dll -r:Mono.Data.Sqlite.dll 
