# Devlogs
## 10/24/2021 (21ga1024.0)

Devlog number 5 is ready!

### 0.
Ok, so this week was *almost* as unproductive as the past 2 weeks, but I managed to get a ton done over the weekend (mainly Saturday, actually).

### 1.
First off, I had to update unity TWICE, because I installed `25f1`, updated to Windows 11, and in that time of like 45 minutes max, a new unity version came out, and I had to install that one too. So that happened.

### 2.
Ok, time for some actual stuff. I started by adding an extension to interpolate, because I use that function so many times, I could just package it all up into its own method. Also, that method I use actually doesn't work in low enough framerates (around 18 or lower, I calculated), so instead of making each instance of that function account for framerate too, I could just make a method to handle it. That was the main reason behind it.

### 3.
Then I made the coin counter and the world indicator, simple enough. The coin indicator actually has a tiny animation when you collect a coin, just because I thought that could be cool. And the backdrop really helped make the text readable. I might add another rectangular one that covers everything, but I don't know about that yet.

### 4.
I decided to turn the EMD stats file into a monobehavior, because that definitely will help me with the general scene stats, like the world and level names. I will eventually add a method in there to save data, but for now at least, it goes without saving. The issue with saving here is that because of the launcher holding many different versions of Arcade Maniac, and that I want save files to transfer seamlessly from one version to another, I will have to save outside of the regular persistant data path Unity gives me, which becomes more of an issue when we talk about different OSes, especially because I don't have a Mac to test it on. So, I might not consider the saving at all until I get at least most of the launcher done. We'll see.

### 5.
I added a new object model for loot, where it generates whether you get the loot or not automatically with the `Loot.Lottery` variable. It handles what item to spawn, and what the chance that item spawns is. Should hopefully help with the loot stuff, like where the enemy has a 10% chance of dropping a health boost.

### 6.
Lastly (skipping some small stuff), we have the pause menu. I actually completely forgot about that one. I have that to do, and then the start menu. The pause menu is annoying, because now you have to go into every single script that is in EMD and add a check for if it is paused or not, sometimes even more if the object has physics. Just pretty tedious to do.

