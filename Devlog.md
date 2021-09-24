# Devlogs
## 9/24/2021 (21ga0924.0)

### 0.
Ok so I was pretty unproductive this week. Sorry about that! Hopefully I'll be more productive next devlog.

### 1.
I made the camera actually work this devlog. I tried a new approach, instead of the other tricks where the camera would just try and position the player in the center at all times. This one only moves when you hit a certain part of the camera, which I've made easy to change, as it is just attached to a collider.

### 2.
I've also tried making some clouds. In order to do that, I made my own object pool manager which I am pretty happy with. The only real issue I have with it is that when you switch pool transforms it doesn't move the old items in it (yet), so I'll add that at some point. For now though and probably not ever in this game, I won't have to do that, so I don't have any real pressure to make it. Back to the topic of clouds, though, my system is more of spawning clumps of white circles that size up and down that despawn when they leave the school. To be honest, I could probably write that into a particle system, but I've never done any work with particle systems. I will start working with them at some point this game, but until I get at least decent with them, I don't want to try and turn the clouds into one. So, that will wait.

### 3.
Man, Unity is stupid when it comes to rebuilding the assembly. It does that pretty much anytime I add/rename/delete a script anywhere in the Assets folder. I wouldn't mind it that much except for some reason somewhere in the assembly rebuilding, it doesn't include the global suppressions I've made, so I have to add them again. And it also kind of alternates between rebuilding in .Net 5.0 and .Net 4.0, which gets really annoying because in either case, Unity's compiler still is using .Net 4.0, and so the things .Net 5.0 wants me to do cannot be done, with the biggest and most annoying one is the whole `new()` thing. I would use it, except .Net 4.0 doesn't allow it. But it is recommended to do it in .Net 5.0, which means that the whole time, Visual Studio is telling me to use `new()`, and when I do, Unity tells me I can't. I am also the kind of guy who doesn't like any messages of any kind, whether they are errors, warnings, or messages. So I get annoyed the whole time I code when it's built like that. And I know I can only suppress it until I mess with the files, which is guarenteed to happen. Anyways, that's my rant on Unity rebuilding the assembly.

### 4.
Lastly, I'm working on a few things, the player death code, damage code, and spikes. All of which are pretty connected. Oh, also I made the stone textures finally. Let me know how you feel about them. I was iffy about them when I made them, but I like them now.

### Ending
There it is! Again, sorry for not being super productive, but I think I'll be able to get back into it over the weekend. Also, I will be streaming this weekend, just to let you guys know!

P.S. I forgot to set the internal Unity build version to `21ga0924.0`, so it still says `21ga0916.0`. Not sure if you even knew I changed it, but I did. I'll try to remember next time, although to be frankly honest, it's easy to forget, and it doesn't do anything, so I might just not do it. We'll see.

Anyways, have a good day!

\- Nerd

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- ~~Reset the HDRP default settings and make custom ones for this camera only.~~
- ~~Remodel the cabinet screen to use a well-known aspect ratio~~
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- ~~Add stone textures to EMD~~
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 9/17/2021 | Upgraded to Unity `2021.1.21f1` |
| 9/18/2021 | Set the player's render layer to `50` to render above the main tilemap layer and below the foreground tilemap layer |
| 9/18/2021 | Lowered the player's hitbox by a quarter of a pixel to allow them to walk through one-block gaps |
| 9/18/2021 | Made the camera a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Camera.prefab`) |
| 9/18/2021 | Created a script to manage the Camera (`Source/Assets/Minigames/Entity March Dream/Scripts/PlayerCamera.cs`) |
| 9/18/2021 | Added a global suppression file to supress `IDE0090` (can't use `new()` in .Net 4.0) |
| 9/18/2021 | Added a collider trigger to the camera to act as a box which the player touches to move the camera |
| 9/18/2021 | Raised player jump height to `12.5` |
| 9/18/2021 | Created a white circle for the clouds (`Source/Assets/Minigames/Entity March Dream/Textures/Cloud.png`) |
| 9/18/2021 | Created an empty cloud object and turned it into a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Clouds.prefab`) |
| 9/18/2021 | Created a script to manage the clouds (`Source/Assets/Minigames/Entity March Dream/Scripts/Clouds.cs`) |
| 9/18/2021 | Created another supression file for `IDE0090` |
| 9/18/2021 | Created an object pool handler script in `Source/Assets/Misc/Scripts/Handlers/PoolHandler.cs` |
| 9/18/2021 | Gave the cloud prefab an object pool, with each object containing a sprite renderer with the cloud texture and a render layer of `-1000` |
| 9/18/2021 | Created a script to manage each piece of cloud in `Source/Assets/Minigames/Entity March Dream/Scripts/CloudPiece.cs` |
| 9/18/2021 | Replaced all requirements of `Unity.Mathematics` and removed said namespace |
| 9/18/2021 | Renamed the 3 tilemap layers to "Background," "Collision," and "Foreground" respectively. |
| 9/21/2021 | Created a script to manage EMD in `Source/Assets/Minigames/Entity March Dream/Scripts/Manager.cs` |
| 9/21/2021 | Changed the player and coin scripts to instead count the coins in the manager script |
| 9/21/2021 | Added a spike texture to the game (`Source/Assets/Minigames/Entity March Dream/Textures/Spikes.png`) |
| 9/23/2021 | Upgraded to Unity `2021.1.22f1` |
| 9/23/2021 | Retextured the EMD stone textures (`Source/Assets/Minigames/Entity March Dream/Textures/Stone-Tiles.png`) |
| 9/24/2021 | Added a `PlayerHealth` variable, a `p_playerHealth` private variable, and a `player` reference to the Player to the `Statistics` object model |
| 9/24/2021 | Removed redundancy in `Source/Assets/Misc/Scripts/Handlers/PoolHandler.cs` on line 70 |
| 9/24/2021 | Removed null coalescing in the PoolHandler script on line 27. I would have kept it except Unity didn't like it for some reason |
| 9/24/2021 | Created a `Die()` method in `Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs` |
