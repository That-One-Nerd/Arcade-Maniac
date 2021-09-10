# Devlogs
## 9/9/2021 (21ga0909.0)

Hey everyone! The first devlog is out, and some big progress has been made! Here is some of it:

### 0.
Just for some info: we are using the High-Definition Render Pipeline (HDRP), because it looks way better than the regular Unity pipeline.

(Also, a new Unity release came out literally today and I didn't see it until writing this, so I guess I am one update behind. I'll update it for the next devlog.)

### 1.
I've modeled the Arcade and the parking lot outside it. I will definitely be adding some stuff in that scene, such as some clouds and a sun/moon, and some background stuff outside the parking lot. I also think that I will have a bit of area where you can walk around the exterior of the arcade. There are also some weird lighting issues, like where lights flicker a lot at a distance. That is partially because of the anti-aliasing, not sure why (using MSAA x8, will add a setting to change it at some point). I also had to mess around with the exposure a bit to get it right, and that meant from what I knew, changing the default settings. That probably wasn't the best idea, and if I can figure out how to get custom settings that apply on a per-camera basis, I'll change the settings to reflect that.

Also, just so everyone knows, I found this cool arcade company called [Ground Kontrol](https://groundkontrol.com) which I am now going to ~~completely copy~~ base my arcade off of. [Here](https://res.cloudinary.com/sagacity/image/upload/c_crop,h_668,w_1072,x_0,y_0/c_limit,f_auto,fl_lossy,q_80,w_1080/Ground_Kontrol_Exterior_-_Night_-_Photo_Credit_-_Charles_Marshall_Olson_nnbgew.png) is also an image I found of the exterior which I used as a reference.

### 2.
I've also modeled myself some doors, like the entryway door and the counter door. I figured out I can use the same avatar for different models, which means that I can use the same open and close door animations for different models, which was great and saved my the klunkyness of multiple animations that do the same thing to different models. I'll keep that in mind next time I make new animations. Also, this was my first time using the Action Editor in blender that lets me include multiple animations in one file. In order for it to import correctly, though, I have to export into a `.fbx` file. But, if it works, it works.

### 3.
I've added some flashing lights onto the floor of the arcade, and made a script to randomize the color. I personally like the feel of it, but on stream a few days ago I had to turn down the intensity of those lights so I could work on some better lighting. If anyone has a better intensity level, let me know. I also had to create almost duplicate materials for a few models, because Unity wouldn't import them correctly. That includes any emission or glass material. On the topic of Unity not importing stuff correctly, I had to set the lights to better levels in Unity, because the blender lights always ended up too dim when imported. Keep that in mind if you modify `Assets/Arcade/Models/Arcade.blend`.

### 4.
I've made myself an Arcade Cabinet with as little extra verts as I think possible, and used a UV map to texture it. This way, I don't have to model a new cabinet every time I want a new game, I just need a new texture. I'm going to make the screen it's own seperate material, so I can make it an emission for extra effect. It will also be a texture. I think in the future I will modify the model a little bit so I can make the screen a good aspect ratio, like `4:3` or something like that, because I didn't consider that at all when making the model this time around. Also, joysticks, buttons, textures, and other details will all be added in the coming future.

By the way, [here](https://www.recroommasters.com/v/vspfiles/photos/RM-XT-ALPHA-JAMMA-2T.jpg) is the image I used to base my cabinet off of.

### 5.
I made a brand new player controller that I'm pretty happy with. It's got a rotation interpolator which turns off when your framerate drops below 18, because that's when the interpolation begins to break down. That value can be changed though, as can most other settings in the player controller. It also normalizes the momentum, so unlike my other 3d player controllers ~~*cough cough* The Caveman *cough cough*~~, travelling diagonally is no longer any faster than moving in a straight line.

### 6.
The arcade will also align the camera with it's viewpoint when interacted with in a customizable radius that will probably stay around `5`. There are some bugs to squash, like when you interact with the cabinet with the "Space" key, the player will both jump and align it's camera with the cabinet, which is a little bit weird because the camera is parented to the player. That can be fixed pretty easily in a number of ways, though, so that'll get patched in the next devlog, that's for sure.

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- Reset the HDRP default settings and make custom ones for this camera only.
- Remodel the cabinet screen to use a well-known aspect ratio
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- Obviously more.

### Ending
Anyways, that's about it for the first devlog! I will definitely be doing a lot more in the future, and I can't wait to see how progress goes! Because of this, the github will include a new branch for every version. `main` will always have the latest version, though!

Also, for those of you who don't understand the version scheming, here it is:

```
21ga0909.0
^ ^^ ^ ^ ^
a bc d e f

a: the last 2 digits of the year of the release
b: this is the game (g), not the launcher (l)
c: this is an alpha release (alpha is before release 1.0, vanilla is release 1.0 and forward, beta is in between vanilla releases)
d: the month of the release
e: the day of the release
f: the #th release of that day
```

So that's about it for this devlog! See you guys in the next one!
