using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    internal static class Constants
    {
        public static short AnswerLength = 4;
        public static short MinNumber = 1;
        public static short MaxNumber = 6;
        public static int MaxAttempts = 10;

        public static string CorrectDigitWrongPosition = "-";
        public static string CorrectDigitCorrectPosition = "+";

        //todo: strings for messages to user
    }
}
