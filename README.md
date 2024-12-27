# MoodleAssistant #

**MoodleAssistant** is a web application that generates multiple question variants for Moodle from a single template question, enabling users to create diverse quizzes with minimal effort.

## Usage ##

To generate your questions, you need two files:
* a **template question**, written with the Moodle XML format (you can write the question from scratch, or write it in Moodle an then export it)
* a **CSV file**.

The template question must contain **parameters**. There are different type of parameters:

Type | Format
------------- | -------------
Basic parameter (string) | <code>[\*[[parameter]]*]</code>
File parameter (MS Word, Excel...) | <code>[\*[[FILE-parameter]]*]</code>
Image parameter | <code>[\*[[IMAGE-parameter]]*]</code>

The CSV file must contain the **values** for the parameters. The first row of the CSV file must contain the name of the parameters.

You can find more informations at the [Tutorial page](https://moodleassistant.azurewebsites.net/Tutorial) of the website.

## Hosting ##

To run the application, you need to have the following tools installed:
* [.NET Core SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/en/download/)

Then, you can run the following commands:
```bash
git clone https://github.com/S0Ale/MoodleAssistant.git # Clone the repository
cd MoodleAssistant/MoodleAssistant # Go to the project folder
dotnet run # Run the application
```

## Deployment ##

A demo of the application is available at [moodleassistant.azurewebsites.net](https://moodleassistant.azurewebsites.net/).
If you want to deploy the application on Azure, you can follow the [official guide](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-get-started-dotnet).

### Publish ###
To publish the application, you can run the following commands:
```bash
dotnet publish MoodleAssistant -c Release
```

The app is published in the `MoodleAssistant/bin/Release/net8.0/publish` folder.
You can then deploy the content of this folder on the host.

More informations are available at the [official documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/?view=aspnetcore-9.0).
