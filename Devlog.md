# Devlogs
## 1/10/2022 (22ga0110.0)

Hey everyone! Happy 2022!

### 0.
Ok, so I know it has been a really long time since the last devlog, and I'm sorry about that. I had a bunch of fun with the family, and just wanted to chill out for a few weeks. I've also been working a bit on Brigade Laboratories, though I got a bit stuck now that I'm at a bit of a trickier part. Teaser coming soon, though I don't know when. But, when I started, I got a bit done.

### 1.
I started by finally fixing that glitch about methods not being found. Turns out it was just because the methods weren't public. Oops. While I was there, I cleaned everything up, like making the text box for the game scene bigger, making the `WriteText()` method slower, etc. If a scene option is selected that doesn't have a method, it will default to move onto the next scene. I then began some of the storyline of the game. Don't panic, I'm not hiding the storyline for a reason. It isn't going to be deep by any means, and might not even be a storyline by some standards, so feel free to spoil it. Maybe don't do it though if you want the challenge of solving it for the first time, so you should wait for when it's done. But, you don't have to.

### 2.
I then moved on to Rocket Mayhem, and fixed a bunch of stuff there. I started by making an actual texture for the seeking rocket, removed an unneccesary parameter, and replaced and added more. Any rocket now has 2 states, an "active" one that is triggered on start and lasts a given number of seconds, then it switches to the "idle" state, which in the case of the seeking rocket, makes it simply fly off-screen. The rockets also now spawn pointing directly at the player. I then completely changed the rocket spawner mechanism, because I didn't love how it was using constant points along a rectangle that is supposed to spawn around the camera's bounds, but only does it for the 16-9 ratio. So, I went and reworked it, and with it I made some extra code that finds a point X percent along a rectangle. It could probably be optimized, but I'm kind of proud of it, because it is one of the times I've actually had to think hard about a mathematical problem that's actually useful in coding. There have been a few beforehand, but usually saalty did those (thanks, by the way. I don't like raytracing physics). The code for that percent along rectangle stuff can be found in `Source/Assets/Misc/Scripts/Extensions/GetPointAlongExtension.cs`. I then just made the spawner use that formula, using the camera's bounds in world-space as the rect, and generating a random decimal 0-1, and making that point the place to spawn the rockets.

### 3.
I also worked on the collision for Rocket Mayhem. I gave everything a smaller hitbox than its actual texture, because you might have a few close calls in the game, and I think it would be better to have an overly-small hitbox than an unfair, big hitbox with false-positives. At the current size, if hitboxes collide, you definitely hit something, fair and square. I then made a few more textures, a new texture for the exploding rocket, and one for a simple rocket, that came along with its own script. The simple rocket just points in the direction of the player at spawn, and just moves in that direction. Pretty, you know, *simple*.

### 4.
Next up, another new game. I know, I'm not finishing any, but I just don't want to do some of the stuff right now, and when I feel in the mood I'll do them. This new game is a programming game, and was, I'm not gonna lie, a big reason why I made the game not require every minigame be completed. I know programming is definitely not most people's fancy in a video game, so it is completely optional that you beat it. But, for the programming die-hards like me (in some languages), this game is for you. The game will use a language that's kind of a mix of c# and python, and it isn't going to be a very complicated language either. For example, you can only declare 5 types of variables, `int`, `decimal` (just a `float` in disguise), `bool`, `string`, and `char`. Also, you can't return any information in a method. Sorry. The language will have its own interpreter, custom made by me and saalty, which is kind of the reason I don't want to make it too complex, because programming an interpreter/compiler sucks. This programming language is going to be like python in the sense that methods are all declared by one keyword, `func`, but the program doesn't need a `Main()` method to run, but like c# in the sense that everything is going to be constrained in `{}`, and things like `for` and `while` loops act in similar ways to c#. Really, I think it's a good mix of complex and easy to understand, at least to someone with a little background in programming. The game will have several different challanges that involve programming some object to do some task. I haven't though of all the challenges yet, but I am brainstorming, don't you worry.