### Ending
Anyways, that's about it. Might not seem like a lot, but the changelog says otherwise. Mainly I just did a bunch of small things I didn't feel like talking about here. You can just look down below.
**NOTE: Itch users can now see the complete changelog like the [github alternative](https://github.com/That-One-Nerd/Arcade-Maniac/blob/21ga1024.0/Devlog.md), because I found a way to not have to manually convert from markdown to Itch's formatting. So that's great!**
Anyways, have a good week, and I'll see you next devlog!

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- ~~Reset the HDRP default settings and make custom ones for this camera only.~~
- ~~Remodel the cabinet screen to use a well-known aspect ratio~~
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- ~~Add stone textures to EMD~~
- Add an ability for the EMD hittable blocks to be hit multiple times
- Make the EMD falling platforms a little less glitchy when falling onto the player from above
- ~~Make the EMD enemy, you know, actually work~~
- Make the EMD player not be able to walk off screen
- Make the EMD player flash into a given color instead of only between clear and red
- Heavily optimize EMD
- Turn the EMD clouds into a particle system
- Finish the EMD pause menu
- Make the EMD start menu
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 10/20/2021 | Upgraded to `Unity 2021.1.25f1` |
| 10/20/2021 | Upgraded to `Unity 2021.1.26f1` |
| 10/20/2021 | Removed some debug code in the EMD Game Interface Health Bar script on line 35 (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Game Interface/HealthBar.cs`) |
| 10/20/2021 | Created a new extension for interpolating many things, such as floats (`Source/Assets/Misc/Scripts/Extensions/InterpolateExtension.cs`) |
| 10/20/2021 | Replaced the EMD Health Bar's interpolation with the extension's |
| 10/20/2021 | Replaced the Arcade Player's rotation interpolation with the extension's (`Source/Assets/Arcade/Scripts/Player.cs`) |
| 10/20/2021 | Replaced the Arcade Cabinet's rotation interpolation with the extension's (`Source/Assets/Arcade/Scripts/Cabinet.cs`) |
| 10/20/2021 | Added a text object to the Game Interface to represent the coin count, and applied it to the prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Game Interface.prefab`) |
| 10/20/2021 | Added a folder in the Misc Fonts for the Pixeled font and its TMP equivalent (`Source/Assets/Misc/Fonts/Pixeled/`) |
| 10/20/2021 | Added the Pixeled font to its folder (`Source/Assets/Misc/Fonts/Pixeled/Pixeled.ttf`) |
| 10/20/2021 | Added a child object to the coin counter to represent the coin icon and applied it to the prefab |
| 10/20/2021 | Created a folder for the coin counter's animations (`Source/Assets/Minigames/Entity March Dream/Animations/Game Interface/Coin Counter/`) |
| 10/20/2021 | Created an animation for the coin icon to bob up and down (`Source/Assets/Minigames/Entity March Dream/Animations/Game Interface/Coin Counter/Coin Bob.anim`) |
| 10/20/2021 | Created an animation for the coin icon to change color and size when coins are being collected (`Source/Assets/Minigames/Entity March Dream/Animations/Game Interface/Coin Counter/Coin Collect.anim`) |
| 10/20/2021 | Created a script for the coin counter (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Game Interface/CoinCounter.cs`) |
| 10/20/2021 | Gave the counter its script |
| 10/20/2021 | Created a `CoinsCollected` and a `p_CoinsCollected` private variable in the EMD statistics file (`Source/Assets/Minigames/Entity March Dream/Scripts/Object Models/Statistics.cs`) |
| 10/20/2021 | Removed the `coinsCollected` variable |
| 10/20/2021 | Removed a useless `else` statement in the `PlayerHealth` variable |
| 10/21/2021 | Added an object in the coin counter to represent text background and applied it to the prefab |
| 10/21/2021 | Added an object to represent the world indicator and applied it to the prefab |
| 10/21/2021 | Added an object to represent the world indicator's background and applied it to the prefab |
| 10/21/2021 | Created a script to manage the world indicator (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Game Interface/WorldIndicator.cs`) |
| 10/21/2021 | Gave the indicator its script |
| 10/23/2021 | Added `world` and `worldLevel` variables to the Statistics class |
| 10/23/2021 | Changed the stats file to be a monobehavior |
| 10/23/2021 | Renamed `instance` to `Instance` in the stats file, and applied get and set permissions to it |
| 10/23/2021 | Replaced the stats constructor with an `Awake()` method, and assigns the `Instance` variable there |
| 10/23/2021 | The variables `canvas`, `canvasComponents`, `player`, and `playerInvul` are all marked as internal instead of public |
| 10/23/2021 | Added a texture to represent the finish (`Source/Assets/Minigames/Entity March Dream/Textures/Finish.png`) |
| 10/23/2021 | Added an object to represent the finish, and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Finish.prefab`) |
| 10/23/2021 | Added 2 identical particle systems to the finish, each facing the other, and applied it to the prefab |
| 10/23/2021 | Removed a line of code that would create falsities where you stomped the EMD abstract enemy, but it still hit you (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Enemy.cs`) |
| 10/23/2021 | Created a script to represent the finish (`Source/Assets/Minigames/Entity March Dream/Scripts/Finish.cs`) |
| 10/23/2021 | Gave the finish its script |
| 10/23/2021 | Marked the EMD player's `anim` variable as internal (`Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs`) |
| 10/23/2021 | Replaced the EMD player camera's instance of the Player with a gameobject instead (`Source/Assets/Minigames/Entity March Dream/Scripts/PlayerCamera.cs`) |
| 10/23/2021 | Added a script to represent any item in EMD (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Item.cs`) |
| 10/23/2021 | Renamed `ren` to `sr` in the EMD abstract enemy |
| 10/23/2021 | Changed the type of `sr` from `Renderer` to `SpriteRenderer` in the EMD abstract enemy |
| 10/23/2021 | Moved the `tilemap` variable from the abstract enemy to the rolling enemy (`Source/Assets/Minigames/Entity March Dream/Scripts/EnemyRolling.cs`) |
| 10/23/2021 | Created a texture to represent 2 types of health boosts (`Source/Assets/Minigames/Entity March Dream/Textures/Health-Boosts.png`)) |
| 10/23/2021 | Added an object to contain all item types |
| 10/23/2021 | Created a script to represent a health boost (`Source/Assets/Minigames/Entity March Dream/Scripts/ItemHealthBoost.cs`) |
| 10/23/2021 | Created an object to represent a health boost and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Health Boost.prefab`) |
| 10/23/2021 | Gave the item its script |
| 10/23/2021 | Correctly renamed the EMD spike textures (`Source/Assets/Minigames/Entity March Dream/Textures/Spikes.png`) |
| 10/23/2021 | Moved the `Spike Right` texture further to the left to match up with the wall |
| 10/23/2021 | Created a struct to represent loot data (`Source/Assets/Misc/Scripts/Object Models/Loot.cs`) |
| 10/24/2021 | Created a `deathLoot` parameter in the abstract enemy |
| 10/24/2021 | Made the abstract enemy drop loot on death |
| 10/24/2021 | Made the `Die()` method virtual, and applied some standard code to it |
| 10/24/2021 | Removed a useless override of the `Die()` method in the rolling enemy |
| 10/24/2021 | Added an object to the game interface that represents and contains the pause menu |
| 10/24/2021 | Created a script to represent the general pause menu as a whole (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/Game Interface/PauseMenu.cs`) |
| 10/24/2021 | Gave the object its script |
| 10/24/2021 | Modified most classes in EMD to not update or move when paused |
| 10/24/2021 | Created a text object in the EMD pause menu |
