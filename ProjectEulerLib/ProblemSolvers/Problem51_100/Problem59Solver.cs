using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEulerDataContracts;

namespace ProjectEulerLib
{
    public class Problem59Solver : ProblemSolver
    {
        public Problem59Solver() : base()
        {
            Problem.Id = 59;
            Problem.UpperBound = 20;
            Problem.IsClosedOnRight = true;
            Problem.Title = "XOR decryption";
            Problem.Description =
@"
Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange). For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key. The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.

For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes. The user would keep the encrypted message and the encryption key in different locations, and without both 'halves', it is impossible to decrypt the message.

Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key. If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message. The balance for this method is using a sufficiently long password key for security, but short enough to be memorable.

Your task has been made easy, as the encryption key consists of three lower case characters. Using p059_cipher.txt (right click and 'Save Link/Target As...'), a file containing the encrypted ASCII codes, and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.
";

            Problem.Solutions.Add(new Solution
            {
                ProblemId = 59,
                Description = 
@"Build xorResult array new char[129][]. each item is a 26 char array, stores 1 ^'a' - 1 ^ 'z', 2^'a' - 2 ^'z', ... 
try 3 lowercase letter keys - maximum 26^3 times
use the xorResult array to decrypt the text
if the alphanumeric char plus space percentage in text is more than 90%, it could be the answer. Further confirm with testing of the text contains 'the '",
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

        public override string solution1()
        {
            char[][] xorResult = new char[129][];
            for (int i = 0; i < 128; i++)
            {
                xorResult[i] = new char[26];
                for (int j = 0; j < 26; j++)
                {
                    xorResult[i][j] = (char)(i ^ (int)('a' + j));
                }
            }

            System.IO.StreamReader sr = new System.IO.StreamReader("p059_cipher.txt");
            string fileContent = sr.ReadToEnd();
            sr.Close();
            string[] encryptedCodesStringArray = fileContent.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] encryptedCodes = new int[encryptedCodesStringArray.Length];
            for (int i = 0; i < encryptedCodes.Length; i++)
                encryptedCodes[i] = Convert.ToInt32(encryptedCodesStringArray[i]);
            char[] decryptedCharArray = new char[encryptedCodes.Length];
            int[] keys = new int[3];

            for (keys[0] = 0; keys[0] < 26; keys[0]++)
            {
                for (keys[1] = 0; keys[1] < 26; keys[1]++)
                {
                    for (keys[2] = 0; keys[2] < 26; keys[2]++)
                    {
                        int x = 0;
                        int letterCount = 0;
                        for (; x < encryptedCodes.Length / 3; x++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                char c = (char)(xorResult[encryptedCodes[x * 3 + k]][keys[k]]);
                                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >='0' && c <= '9' || c == ' ')
                                    letterCount++;
                                decryptedCharArray[x * 3 + k] = c;
                            }
                        }

                        if (encryptedCodes.Length % 3 > 0)
                            decryptedCharArray[x * 3 + 1] = (char)(xorResult[encryptedCodes[x * 3 + 1]][keys[1]]);

                        if (encryptedCodes.Length % 3 > 1)
                            decryptedCharArray[x * 3 + 2] = (char)(xorResult[encryptedCodes[x * 3 + 2]][keys[2]]);

                        string decryptedString = new string(decryptedCharArray);
                        if (letterCount * 10 > decryptedString.Length * 9)
                        {
                            if (decryptedString.Contains(" ") && decryptedString.Contains("the "))
                            {
                                char k0 = (char)('a' + keys[0]);
                                char k1 = (char)('a' + keys[1]);
                                char k2 = (char)('a' + keys[2]);
                                int sum = 0;
                                foreach(char c in decryptedString) sum += (int)c;
                                return $"{sum}: [{k0}{k1}{k2}]: {decryptedString}";
                            }
                        }
                    }
                }
            }

            return "Unable to decrypt";
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
