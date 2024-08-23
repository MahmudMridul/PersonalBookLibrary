# Personal Book Library

## How to Setup Backend

1. Install .NET SDK 8 (LTS version).
2. Install Visual Studio 2022 Preview.
3. Install SQL Server Management Studio (Optional).
   1. Create a server named `localhost`.
   2. Create a Database named `PersonalLibrary`.
   3. Go to Visual Studio and build the project.
   4. Select tools in VS and then go to NuGet Package Manager and select Package Manager Console.
   5. Run this command `Update-Database`.
   6. Run the project in VS.
4. If you don't want to setup Database then After step 2 open the project and open the file `appsettings.Development.json`.
5. Find the property `UseInMemoryDb` and set it to `true`.
6. Run the project in VS.
