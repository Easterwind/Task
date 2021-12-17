To run api

 0. Requirements: Visual Studio 2019, Microsoft SQL Server Management Studio 18.
 1. Open solution file (Shop.sln) in Visual Studio.
 2. Go to Shop.API-> appsettings.json and change ConnectionStrings->DefaultConnection->Server and add password, if you have.
 3. Go to Package Manager Console and run in Shop.DAL update-database
 4. Run Shop.API
 
To write api I use asp.net core and mssql. To run this project you must have Microsoft SQL Server Management Studio.