# SCP-343
 Adds a new SCP to the game and gives Class-D a chance of surviving the horros of the facility!
 
## Features
- SCP-343 is a essential way to escape for the Class-D
- SCP-343 cannot die (configurable)
- SCP-343 can open every door with his hands (configurable)
- SCP-343 cannot pick up nor drop items (configurable)
- SCP-343 can only spawn once in a round with a chance (configurable)
- SCP-343 only dies from decontamination and the Alpha Warhead (configurable)
- SCP-343 cannot be cuffed (by a disarmer)
- SCP-343 can escape
- SCP-343 can spawn with predefined inventory (configurable) 
- SCP-343 can be spawned via command

## Commands
### SpawnSCP343

- Command: spawnscp343
- Aliases: spawn343; 343
- Parameters: spawn343 <Playername/ID>
- <Playername/ID>: You can leave that empty (it will take your instead)
- Permission: scp343.spawn

Config Values | Default Value | Description
------------ | ------------- | -------------
IsEnabled | true | Enable or Disable the SCP-343 Plugin.
spawnChance | 33 | The chance that SCP-343 spawns in a round.
canGrab | false | Should SCP-343 be able to pickup items?
canDrop | false | Should SCP-343 be able to drop items?
hasBypass | true | Should SCP-343 be able to open any door?
isInvincible | true | Should SCP-343 be in godmode?
spawnBroadcast | "<b>You have spawned as <color=red>SCP-343</color></b>\n<i>Help your fellow <color=orange>Class-D</color> to escape!</i>" | Customize the broadcast SCP-343 gets when he spawns in.
broadcastLength | 10 | How long should Broadcast be? (in seconds)
nukeDeath343 | "<b>The Powers of the Alpha Warhead have weakend you</b>" | Customize the broadcast SCP-343 gets when he dies to the nuke.
deconDeath343 | "<b>The Decontamination has bring you down to your knees!</b>" | Customize the broadcast SCP-343 gets when he dies to the nuke.
spawnItemsEnabled | false | Should SCP-343 spawn with items?
scp343Inventory | None, None, None, None, None, None, None, None |  The Items SCP-343 spawns with.(Use the #resources channel on Discord for ItemType Names)
