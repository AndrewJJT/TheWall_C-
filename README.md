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
6. In terminal (cmd or powershell), in the directory where the TheWall.csproj lives, run "dotnet run" command 
