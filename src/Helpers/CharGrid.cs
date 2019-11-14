using System;
using System.Drawing;
using System.Linq;

namespace Orikivo.Ascii
{
    /// <summary>
    /// A raw character grid used to store character values at specified positions.
    /// </summary>
    public class CharGrid
    {
        public CharGrid(int width, int height, char emptyChar)
        {
            Map = new char[height][];

            for (int y = 0; y < height; y++)
            {
                char[] row = new char[width];

                for (int x = 0; x < width; x++)
                    row[x] = emptyChar;

                Map[y] = row;
            }
        }

        public char[][] Map { get; private set; }
        public int Width => Utils.GetObjectWidth(Map);
        public int Height => Map.GetLength(0);

        public void DrawChar(CharValue value)
        {
            if (value.X >= Width || value.Y >= Height || value.X < 0 || value.Y < 0)
                throw new Exception("The coordinates specified on the following CharValue are out of bounds.");

            Map[value.Y][value.X] = value.Char;
        }

        public void DrawString(string value, char separatorChar, int x, int y)
        {
            string[] rows = value.Split(separatorChar);
            int width = Utils.GetObjectWidth(rows);
            int height = rows.Length;
            // string.PadLeft, string.PadRight
            if (width + x >= Width || height + y >= Height || x < 0 || y < 0)
                throw new Exception("The coordinates specified on the following CharValue are out of bounds.");

            for (int dy = y; dy < height + y; dy++)
            {
                string row = rows[dy];
                for (int dx = 0; dx < width + x; dx++)
                {
                    Map[dy + y][dx + x] = row[dx];
                }
            }
        }

        public void DrawObject(AsciiObject obj, Point pos)
        {


            Console.WriteLine($"Width: {Width}\n Obj.Width: {obj.Width}\n Pos.X: {pos.X}");

            Console.WriteLine($"Height: {Height}\n Obj.Height: {obj.Height}\n Pos.Y: {pos.Y}");
            if (pos.X + obj.Width > Width || pos.Y + obj.Height > Height || pos.X < 0 || pos.Y < 0)
                throw new Exception("The coordinates specified on the following CharValue are out of bounds.");

            for (int y = pos.Y; y < obj.Height + pos.Y; y++)
            {
                for (int x = pos.X; x < obj.Width + pos.X; x++)
                {
                    Console.WriteLine($"Grid.X: {x} Pos.X: {pos.X}");
                    Map[y][x] = obj.Chars[y - pos.Y][x - pos.X];
                }
            }
        }
        
        /// <summary>
        /// Converts the <see cref="CharGrid"/> into a string.
        /// </summary>
        public string ToString(char separatorChar)
        {
            return string.Join(separatorChar.ToString(), Map.Select(x => new string(x)));
        }
    }
}
