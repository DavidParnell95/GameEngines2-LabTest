# GameEngines2-LabTest
This is a submission for Game Engines 2's lab test. Overall item generation
and initialization with a random color worked. Color changes also worked... albeit 
waaaaay too quickly. Seek behaviour is also carried out way too quickly. 
Here's a video of it in action

[![](http://img.youtube.com/vi/0BdTyU3ShB0/0.jpg)](http://www.youtube.com/watch?v=0BdTyU3ShB0 "video")

## Item Generation
This involved the generation of a number of 
objects, with a random color. These colors could either be
Red, Green or Yellow. This was done by instantiating prefabs a set distance 
from the car object in a circle around it. 

![spawn_ref](https://github.com/DavidParnell95/GameEngines2-LabTest/blob/master/Screenshot%20(135).png)

An initial color is set and if an object is green, it is given the tag:
"active". This tag is used to identify what objects the car may go to. When 
an object changes to a different color, named "inactive", stopping the car
from travelling towards it. Color changes were implemented using IEnumerators. 

![tag_ref](https://github.com/DavidParnell95/GameEngines2-LabTest/blob/master/Screenshot%20(136).png)

## Movement 
Using tutorials from lectures, seek steering behavior was implemented, 
with the destination for the car to travel to. Using a function, the closest 
object with an "active" tag and this object is set as the target for the car to
move towards 

![near_ref](https://github.com/DavidParnell95/GameEngines2-LabTest/blob/master/Screenshot%20(137).png)
