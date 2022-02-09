[![Run on Repl.it](https://repl.it/badge/github/dvingerh/TbVolScroll)](https://repl.it/github/dvingerh/TbVolScroll) 
## tb-vol-scroll 4.0

Simple and customizable utility to enable audio control by scrolling inside the taskbar.

### Functionality

- Taskbar scroll: Control system volume.
- Hold <kbd>ALT</kbd>: Enable precise volume control.
- Hold <kbd>CTRL</kbd>: Toggle system audio mute.
- Hold <kbd>SHIFT</kbd>: Cycle through available audio playback devices.

###### Available Menus
- Audio Playback Devices: Switch default audio playback device from a list of available devices.
- System Volume Mixer: Opens the built-in Windows volume mixer for per-application audio volume control.
- Volume Slider Control: Open a popup with a volume slider and peak volume meter.

### Configuration

- Appearance:
  - Color
  - Font
  - Opacity
  - Padding (affects volume bar size)
  - Tray icon style

- Behavior:
  - Volume bar autohide time-out
  - Volume scroll step percentage
  - Precise volume control threshold
  - Enable/disable <kbd>CTRL</kbd> to toggle system audio mute
  - Enable/disable <kbd>SHIFT</kbd> to cycle through available audio playback devices
  - Enable/disable <kbd>ALT</kbd> to manually enable precise volume control
  - Enable/disable requesting of Administrator permissions on start
  - Enable/disable reverse scrolling direction for scroll actions

## Preview

#### Volume bar
![Volume bar](Images/gif_volumebar.gif?raw=true)

#### Cycle audio playback devices
![Volume bar](Images/gif_audiodevices.gif?raw=true)

#### Mute and unmute
![Volume bar](Images/gif_mute.gif?raw=true)

#### Audio Playback Devices
![Audio Playback Devices](Images/audioplaybackdevices.png?raw=true)

#### Volume Slider Control

![Tray menu](Images/gif_volumeslidercontrol.gif?raw=true)

#### Configuration
![Configuration](Images/configuration.png?raw=true)

#### Tray menu

![Tray menu](Images/traymenu.png?raw=true)


## Thanks
 #
- [Taskbar.cs by Franz Alex Gaisie-Essilfie](https://gist.githubusercontent.com/franzalex/e747e6b318ab8f328aa02301f25ec534/raw/84f731f2e2396dc8ce28b564a75b712bf56b184f/Taskbar.cs)
- [CustomFontDialog by umaranis](https://github.com/umaranis/CustomFontDialog)