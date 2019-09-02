# TheWall_C-
- Small MVC web app for posting messages and comments by users

Instructions for running the applicaion:

*Please note I use Window, so I am not exactly sure how the process work on Mac, but I have the following instructions  
Before installing the .NET Core SDK on Mac OS you need to have the latest version of OpenSSL set up. The easiest way to get OpenSSL is by using Homebrew.   
If you do not already have Homebrew you can download and install it by going to their Homepage. (https://brew.sh/)  
Once installed, do the following in terminal...  

brew install openssl  
ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/  
ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/  

From there you can download the appropriate .NET Core SDK.  


1. Clone/Download source code
2. Install VS Code 
3. Download 2.2.5 version of .NET Core, https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2.5/2.2.5-download.md
(64bit version for window)  
4. For support, download extension on VS code: C# for Visual Studio Code (powered by OmniSharp)
5. Install MySql Sever
6. In terminal after navigating to your project directory, run the following commands  
    dotnet add package MySql.Data -v 8.0.16
7. Inside the appsetting.json file, please change the information of connection string to match your own local MySql Sever
8. Install EF Framework Core dependency, run the following command at project directory  
    dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0
9. After the project is opened with VS Code, migrate Models to local database with the following commands  
   dotnet ef migrations add YourMigrationName    
   dotnet ef database update  
10. After the database is created in local MySql server, go to project's Model folder and uncomment all the //[Required] line above the model properties 
11. Save the all the files. In terminal (cmd or powershell), in the directory where the TheWall.csproj lives, run "dotnet run" command 
