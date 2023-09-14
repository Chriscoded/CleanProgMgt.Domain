# Project and task management
Project Managements software built with ASP.NET CORE version 7 with clean architecture

# Overview
Provide a brief overview of your API, including its purpose, main features, and any key components.
This is a simple application that allows you to perform CRUD operations on Task, Notification, Project and Users

# Prerequisites
To run an ASP.NET Core application, developers typically install the following

1. .NET Core SDK: The .NET Core SDK provides the necessary tools and libraries for developing and running ASP.NET Core applications. You can download the latest SDK from the official .NET website: [Download](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) .NET SDK.

2. Or Download Visual studio 2022 IDE or Text Editor: You need an integrated development environment (IDE) or a text editor to write, edit, and debug your ASP.NET Core code. Popular choices include Visual Studio  [Download](https://visualstudio.microsoft.com/vs/community/) , Visual Studio Code [Download](https://code.visualstudio.com/download), Rider, and others.

3. SQL Server

4. Web Browser: You'll need a web browser to test and interact with your ASP.NET Core web application.

5. Git (Optional): If you're using source control with Git, you'll need Git installed to manage your code repository.

6. HTTP Tools (Optional): Tools like Postman or Insomnia can be useful for testing API endpoint

# Getting Started


# Clone the Repository:

# bash
git clone https://github.com/your-username/your-api.git](https://github.com/Chriscoded/CleanProgMgt.Domain.git
Navigate to the Project Directory:

# bash

cd CleanProgMgt.Domain/CleanProgMgt.API

#  Restore Dependencies:

dotnet restore
#  Database Setup:

Create a database and configure the connection string in appsettings.json.
# Run database migrations:
sql
dotnet ef database update
# Run the API:

arduino

dotnet run
Your API should now be running locally and accessible at http://localhost:5183/swagger/index.html

# API Documentation
Sorry I had no time for proper documentation
# Ensure you create a user and a project before creating tasks and notification as they hav one to many relationship

# API Endpoints

# Notifications

PUT
/api/Notifications/{notificationId}/mark-read

PUT
/api/Notifications/{notificationId}/mark-unread

GET
/api/Notifications

POST
/api/Notifications

GET
/api/Notifications/{id}

PUT
/api/Notifications/{id}

DELETE
/api/Notifications/{id}
Projects

# Projects

GET
/api/Projects

POST
/api/Projects

GET
/api/Projects/{id}

PUT
/api/Projects/{id}

DELETE
/api/Projects/{id}
Tasks

# Tasks

GET
/api/Tasks

POST
/api/Tasks

GET
/api/Tasks/{id}

PUT
/api/Tasks/{id}

DELETE
/api/Tasks/{id}

GET
/api/Tasks/GetTasksByStatusOrPriority

GET
/api/Tasks/due-this-week

GET
/api/Tasks/change-task-status
Users

# Users

GET
/api/Users

POST
/api/Users

GET
/api/Users/{id}

PUT
/api/Users/{id}

DELETE
/api/Users/{id}

# Important status Enums

# task status

        Pending = 1,
        In_progress = 2,
        Completed = 3,
        Failed = 4

# Task Priority
        Low = 1,
        Medium = 2,
        High = 3

# Notification Types
        due_date_reminder = 1,
        status_update = 2,
        new_task = 3
# Notification Status
        Read = 1,
        Unread = 2,


