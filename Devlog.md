# Devlogs
## 10/01/2021 (21ga1001.0)

Hey everyone! Welcome to the first devlog of october!

### 0.
I did a lot this week, and I'm pretty happy with myself. I got a little unproductive the past 3 days, but I did a lot while I had the time. I just had a bit too much schoolwork to be able to fully work on this. But, point is, I did a lot this week.

### 1.
I made the player be able to take damage and die this devlog. The health works in percentages, but usually is diminished in either quarters or halves. But, it can really be whatever. I also made a difference between the global stats and the EMD stats, since that was getting confusing. Now the stats will be saved as its own file, though I haven't made that yet (mainly since it will be a bit complicated when merged with the launcher). But you can make the player take damage, and then they will be invulnerable for a bit, and while that happens any attempts to change the player health variable will not do anything. However, you can completely kill the player at any time, invulnerable or not, by executing the `Die()` method in the player. This shouldn't be used much, and is really only supposed to be called when the player falls off the world, but it can be used. The player also can flash either red-tinted or transparently when taking damage. It is currently set to and will probably stay as red. I also made the player fall a little bit faster than they jump. This is a trick used in most platformers that makes it seem more realistic (ex. SMB), despite the fact that it definitely isn't. We just aren't used to seeing a perfectly simulated jump, where the up time is exactly the same as the down time. So the `fallSpeed` variable controls that.

### 2.
I also made spikes. They use a different tilemap than regular ground to make things easier, but that does come with its own downsides, like now the tilemap doesn't check if the block is actually a spike texture, so you can make a wall that the player can walk though, but takes damage when they do, by just putting regular tiles there. That shouldn't be used, though, and when that doesn't happen, it works fine. It has a variable for damage and a variable for extra damage, which is triggered when the player hits the spikes with a high enough velocity (also a spike variable). In vanilla AM, these values will stay as they are currently.

### 3.
I made some semisolid platforms that to be honest, were way weirder to program than I expected. I thought I could just turn the collider on when the player was above it, but that caused the player to glitch out when passing through. I did some thing where it checks above and below, and I don't love it, but it works, so I am sticking with it. The semisolid platform has some variables, but probably don't touch them since they just make it stop working and it doesn't really make sense.

