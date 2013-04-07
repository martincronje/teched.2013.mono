namespace QuickWeather.Core.Model
{
    public class Color
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

    }
}
