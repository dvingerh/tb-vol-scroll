[![Run on Repl.it](https://repl.it/badge/github/dvingerh/TbVolScroll)](https://repl.it/github/dvingerh/TbVolScroll) 
## tb-vol-scroll 1.93

Simple utility to enable volume control when your mouse cursor is positioned above the taskbar.

Hold the left <kbd>ALT</kbd> key to enable precise volume control (decrease/increase volume by 1%). Standard volume step is 5%.

The volume bar will follow the cursor when it's moved. By default, if the volume is lower than 10% precise volume control is automatically enabled.

In the tray icon menu a few additional settings can be found to change the bar's dimensions, font style, color and opacity. To hide the tray icon, pass the `notray` switch as an argument when executing the program.

## Known problems

- Scrolling isn't detected when certain windows have focus, such as Task Manager or the Group Policy Management Console. This is likely a security measure by Windows of some sorts.  
**Running the software as Administrator solves this problem**.

There as of version 1.9 there is an option in the context menu to restart the program as Administrator. If the program is running with Administrator privileges this will be indicated in the context menu as well.

## Preview

![Preview](https://github.com/dvingerh/tb-vol-scroll/blob/master/example.gif?raw=true)

## Thanks

This software was [tested and approved](https://www.softpedia.com/get/Multimedia/Audio/Other-AUDIO-Tools/TbVolScroll.shtml) by SoftPedia.

![](https://s1.softpedia-static.com/_img/sp100clean.png?1)  

##

- Costura.Fody.1.6.2

- Fody.2.0.0

- MouseKeyHook.5.4.0

- [Sverrir's AudioManager script](https://gist.github.com/sverrirs/d099b34b7f72bb4fb386)

And several StackOverflow answers.