### 4.
I also made a hittable block, which I am going to use for coins and health boosts (I haven't made health boosts yet). They do what you might think, they bob up when you hit them and they spawn an item. While they aren't supposed to, they can spawn any gameobject or prefab given to them, so that could be something to play with. Most of the variables are pretty self-explanatory, and so I won't be explaining them here, but if you would like to know anyway, reach out somehow and I can give a bit more detail.

### 5.
I made a falling platform, which was pretty simple to code, except I wanted different gravity levels, so I had to somehow make the player stick to the falling platform, which I did by just giving the player a lot of gravity while on it. It is a bit of a weird fix, but it works completely, so I'm keeping it and you can't make me change my mind (probably).

### 6.
Lastly, I made a tiny bit of an enemy! It is pretty inspired by the goomba, but I am making it a ball, and it will roll around (rolling the other way when it hits a wall). I'm having some trouble getting it over slopes, but I'll fix that bit later. For now, it rolls pretty weirdly, and I'm not super proud of it at the moment, but chill, I'm working on it.

### Ending
So, that's about it! I've made a lot of progress this devlog, and I hope you like how it's coming along! I think I'm due to have the game's core mechanics finished by the end of this month, but the whole 50 levels thing might slow me down, and I've been considering lowering it down to 25, but we'll see how it goes! Anyways, have a good day!

P.S. Aaand, there's a new Unity update. Of course there is. I'll update to `2021.1.23f1` after this.

P.P.S. Also, I think the Release system will be: There will be a release for every Arcade Maniac version I feel ok compiling, which is definitely not every devlog, especially none of these first few devlogs. So I'll remove the release on Github for `21ga0909.0`

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
- Make the EMD enemy, you know, actually work
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 9/25/2021 | Added an `alive` private variable to `Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs` |
| 9/25/2021 | Finished the `Die()` method in the player |
| 9/25/2021 | Shuffled the order of things in the player `Update()` method |
| 9/25/2021 | Put `Collision()` and `Movement()` in an IF statement checking for being alive |
| 9/25/2021 | Moved `Source/Assets/Misc/Scripts/Object Models/` to `Source/Assets/Minigames/Entity March Dream/Scripts/` |
| 9/25/2021 | Changed the namespace of the statistics file from `That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels` to `That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels` |
| 9/25/2021 | Removed unrequired `using` statement to `That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream` in the statistics file (line 0) |
| 9/25/2021 | Changed the `PlayerHealth` and `p_PlayerHealth` variables in `Source/Assets/Minigames/Entity March Dream/Scripts/Object Models/Statistics.cs` to floats (from integers) |
| 9/25/2021 | Removed an extra whitespace line in `Source/Assets/Arcade/Scripts/StatCanvas.cs` (line 32) |
| 9/25/2021 | Added `Source/Assets/Misc/Scripts/Object Models/GeneralStats.cs` for representing all general statistics |
| 9/25/2021 | Moved `completedGames`, `requiredGames`, `totalGames`, `CompletedPercent`, and `CompletedPercentTotal` from `Source/Assets/Minigames/Entity March Dream/Scripts/Object Models/Statistics.cs` to `Source/Assets/Misc/Scripts/Object Models/GeneralStats.cs` |
| 9/25/2021 | Replaced all references to `Statistics` with `GeneralStats` in the statcanvas |
| 9/25/2021 | Removed `Source/GlobalSuppressions.cs`, `Source/GlobalSuppressions2.cs`, and `Source/Arcade Maniac.sln` as both are not being used in any way |
| 9/25/2021 | Added using references to `That_One_Nerd.Unity.Games.ArcadeManiac.Misc` and `UnityEngine.SceneManagement` in the EMD Player |
| 9/25/2021 | Swapped the assigning of `p_PlayerHealth` from line 15 to 14 in the EMD stats |
| 9/25/2021 | Added a using reference to `That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels` in the EMD Player |
| 9/25/2021 | Made `IsGrounded` account for the collider being missing in the EMD Player |
| 9/25/2021 | Made the EMD coin account for the EMD Player being missing (`Source/Assets/Minigames/Entity March Dream/Scripts/Coin.cs`) |
| 9/25/2021 | Made a `ren` reference to the Renderer in the EMD Player (and assign it in the `Awake()` method) |
| 9/25/2021 | Added a `deathDrag` variable to the EMD Player (used in `Die()`) |
| 9/25/2021 | Made the EMD Player not move at all if not on screen |
| 9/25/2021 | Made the EMD Player die when their y-position drops below a given variable `deathFloor` |
| 9/25/2021 | Applied new variables `deathDraw`, `deathFloor`, and `jumpHeightDeath` to prefab EMD Player |
| 9/25/2021 | Make the EMD Player fall faster (decided by a new variable `fallSpeed`) |
| 9/25/2021 | Applied the new variable `fallSpeed` to prefab EMD Player |
| 9/26/2021 | Moved all variabled in `Source/Assets/Minigames/Entity March Dream/Scripts/Manager.cs` to the EMD stats file |
| 9/26/2021 | Removed the `static` modifier in the `coinsCollected` variable in the EMD stats file |
| 9/26/2021 | Replaced all references to the EMD Manager with the appropriate reference to the EMD stats file |
| 9/26/2021 | Added a using reference in the EMD coin to `That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels` |
| 9/26/2021 | Deleted the EMD manager file |
| 9/26/2021 | Added a new tilemap specifically designed for spikes in EMD |
| 9/26/2021 | Added a script to manage spike collision in EMD (`Source/Assets/Minigames/Entity March Dream/Scripts/Spikes.cs`) |
| 9/26/2021 | Added the spike textures to the EMD tile palette (`Source/Assets/Minigames/Entity March Dream/Textures/Spikes.png`) (saved assets in `Source/Assets/Minigames/Entity March Dream/Palettes/Assets/`) |
| 9/26/2021 | Modified the EMD stats to clamp the player health value between 0 and 1, and to check for duplicates |
| 9/26/2021 | Made the EMD Player `Die()` method not return after setting the player health value |
| 9/26/2021 | Added a new variable `playerInvul` in the stats |
| 9/26/2021 | Made the player tick down the invul timer or set it null if it is not null |
| 9/26/2021 | Created a variable `invulTime` and `invulFlashSpeed` in the EMD player |
| 9/26/2021 | Made the player health not decrease if invulnerable, and set the invulnerable timer to the player variable when damage is taken |
| 9/26/2021 | Applied the player invulnerability timer and flash speed to the EMD player prefab |
| 9/26/2021 | Replaced any call to `Renderer` in EMD player with `SpriteRenderer` |
| 9/26/2021 | Removed the useless `Renderer` variable in the player |
| 9/26/2021 | Added new `InvulFlashMode` enum to player |
| 9/26/2021 | Added new variable `invulFlashMode` to player |
| 9/26/2021 | Made the player flash either transparently or to red when invulnerable/taking damage based off the variable `invulFlashMode` |
| 9/26/2021 | Drew some textures for some hittable block textures (`Source/Assets/Minigames/Entity March Dream/Textures/Hittable-Blocks.png`) |
| 9/26/2021 | Made an empty object for containing all hittable blocks |
| 9/26/2021 | Made an empty object for containing all coins |
| 9/26/2021 | Created an object to represent a hittable block, and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Hittable Block.prefab`) |
| 9/26/2021 | Gave the block a box collider 2D |
| 9/26/2021 | Created a script to manage the hittable block (`Source/Assets/Minigames/Entity March Dream/Scripts/HittableBlock.cs`) |
| 9/26/2021 | Gave the block its script |
| 9/26/2021 | Gave the hittable block a child that is used to render and animate (moved the spriterenderer over to it) |
| 9/26/2021 | Added an animation for the hittable block's child when it's hit (`Source/Assets/Minigames/Entity March Dream/Animations/Hittable Block/Block Hit.anim`) |
| 9/27/2021 | Made a texture for the semisolid platforms (`Source/Assets/Minigames/Entity March Dream/Textures/Semisolid-Platforms.png`) |
| 9/27/2021 | Made an empty object for containing all semisolid platforms |
| 9/27/2021 | Created an object to represent a semisolid platform, and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Semisolid Platform.prefab`) |
| 9/27/2021 | Created a script to manage the semisolid platform (`Source/Assets/Minigames/Entity March Dream/Scripts/SemisolidPlatform.cs`) |
| 9/27/2021 | Gave the platform its script |
| 9/27/2021 | Created a texture for a falling platform (`Source/Assets/Minigames/Entity March Dream/Textures/Falling-Platform.png`) |
| 9/28/2021 | Created an obhect for containing all falling platforms |
| 9/28/2021 | Created an object to represent a falling platform, and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Falling Platform.prefab`) |
| 9/28/2021 | Gave the platform a kinematic rigidbody |
| 9/28/2021 | Created a script to manage the semisolid platform (`Source/Assets/Minigames/Entity March Dream/Scripts/FallingPlatform.cs`) |
| 9/28/2021 | Gave the platform its script |
| 9/30/2021 | Gave the EMD player a `gravityScale` variable |
| 9/30/2021 | Applied the variable `gravityScale` to the prefab EMD player |
| 9/30/2021 | Made a texture for the EMD stompable enemy (`Source/Assets/Minigames/Entity March Dream/Textures/Enemy.png`) |
| 9/30/2021 | Created an object for containing all enemies |
| 9/30/2021 | Made a script for any EMD enemy to derive from (abstract) (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Enemy.cs`) |
| 10/01/2021 | Created an object to represent a ball enemy and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Rolling Enemy.prefab`)
| 10/01/2021 | Made a script for the rolling enemy (`Source/Assets/Minigames/Entity March Dream/Scripts/EnemyRolling.cs`) |
| 10/01/2021 | Gave the rolling enemy it's script |
| 10/01/2021 | Gave the rolling enemy a rigidbody 2d |
| 10/01/2021 | Gave the rolling enemy a circle collider |
