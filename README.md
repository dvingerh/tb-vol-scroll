[![Run on Repl.it](https://repl.it/badge/github/dvingerh/TbVolScroll)](https://repl.it/github/dvingerh/TbVolScroll) 
## tb-vol-scroll 2.0

Simple utility to enable volume control when your mouse cursor is positioned above the taskbar, among a few other options.

The volume bar will follow the cursor when it's moved around and display the current volume when scrolling up or down.

### Functionality

- Taskbar scroll: Control system volume.
- Hold <kbd>ALT</kbd>: Enable precise volume control.
- Hold <kbd>CTRL</kbd>: Toggle system audio mute.
- Hold <kbd>SHIFT</kbd>: Cycle through available audio playback devices.

### Settings

- Appearance:
  - Color
  - Opacity
  - Text padding (affects volume bar size)

- Behavior:
  - Volume bar autohide time-out
  - Volume scroll step percentage
  - Precise volume control threshold
  - Enable/disable <kbd>CTRL</kbd> to toggle system audio mute
  - Enable/disable <kbd>SHIFT</kbd> to cycle through available audio playback devices
  - Enable/disable requesting of Administrator permissions on start

### Tray menu

![Tray menu](traymenu.png?raw=true)


## Known problems

- The auto-hide taskbar feature is **not** supported. 
- Windows prevents scroll event detection while certain windows are focused (i.e. Task Manager) when the program does not have Administrator privileges.

## Preview

![Preview](example.gif?raw=true)

![Settings](settings.png?raw=true)

## Thanks

##
- [Taskbar.cs by Franz Alex Gaisie-Essilfie](https://gist.githubusercontent.com/franzalex/e747e6b318ab8f328aa02301f25ec534/raw/84f731f2e2396dc8ce28b564a75b712bf56b184f/Taskbar.cs)
- [Sverrir's AudioManager script](https://gist.github.com/sverrirs/d099b34b7f72bb4fb386)
