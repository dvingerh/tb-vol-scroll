[![Run on Repl.it](https://repl.it/badge/github/dvingerh/TbVolScroll)](https://repl.it/github/dvingerh/TbVolScroll) 
## tb-vol-scroll 2.7

Simple utility to enable volume control when your mouse cursor is positioned above the taskbar, among a few other options.

The volume bar will follow the cursor when it's moved around and display the current volume when scrolling up or down.

### Functionality

- Taskbar scroll: Control system volume.
- Hold <kbd>ALT</kbd>: Enable precise volume control.
- Hold <kbd>CTRL</kbd>: Toggle system audio mute.
- Hold <kbd>SHIFT</kbd>: Cycle through available audio playback devices.

###### Available Menus
- System Volume Mixer: Opens the built-in volume mixer for per-application audio volume control.
- Audio Playback Devices: Switch default audio playback device from a list of available devices.
- Volume Slider Popup: Open a popup with a volume slider. (Also accessible via <kbd>Middle Mouse Button</kbd> on the tray icon.)
- Check For Updates: Check for a new version of tb-vol-scroll and automatically update the executable when one is found.

### Configure

- Appearance:
  - Color
  - Opacity
  - Text padding (affects volume bar size)

- Behaviour:
  - Volume bar autohide time-out
  - Volume scroll step percentage
  - Precise volume control threshold
  - Enable/disable <kbd>CTRL</kbd> to toggle system audio mute
  - Enable/disable <kbd>SHIFT</kbd> to cycle through available audio playback devices
  - Enable/disable requesting of Administrator permissions on start

## Known problems

- The auto-hide taskbar feature is **not** supported. 
- Windows prevents scroll event detection while certain windows are focused (i.e. Task Manager) when the program does not have Administrator privileges.

## Preview


#### Volume bar
![Volume bar](Images/gif_volumebar.gif?raw=true)

#### Cycle audio playback devices
![Volume bar](Images/gif_audiodevices.gif?raw=true)

#### Mute and unmute
![Volume bar](Images/gif_mute.gif?raw=true)

#### Audio Playback Devices
![Audio Playback Devices](Images/audioplaybackdevices.png?raw=true)

#### Volume Slider Popup

![Tray menu](Images/volumesliderpopup.png?raw=true)

#### Configure
![Configure](Images/configure.png?raw=true)

#### Tray menu

![Tray menu](Images/traymenu.png?raw=true)


## Thanks
 #
- [Taskbar.cs by Franz Alex Gaisie-Essilfie](https://gist.githubusercontent.com/franzalex/e747e6b318ab8f328aa02301f25ec534/raw/84f731f2e2396dc8ce28b564a75b712bf56b184f/Taskbar.cs)
