# _Message Board_

#### By _**Jason Falk**_

#### _A Fidgetech project._

## Technologies Used

* _Html/C#/Bootstrap_
* _MySql Workbench_
* _Dotnet_
* _Postman_

## Description

_The MessageBoard api is a web api that can get and post messages from various groups._

## Documentation

GET: https://localhost:5001/api/messages
| Parameter |  Type  | Required | Description |
|:-----|:--------:|:------:|-------: |
| pagenumber   | int | required | Returns page matching pagenumber |
| group   |  string  |   not required | Returns messages with a matching group value |
| minimumpostdate & maximumpostdate | string | not required | Returns messages posted between minimumpostdate and maximumpostdate |

GET https://localhost:5001/api/messages?pagenumber=2
GET https://localhost:5001/api/messages?group=weather
GET https://localhost:5001/api/messages?minimumpostdate=2024-06-03T15:34:00&maximumpostdate=2024-06-04T13:17:53.005838

----

GET: https://localhost:5001/api/messages/7
| Parameter |  Type  | Required | Description |
|:-----|:--------:|:------:|-------: |
| id | int | required | Returns message matching id |

---

POST: https://localhost:5001/api/messages

``When making a POST request to http://localhost:5000/api/messages/, you need to include a body. Here's an example body in JSON:``

``{``
``"content": "string",``
``"group": "string",``
``"user_name": "string"``
``}``

---

PUT: https://localhost:5001/api/Messages/20?user_name=string

``When making a PUT request to http://localhost:5000/api/messages/, you need to include a body. Here's an example body in JSON:``

``{``
``"content": "string",``
``"group": "string",``
``"user_name": "string"``
``}``

| Parameter |  Type  | Required | Description |
|:-----|:--------:|:------:|-------: |
| id | int | required | Returns message matching id |
| user_name | string | required | Requires user_name in order to edit message |

----

DELETE: https://localhost:5001/api/Messages/19?user_name=string

| Parameter |  Type  | Required | Description |
|:-----|:--------:|:------:|-------: |
| id | int | required | Returns message matching id |
| user_name | string | required | Requires user_name in order to delete message |

## Setup/Installation Requirements

1. _Open Git Bash/Open the terminal of your choice navigate to the directory of your choice and run this command `git clone https://github.com/JasoFal/MessageBoardApi.git`_
2. _Once you have cloned the project, navigate to the project folder using Git Bash/ a terminal of your choice using the `cd` command and run `code .` within the project folder. Alternatively, you can use VSCodes (You can use any editor but these instructions are for VSCode) open the folder option under the File tab to open the project manually shortcut is `Ctrl + O`_

##### Installing Dependencies

3. _Navigate to the project directory, in this case, **MessageBoard** using the command `cd MessageBoard` in the terminal._
4. _Then once in the MessageBoard directory, run: `dotnet restore` and `dotnet build`._

##### Setting up database

5. _Within the **MessageBoard** directory create a file named appsettings.json._
6. _Locate the file named `appsettings.example.json` and add example code to your appsettings.json adding your UserID and Password (Brackets [] not needed when adding UserId and Password). **Warning:** Do not rename the example file as it could have complications with Git._
7. _Run `dotnet ef database update` to create a database._

##### To run the project do the following:
1. _To run the app type `dotnet watch run` in the terminal within **MessageBoard** directory._
* _Then using a browser of your choice enter https://localhost:5001/swagger/index.html into the search bar._
* _This should bring you to a swagger page displaying documentation info and the ability to test api endpoints_
* _Alternatively use **Postman** to test api endpoints._

## Known Bugs

* _No known bugs._

## License

_MIT License_

Copyright (c) 6/10/2024 Jason Falk

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.