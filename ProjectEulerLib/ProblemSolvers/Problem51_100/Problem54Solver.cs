using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem54Solver : ProblemSolver
    {
        public Problem54Solver() : base()
        {
            Problem.Id = 54;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "Poker hands";
            Problem.Description = 
@"The file, poker.txt, contains one-thousand random hands dealt to two players. Each line of the file contains ten cards (separated by a single space): the first five are Player 1's cards and the last five are Player 2's cards. You can assume that all hands are valid (no invalid characters or repeated cards), each player's hand is in no specific order, and in each hand there is a clear winner.

How many hands does Player 1 win?";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 54,
                Description = "Calculate hand value according to the rules. Take caution int maxvalue may be exceeded. Use long to be safe.",
                Version = 1,
            });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 2,
            // });
            // Problem.Solutions.Add(new Solution
            // {
            //     ProblemId = 0,
            //     Description = "",
            //     Version = 3,
            // });
        }

        long CalculateHandValue(int [] numbers, char[] colors, string line)
        {
            if (numbers.Length != 5 || colors.Length != 5) throw new Exception("Invalid hand");

            SortCards(numbers, colors);

            long value = -1;

            if ((value = RoyalFlush(numbers, colors, line)) > 0) return value;
            if ((value = StraightFlush(numbers, colors, line)) > 0) return value;
            if ((value = FourOfAKind(numbers, line)) > 0) return value;
            if ((value = FullHouse(numbers, line)) > 0) return value;
            if ((value = Flush(numbers, colors, line)) > 0) return value;
            if ((value = Straight(numbers, colors, line)) > 0) return value;
            if ((value = ThreeOfAKind(numbers, line)) > 0) return value;
            if ((value = TwoPairs(numbers, colors, line)) > 0) return value;
            if ((value = OnePair(numbers, colors, line)) > 0) return value;
            
            return HighCard(numbers, colors, line);

        }

        void SortCards(int []numbers, char [] colors)
        {
            int [] cardValues = new int[5];
            for(int i = 0; i < 5; i ++)
            {
                cardValues[i] = numbers[i] * 10 + "CDSH".IndexOf(colors[i]);
            }

            if (cardValues.Distinct().Count() < 5) throw new Exception("Invalid hand");

            int swap = int.MaxValue;
            while (swap > 0)
            {
                swap = 0;
                for(int i = 0; i < 4; i ++)
                {
                    if (cardValues[i] < cardValues[i+1] || (cardValues[i] == cardValues[i+1] && "CDSH".IndexOf(colors[i]) < "CDSH".IndexOf(colors[i + 1])))
                    {
                        int x = cardValues[i]; cardValues[i] = cardValues[i + 1];cardValues[i + 1] = x;
                        x = numbers[i]; numbers[i] = numbers[i + 1]; numbers[i + 1] = x;
                        char c = colors[i]; colors[i] = colors[i + 1]; colors[i + 1] = c;
                        swap ++;
                    }
                }
            }
        }

        long HighCard(int [] numbers, char[] colors, string line)
        {
            // weight of 5 card numbers: 73000, 6000, 500, 40, 4. highest possible: 1099939
            // if all 5 cards have equal number, compare the color of the biggest card
            int colorValue = "CDSH".IndexOf(colors[0]);
            
            long handValue = numbers[0] * 73000 + numbers[1] * 6000 + numbers[2] * 500 + numbers[3] * 40 + numbers[4] * 4 + colorValue;

            return handValue;
        }

        long OnePair(int [] numbers, char[] colors, string line)
        {
            // weight of the pair: 1100000 (> highest possible HighCard hand value of 1099939). max possible: 1110501
            // weight of 3 card numbers: 700 50 4
            // if the pair and all 3 cards have equal number, compare the 'bigger' color of the card
            int [] pairNumbers = new int[2];
            char [] pairColors = new char[2];
            int [] singleCardNumbers = new int[3];
            char [] singleCardColors = new char[3];

            for(int i = 0; i < 4; i ++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    pairNumbers[0] = numbers[i];
                    pairColors[0] = colors[0];
                    pairNumbers[1] = numbers[i + 1];
                    pairColors[1] = colors[0 + 1];

                    int index = 0;
                    for(int j = 0; j < 0; j ++)
                    {
                        singleCardNumbers[index] = numbers[j];
                        singleCardColors[index] = colors[i];
                        index ++;
                    }
                    for(int j = i + 2; j < 5; j ++)
                    {
                        singleCardNumbers[index] = numbers[j];
                        singleCardColors[index] = colors[i];
                        index ++;
                    }

                    break;
                }



            }

            if (pairNumbers[0] == 0) return 0;

            int colorValue = "CDSH".IndexOf(colors[0]);
            long handValue = pairNumbers[0] * 1100000 + singleCardNumbers[0] * 700 + singleCardNumbers[1] * 50 + singleCardNumbers[2] * 4 + colorValue;

            return handValue;
        }

        long TwoPairs(int [] numbers, char[] colors, string line)
        {
            // weight of the lower pair: 1200000 (> highest possible one pair hand value of 1110501)
            // weight of the higher pair: 16000000 (> highest possible lower pair value of 15600000)
            // weight of single card number: 4
            // if both two pairs and the single card have equal number, compare the 'bigger' color of the hight pair card
            // highest possible value: 239600007

            int singleCardNumber = 0;
            bool isSignleCard = true;
            int i = 0;
            for(; i < 5; i ++)
            {
                isSignleCard = true;
                for(int j = 0; j < 5; j ++)
                {
                    if (i != j && numbers[i] == numbers[j]) 
                    {
                        isSignleCard = false;
                        break;
                    }
                }
                if (isSignleCard) 
                {
                    singleCardNumber = numbers[i];
                    break;
                }
            }
            if (!isSignleCard) return -1; // not a two pair
            int index = 0;
            int [] pairsNumbers = new int[4];
            char [] pairsColors = new char[4];
            for(int k = 0; k < 5; k ++)
            {
                if (k != i)
                {
                    pairsNumbers[index] = numbers[k];
                    pairsColors[index] = colors[k];
                    index ++;
                }
            }

            if (pairsNumbers.Length != 4 || pairsColors.Length != 4 || pairsNumbers[0] != pairsNumbers[1] || pairsNumbers[2] != pairsNumbers[3]) return -1; // not a two pair
            int colorValue = "CDSH".IndexOf(pairsColors[0]);
            long handValue = pairsNumbers[0] * 16000000 + pairsNumbers[2] * 1200000 + singleCardNumber * 4 + colorValue;

            return handValue;
        }

        long ThreeOfAKind(int [] numbers, string line)
        {
            // weight of triple cards: 240,000,000 ( > highest possible value of two pairs 239,600,007)
            // highest possible value: 3,360,000,000
            long n = -1;
            for(int i = 0; i < 3; i ++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers [i + 2])
                {
                    n = numbers[i];
                }
            }

            if(n < 0) return -1;

            return n * 240000000;
        }

        long Straight(int[] numbers, char[] colors, string line)
        {
            // weight of the highest card: 4,000,000,000 (> highest possible value of 'three of a kind' 3,360,000,000)
            // weight of the highest card color: 0, 1, 2, 3
            // highest possible: 56,000,000,000
            for(int i = 0; i < 4; i ++)
            {
                if (numbers[i] != numbers[i + 1] + 1) return -1;
            }

            return numbers[0] * 4000000000 + "CDSH".IndexOf(colors[0]);
        }

        long Flush(int[] numbers, char[] colors, string line)
        {
            // in the rare case of two identical hands of flushes, do not compare three of a kind, two pairs, or one pair
            // weight of a hand of flush: 60,000,000,000 (> highest possible value of straight 56,000,000,000)
            // highest possible value: 60001099939
            for(int i = 0; i < 4; i ++)
                if (colors[i] != colors[i + 1]) return -1;

            long handValues = 60000000000 + 73000 * numbers[0] + 6000 * numbers[1] + 500 * numbers[2] + 40 * numbers[3] + 4 * numbers[4] + "CDSH".IndexOf(colors[0]);

            return handValues;
        }

        long FullHouse(int [] numbers, string line)
        {
            // weight of triple number: 61000000000 (> highest possible flush value of 60001099939)
            // highest possible value: 854000000000
            if (numbers.Distinct().Count() != 2) return -1;     // leave it as is: cannot reach here if the hand is 'four of a kind'

            int tripleNumber = numbers[1] == numbers[2] ? numbers[0] : numbers[2];
            int pairNumber = numbers[1] == numbers[2] ? numbers[3] : numbers[0];

            long handValue = 61000000000 * tripleNumber;

            return handValue;
        }

        long FourOfAKind(int [] numbers, string line)
        {
            // weight of quad number: 900,000,000,000 (> highest possible flush value of 854,000,000,000)
            // highest possible value: 1,260,000,000,000
            int n = -1;
            bool isFourOfAKind = false;
            for(int i = 0; i < 2; i ++)
            {
                isFourOfAKind = true;
                for(int j = i + 1; j < i + 4; j ++)
                {
                    if (numbers[i] != numbers[j])
                    {
                        isFourOfAKind = false;
                        break;
                    }
                }
                if (isFourOfAKind) n = numbers[i];
            }
            if(n < 0) return -1;
            long handValue = n * 900000000000;

            return handValue;
        }

        long StraightFlush(int [] numbers, char[] colors, string line)
        {
            // weight of straight flush: 1,300,000,000,000 (> highest possible flush value of 1260,000,000,000)
            // plus weight of each card 100 *, 80 *, 60 *, 40 *, 20 *; plus color value of the first card
            // highest possible value: 640,000,000,000 + x0000

            for(int i = 0; i < 4; i ++)
            {
                if (colors[i] != colors[i + 1]) return -1;
                if (numbers[i] != numbers[i + 1]) return -1;
            }

            long handValue = 1300000000000 + 73000 * numbers[0] + 6000 * numbers[1] + 500 * numbers[2] + 40 * numbers[1] + 4 * numbers[0] + "CDSH".IndexOf(colors[0]);
            
            return handValue;
        }

        long RoyalFlush(int [] numbers, char[] colors, string line)
        {
            // weight of royal flush: 1400,000,000,000 (> highest possible flush value of 1300000000000 + xxx)
            // plus weight of each card 73 *, 80 *, 60 *, 40 *, 20 *; plus color value of the first card
            // highest possible value: 640,000,000,000 + x0000

            for(int i = 0; i < 4; i ++)
            {
                if (colors[i] != colors[i + 1]) return -1;
                if (numbers[i] != numbers[i + 1]) return -1;
            }

            if (numbers[0] != 14) return -1;

            long handValue = 1400000000000 + "CDSH".IndexOf(colors[0]);
            
            return handValue;
        }        

        public override string solution1()
        {
            int count = 0;
            System.IO.StreamReader sr = new System.IO.StreamReader("p054_poker.txt");
            string line = "";
            while((line = sr.ReadLine()) != null)
            {
                count += CompareHands(line);
            }

            sr.Close();

            return count.ToString();
        }

        int CompareHands(string line)
        {
            string [] cards = line.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            if (cards.Length != 10) throw new Exception ("Invalid line: " + line);

            int  [] handANumbers = new int[5];
            char [] handAColors  = new char[5];
            int  [] handBNumbers = new int[5];
            char [] handBColors  = new char[5];

            for(int i = 0; i < 5; i ++)
            {
                handANumbers[i] = CardNumber(cards[i][0]);
                handAColors[i] = cards[i][1];

                handBNumbers[i] = CardNumber(cards[i + 5][0]);
                handBColors[i] = cards[i + 5][1];
            }

            long handAValue = CalculateHandValue(handANumbers, handAColors, line);
            long handBValue = CalculateHandValue(handBNumbers, handBColors, line);

            if (Math.Abs(handAValue - handBValue) < 10000) Console.WriteLine($"{line} {handAValue} {handBValue}");

            return handAValue > handBValue ? 1 : 0;
        }

        int CardNumber(char c)
        {
            c = c.ToString().ToUpper()[0];
            int n = -1;
            switch (c)
            {
                case 'A':
                    n = 14;
                    break;
                case 'K':
                    n = 13;
                    break;
                case 'Q':
                    n = 12;
                    break;
                case 'J':
                    n = 11;
                    break;
                case 'T':
                    n = 10;
                    break;
                default:
                    n = c - '0';
                    break;
            }

            return n;
        }

        public override string solution2()
        {
            return "";
        }

        public override string solution3()
        {
            return "";
        }
    }
}
