## TbVolScroll

Simple (and ugly written) utility to enable volume control when your mouse cursor is positioned above the taskbar.

Hold the left <kbd>ALT</kbd> key to enable precise volume control (decrease/increase volume by 1%). Standard volume step is 5%.

The volume bar will follow the cursor when it's moved. By default, if the volume is lower than 10% precise volume control is automatically enabled.

In the tray icon menu a few additional settings can be found to change the bar's dimensions, color and opacity.

## Known problems

- Scrolling isn't detected when certain system windows have focus, such as Task Manager or the Group Policy Management Console. This is likely a security measure by Windows of some sorts.

## Preview

![Preview](https://github.com/notcammy/TbVolScroll/blob/master/example.gif?raw=true)

## Thanks

- Costura.Fody.1.6.2

- Fody.2.0.0

- MouseKeyHook.5.4.0

- [Sverrir's AudioManager script](https://gist.github.com/sverrirs/d099b34b7f72bb4fb386)

And several StackOverflow answers.
