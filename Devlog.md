# Devlogs
## 11/07/2021 (21ga1107.0)

Hey everyone! Sorry for the late devlog. I didn't get like ***anything*** done last week. Sorry about that.

### 0.
I can tell I've been getting burnt out. I'm really going to have to finish EMD fast, before I just can't work on it anymore. I am almost done though. I just need a few more things. Here's what I've got so far.

### 1.
I have now created the EMD pause and start menus. The game uses the mouse exactly zero times, so all ways of interacting involve the keyboard, including buttons (since an arcade doesn't usually have a cursor). So all buttons have to use a different method of interaction, and I used 2. The pause buttons require you to press a given key to interact with them, and the start menu buttons use an arrow system, where you move the arrow with your movement keys. Hopefully both of them make enough sense to play with. Please leave feedback and let me know!

### 2.
Saving also works now. THe current setup has the game save files to a folder called `Arcade Maniac Global/Save Data`. This folder is not really required, but will be kept there for modding and development purposes. Note that I am thinking of setting the save data folder back to the regular `Arcade Maniac` folder, but I'm not entirely sure yet. We'll see how it goes. Also: note that when the final game and launcher come out, the save data in the `Save Data/` folder will only be for the current session. When the launcher changes profiles (because there will be a profile editor), the save file accessible by the game will be modified. Actual save data will probably be stored in `Arcade Maniac Launcher/Data/Save Data/<PROFILE NAME>/`. Not sure yet though. The files will also be serialized in JSON, instead of binary, since I actually am fine with them being modified, though I will probably have some backup system to tell if you changed the data at any time, just to make sure nobody modifies the save files and then claims they beat the game without actually doing anything. I trust you guys wont do that though :).

### 3.
Lastly comes small improvements. I'm trying to finish the "Stuff to Do" checklist, you see. I've made the hittable blocks now be able to be hit a given amount, made the player not be able to walk off the left side of the screen, and made the player flash to a given color instead of only Red and Clear. However, I've removed the falling platform falling on you glitchyness, because I don't want to worry about it, and it probably won't happen much anyways. Might fix it later, might not. Don't know yet.

### 4.
Lastly, I've had some trouble making the clouds a particle system. I want to do that because object pooling is just inferior to that in this current case. Sometimes object pooling is useful, but not this time. So I want to replace it, but unfortunately, I don't know how to make the particles not move along with the camera, because I need that. I need the particle system to be brought along with the camera, but not the particles themselves. That's really all I need done, and I need it for more than just the clouds anyway, so I need to learn this at some point.

### Ending.
Also something that will affect Arcade Maniac for the better is that I have enlisted the help of my friend who goes by the discord username `Saalty` as a co-developer to help me with Arcade Maniac! Hopefully the 2 of us will be able to help each other, but there are definitely some things he is going to be the lead in, such as like *all of the networking*.