### 5.
The game is called Hacker Magic, by the way. HM for short. I've made a basic version of the text-box used to program in so far, and I've also cooked up a syntax highlighter to go along with it, and it taught me that the syntax highligher developers are probably seriously underpaid. That sucked. But, it got done, and I like how it functions. With the debug mode switch on, like it is currently, text glitches out like mad when there is an error in the highlighter, but if the switch is off, in the case of an error, the highlighter will simply default to highlighting nothing. Better than breaking all of the code, I guess. It runs on Unity's rich text system, because I didn't want to make my own fragment shader for that, that's way out of the scope of my intentions. So, it works as is, but adding your own rich text into the code kind of breaks it. Do it at your own risk, I suppose. I asked saalty to make the interpreter, but if he isn't up for that, I'll do the making.

### Ending.
Well, that's about it. I feel pretty productive about what I've done the last 2 weeks. I meant to post the devlog over the weekend, but I forgot. Oh well, it happens sometimes. I might not be able to do weekly devlogs anymore though, sorry. I'll try to stick to every 2 weeks, but we'll see how it goes. I won't get worse than monthly, though, don't worry. And this game isn't getting cancelled, no way. It may take me a decade (hopefully not), but I'll get this game out.

Have a good 2022, everybody!

P.S. I think I actually have the interpreter in HM currently highlighting `float` instead of `decimal`. That'll get fixed in the next devlog.

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- Fix the RM player rocket's particle systems
- Add textures to the RM rockets.
- Add RM background (stars).
- Make the RM particle systems work.
- ~~Fix 9-5 method calling.~~
- Add an interpreter for HM
- Obviously more.

