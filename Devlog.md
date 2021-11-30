# Devlogs
## 11/29/2021 (21ga1129.0)

Hey everyone! Sorry this devlog is so delayed, I had some complications, but we got a lot done!

### 0.
First off, sorry for the 15 day devlog. I had a campout over the weekend, so I couldn't publish it then, and I meant to publish the devlog yesterday, but I forgot. Oh well. I also have another campout coming up, so another 2 week devlog. Sorry about that. But, I'm going to try to stream on either Sunday afternoon or the week after. We'll see how it goes. Anyways, onto the actual devlog.

### 1.
I got the rocket rotation working, using quaternions, which are, well, annoying to say the least. For those of you who don't know, quaternions are a 4-dimensional extension of the complex numbers. You have the real axis, as well as 3 imaginary axis, `i`, `j`, and `k`, and some funny business is done with them. Luckily, I didn't have to do much math, just use the built in quaternion interpolation function, and make it a bit smoother.

### 2.
I've been trying to make the rocket's particle systems work, but for some reason, I have an issue. The particles themselves are fine, but the toggling them ON is weird. It takes a really long time to turn on sometimes, and the time exactly is completely random. Sometimes one particle system will turn on and not the other. I have no idea why. This has taken a while to try and fix. I had my friend Saalty try to fix the thing, but he couldn't either. Oh well, something to fix later.

### 3.
But, on the other hand, Saalty did a lot of work for me over the campout! He made an enemy rocket spawner, and some rockets that follow the player. The only thing missing is to make the spawner spawn the rockets at the camera's bounds. It does that, but only at the origin, because it uses some hard-coded numbers. Another thing to fix.

### Ending.
Anyways, that's it! It might not look like much, but that's because we are trying out new things and leaving a lot of tiny changes and modifications out of this. On that note, I can't include the changelog for this devlog, because I got a bit inconsistent at keeping it up to date and it kind of fell too far behind to fix. So, I'll just restart it for the next devlog.

That's all for this devlog, have a good 2 weeks!

P.S. I'm removing the things already done in this checklist below.

### Stuff to Do:
- I have to make the arcade cabinet account for framerate like the player controller does when it angles the camera towards itself.
- Fix light flickering
- Add more details to cabinet
- Fix the camera acting weird when the player interacts with the cabinet by pressing "Space"
- Fix the RM player rocket's particle systems
- Add textures to the RM rockets.
- Add RM background (stars).
- Make the RM particle systems work.
- Obviously more.
