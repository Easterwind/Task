# Shop WebApi 

This is an API for a WEB shop that covers a part which manages products.

To run this API

 0. Requirements: Visual Studio 2019, Microsoft SQL Server Management Studio 18.
 1. Open solution file (Shop.sln) in Visual Studio.
 2. Go to Shop.API-> appsettings.json and change ConnectionStrings->DefaultConnection->Server and add password, if you have.
 3. Go to Package Manager Console and run in Shop.DAL update-database
 4. Run Shop.API
 
To write API I used ASP.NET Core and Microsoft SQL Server. To run this project you must have Microsoft SQL Server 15.

You can check demo here: https://shopproduct.azurewebsites.net/