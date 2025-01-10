# Student Housing Project



This project is a windows form application made for a school project that allows users to be able to see the house rules, their schedule, plan events, see required responsibilities, mark responsibilities when fulfilled and be able to submit complaints sub-anomymously. For Admins we have the possibility to see the complaints, see who wrote them, mark them as read or inapropriate, be able to create new accounts (Admin/Normal) and see all the accounts.

# Installation
For the full functionality of this project you need to have the required NuGet packages installed. and the required database that this project is using. 

### SQLite Database
[SQLite Studio](https://sqlitestudio.pl/)

### NuGet Packages
The Nuget Package should already be installed in this project. but if you somehow don;t have the package follow these steps:
- Open the project in Visual Studio
- Right click on 'project' and click 'Manage NuGet Packages'
- Search for 'system.data.sqlite' and install it.


# User Guide

## Login
Login with the username and password you get via your Admin.
height: 653 px width: 1173 px

![login form](<Documents/Images README/Login.png>)

## Schedule 

Here you can see the schedule where eventual events are going to be displayed. 
These events are connected to all accounts and can be seen by all users. You can scroll through the selected day to see all the events on that day.

![schedule](<Documents/Images README/Calendar with event.png>)

When you click on one of the events a detailed view of the event will be displayed. 

![list event](<Documents/Images README/List Events.png>)

### Event Description
![Detailed Info](<Documents/Images README/Event Desc.png>)
## Plan Events
Here you fill in the events by entering the events and when you press the submit button the button should be in the schedule with the title you chose.

![booking events](<Documents/Images README/Booking Event.png>)

## Complaints
In This Area you can submit complaints and choose whether you want it to send anymously or not.

![complaint form](<Documents/Images README/Complaint Form.png>)

## Responsibilities
In this tab you can see a list of your own responsibilities and add new ones in the add tab.

### Whenever your done with your chores you can click on the button 'done' and the chore will be completed and removed from your list.

![your responsibilities](<Documents/Images README/Manage Chores.png>)

### You can also add chores and assign them to other users. When you clog your roommates chores with random stuff they can submit a complaint.
![add chores](<Documents/Images README/Add Chore.png>)

# Admin

The admin has the same login function as users, the system will automatically check if you are an admin or not.

## Complaints
In this tab you can see all the complaints that have been submitted by other users.
and click the buttons delete to delete them and the left button for if you want actions to be taken on them for misuse.
When you click the button the complaint will be deleted which in this context signifies as read.

![complaint manager](<Documents/Images README/Complaint Manager.png>)

## Banning Users
Whenever you ban a user by clicking the button 'ban' the user will be banned from the complaint system and will not be able to submit any further complaints. You can also unban a user by clicking the button 'unban' under the "Unban Users" tab.

### Banninng Users you click on ban user
![ban user](<Documents/Images README/Zoom Ban.png>)

### Unbanning Users you click on unban 
![unban user](<Documents/Images README/Unban User.png>)
## Create Account
In the tab 'RegisterUser' you can create new accounts for your users to use the form for, you decide the credentials and whether they are an admin or not.

![add user](<Documents/Images README/Add User.png>)











# Database
We are currently making use of a SQLite database and we are directly extracting and inputting data into it so make sure that the database is working properly.

![database](<Documents/Images README/Database Tables.png>)