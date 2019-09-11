# Computer graphic freestyle practice

A single player shooter game with Artificial intelligence (AI) Enemies.  
The story happens on a futuristic space base on the moon.  
The player has to defend and free the base from enemies that occupied the base.  
The game never ends as long as the player not dead. The player has 1000 points of health and can be damaged,  
If it has been hit by rockets or their particles.  
There is also the feature of fuel. It will be calculated as the ship flies every 5000 units in the arena.  
If there are no fuels left, the ship will explode.

There are two type of enemies in this game.
```
* Long range Rocket: with possibility to follow the player.
  It can see the player in a big range and can also follow him to damage him.

* Short range Rocket: it can see the player and will be shot as the player is in a short range with him.
  It flies in a direct direction and tries to be exploded near to the player to damage him with his particles.
  It also flies faster as the long range missile.

  Both type will explode if can not achieve the player after a defined range of flight.
  For a better vision there is a skin thin sphere around the rocket so that they can be better seen in the scene.
```
## Getting Started
The game starts somewhere in the sky flying toward the base. The player can not leave the arena and if yes, he will be prompted to go back.  
If not returning in 15 seconds, the player ship will be destroyed and the scene will be reloaded automatically.  
Hitting any object in the scene will cause the spaceship to explode.
For refueling are red barrels in different places on the scene.  
The ship has to fly near above to these barrels to be able to refuel.
It also works the same with two "first aid" boxes on the scene to gain health again.  
Both barrels and health kit are placed in places NOT easy to achieve to make the game and fly more challangable.  
There is also an overhead camera following the player from above to have a better vision.
The scene is planned in 1920x1080 resoloution.  
There are 8 invisible sphere zones in the scene, by "triggering in" every zone will be spawn a rocket in this zone. This helps to have a continuable dogfight in the sky.
* #### Controls for player movement

		Key arrow "UP":     It works as gas to move the spaceship forward
		Key arrow "DOWN":   No function available to this key

		Key arrow "RIGHT":  Rotates the ship through its Y-Axis toward RIGHT
		Key arrow "LEFT":   Rotates the ship through its Y-Axis toward LEFT

		Key "W":      Rotates the ship through its X-Axis toward DOWN
		Key "S":      Rotates the ship through its X-Axis toward UP

		Key "D":      Rotates the ship through its Z-Axis toward RIGHT
		Key "A":      Rotates the ship through its Z-Axis toward LEFT

* #### Fire key
		By pressing "space key" can shoot the enemy.

* #### Pause Menu
      By hitting "escape key" you can choose to pause or quit the game. Hitting the "ESC" again would also let you back to the game.


## Built With
Software
* [Unity3d](https://blogs.unity3d.com/2019/04/16/introducing-unity-2019-1/?_ga=2.116067398.1323338192.1563142251-81743354.1561804564) - 	Unity3d Version 2019.1.8f1

Hardware
* [Intel](https://ark.intel.com/content/www/de/de/ark/products/series/122593/8th-generation-intel-core-i7-processors.html) - Intel® Core™ i7-8700 Processor, Hexa-Core
* [AMD](https://www.amd.com/de/products/graphics/radeon-rx-580) -  AMD RX-580 Graphic card

Operating system
* [Windows 10](https://www.microsoft.com/de-de/windows/) - 	Windows 10 Professional 64
* [DirectX 11](https://support.microsoft.com/de-de/help/179113/how-to-install-the-latest-version-of-directx) - DirectX 11

## License
*Student's project for module [computer graphic](https://lsf.htw-berlin.de/qisserver/rds?state=modulBeschrGast&moduleParameter=modDescr&struct=auswahlBaum&next=wait.vm&nextdir=qispos/modulBeschr/gast&createPDF=Y&create=blobs&nodeID=auswahlBaum%7Cabschluss%3Aabschl%3D84%7Cstudiengang%3Astg%3D116%7CstgSpecials%3Avert%3D%2Cschwp%3D%2Ckzfa%3DH%2Cpversion%3D20122%7CkontoOnTop%3Apordnr%3D28773%7Cpruefung%3Apordnr%3D28657&expand=1&lastState=modulBeschrGast&asi=#auswahlBaum%7Cabschluss%3Aabschl%3D84%7Cstudiengang%3Astg%3D116%7CstgSpecials%3Avert%3D%2Cschwp%3D%2Ckzfa%3DH%2Cpversion%3D20122%7CkontoOnTop%3Apordnr%3D28773%7Cpruefung%3Apordnr%3D28657) by [applied computer science](https://ai-bachelor.htw-berlin.de/) at [HTW Berlin](https://www.htw-berlin.de/)*  
It has been distributed with Unity3d as a freestyle practice.
The course was provided by [**Prof. Dr.-Ing. Thomas Jung**](https://www.htw-berlin.de/hochschule/personen/person/?eid=452) at Summer semester 2019.

## References

* #### Books: (All the following books are available at HTW Berlin Library)

	[Einstieg in Visual C# 2012](https://www.rheinwerk-verlag.de/einstieg-in-visual-basic-2012_3188/?GPP=openbook), Thomas Theis  
	ISBN: 978-3-8362-1960-3  

	[Einstieg in C# mit Visual Studio 2019](https://www.rheinwerk-verlag.de/einstieg-in-c-mit-visual-studio-2019_4904/), Thomas Theis  
	ISBN:  978-3-8362-7044-1

	[Einstieg in Unity: 2D- und 3D-Spiele entwickeln](https://www.rheinwerk-verlag.de/einstieg-in-unity_4654/), Thomas Theis  
	ISBN: 978-3-8362-4292-9

* #### Web

  [Unity3d Documentation / Script References](https://docs.unity3d.com/2019.1/Documentation/ScriptReference/)

  [Unity3d Answers](https://answers.unity.com/questions/index.html)

  All the audios/music in the game downloaded from [FreeSoundDotOrg](https://freesound.org/)


* #### Used in the scene "Asset Store" contents

1. [Star Sparrow Modular Spaceship](https://assetstore.unity.com/packages/3d/vehicles/space/star-sparrow-modular-spaceship-73167)

2. [First aid kit army](https://assetstore.unity.com/packages/3d/props/first-aid-kit-army-148353)

3. EBAL STUDIOS - Space Missiles: Unfortunately this asset has been depricated and removed from unity asset store

      All the three assets above were free to use on the unity asset store.

## Author
* **Nima Azimihashemi** - [Github](https://github.com/nimaazha)
