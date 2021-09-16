# Devlogs
## 9/16/2021 (21ga0916.0)

Hi! 2 devlogs down, many more to go!

### 0
I did a good amount this week. I am done for the most part with the arcade exterior for now. I will definitely come back to it later, as it is nowhere near finished, but now I am working on the minigames. But, let's get into summarizing the changelog.

### 1
I decided to do the thing I wanted and fix the arcade screen to use a `4:3` ratio, so images are now way easier to create. Since that happened, I also had to re-uv map the arcade, which meant I had to fix the broken textures. But, that wasn't hard because they were super basic anyways. I also decided to have a canvas on a second monitor for showing statistics. It is unrequired, and right now does literally nothing, but I'll work on that more some other time. I also imported TextMeshPro because I wanted text with different colors in it. I also figured out how to add custom HDRP assets to the camera, so I did that and reset the default ones. The player also had some weird stuff happening with the floor, so I removed all friction, and now it works fine.

### 2
Now comes the real nice part, where I start my first minigame. I started on EMD - AE (Entity March Dream - Arcade Edition), and I got a bit done. I started with some outlines for a tilemap which I will use, but didn't do much. I then textured some player sprites. I am using the same design as used in SASR (SneakAndSeek Remastered), TOT (Trick Or Treat), and RB (Rebuild). I also made a script to control their movement, animation, and collision. I took the approach of seperating each topic into it's own method and calling them all during the `Update()` method.

### 3
I have also made some textures for the grass. I think it looks very good. Note: the outline in the stone textures are sharper on purpose. It is to depict a stronger object. I have not finished the stone textures yet, but I will soon, possibly in the next stream. I also had an idea to get the textures for this game from another game which textures I really likes, but the developer said no, which is fair, and so I made my own, which I like just as much.

### 4
I also made a coin.

### Ending
So that's about it! I hope you liked the progress coming along. It is a bit slowed due to school, but luckily I've managed to stay on track at school so far (unlike last year :sade:), and I think I can keep it up, so development will be slowed slightly, but not as much as it would be if I wasn't on track. Anyways, have a good one!

