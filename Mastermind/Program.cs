using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = GenerateAnswer();
            // uncomment when debugging
            //Console.WriteLine("[{0}]", string.Join(", ", answer));

            var attempts = 0;

            while (attempts < Constants.MaxAttempts)
            {
                Console.Write("Enter your guess: ");
                var guess = Console.ReadLine();
                if (IsValidGuess(guess))
                {
                    var result = VerifyGuess(guess, answer);

                    if (result.IsSuccess)
                    {
                        Console.WriteLine("Congratulations, you won!");
                        Console.Read();
                        Environment.Exit(0);
                    }
                    else
                    {
                        attempts++;
                        Console.WriteLine(result.Result);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Invalid attempt.");
                }
            }
            Console.WriteLine("Sorry, you have lost.");
            Console.WriteLine("The correct answer was [{0}]", string.Join(", ", answer));
            Console.Read();
            
        }
        
        /// <summary>
        /// Verify the input is of the expected length and each digit is within the expected range
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        private static bool IsValidGuess(string guess)
        {
            if (guess.Length != Constants.AnswerLength) return false;
            foreach (var item in guess)
            {
                if (short.Parse(item.ToString()) < Constants.MinNumber || short.Parse(item.ToString()) > Constants.MaxNumber) return false;
            }

            return true;
        }

        /// <summary>
        /// Compare the input against the expected answer, and return the result, including successful attempt 
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        private static GuessResult VerifyGuess(string guess, short[] answer)
        {
            var result = new StringBuilder();
            for (var i = 0; i < Constants.AnswerLength; i++)
            {
                if (answer[i] == short.Parse(guess[i].ToString()))
                    result.Append(Constants.CorrectDigitCorrectPosition);
                else if (answer.Contains(short.Parse(guess[i].ToString())))
                {
                    result.Append(Constants.CorrectDigitWrongPosition);
                }
                  
            }

            return new GuessResult
            {
                Result = result.ToString(),
                IsSuccess = result.Length == Constants.AnswerLength &&
                            !result.ToString().Contains(Constants.CorrectDigitWrongPosition) 
            };
        }


        private static short[] GenerateAnswer()
        {
            var answer = new short[Constants.AnswerLength];
            var random = new Random();
            for (var i = 0; i < Constants.AnswerLength; i++)
            {
                answer[i] = GenerateRandomNumber(random);
            }
            return answer;
        }

        private static short GenerateRandomNumber(Random random)
        {
            return (short)random.Next(Constants.MinNumber, Constants.MaxNumber);
        }
    }
}
