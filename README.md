# EZModLoader
EndZone Mod Loader

Uses Doorstop, which lets one specified DLL be executed at game start; this modloader will load all other mods in the folder as well

Super basic.  Requires other mod's Main to be in a class named "Preloader".  This is a tiny token attempt at security so that we should hopefully only be executing mods that are intended for EZ

Mostly this is up just for reference atm; hopefully we can come up with something a bit cleaner, probably with metadata files, proper logging, and mod ordering




The project is offered “as-is”, without warranty, and disclaiming liability for damages resulting from using the project

## Warning: This type of modding is dangerous.  This ModLoader will execute arbitrary DLL files within the game's folder.  Do not put any DLL files that you do not trust into this folder, or any that are not open sourced.  
## Never run EndZone as an administrator while using mods.  Ensure you are using UAC if possible

### To Install
Head to the Releases tab and download the latest Zip file.  Unzip into your EndZone folder, by default *C:\Program Files (x86)\Steam\steamapps\common\Endzone - A World Apart*.  You should not need to replace any files unless this or another loader, such as CreativeZone, has already been installed.

That's it!  Now just find any mods you'd like and put their .dll file into the *Endzone_Data/Managed* folder, and they should run automatically on game startup

### Mod Ordering
Isn't really implemented yet, but, it processes the DLL files in alphabetical order.  So if necessary, you can add numbers to the beginnings of the names of mods to dictate the load order
