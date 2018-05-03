# Contributing

## Getting started

Getting started contributing is a bit finnicky at the moment. At the very least, you'll need Git LFS and Git Bash installed on your local system.
1. First, create a blank 2D Unity project. We recommend naming it "Brass Republic".
2. Next, navigate to the project directory in Git Bash and type `git init`.
3. You'll need to set the remote to the repository. Type `git remote add origin "https://github.com/CKunhardt/brass-republic.git"`, using either our repository if you have push access, or the URL for your fork.
4. Next, you'll need Github for Unity. Download it from `https://github.com/github-for-unity/Unity/releases`. Once downloaded, drag the file into Unity with your project open.
5. Now, run the following commands to remove certain files from your project:
    - `rm -rf ProjectSettings/*`
    - `rm UnityPackageManager/manifest.json`
    - `rm Assets/Plugins.meta`
6. Finally, use `git pull origin master` to pull the repo into your blank project.

From now on, you'll use the Github for Unity plugin to make changes. In Unity, go to Window -> GitHub to open up the necessary window for that.

## Project Structure

The game is run from the PlayerScene; this is the first scene that is loaded, and contains any objects with DontDestroyOnLoad(). The Player object with the linked camera are here, as are any event-based dialogue. The player scene also initializes the `GameManager`.

### GameManager

The GameManager is the central singleton of the entire game. Being a singleton, it can be referenced from anywhere using `GameManager.Instance`. In it are included a wealth of variables, which can be added to if need be. The game progression is handled by the nested class, `GameStateVariables`, and an instance of this class is included as a variable `GSV`. To add to the game state variables, first declare the new variable in the class, and then initialize it in the constructor.

### Dialogue

The dialogue system is nested under the `UICanvas` under the object `DialogueSystem`. A `DialogueManager` takes the `Dialogue` from a `DialogueTrigger`, and interfaces with the dialogue box to display dialogue. Event dialogue is handled by the `DialogueMessageHandler`, which has nested DM events. The DM prefab is the base for a DialogueMessage -- to make a new one: 
- Drag one under `DialogueMessageHandler`
- Name it according to conventions
- Add a function declaration to `IDialogueMessageHandler`
- Implement the function in `DialogueMessageHandler`, referring to existing functions as models.

To call a dialogue event, run `ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.[DM_YourFunction] ());` This is usually handled by the event messaging system.

### Event Messaging

The event messaging system allows certain behavior to be executed for certain events. Currently, the `EventMessageHandler` contains three categories of checks: `CheckSceneEvents()`, `CheckDialogueEvents()`, and `CheckCustomEvents()`. For the current game, these encompass any scenario. To call a dialogue event from an interaction, one generally calls `ExecuteEvents.Execute<IEventMessageHandler> (GameManager.Instance.EMH, null, (x, y) => x.CheckDialogueEvents ("target name"));` from an interaction. The current `DialogueInteraction` script needs to be reworked so that an external object target is not needed when you're not talking to an NPC, but the general idea is to pass a target name into the `IEventMessageHandler`. The `GameManager` is really the only place that runs the `CheckSceneEvents()`.

### Battle System

The Battle System is fairly straight forward. The `BattleSystem` level has its own Player and Camera so the default Player/Camera are disabled during battle sequences. In the Battle folder, there are the following, currently:
- `BattleManager` -- Singleton that handles logic that needs to be called from any script in the battle
- `EnemyHealth` -- component of Enemy object that handles damage dealt to the enemy
- `EnemyMovement` -- component of the Enemy object that handles enemy's movement
- `EnemyProjectile` -- a template for the enemy's projectiles; needs to be instantiated (as opposed to being attached to a game object in the scene editor)
- `EnemyProjectileSpawner` -- spawns `EnemyProjectile`s
- `MouseMovement` -- component of the Player object that handles the player's movement
- `PlayerHealth` -- component of the Player object that handles damage dealt to the player
- `EnemyProjectile` -- a template for the player's projectiles; needs to be instantiated (as opposed to being attached to a game object in the scene editor)
- `PlayerProjectileSpawner` -- spawns `PlayerProjectile`s
- `Projectile` -- Abstract class for projectiles

### Portals and Spawners

These two prefabs handle level transitions. Drag a spawner prefab into a scene, enable the sprite renderer, position it where you want the player to spawn, then disable the sprite renderer. Rename the spawner to Spawner_[from level]. For portals, drag the portal into its position in the scene. Rename the Portal to Portal_[target scene], enter the target scene's name, and set the spawner name.

### Other

Everything else is just a specific script for a specific object or behavior, and should be self-explanatory

