# Devlogs
## 11/14/2021 (21ga1114.0)

Hey everyone! EMD is pretty much done!

### 0.
So I haven't done a bunch this week, but next week I bet I'll get a ton done, because I've started a new minigame, called Rocket Mayhem! RM is a bullet-hell game, and you can see more details on the [trello](https://trello.com/c/Ygtg6AYm/5-rocket-mayhem). Anyways, here's what I've got.

### 1.
So I finally got enough knowledge of Unity's particle system to use it to make clouds. It isn't amazing, and I wish I could include bunches, but oh well, good enough (for now at least, who knows). I also started a bit on the sound effects of the game. I will end up working on music eventually, but it isn't a task I want to work on right now, so I'll probably do it towards the end of development. But I do have some sound effects for the game, and they work well. I learned how to use animation triggers, which are way better of a solution than my old solution, which was to toggle a variable in a script. Lmao, that one isn't nearly as neat and tidy as this one.

### 2.
I've also done a bit with post-processing. I'm not amazingly happy with it, and I'll probably come back to it once I get an idea of how exactly I want it, but it works for now. I thought I would have to use the post processing stack, but apparently HDRP already comes with post processing, so that was great. I couldn't get the stack to work anyways lmao, so at least we have this (though, I was probably just stupid and missed something obvious to get the stack to work. Oh well).

### 3.
That's basically it with EMD. We have levels to do, and I suck at making levels, so I'm not going to do it right now. Instead, I've started on the next minigame, Rocket Mayhem. I haven't done much, but I have selected a palette to use, `mail24` (not sure why it's called that), and I've made a design for the player rocket, which will randomly be assigned a new color every time you load the scene. The rocket also moves in the direction of the mouse, when any key is pressed. It's also supposed to rotate towards the mouse position, but I don't have that one down yet. It just spins out of control right now.

### Ending.
Anyways, that's about it. Since EMD is pretty much done, this will be the first alpha release. You basically only have one level, but you do get to test out the mechanics for yourself. Also, something I'm gonna want to do at some point is to lower the MSAA (Multi-Sample Anti-Aliasing) count, because right now I have it at x3, and that will definitely not run on all computers. Something to fix in the future. Anyways, that's about it! Have a good one!

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
- ~~Turn the EMD clouds into a particle system~~
- ~~Finish the EMD pause menu~~
- ~~Make the EMD start menu~~
- Make the RM (Rocket Mayhem) rocket not flip out when turning
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 11/08/2021 | Upgraded to `Unity 2021.2.1f1` |
| 11/08/2021 | Downgraded to `Unity 2021.1.28f1` |
| 11/08/2021 | Replaced the EMD cloud object pool with a particle system (`Source/Assets/Minigames/Entity March Dream/Prefabs/Clouds.prefab`) |
| 11/08/2021 | Parented the EMD clouds to the EMD camera (`Source/Assets/Minigames/Entity March Dream/Prefabs/Camera.prefab`) |
| 11/11/2021 | Added to the player the `hurtSound`, `healSound`, `jumpSound`, `walkSound`, `coinSound`, `stompSound`, and `landSound` audio clip variables (`Source/Assets/Minigames/Entity March Dream/Prefabs/Player.prefab`) |
| 11/11/2021 | Added a `audioSource` internal variable to the player |
| 11/11/2021 | Added an audio source component to the player and applied it to the prefab |
| 11/11/2021 | Made the player play the `jumpSound` clip when jumping |
| 11/11/2021 | Created a folder in EMD for sound clips (`Source/Assets/Minigames/Entity March Dream/Sounds/`) |
| 11/11/2021 | Created a sound clip for the player jump (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Jump.wav`) |
| 11/11/2021 | Created a sound clip for the player when they gain health (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Gain Health.wav`) |
| 11/11/2021 | Created a sound clip for the player when they lose health (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Lose Health.wav`) |
| 11/11/2021 | Made the player play the heal/hurt sounds when their health changes (`Source/Assets/Minigames/Entity March Dream/Scripts/Object Models/Statistics.cs`) |
| 11/11/2021 | Created a sound clip for the player when they collect a coin (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Collect Coin.wav`) |
| 11/11/2021 | Made the player play the coin sound when they collect a coin (`Source/Assets/Minigames/Entity March Dream/Scripts/Coin.cs`) |
| 11/11/2021 | Updated the Visual Studio Editor package from `2.0.11` to `2.0.12` |
| 11/11/2021 | Created a sound clip for the player when they land (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Land.wav`) |
| 11/11/2021 | Made the player play the land sound when they fall |
| 11/11/2021 | Created a sound clip for when any enemy dies (`Source/Assets/Minigames/Entity March Dream/Sounds/Enemy Die.wav`) |
| 11/12/2021 | Made the player play the stomp sound when an enemy dies (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Enemy.cs`) |
| 11/12/2021 | Created a method in the player script to play the walk sound |
| 11/12/2021 | Added animation events in the player walk animation to trigger the walk sound via the new method (`Source/Assets/Minigames/Entity March Dream/Animations/Player/Player Walking.anim`) |
| 11/12/2021 | Created a sound clip for when the player walks (`Source/Assets/Minigames/Entity March Dream/Sounds/Player Step.wav`) |
| 11/13/2021 | Added a new folder for any rendering effects in EMD (`Source/Assets/Minigames/Entity March Dream/Rendering Effects/`) |
| 11/13/2021 | Added an HDRP Volume Profile for the EMD player camera (`Source/Assets/Minigames/Entity March Dream/Rendering Effects/EMD Camera Volume.asset`) |
| 11/13/2021 | Added an HDRP Volume component in the camera and gave it the profile, and applied it to the prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Camera.prefab`) |
| 11/13/2021 | Added a lens distortion affect to the volume profile |
| 11/13/2021 | Applied the EMD volume profile to the camera in the title screen (`Source/Assets/Minigames/Entity March Dream/Scenes/EMD Title Screen.unity`) |
| 11/13/2021 | Set up World 1-1 in EMD for world designing (`Source/Assets/Minigames/Entity March Dream/Scenes/World 1/EMD Level 1-1.unity`) |
| 11/14/2021 | Made a scene for World 1-2 in EMD (`Source/Assets/Minigames/Entity March Dream/Scenes/World 1/EMD Level 1-2.unity`) |
| 11/14/2021 | Finished EMD level 1-1 |
| 11/14/2021 | Created a folder for the new minigame, Rocket Mayhem (`Source/Assets/Minigames/Rocket Mayhem/`) |
| 11/14/2021 | Created a folder for RM (Rocket Mayhem) scenes (`Source/Assets/Minigames/Rocket Mayhem/Scenes/`) |
| 11/14/2021 | Created a folder for RM scripts (`Source/Assets/Minigames/Rocket Mayhem/Scripts/`) |
| 11/14/2021 | Created a folder for RM textures (`Source/Assets/Minigames/Rocket Mayhem/Textures/`) |
| 11/14/2021 | Created a sample scene for RM (`Source/Assets/Minigames/Rocket Mayhem/Scenes/Testing Game.unity`) |
| 11/14/2021 | Created a script for the player (`Source/Assets/Minigames/Rocket Mayhem/Scripts/PlayerRocket.cs`) |
| 11/14/2021 | Created a texture for 8 different possible rockets for the player (`Source/Assets/Minigames/Rocket Mayhem/Textures/Player-Rockets.png`) |