Anyways, that's about it. I hope you like the progress coming along, and I believe I can get everything (besides mapmaking), done in the next few weeks. Have a good one!

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- ~~Reset the HDRP default settings and make custom ones for this camera only.~~
- ~~Remodel the cabinet screen to use a well-known aspect ratio~~
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- ~~Add stone textures to EMD~~
- ~~Add an ability for the EMD hittable blocks to be hit multiple times~~
- ~~Make the EMD enemy, you know, actually work~~
- ~~Make the EMD player not be able to walk off screen~~
- ~~Make the EMD player flash into a given color instead of only between clear and red~~
- Heavily optimize EMD
- Turn the EMD clouds into a particle system **(In Progress)**
- ~~Finish the EMD pause menu~~
- ~~Make the EMD start menu~~
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 10/26/2021 | Upgraded to `Unity 2021.2.0f1` |
| 10/30/2021 | Downgraded to `Unity 2021.1.26f1` |
| 10/30/2021 | Upgraded to `Unity 2021.1.27f1` |
| 10/31/2021 | Created a texture for the EMD pause menu buttons (`Source/Assets/Minigames/Entity March Dream/Textures/Pause-Button.png`) |
| 10/31/2021 | Added a background to the EMD health bar (`Source/Assets/Minigames/Entity March Dream/Textures/Health-Bar.png`) |
| 10/31/2021 | Added an object to represent the EMD resume button in the game interface, and applied it to the prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Game Interface.prefab`) |
| 10/31/2021 | Created a script to represent the EMD pause buttons (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Game Interface/PauseButton.cs`) |
| 10/31/2021 | Gave the pause menu an additional 2 buttons for restarting and quitting |
| 10/31/2021 | Created a scene for the title screen (`Source/Assets/Minigames/Entity March Dream/Scenes/EMD Title Screen.scene`) |
| 10/31/2021 | Created a texture for the EMD title screen (`Source/Assets/Minigames/Entity March Dream/Textures/Title.png`) |
| 10/31/2021 | Added a UI object to represent the title |
| 10/31/2021 | Created an object for the tilemap of the title screen |
| 11/01/2021 | Added the EMD player prefab to the title screen (`Source/Assets/Minigames/Entity March Dream/Prefabs/player.prefab`) |
| 11/01/2021 | Accounted for a possible missing EMD stats file in the EMD player script (`Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs`) |
| 11/01/2021 | Created a folder in the EMD script bunches folder to represent the start menu scripts (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Start Menu/`) |
| 11/01/2021 | Created a script in the EMD start menu bunch to represent the entire start menu as a whole (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Start Menu/StartMenu.cs`) |
| 11/01/2021 | Created an object in the start menu to act as the "Press Any Key" text |
| 11/01/2021 | Created a script for the any key text (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Start Menu/AnyKeyText.cs`) |
| 11/01/2021 | Added 3 text messages, for "buttons" in the EMD start menu |
| 11/01/2021 | Removed `oldVelocity` and `oldGravityScale` from the abstract EMD enemy (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Enemy.cs`) |
| 11/01/2021 | Created a texture for an arrow in the start menu (`Source/Assets/Minigames/Entity March Dream/Textures/Start-Arrow.png`) |
| 11/01/2021 | Created a script for the arrow (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Start Menu/StartArrow.cs`) |
| 11/02/2021 | Created a script to represent the global config of the game (`Source/Assets/Misc/Scripts/Object Models/GlobalConfig.cs`) |
| 11/02/2021 | Created a script for the saving of data in EMD (`Source/Assets/Minigames/Entity March Dream/Scripts/Object Models/SaveData.cs`) |
| 11/02/2021 | Made the quit button in the pause menu save before exiting |
| 11/02/2021 | Made the EMD finish save before moving on (`Source/Assets/Minigames/Entity March Dream/Scripts/Finish.cs`) |
| 11/02/2021 | Made the EMD hittable block's `timeUntilSpawn` variable private, and made it be assigned automatically (`Source/Assets/Minigames/Entity March Dream/Scripts/HittableBlock.cs`) |
| 11/02/2021 | Made the EMD hittable block be able to be hit multiple times, in a new variable `maxHits` |
| 11/02/2021 | Made the EMD hittable block use the loot system previously made |
| 11/02/2021 | Added an edge collider to the EMD camera so the player can't walk off screen, and applied it to the prefab (`Source/Assets/Minigames/Entity March Dream/Scripts/PlayerCamera.cs`) |
| 11/02/2021 | Replaced the EMD player's `invulFlashMode` with a new `invulFlashColor` variable, and made the player fade to that color when taking damage (`Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs`) |
| 11/02/2021 | Replaced the cloud object pool with a particle system and applied it to the prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Clouds.prefab`) |
| 11/02/2021 | Deleted the cloud management script, since it is no longer required (`Source/Assets/Minigames/Entity March Dream/Scripts/Clouds.cs`) |
| 11/02/2021 | Created a folder for EMD materials (`Source/Assets/Minigames/Entity March Dream/Materials/`) |
| 11/02/2021 | Created a material for the cloud particle system (`Source/Assets/Minigames/Entity March Dream/Materials/Clouds.mat`) |
