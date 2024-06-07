Overview:
This project demonstrates a simple OAuth login API developed using ASP.Net Core MVC. The API authenticates users and provides them with a JWT token that includes their roles and accessible system regions.

Features:
-User authentication using username and password.
-JWT token generation with roles and accessible system regions in claims.
-Static user data for authentication and authorization.

Technologies Used:
-ASP.Net Core MVC
-JWT (JSON Web Token) for authentication
-Static data for user information

Project Structure:
/APIauthentication
|-- /Controllers
|   |-- HomeController.cs
|-- /Models
|   |-- User.cs
|   |-- userLogin.cs.cs
|-- /Repository
|   |-- Service.cs
|-- appsettings.json
|-- Program.cs

Login:
Endpoint: /login
Method: POST
Description: Authenticates the user and returns a JWT token with roles and accessible system regions.

Request Body:
{
  "username": "user1",
  "password": "password1"
}

Response Body:
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "Username": "player1",
    "Role": "player",
    "Regions": "b_game"
}

JWT Token Structure
The JWT token will contain the following claims:

-name: Subject (the username)
-role: The roles assigned to the user 
-regions: The accessible system regions 

Example JWT Payload:
{
	"Name": "player1",
	"Role": "player",
	"regions": "b_game"
}

By following the setup instructions and using the provided static data, we can test the OAuth login API functionality. This demonstrates how to structure a simple OAuth login API with role-based access control using ASP.Net Core MVC.


