namespace tb_vol_scroll.Classes.Helpers
{
    public static class Enums
    {
        public enum MouseWheelDirection
        {
            Up,
            Down,
            None
        }

        public enum ActionTriggerType
        {
            RegularVolumeScroll,
            PreciseVolumeScroll,
            MuteToggleScroll,
            DeviceSwitchScroll,
            InternalEvent,
            AudioDisabled,
            AudioEnabled,
            ConfigurationApplied,
            Startup
        }
    }
}
