# EZModLoader
EndZone Mod Loader
EndZone uses Doorstop, which lets one specified DLL be executed at game start; if you point it at this modloader, this will load all other mods in the folder as well

Super basic.  Requires other mod's Main to be in a class named "Preloader".  This is a tiny token attempt at security so that we should hopefully only be executing mods that are intended for EZ

Mostly this is up just for reference atm; hopefully we can come up with something a bit cleaner, probably with metadata files, proper logging, and mod ordering
