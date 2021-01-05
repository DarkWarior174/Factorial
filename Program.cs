using System;
using System.Linq;
using System.Threading;

namespace Factorial
{
	class CalculateFactorial
	{
		static void Main(string[] args)
		{
			int n = InputValue();
			ulong factorial = ComputeFactorial((ulong)n);
			OutputValue(factorial);
		}

		static int InputValue()
		{
			string factorial;
			int intFactorial;
			do
			{
				Console.WriteLine("Введите число, факториал которого необходимо вычеслить:");
				factorial = Console.ReadLine();
			}
			while (!int.TryParse(factorial, out intFactorial));
			return intFactorial;
		}

		static ulong ComputeFactorial(ulong n)
		{
			if (n == 1)
				return 1;
			else
			return ComputeFactorial(n - 1) * n;
		}

		static void OutputValue(ulong factorial)
		{
			byte color = 1;
			int txtLenght = factorial.ToString().Count() + 4;
			int accuracyXPos;
			int accuracyYPos;
			string[] boxDrawing = new string[3];
			boxDrawing[0] = "\u2554" + new string('\u2550', txtLenght - 2) + "\u2557";
			boxDrawing[1] = "\u2551 " + factorial + " \u2551";
			boxDrawing[2] = "\u255A" + new string('\u2550', txtLenght - 2) + "\u255D";
			while (true)
			{
				accuracyXPos = (Console.WindowWidth / 2) - (txtLenght / 2);
				accuracyYPos = (Console.WindowHeight / 2) - 2;
				color = ColorChanger(color);
				Console.Clear();
				for (int i = 0; i < boxDrawing.Length; i++)
				{
					Console.SetCursorPosition(accuracyXPos, accuracyYPos);
					Console.WriteLine(boxDrawing[i]);
					accuracyYPos = Console.CursorTop;
				}
				Console.SetCursorPosition(accuracyXPos, Console.WindowHeight);
				Thread.Sleep(750);
			}
		}

		static byte ColorChanger(byte value)
		{
			switch (value)
			{
				case 1:
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
					value = 2;
					break;
				case 2:
					Console.BackgroundColor = ConsoleColor.DarkGray;
					Console.ForegroundColor = ConsoleColor.White;
					value = 3;
					break;
				case 3:
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
					value = 4;
					break;
				case 4:
					Console.BackgroundColor = ConsoleColor.White;
					Console.ForegroundColor = ConsoleColor.Black;
					value = 1;
					break;
			}
			return value;
		}
	}
}