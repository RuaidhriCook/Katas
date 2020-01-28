using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public static class KataImplementations
    {
        public static void Main()
        {
        }

        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            List<string> friends = new List<string>();
            for (var i = 0; i < names.Length; i++)
            {
                
                if (names[i].Length == 4)
                {
                    friends.Add(names[i]);
                }
            }
            return friends;
        }

        public static string PrinterError(String printerControl)
        {
            int stringLen = printerControl.Length;
            int numErrors = 0;

            for (var i = 0; i < stringLen; i++)
            {
                if (printerControl[i] > 109 && printerControl[i] < 172)
                {
                    numErrors++;
                }
            }

            return numErrors.ToString() + "/" + stringLen.ToString();
        }

        public static int CountBits(int number)
        {
            List<int> binaryNum = new List<int>();

            while (number > 0)
            {
                number = Math.DivRem(number, 2, out var remainder);

                binaryNum.Add(remainder);
            }

            return binaryNum.Count(x => x.Equals(1));

            //Advanced answer
            //return Convert.ToString(number, 2).Count(x => x == '1');
        }

        public static int Find(int[] integers)
        {
            List<int> oddInts = new List<int>();
            List<int> evenInts = new List<int>();

            //loop through array
            foreach (var item in integers)
            {
                if (item % 2 == 0)
                {
                    evenInts.Add(item);
                }

                else
                {
                    oddInts.Add(item);
                }

                if(oddInts.Count > 2 && evenInts.Count == 1)
                {
                    return evenInts.First();
                }

                if (evenInts.Count > 2 && oddInts.Count == 1)
                {
                    return oddInts.First();
                }
            }

            return 0;

            //Big brain answer
            //var evenNumbers = integers.Where(integer => integer % 2 == 0);
            //var oddNumbers = integers.Where(integer => integer % 2 == 1);
            //return evenNumbers.Count() == 1 ? evenNumbers.First() : oddNumbers.First();
        }

        public static string DNAComplement(string dna)
        {
            char[] dnaComplement = new char[dna.Length];

            for (var i = 0; i < dna.Length; i++)
            {
                switch (dna[i])
                {
                    case 'A':
                        dnaComplement[i] = 'T';
                        break;

                    case 'T':
                        dnaComplement[i] = 'A';
                        break;

                    case 'G':
                        dnaComplement[i] = 'C';
                        break;

                    case 'C':
                        dnaComplement[i] = 'G';
                        break;
                }
            }

            return new string(dnaComplement);

            //Efficient version
            //return dna.Replace('T', '?').Replace('A', 'T').Replace('?', 'A').Replace('G', '?').Replace('C', 'G').Replace('?', 'C');
        }

        public class Xbonacci
        {
            public double[] Tribonacci(double[] signature, int sequenceLength)
            {
                double[] tribonacciSequence = new double[sequenceLength];

                if (sequenceLength <= 0)
                {
                    return new double[0];
                }

                for (var i = 0; i < 3; i++)
                {
                    tribonacciSequence[i] = signature[i];
                }
                
                for (var j = 3; j<sequenceLength; j++)
                {
                    tribonacciSequence[j] =
                        tribonacciSequence[j - 3] 
                        + tribonacciSequence[j - 2] 
                        + tribonacciSequence[j - 1];
                }
                
                return tribonacciSequence;
            }
        }

        public static bool ValidatePin(string pin)
        {
            if (pin.Length == 4 || pin.Length == 6)
            {
                foreach (var character in pin)
                {
                    if (character < '0' || character > '9')
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static string PigLatin(string sentence)
        {
            string finalPigLatin = "";

            foreach (var word in sentence.Split(' ').ToList<string>())
            {
                finalPigLatin = finalPigLatin + word.Substring(1) + word.Substring(0, 1) + "ay ";
            }
            
            return finalPigLatin.Trim();

            //Big brain solution
            //return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
        }

        public static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            //Counter for amount of numbers divisible by
            int divisibleByCount = 0;

            for (var i = 1; i <= 1000; i++)
            {
                if (number % i == 0)
                {
                    divisibleByCount++;

                    if (divisibleByCount > 2)
                    {
                        return false;
                    }
                }

                
            }

            return true;
        }

        public static int[] DeleteNth(int[] arr, int n)
        {
            //keep a count of each number
            Dictionary<int, int> numCount = new Dictionary<int, int>();

            List<int> sortedList = new List<int>();
            
            //iterate through and add number to list only if there's less than N of them in the list already
            for (var i = 0; i < arr.Length; i++)
            {
                //if numcount for number arr[i] is not greater than n than add it to the list and increase numcount fo that number
                if (numCount.ContainsKey(arr[i]))
                {
                    if (numCount[arr[i]] < n)
                    {
                        numCount[arr[i]]++;
                        sortedList.Add(arr[i]);
                    }
                }

                else
                {
                    numCount.Add(arr[i], 1);
                    sortedList.Add(arr[i]);
                }
            }
            return sortedList.ToArray();

            //Better solution
            //var result = new List<int>();
            //foreach (var item in arr)
            //{
            //    if (result.Count(i => i == item) < n)
            //        result.Add(item);
            //}
            //return result.ToArray();
        }

        public static string orderWeight(string weightList)
        {
            Dictionary<string, double> weightDictionary = new Dictionary<string, double>();

            //Split string into a list of strings
            foreach (var weight in weightList.Split(' ').ToList<string>())
            {
                double sumweight = 0;

                //add the digits of the number together 
                foreach (var number in weight.ToCharArray())
                {
                    sumweight += char.GetNumericValue(number);
                }

                string newWeight = weight;

                //Checks key doesn't already exist - creates new one if so
                while(weightDictionary.ContainsKey(newWeight))
                {
                    newWeight = weight + " ";
                }

                weightDictionary.Add(newWeight, sumweight);
            }

            string finalWeightList = "";

            foreach (var weight in weightDictionary.OrderBy(key => key.Key).OrderBy(key => key.Value))
            {                                       
                                                    //Trims to remove extra spaces added to create unique dictionary key
                finalWeightList = finalWeightList + weight.Key.Trim() + " ";
            }
            
            return finalWeightList.Trim();

            //Smart solution
            //return string.Join(" ", weightList.Split(' ')
                //.OrderBy(n => n.ToCharArray()
                //.Select(c => (int)char.GetNumericValue(c)).Sum())
                //.ThenBy(n => n));
        }

        public static int FindEvenIndex(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for(int l = 0; l < i; l++)
                {
                    sumLeft += arr[l];
                }

                for (int r = i+1; r < arr.Length; r++)
                {
                    sumRight += arr[r];
                }

                if (sumLeft == sumRight)
                {
                    return i;
                }
            }

            return -1;
        }

        public static string Rgb(int r, int g, int b)
        {
            return findHex(r) + findHex(g) + findHex(b);
        }

        private static string findHex(int colour)
        {
            string part1 = "";
            string part2 = "";
            
            if(colour > 0)
            {
                if (colour > 255)
                {
                    colour = 255;
                }

                int remainder = colour % 16;
                int remainder2 = (colour / 16) % 16;

                part1 = remainder2 > 9 ? ((char)(55 + remainder2)).ToString() : remainder2.ToString();
                part2 = remainder > 9 ? ((char)(55 + remainder)).ToString() : remainder.ToString();
            }

            else
            {
                return "00";
            }
            
            return part1 + part2;
        }

        public static int Add(string a, string b)
        {
            int number1 = int.Parse(a);
            int number2 = int.Parse(b); 

            int total = number1 + number2;

            return total; // Fix this!
        }

        public static string Extract(int[] numberSequence)
        {
            List<string> finalList = new List<string>();

            //loop through array, check if next 3 numbers after current index are consecutive
            for (int index = 0; index < numberSequence.Length; index++)
            {
                int counter = 0;

                //check index value against the numbers following it
                while (true)
                {
                    int startSequenceNum = numberSequence[index];

                    //If index does not have two numbers following it
                    if (index + 2 >= numberSequence.Length)
                    {
                        finalList.Add(startSequenceNum.ToString());
                        break;
                    }

                    //If the index plus the counter are outside of the length of the array
                    if (index + counter >= numberSequence.Length)
                    {
                        finalList.Add(startSequenceNum.ToString() + "-" + (numberSequence[index + counter - 1]).ToString());
                        index = index + counter;
                        break;
                    }


                    int endSequenceNum = numberSequence[index+counter];

                    if (startSequenceNum + counter == endSequenceNum)
                    {
                        counter++;
                    }

                    else
                    {
                        if (counter >= 2)
                        {
                            finalList.Add(startSequenceNum.ToString() + "-" + (endSequenceNum - 1).ToString()); ;
                            index = index + counter;
                            break;
                        }

                        else
                        {
                            finalList.Add(startSequenceNum.ToString());
                            counter++;
                            break;
                        }
                    }
                }
            }

            return string.Join(",", finalList.ToArray());
        }
    }

}
