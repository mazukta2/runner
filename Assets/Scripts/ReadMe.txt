This simple runner is my experiments with more SOLID approach in design of Unity 
applications.

Its not for every game and it has disadvantages. But its was interesting to explore this 
and I discovered some new techniques for my production code.

Two goals of this design - SOLID and controlled lifetime of entities.

How it works:

There are three types of entities.

== Components ==
It's MonoBehaviours. Anything that must exist in a scene or prefab. GameCore.cs is 
an entry point.

Because its Unity there is not clear division between view and logic. Some of those
classes only show things, and some of them work with collision and hitboxes.

I want MB to be ready to use after Awake. So if you have logic in Start anywhere in the
project you can count that everything is already setted and working. You can use 
some initialization methods between Awake and Start, but it means class is not 
independed in initialization and time of this initialization not known for sure.

So to fix this - I invert logic and now Awake must ask for needed data.
To make this more flexible I ask for abstract Provider classes. For example 
CharacterProvider can use character from current session or from prefab spawner.

== Data ==
Its just game definitions in ScriptableObjects. Nothing special.

== Models ==
Its a game logic and game entities. Its a little bit mixed right now. 

Services is a global objects that control flow of the game. They more like systems in
ECS model. Components can get access to services through providers. 

Entities - its just state of the game. This layer dont use Unity logic and 
can be easily transferred to server or saved.

== TODO ==
* More work with models should be done. 
* Obsticales is not part of models.
* More clear seperation of entities and services.