P.S. Currently updating Unity to `2021.1.21f1` while writing this. Man, unity updates weekly I swear it is a little bit annoying lmao.

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- ~~Reset the HDRP default settings and make custom ones for this camera only.~~
- ~~Remodel the cabinet screen to use a well-known aspect ratio~~
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- Add stone textures to EMD
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 9/10/2021 | Removed some useless code in `Source/Assets/Arcade/Scripts/Floor.cs` |
| 9/10/2021 | Upgraded to `Unity 2021.1.20f1` |
| 9/11/2021 | Changed the screen in the arcade cabinet to be a `4:3` size ration |
| 9/11/2021 | Re-unwrapped the arcade cabinet model |
| 9/11/2021 | Fixed all broken arcade textures |
| 9/11/2021 | Added a canvas for displaying statistics to the player in the `Source/Assets/Arcade/Scenes/Arcade.unity`. This canvas renders to the second screen. |
| 9/11/2021 | Added a camera to the stat canvas for rendering. This camera has no audio listener |
| 9/11/2021 | Imported essentials for TextMeshPro |
| 9/11/2021 | Added the name of the game to the stat canvas (as a TMP) |
| 9/11/2021 | Added script to control stat canvas (`Source/Assets/Arcade/Scripts/StatCanvas.cs`) |
| 9/11/2021 | Added editorconfig file so VS 2019 would stop yelling at me for "Private member 'Update' is unused" |
| 9/11/2021 | Added a folder for script extensions in `Source/Assets/Misc/Scripts` |
| 9/11/2021 | Added a script extension to combine words together (Ex: `this is a test` => `ThisIsATest`) (`Source/Assets/Misc/Scripts/Extensions/CombineExtension.cs`) |
| 9/11/2021 | Added a folder for object models in `Source/Assets/Misc/Scripts` |
| 9/11/2021 | Added an object model for tracking stats (`Source/Assets/Misc/Scripts/Object Models/Statistics.cs`)
| 9/11/2021 | Added text to tell you how far you are into the game in the stat canvas |
| 9/11/2021 | Modified the editorconfig of VS so it would stop telling me to use `new()` over `new object()` (because that doesn't work in .Net 4.0, which Unity uses) |
| 9/12/2021 | Added a folder to contain a bunch of different roboto fonts in `Source/Assets/Misc/Fonts` |
| 9/12/2021 | Added a folder to contain the righteous regular font and TMP asset `Source/Assets/Misc/Fonts` |
| 9/12/2021 | Mofified the cabinet script to allow any outside script with the instance to detect if that arcade is active |
| 9/12/2021 | Added a folder for custom HDRP settings in `Source/Assets/Arcade` |
| 9/12/2021 | Added custom HDRP settings for the Arcade only in `Source/Assets/Arcade/HDRP` |
| 9/12/2021 | Modified the arcade player script to lower friction with the arcade mesh (edited `Source/Assets/Arcade/Scripts/Player.cs`) |
| 9/12/2021 | Added a new scene as a EMD test scene (`Source/Assets/Minigames/Entity March Dream/Scenes/Testing Game.unity`) |
| 9/12/2021 | Made outlines for some grass textures (the main textures for maps). They don't look like much, but they work for now (`Source/Assets/Minigames/Entity March Dream/Textures/Grass-Tiles.png`) |
| 9/12/2021 | Sliced `Source/Assets/Minigames/Entity March Dream/Textures/Grass-Tiles.png` into 40 8x8 tiles and named them and shaped their colliders accordingly |
| 9/12/2021 | Created a folder in `Source/Assets/Minigames/Entity March Dream` to store tile palette data, and a folder within it dedicated to tile palette assets |
| 9/12/2021 | Created a new tile palette named `EMD-Tilemap` dedicated to the textures for EMD and saved in `Source/Assets/Minigames/Entity March Dream/Palettes` |
| 9/12/2021 | Imported the grass textures into the palette and saved the assets in `Source/Assets/Minigames/Entity March Dream/Palettes/Assets` |
| 9/12/2021 | Added 3 tilemaps in a grid, layer 0 (background), layer 1 (main), and layer 2 (foreground) |
| 9/12/2021 | Textured some rock outline sprites, (rock textures are going to be decoration textures) (`Source/Assets/Minigames/Entity March Dream/Textures/Stone-Tiles.png`) |
| 9/12/2021 | Sliced `Source/Assets/Minigames/Entity March Dream/Textures/Stone-Tiles.png` into 40 8x8 tiles and named them and shaped their colliders accordingly |
| 9/12/2021 | Imported the stone textures into `EMD-Tilemap` palette and saved the assets in `Source/Assets/Minigames/Entity March Dream/Palettes/Assets` |
| 9/12/2021 | Designed a player for EMD based on the design in `TrickOrTreat`, `Rebuild`, and `SneakAndSeek Remastered` (`Source/Assets/Minigames/Entity March Dream/Textures/Player.png`) |
| 9/13/2021 | Split the player texture into 4 sprites to be used as animations (9x11) |
| 9/13/2021 | Created a script to control the player in EMD (`Source/Assets/Minigames/Entity March Dream/Scripts/Player.cs`) |
| 9/13/2021 | Created a folder to store prefabs in `Source/Assets/Minigames/Entity March Dream` |
| 9/13/2021 | Created a player object (saved in `Source/Assets/Minigames/Entity March Dream/Prefabs`) |
| 9/14/2021 | Added a custom tag representing the ground named "EMD Ground." Layer 1 (main) is given this tag |
| 9/16/2021 | Created a folder to store animations in `Source/Assets/Minigames/Entity March Dream` and a folder in that for the Player |
| 9/16/2021 | Created animations for the player standing still, walking, jumping, and falling (`Source/Assets/Minigames/Entity March Dream/Animations/Player/*.anim`) |
| 9/16/2021 | Gave the player a prefab in `Source/Assets/Minigames/Entity March Dream/Prefabs` |
| 9/16/2021 | Added a coin texture (`Source/Assets/Minigames/Entity March Dream/Textures/coin.png`) |
| 9/16/2021 | Added a script for managing the coin (`Source/Assets/Minigames/Entity March Dream/Scripts/Coin.cs`) |
| 9/16/2021 | Added a coin object and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Coin.prefab`) |
| 9/16/2021 | Added actual design to the grass textures for EMD |