### Complete Changelog
| Date | Change |
| - | - |
| 1/1/2022 | Fixed the 9-5 method calling by making the option methods public (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/SceneManager.cs`) |
| 1/1/2022 | Made `Scene0Option1()` transition back to the arcade in the scene manager |
| 1/1/2022 | Added a `CurrentSceneIndex` variable that indirectly changes the `CurrentScene` variable. |
| 1/1/2022 | Made the abstract game scene model use a big text box for the `Text` variable (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/Abstract/GameScene.cs`) |
| 1/1/2022 | Modified the abstract game scene model to represent the variables in a more neat manner. |
| 1/1/2022 | Gave the abstract game scene model a new variable to depict the speed of the scene text being written. |
| 1/1/2022 | Modified the default speeds of the `WriteText()` method of the TextRenderer to be slower. (`Source/Assets/Minigames/The Average 9-5 Job/Scripts/TextRenderer.cs`) |
| 1/1/2022 | Modified the SceneManager to make new speed the old speed divided by the speed given. |
| 1/1/2022 | Added a default method for when scene options don't have their functions. |
| 1/1/2022 | Removed the method for Scene 0 Option 0, since it's purpose was already covered by the default method. |
| 1/1/2022 | Added game scenes 1 - 10 (10 is incomplete) |
| 1/1/2022 | Removed the spawner in the Rocket Mayhem testing scene and replaced it with a single seeking projectile (`Source/Assets/Minigames/Rocket Mayhem/Scenes/Testing Game.unity`) |
| 1/1/2022 | Changed the pixels per unit variable in the seeking projectile texture from 8 to 12 (`Source/Assets/Minigames/Rocket Mayhem/Textures/Projectile-Seeking.png`) |
| 1/1/2022 | Replaced the temporary seeking projectile texture with a real one |
| 1/1/2022 | Added a texture for the simple projectile (`Source/Assets/Minigames/Rocket Mayhem/Textures/Projectile-Simple.png`) |
| 1/1/2022 | Removed the `sprite` variable in the abstract projectile, since it wasn't necessary. (`Source/Assets/Minigames/Rocket Mayhem/Scripts/Abstract/Projectile.cs`) |
| 1/1/2022 | Removed the `lifetime` variable, as it had a better counterpart `activeTime` |
| 1/1/2022 | Renamed the `Move()` virtual methods to `MoveActive()` |
| 1/1/2022 | Added a `MoveIdle()` virtual method that simply moves the rocket forward. |
| 1/1/2022 | Made the `activeTime` variable control if the rocket uses the `MoveActive()` method or the `MoveIdle()` methods. |
| 1/1/2022 | Added a `speedIncrease` variable, and made it slowly increase the rocket speed (only if idle). |
| 1/1/2022 | Completely reworked the projectile spawner (`Source/Assets/Minigames/Rocket Mayhem/Scripts/ProjectileSpawner.cs`) |
| 1/1/2022 | Added an extension for getting points along a rectangle (`Source/Assets/Misc/Scripts/Extensions/GetPointAlongExtension.cs`) |
| 1/2/2022 | Made a script for a simple projectile, one that doesn't follow the player (`Source/Assets/Minigames/Rocket Mayhem/ProjectileSimple.cs`). |
| 1/2/2022 | Made a prefab for the simple projectile (`Source/Assets/Minigames/Rocket Mayhem/Prefabs/Projectile Simple.prefab`). |
| 1/2/2022 | Made the enemy projectile look at the player in the awake function. |
| 1/2/2022 | Made the exploding projectile script explode when it hits the player or becomes idle (`Source/Assets/Minigames/Rocket Mayhem/Scripts/ProjectileExploding.cs`) |
| 1/2/2022 | Made the abstract projectile's `HitPlayer()` method also call the `Despawn()` method |
| 1/2/2022 | Created a texture for the exploding projectile (`Source/Assets/Minigames/Rocket Mayhem/Textures/Projectile-Exploding.png`) |
| 1/2/2022 | Applied the texture to the exploding projectile prefab (`Source/Assets/Minigames/Rocket Mayhem/Prefabs/Projectile Exploding.prefab`) |
| 1/2/2022 | Gave each projectile a collider slightly smaller than its texture. |
| 1/2/2022 | Gave the player prefab a collider (`Source/Assets/Minigames/Rocket Mayhem/Prefabs/Player Rocket.prefab`) |
| 1/2/2022 | Assigned the collider in the player script (`Source/Assets/Minigames/Rocket Mayhem/Scripts/PlayerRocket.cs`) |
| 1/2/2022 | Made the abstract projectile assign the collider, checked it against the player collider to trigger the `HitPlayer()` method |
| 1/3/2022 | Added a folder for a new game, the programming game called `Hacker Magic` (`Source/Assets/Minigames/Hacker Magic/`) |
| 1/3/2022 | Made a new folder for the game's scenes (`Source/Assets/Minigames/Hacker Magic/Scenes/`) |
| 1/3/2022 | Made a folder for the scripts (`Source/Assets/Minigames/Hacker Magic/Scripts/`) |
| 1/3/2022 | Made a scene for testing (`Source/Assets/Minigames/Hacker Magic/Scenes/Testing.unity`) |
| 1/3/2022 | Added the `Press Start 2P` font to the game (`Source/Assets/Misc/Fonts/Press Start 2P/Press Start 2P.ttf`) |
| 1/3/2022 | Added a canvas to view the program. |
| 1/3/2022 | Made a script to highlight text and format it (`Source/Assets/Minigames/Hacker Magic/Scripts/SyntaxManager.cs`) |
| 1/3/2022 | Made an object model for a markup component (`Source/Assets/Minigames/Hacker Magic/Scripts/Object Models/MarkupComponent.cs`) |
| 1/4/2022 | Made an extension for comparing strings (`Source/Assets/Misc/Scripts/Extensions/IsSimilarExtension.cs`) |
| 1/4/2022 | Added an extension for figuring out if a list contains another list at a current index (`Source/Assets/Misc/Scripts/Extensions/ContainsAtExtension.cs`) |
| 1/4/2022 | Made an object model for only markup info, not a whole component (`Source/Assets/Minigames/Hacker Magic/Scripts/Object Models/MarkupInfo.cs`) |
| 1/5/2022 | Made an extension for detecting string differences (`Source/Assets/Misc/Scripts/Extensions/DifferenceExtension.cs`) |
| 1/5/2022 | Made a script to execute the program given (`Source/Assets/Minigames/Hacker Magic/Scripts/ScriptExecutor.cs`) |
| 1/5/2022 | Made an object model for an "environment variable" (The variables in the programming game) (`Source/Assets/Minigames/Hacker Magic/Scripts/Object Models/EnvironmentVariable.cs`) |
| 1/6/2022 | Reworked some of the interpolation extension code (`Source/Assets/Misc/Scripts/Extensions/InterpolateExtension.cs`) |
