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

- Command: spawn343
- Aliases: 343
- Parameters: spawn343 <Playername/ID>
- <Playername/ID>: Leaving empty will make the sender a Scp343.
- Permission: scp343.spawn

Config Values | Default Value | Description
------------ | -------- | -------------
is_enabled | true | Enable or disable the SCP-343 Plugin.
max_scp343s | 1 | The maximum amount of Scp343's that may spawn naturally.
spawn_chance | 33 | The percentage that SCP-343 spawns in a round.
can_grab | false | If Scp343 can pickup items
can_drop | false | If Scp343 can drop items
has_bypass | true | If Scp343 can open locked doors
is_invincible | true | If Scp343 is immune to damage
attempted_cuff | "You cannot cuff <color=red>SCP-343</color>" | The broadcast played to anyone attempting to disarm Scp343
spawn_broadcast | "<b>You have spawned as <color=red>SCP-343</color></b>\n<i>Help your fellow <color=orange>Class-D</color> to escape!</i>" | Customize the broadcast SCP-343 gets when he spawns in.
scp343Inventory | None |  The Items SCP-343 spawns with.
