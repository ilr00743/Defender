namespace FallingBalls.Helper {
    public static class TimeHelper {
        public static string ConvertTotalSecondsToTimer(float value) {
            var seconds = (int)(value % 60);
            var minutes = (int)(value / 60) % 60;
            var hours = (int)(value / 3600) % 24;
            return $"Timer: {hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}