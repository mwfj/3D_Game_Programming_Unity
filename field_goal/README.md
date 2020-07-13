# Assignment 1 Field Goal

## Funtion explaination

In my game, I create five main objects: Football, Football court, Aim Target(Target) and Football Gate, and a box collider<br>

+ Script `BallController` controls Football

+ Script `TargetController` controls the aim target

+ Script  `ScoreArea` is to detect the collision between footbal and Goal Area; Show the current score that the player's got; Finally, show the instrution for playing this game

+ Script `GameController` to do that game reload and quit game

I use `Rigidbody.AddForce()` to "Kick" the ball
The kick direction would be the direction between aim target and football

```c++ 
AddForce( dir, ForceMode.Impulse);
```

When the football enter the collision area, it will trigger the function of  `void OnTriggerEnter(Collider other)` in the script `ScoreArea.cs`, the "Goal text" will show on screen and the score will add one. In addition, when the football flying, the football will self-rotate.

After each kick, the scene will be reset in 4 seconds by using `SceneManager.LoadScene`. But the score wil not be reset, because I stored it by using the function `PlayerPrefs.SetInt("score", count);`

For the text, I use 3D text on Canvas to show the score, using instruction and Goal text(On the ScoreArea.cs)

For the material: I made a yellow material for Unity on Football Gate; I find the football court material and football material online

Football Court Material Link: [football court link](https://www.wallpaperup.com/593977/CLEMSON_TIGERS_college_football.html)

Football material Link: [football material](https://www.colourbox.com/image/football-background-highly-detailed-texture-image-5051106)


## User Guide
1. **User can kick the ball by pressing the `space` key.**<br>


2. **You can use the  `'w', 'a', 's','d' or arrow key`** in the keyboard to control the aim target.

3. **Quit the game** by pressing the `Q` key

## Result

Since I am using a mac system. To prevent system compatibility issues, I recorded my game as a video(on the root path in my game folder).

![result1](./Game_Screenshots/start.png)
![result1](./Game_Screenshots/goal.png)
