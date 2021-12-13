# Devlogs
## 12/13/2021 (21ga1213.0)

Happy December everyone!

### 0.
Ok, so I meant to release this devlog yesterday, but I didn't have time, because of the teaser I made over the weekend (which if you haven't seen already, you can find [here](https://www.youtube.com/watch?v=KVMNJAwnl9w). Yes, I am now working on 2 games at the same time. I'll try not to work too little here, though, but we'll see how it goes.

### 1.
Anyways, me and Saalty have made some more projectiles for Rocket Mayhem, and I've still been trying to fix the particles, but it won't work for some reason. This one issue has burnt me out quite a bit, but hopefully I'll figure it out soon. And, this is not something I can compromise. I kind of *need* to be able to turn particles on and off at will, even if not for this game, then for the next minigames. So, I still have that to fix. Fun. :\(

### 2.
I've made a temporary texture for the enemy rockets since I didn't want to stare at white boxes for the rest of eternity, so now it's a red outline with a shadow because I wanted a shadow for some reason. So we have that. I'll make them actual textures eventually, but for now they will stick, because I don't really want to texture them, at least not yet.

### 3.
The camera now follows the player, and the code for it is in its own file. I've put the code in a `FixedUpdate()` loop, which for those of you who don't know, is triggered a specified amount every second. I did that instead of the regular `Update()` loop, because the physics of the rocket runs on the fixed loop as well, and if I don't follow along, I get weird jittery effects. I didn't realize this was the case until now, so if you look back at some of my other games, mainly `Rebuild` and `SneakAndSeek (both remastered and original)`, you'll see the jitter I'm talking about. 

### 4.
And now I've started work on another minigame at the same time, `The Average 9-5 Job` (aka the Text Only game). This one will probably take very little time to make, I've just got to work out a good system, and then make the actual storyline, and that's basically it. I've made the font for this minigame `Roboto Mono`, because I think that font fits the genre. I've made a bunch of stuff, I just have to work on a little debugging to fix the triggers working on an input being given. After that, I can basically start the storyline. I can almost guarantee that this game will be done by the end of this month, but who knows.

### 5.
Lastly, I changed a bunch of `System.Collections.IEnumerator` methods to `async` methods, because I think they are far neater to work with, and produce nearly identical results. So I went and changed all of those methods to their equivalent async method. I haven't tested all of them, but I've tested a few, and they all work, so it *should* be fine. Hopefully.

### Ending.
Anyways, that's the end of the devlog. I haven't worked in almost a week on this game, which isn't amazing, but I think I can get a lot done in the next few weeks.

Well, I'll see you then!

P.S: I'm gonna stop updating Unity versions, because the `2021.2.XX` versions are causing a bunch of errors for some reason (and also I don't want to drive Saalty insane with the weekly updates, lmao).

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- Fix the RM player rocket's particle systems
- Add textures to the RM rockets.
- Add RM background (stars).
- Make the RM particle systems work.
- Fix 9-5 method calling.
- Obviously more.

### Complete Changelog
| Date | Change |
| - | - |
| 12/3/2021 | Made a folder for abstract scripts in Rocket Mayhem (`Source/Assets/Minigames/Rocket Mayhem/Scripts/Abstract/`) |
| 12/3/2021 | Made an abstract projectile class for Rocket Mayhem (`Source/Assets/Minigames/Rocket Mayhem/Scripts/Abstract/Projectile.cs`) |
| 12/3/2021 | Removed some useless variables in the abstract Item class in EMD (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Item.cs`) |
| 12/3/2021 | Made the Enemy Rocket class in Rocket Mayhem derive from the newly created abstract item class (`Source/Assets/Minigames/Rocket Mayhem/Scripts/EnemyRocket.cs`) |
| 12/3/2021 | Renamed the Enemy Rocket class to `ProjectileSeeking` (`Source/Assets/Minigames/Rocket Mayhem/Scripts/ProjectileSeeking.cs`) |
| 12/3/2021 | Renamed the Enemy Rocket Spawner class to `ProjectileSpawner` (`Source/Assets/Minigames/Rocket Mayhem/Scripts/ProjectileSpawner.cs`) |
| 12/3/2021 | Created a temporary texture for the seeking projectile object (`Source/Assets/Minigames/Rocket Mayhem/Textures/Projectile-Seeking.png`) |
| 12/5/2021 | Modified the camera script to include a speed parameter (`Source/Assets/Minigames/Rocket Mayhem/Scripts/CameraController.cs`) |
| 12/5/2021 | Gave the RM camera the camera controller script |
| 12/7/2021 | Added an exploding projectile script (`Source/Assets/Minigames/Rocket Mayhem/Scripts/ProjetileExploding.cs`) |
| 12/7/2021 | Made a prefab for the exploding projectile (`Source/Assets/Minigames/Rocket Mayhem/Prefabs/Projectile Exploding.cs`) |
| 12/7/2021 | Made a folder for the next minigame (`Source/Assets/Minigames/The Average 9-5 Job/`) |
| 12/7/2021 | Made a folder for the scenes in 9-5 (`Source/Assets/Minigames/The Average 9-5 Job/Scenes/`) |
| 12/7/2021 | Made a folder for the prefabs in 9-5 (`Source/Assets/Minigames/The Average 9-5 Job/Prefabs/`) |
| 12/7/2021 | Made a folder for the scripts in 9-5 (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/`) |
| 12/7/2021 | Made a scene for the actual game (`Source/Assets/Minigames/The Average 9-5 Job/Scenes/Main.unity`) |
| 12/7/2021 | Removed a useless method `TestParticles()` from the RM player (`Source/Assets/Minigames/Rocket Mayhem/Scripts/PlayerRocket.cs`) |
| 12/7/2021 | Replaced all `System.Collections.IEnumerator` instances with their appropriate asyncronous variations |
| 12/7/2021 | Made a font folder for Roboto Mono (`Source/Assets/Misc/Fonts/Roboto Mono/`) |
| 12/7/2021 | Added the Roboto Mono family to its folder |
| 12/7/2021 | Added a canvas and a text object to the 9-5 main scene. |
| 12/7/2021 | Created a text renderer script and game it to the newly created text object (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/TextRenderer.cs`) |
| 12/7/2021 | Created a folder for abstract items in the game (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/Abstract/`) |
| 12/7/2021 | Created an abstract struct to represent a game scene (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/Abstract/GameScene.cs`) |
| 12/7/2021 | Created an input bar for the user |
| 12/7/2021 | Created a script to control the input bar (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/InputHandler.cs`) |
| 12/7/2021 | Replaced the `typeof()` reference with a slightly better `GetType()` reference in the Stat Canvas (`Source/Assets/Arcade/Scripts/StatCanvas.cs`) |
