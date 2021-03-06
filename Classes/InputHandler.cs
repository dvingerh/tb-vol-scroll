﻿using Gma.System.MouseKeyHook;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        public bool isAltDown;
        public bool isCtrlDown;
        public bool isShiftDown;
        public bool isScrolling;
        public bool popupShowing = false;
        private bool isSubscribed = false;
        public IKeyboardMouseEvents inputEvents;
        
        private readonly MainForm callbackForm;

        public bool IsSubscribed { get => isSubscribed; set => isSubscribed = value; }

        public InputHandler(MainForm callbackForm)
        {
            this.callbackForm = callbackForm;
            SubscribeMouse();

        }

        public void SubscribeMouse()
        {
            IsSubscribed = true;
            inputEvents = Hook.GlobalEvents();
            inputEvents.MouseWheel += OnMouseScroll;
            inputEvents.MouseMove += UpdateBarPositionMouseMove;
            inputEvents.KeyDown += EnableKeyActions;
            inputEvents.KeyUp += DisableKeyActions;
        }

        public void UnsubscribeMouse()
        {
            IsSubscribed = false;
            inputEvents.MouseWheel -= OnMouseScroll;
            inputEvents.MouseMove -= UpdateBarPositionMouseMove;
            inputEvents.KeyDown -= EnableKeyActions;
            inputEvents.KeyUp -= DisableKeyActions;
            inputEvents.Dispose();
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (callbackForm.isDisplayingVolume)
            {
                if (TaskbarHelper.IsCursorInTaskbar())
                   callbackForm.SetVolumeBarPosition();
                else
                    callbackForm.HideVolumeBar();

            }
        }

        private void DisableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = false;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = false;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                isShiftDown = false;
        }

        private void EnableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = true;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = true;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                isShiftDown = true;
        }

        private async void OnMouseScroll(object sender, MouseEventArgs e)
        {
            if (TaskbarHelper.IsValidAction() && !popupShowing && callbackForm.isReady && !callbackForm.audioHandler.AudioDisabled)
            {
                isScrolling = true;
                if (!isShiftDown && !isCtrlDown)
                {
                    await Task.Run(async () =>
                    {
                        await callbackForm.DoVolumeChanges(e.Delta);
                        await callbackForm.DoAppearanceUpdate(updateType: "volume");
                    });
                }
                else if (isCtrlDown && Properties.Settings.Default.ToggleMuteShortcut && !isShiftDown && !isAltDown)
                {
                    callbackForm.SetMuteStatus(e.Delta);
                    await Task.Run(async () =>
                    {
                        await callbackForm.DoAppearanceUpdate(updateType: "mute");
                    });
                }
                else if (isShiftDown && Properties.Settings.Default.SwitchDefaultPlaybackDeviceShortcut && !isCtrlDown && !isAltDown)
                {
                    await Task.Run(async () =>
                    {
                        await callbackForm.ToggleAudioPlaybackDevice(e.Delta);
                        await callbackForm.DoAppearanceUpdate(updateType: "device");
                    });
                }
                isScrolling = false;
            }
        }
    }
}
