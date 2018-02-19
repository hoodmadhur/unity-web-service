# unity-web-service

Tools Used : 
WAMP server 3.1 64 Bit
Unity 2017.3.0f3


To use the PHP scripts, copy the php/demo folder to www folder in your apache server.
Add the demo sql database in your mysql database.

First scene in Unity start.unity, always load that first when starting to play the game.
other scenes will be loaded based on if a new user is playing or a returning user.


Flow : 
start scene :
User clicks login button, if user is regsitered, then he will be taken to game scene and all relevant data will be shown. 
If its a new user, registration screen will be shown wheere user enters name, age and selects a character from drop down, on successful registration, user will be taken to game scene.
