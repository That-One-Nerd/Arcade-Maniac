# Devlogs
## 10/15/2021 (21ga1015.0)

4 down! (Would have been 5, but I missed last week)

### 0.
Alright, so these past 2 weeks were very unproductive. I've just been distracted almost every day. I won't be able to stream this weekend, because I'll be going on a camping trip, but hopefully I'll be able to stream next weekend, and that will finally get me back into the mood. I've done some stuff here and there, but overall not very much. You can see where I just stopped, basically after the 7th.

### 1.
The first thing I've done is changed the name of the ball enemy from `Rolling Enemy` to `Enemy Rolling`, just so all the enemies appear together alphabetically. I've also made that, along with the base abstract class, actually work. One thing to note is that so far, the rolling enemy doesn't have any speed cap. So that might be something I have to do. But for now, and for any bumpy and weird terrain, it works fine. The rolling enemy will disable its gravity to climb up slopes, because otherwise it can't. The enemy will also despawn when below the death barrier, and not move at all when off screen. This does leave room for seeing the enemy be a little weird when you move over to it after being off screen, but it works for now, and I don't have too much of any intention of changing it. If I would, I might just increase the bounds of the check (somehow, not sure yet). Lastly, the player will now bounce off the enemy when stomping it, higher if holding jump.

### 2. 
Added a canvas for the game interface, and added a health bar. The bar has an animation for taking damage and gaining health. To be honest, I think working on the canvas is what burnt me out this week, but I'm not super sure.

