# Computer graphic freestyle practice

A single player shooter game with Artificial intelligence (AI) Enemies.  
The story happens on a futuristic space base on the moon.  
The player has to defend and free the base from enemies that occupied the base.  
The game never ends as long as the player not dead. The player has 100% health and can be destroyed at once if has been hit by rockets.
The enemy spaceships can make damage but not a complete destruction at once.  

There are three type of enemies in this game.
```
* Rocket on the ground with possibility to follow the player.
  It would be shot the first second the player would be in his sight range.

* Rocket on the ground that sees the player in a wide range but it can be shooted in short range and it just flies in a direct direction.
  It will be exploded after 100 meter if not chasing the player.

* Flying spaceships of enemies following the player and shooting at him if the player at their chase range
```
## Getting Started
The game starts somewhere in the sky flying toward the base. The player can not leave the arena and if yes, he will be prompted to go back. If not returning in 10 seconds, the player ship will be destroyed. (Game over)

* #### Controls for player movement

		Key UP - It works as gas to move the spaceship forward
		Key DOWN - not implemented

		Key RIGHT - Rotates the ship through its Y-Axis toward RIGHT
		Key LEFT - Rotates the ship through its Y-Axis toward LEFT

		Key W - Rotates the ship through its X-Axis toward DOWN
		Key S - Rotates the ship through its X-Axis toward UP

		Key D - Rotates the ship through its Z-Axis toward RIGHT
		Key A - Rotates the ship through its Z-Axis toward LEFT

* #### Fire key
		Right and Left mouse keys each are responsible for each laser guns on the spaceship
		By pressing space key can they both shoot at the same time.

## Built With
Software
* [Unity3d](https://blogs.unity3d.com/2019/04/16/introducing-unity-2019-1/?_ga=2.116067398.1323338192.1563142251-81743354.1561804564) - 	Unity3d Version 2019.1.8f1

Hardware
* [Intel](https://ark.intel.com/content/www/de/de/ark/products/series/122593/8th-generation-intel-core-i7-processors.html) - Intel® Core™ i7-8700 Processor, Hexa-Core
* [AMD](https://www.amd.com/de/products/graphics/radeon-rx-580) -  AMD RX-580 Graphic card

Operating system
* [Windows 10](https://www.microsoft.com/de-de/windows/) - 	Windows 10 Professional 64
* [DirectX 11](https://support.microsoft.com/de-de/help/179113/how-to-install-the-latest-version-of-directx) - DirectX 11

## Author

* **Nima Azimihashemi** - [Github](https://github.com/nimaazha)

## License
*Student's project for module computer graphic by [applied computer science](https://ai-bachelor.htw-berlin.de/) on [HTW Berlin](https://www.htw-berlin.de/)*  
This project is free to use.  
It has been distributed with Unity3d as a freestyle practice.
The course was provided by [**Prof. Dr.-Ing. Thomas Jung**](https://www.htw-berlin.de/hochschule/personen/person/?eid=452) at Summer semester 2019.

## References

* #### Books

		Einstieg in Visual C# 2012, Thomas Theis  
		ISBN: 978-3-8362-7044-1  

		Einstieg in C# mit Visual Studio 2019, Thomas Theis  
		ISBN: 978-3-8362 1960-3  

		Einstieg in Unity: 2D- und 3D-Spiele entwickeln, Thomas Theis  
		ISBN: 978-3-8362-4292-9

* #### Web
