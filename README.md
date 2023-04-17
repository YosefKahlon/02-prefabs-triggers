# Space War
Unity basics: prefabs, triggers, coroutines

This project represents a Unity game of a spaceship shooting at enemies.





# Improvements

## Round World

This improvement was made to make the game world rounded. To achieve this, I added 4 Edge Collider 2D components to the sides of the world.

![Alt text](Assets/Images/Screenshot%202023-04-17%20214529.jpg)

I gave each Edge Collider a unique tag. When the PlayerSpaceship Collider collides with one of these Edge Colliders, I multiply the position of the PlayerSpaceship by -1 to flip it around the edge of the world. Specifically, for the right and left sides, I flip the X axis by -1, and for the top and bottom sides, I flip the Y axis by -1.

* [OnTriggerEnter2D(Collider2D other)](https://github.com/YosefKahlon/Space-War/blob/master/Assets/Scripts/EdgeManipulator.cs#:~:text=private%20void-,OnTriggerEnter2D,-(Collider2D%20other))


## Add Laser
In this improvement, the PlayerSpaceship gains an additional laser for shooting. When the player collides with the +1 laser object, their laser count increases by 1.

To implement this, I first made the +1 laser object spawn in a random position on the screen with the Coroutine method.

* [SpawnRoutine()](https://github.com/YosefKahlon/Space-War/blob/master/Assets/Scripts/2-spawners/TimedSpawnerRandom.cs#:~:text=IEnumerator-,SpawnRoutine,-()%20%7B%20%20%20%20//%20co))

The next step was to add a collider to the +1 laser object, which I did by giving it a tag. When this collider is triggered, I increment the laser count.
* [OnTriggerEnter2D(Collider2D other)](https://github.com/YosefKahlon/Space-War/blob/master/Assets/Scripts/2-spawners/LaserShooter.cs#:~:text=private%20void-,OnTriggerEnter2D,-(Collider2D%20other))

Finally, to spawn the new laser(s), I used the spawnObject() method, which is an overridden method from the base class. If the laser count is 0, the score text field of the new object is modified. If the laser count is greater than 0, a container game object is created, and multiple laser game objects are instantiated as children of the container game object.

The position of the new laser game objects is offset so that they appear side by side.

To keep the score for all lasers, I set the same SetScoreField to all of them
* [spawnObject()](https://github.com/YosefKahlon/Space-War/blob/master/Assets/Scripts/2-spawners/LaserShooter.cs#:~:text=protected%20override%20GameObject-,spawnObject,-()))


![Alt text](Assets/Images/Screenshot%202023-04-17%20233408.jpg)


## Editor version
2021.3.18f1
