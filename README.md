[![Run on Repl.it](https://repl.it/badge/github/dvingerh/TbVolScroll)](https://repl.it/github/dvingerh/TbVolScroll) 
## tb-vol-scroll 1.97

Simple utility to enable volume control when your mouse cursor is positioned above the taskbar.

The volume bar will follow the cursor when it's moved around and display the current volume when scrolling up or down.

### Functionality

- Taskbar scroll: Control system volume.
- Hold <kbd>ALT</kbd>: Enable precise volume control.
- Hold <kbd>CTRL</kbd>: Toggle system audio mute.

### Settings

- Ability to change the following visual settings:
  - Color
  - Opacity
  - Dimensions
  - Autohide time-out

- Volume scroll step: Change scrolling step percentage.
- Precise control threshold: Change threshold at which to auto-enable precise volume control.
- Open Startup Folder
- Restart application:
  - Normal
  - Administrator Privileges
- `notray` argument: Don't show tray icon while running

## Known problems

- Windows prevents scroll event detection while certain windows are focused (i.e. Task Manager) when the program does not have Administrator privileges.

## Preview

![Preview](https://github.com/dvingerh/tb-vol-scroll/blob/master/example.gif?raw=true)

## Thanks

This software was [tested and approved](https://www.softpedia.com/get/Multimedia/Audio/Other-AUDIO-Tools/TbVolScroll.shtml) by SoftPedia.

![](https://s1.softpedia-static.com/_img/sp100clean.png?1)  

##
- [Taskbar.cs by Franz Alex Gaisie-Essilfie](https://gist.githubusercontent.com/franzalex/e747e6b318ab8f328aa02301f25ec534/raw/84f731f2e2396dc8ce28b564a75b712bf56b184f/Taskbar.cs)
- [Sverrir's AudioManager script](https://gist.github.com/sverrirs/d099b34b7f72bb4fb386)