### 3.
It's extension time! I added an extension to any monobehavior to shake it's gameobject. I did that instead of making it monobehavior specific, because I'm definitely going to use the exact same shake method many times in Arcade Maniac (not just EMD). So, might as well make it easy to access in many places. That also saved me the burden of making an animation that shakes the health bar, because I already wanted to do that. Sometimes, coroutines are just better than animations. Speaking of which, for those of you who don't know what a coroutine is, it is basically Unity's way of making a function that can last several frames. You make one by making the return type of a method `System.Collections.IEnumerator`, and now anything before a `yield return <something, usually null. literally doesn't matter>;` statement will be executed in that frame. Every one of those statements is equivalent to waiting for the next frame. They do have to be called in a special way, though. You have to run `StartCoroutine(IEnumerator)` for it. Otherwise, it will run like a normal method. Anyways, that's coroutines for you.

### Ending.
And you wanna know what? That's ***it***. In 2 weeks. That's all of it. As you can see, I was really unproductive this week. Hopefully I can make it up next week. I have a goal to get at least a changelog the size of this one or larger in the week. We'll see how it goes. I sure hope I can make that goal. Anyways, that's all. Have a nice week, you guys!

\- Nerd

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
- Obviously more.

### Complete changelog:
| Date | Change |
| - | - |
| 10/01/2021 | Upgraded to `Unity 2021.1.23f1` |
| 10/02/2021 | Applied all variables to the EMD rolling enemy prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Rolling Enemy.prefab`) |
| 10/02/2021 | Renamed the prefab to "Enemy Rolling" |
| 10/02/2021 | Added a using modifier for `System.Linq` in the EMD abstract enemy class (`Source/Assets/Minigames/Entity March Dream/Scripts/Abstract/Enemy.cs`) |
| 10/02/2021 | Changed the `AssignVars()` method in the EMD enemy to instead of looking for only one tilemap collider, look for all and filter for a specific one |
| 10/02/2021 | Changed the `AssignVars()` method to modify the rigidbody shared material instead of the collider's |
| 10/02/2021 | Changed the `Awake()` method in the EMD rolling enemy script to modify the rigidbody shared material instead of the collider's (`Source/Assets/Minigames/Entity March Dream/Scripts/EnemyRolling.cs`) |
| 10/02/2021 | Removed some comments in the EMD rolling enemy script that was there for clarification |
| 10/02/2021 | Added a new variable `groundDist` in the EMD rolling enemy |
| 10/02/2021 | Made the `Move()` method in the EMD rolling enemy detect when it is next to a slope and disable gravity when it is (to make it able to climb) on lines 42 - 48 |
| 10/02/2021 | Added an `OnCollisionStay2D(Collision2D collision)` method in the EMD rolling enemy that detects when the enemy has hit a wall and makes it turn around |
| 10/02/2021 | Set the player's mass to be 100 (`Source/Assets/Minigames/Entity March Dream/Prefabs/Player.prefab`) |
| 10/02/2021 | Changed the height of the semisolid platform in the example from `3.36` (idk why it was like that) to `2` |
| 10/02/2021 | Changed the rolling enemy prefab speed to 2 |
| 10/02/2021 | Added a `Renderer` private variable to the emd abstract enemy (assigned in the `AssignVars()` method) |
| 10/02/2021 | Made the abstract enemy's rigidbody be disabled and not run the `Move()` method if the enemy is not on screen |
| 10/02/2021 | Added a call to `OnHitPlayer()` if the abstract enemy's bounding collider touches the player |
| 10/02/2021 | Made the abstract enemy despawn when it falls off the world |
| 10/05/2021 | Swapped line 22 in the abstract enemy script with a new virtual method `OnCollisionStay2D(Collision2D collision)`, which checks for if the player is moving down or not. If it is, execute `OnPlayerStomp()`, otherwise execute `OnHitPlayer()` |
| 10/05/2021 | Marked the rolling enemy's `OnCollisionStay2D(Collision2D collision)` as protected and override, and made it execute the base method |
| 10/06/2021 | Added `bounceHeight` and `bounceHeightExtra` variables to the EMD abstract enemy |
| 10/06/2021 | Made the `OnPlayerStomp()` method `virtual` in the EMD abstract enemy, and moved the code from the rolling enemy's version there |
| 10/06/2021 | Removed the `OnPlayerStomp()` method in the rolling enemy |
| 10/06/2021 | Made the player bounce when stomping on an enemy, higher if holding up |
| 10/06/2021 | Applied the `bounceHeight` and `bounceHeightExtra` variables to the rolling enemy prefab |
| 10/06/2021 | Added a canvas for UI and made it a prefab (`Source/Assets/Minigames/Entity March Dream/Prefabs/Game Interface.prefab`) |
| 10/06/2021 | Added a health slider in the canvas |
| 10/06/2021 | Made a texture for the health bar (`Source/Assets/Minigames/Entity March Dream/Textures/Health-Bar.png`) |
| 10/07/2021 | Created a script for each piece of the UI (`Source/Assets/Minigames/Entity March Dream/Scripts/GameInterfacePiece.cs`) |
| 10/07/2021 | Made the abstract enemy class use `OnCollisionEnter2D` instead of `OnCollisionStay2D` |
| 10/07/2021 | Created a folder for managing bunches of scripts in EMD (a bunch being many different scripts controlling tiny pieces of one thing. Ex: the many components in a canvas) (`Source/Assets/Minigames/Entity March Dream/Scripts/Bunches/`) |
| 10/07/2021 | Created a folder for managing the bunch of game interface scripts (`Source/Assets/Minigames/Entity March Dream/Scripts/Bundles/Game Interface`) |
| 10/07/2021 | Created a script to manage the health bar in the game interface (`Source/Assets/Minigames/Entity March Dream/Scripts/Bundles/Game Interface/HealthBar.cs`) |
| 10/07/2021 | Gave the health bar its script |
| 10/13/2021 | Added an extension script for representing gameobject shaking (`Source/Assets/Misc/Scripts/Extensions/ShakeExtension.cs`) |
| 10/13/2021 | Added an object model for shake data (`Source/Assets/Misc/Scripts/Object Models/ShakeData.cs`) |
| 10/13/2021 | Added a dictionary in the EMD stats script that contains all canvas components based on their gameobject |
| 10/13/2021 | Added a constructor to the EMD stats script that assigns all canvas components to the variable |
| 10/13/2021 | Makes the player health variable in the EMD stats script call `OnGainHealth()` or `OnLoseHealth()` in the EMD health bar depending on if you are gaining or losing health |
| 10/14/2021 | Created an animation for the EMD health bar when it gains health (`Source/Assets/Minigames/Entity March Dream/Animations/Game Interface/Health Bar/Gain Health.anim`) |
