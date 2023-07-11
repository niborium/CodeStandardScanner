# CodeStandardScanner
Code Standard Scanner is a lightweight .NET (CLI) console application that analyzes TypeScript and TypeScriptX files for adherence to specified code standards. This is just an example and can be modified for your needs.  
This can scan any projects for .TS and .TSX files and validate you following your set code standards. This can be modified for any file extenstions and with your specified code standards for you needs. Great for companies, teams or as individuals to setup code standards scanning.. just a basic scanning tool to scan and enfoce rules. Could be an simple alternative to ESLint/typescript-eslint for example or could also be customized with advanced configure for your needs. This CLI is very flexible.

# Run the CodeStandardScanner locally on your machine for testing
```
dotnet run -- <folder-path>
```
For example:
```
dotnet run -- "C:\Projects\MyProject"
```
Note that the folder path should be enclosed in quotes if it contains spaces or special characters.

The application will start running and perform the code standard scanning on the specified folder and its subfolders. The violations or confirmation of adherence to the code standards will be displayed in the console output.

Make sure to replace <folder-path> with the actual path to the folder you want to scan. The application will recursively scan all .ts and .tsx files in the specified folder and its subfolders, checking for code standard violations.

Remember that you need to have the .NET SDK installed on your machine to execute the dotnet run command.

# Here's how you can publish your .NET console application as a standalone executable:

1) Open a command prompt or terminal window.

2) Navigate to the directory containing your .NET console application project.

3) Use the following command to publish your application:

```
dotnet publish -c Release -r <runtime-identifier> --self-contained true
```

Replace <runtime-identifier> with the appropriate value for your target platform. For example, win-x64 for Windows 64-bit, linux-x64 for Linux 64-bit, or osx-x64 for macOS 64-bit. You can find a full list of runtime identifiers in the official documentation.

The -c Release flag indicates that you want to publish the release build of your application.

The --self-contained true flag ensures that the published output includes the necessary .NET runtime components for the specified target platform.

4) After executing the command, the publish output will be generated in a folder named publish (or bin/Release/net<version>/<runtime-identifier>/publish depending on the project configuration).

5) Inside the publish folder, you'll find the standalone executable file for your application. The filename will match your project name. For example, if your project is named CodeStandardScanner, the executable will be named CodeStandardScanner.exe (on Windows).

You can now distribute the standalone executable (CodeStandardScanner.exe) to other machines without requiring the .NET SDK or runtime. Recipients can simply run the executable on their machines to perform the code standard scanning.

 it is possible to integrate the code scanner into CI/CD pipelines or build tools like Webpack. Integrating the scanner into your development workflow can help enforce code standards and catch violations early in the development process. Here are a couple of integration options:

# CI/CD Pipeline Integration:

1) Choose your CI/CD platform (e.g., Jenkins, Travis CI, Azure DevOps).
2) Add a build step in your pipeline configuration to run the code scanner as part of your build process.
3) Configure the scanner to run against the desired project or repository.
4) Specify the code standards or guidelines to enforce.
5) Set up the pipeline triggers to run the scanner on each code change or as needed.
6) Define the behavior for handling scanner violations, such as failing the build or generating reports.

# Webpack Integration:

1) Add a custom Webpack plugin or loader to your Webpack configuration.
2) Configure the plugin/loader to run the code scanner on the desired TypeScript/TypeScriptX files during the build process.
3) Specify the code standards or guidelines to enforce within the plugin/loader configuration.
4) Determine the action to take when scanner violations are detected, such as logging warnings, throwing errors, or generating reports.
5) Run the Webpack build process, and the scanner will automatically analyze the specified files during the build.

By integrating the code scanner into your CI/CD pipeline or build tools, you can automate the code analysis and enforce code standards consistently across your projects. This helps maintain code quality and reduces the chance of introducing code violations during development.

# NOTE!
Please note this is an basic example for a CodeStandardScanner that can be easily modified and integrated with your CI/CD Pipeline or with Webpack for example. You need by yourself modify this code for your specific needs and requriements (code standards) and configure the implementation to suite your company or team.
