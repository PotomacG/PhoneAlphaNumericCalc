using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication1
{
    public class CalcNumbers
    {
        static string[,] keyList = new string[10, 4] {  {"0", "","",""},
                                                        {"1","","",""},
                                                        {"A","B","C",""},
                                                        {"D","E","F",""},
                                                        {"G","H","I",""},
                                                        {"J","K","L",""},
                                                        {"M","N","O",""},
                                                        {"P","Q","R","S"},
                                                        {"T","U","V",""},
                                                        {"W","X","Y","Z"}};


        public static ArrayList outputList;
        static List<CurNumbers> listCurNumbers;

        public static void SetNumbers(string phoneNumber)
        {
            outputList = new ArrayList();
            listCurNumbers = new List<CurNumbers>();
            string prefix;
            int curKey;
            int totStringLen = phoneNumber.Length - 1;
            int totSuffixChars = 1;

            //Fill the "listCurNumbers" generic list parsing the phoneNumber string from right to left
            for (int i = totStringLen; i >= 0; i--)  //right to left
            {
                CurNumbers curNumber = new CurNumbers();
                curKey = Convert.ToInt32(phoneNumber.Substring(i, 1));
                prefix = phoneNumber.Substring(0, i);

                //single member curNumber is ready to populate and be added to the list
                curNumber.numPosition = i;
                curNumber.prefix = prefix;
                curNumber.chrKeyedIn = phoneNumber.Substring(i, 1);
                curNumber.numKeyedIn = curKey;
                curNumber.suffixChars = GetSuffixChars(curKey);
                totSuffixChars *= curNumber.suffixChars.Count;
                curNumber.numSuffixChars = curNumber.suffixChars.Count;
                curNumber.numTotSuffixChars = totSuffixChars;

                //add to list - rinse and repeat:)
                listCurNumbers.Add(curNumber);
            }

            //List is populated - Parse again to compute all possible suffix strings
            for (int i = 0; i <= totStringLen; i++)
            {
                PopulateAllSuffixTotals(i);
            }

            //Finally Output the entire list
            for (int i = 0; i <= totStringLen; i++)
            {
                FillOutputList(i);
            }
        }

        static void PopulateAllSuffixTotals(int listIndex)
        {
            SuffixChar sc;
            //Build each collections suffixList based on all of the elements that went after it.

            if (listIndex == 0)
            //Last Number keyed in always has suffixCharsTotal that match suffixChars
            {
                listCurNumbers[listIndex].suffixCharsTotal = listCurNumbers[listIndex].suffixChars;
            }
            else
            {
                //All other keys - Create suffixCharsTotal list (whether it is part of the output or not)
                foreach (SuffixChar sc1 in listCurNumbers[listIndex].suffixChars)
                {
                    foreach (SuffixChar sc2 in listCurNumbers[listIndex - 1].suffixCharsTotal)
                    {
                        sc = new SuffixChar();
                        sc.suffix = sc1.suffix + sc2.suffix;
                        listCurNumbers[listIndex].suffixCharsTotal.Add(sc);
                    }
                }
            }
        }

        static void FillOutputList(int listIndex)
        {
            string prefix;
            string numberCombo;

            if (listCurNumbers[listIndex].numSuffixChars > 1)
            {
                prefix = listCurNumbers[listIndex].prefix;

                //Enter 1 output value for each of the suffixCharsTotal elements
                for (int i = 0; i < listCurNumbers[listIndex].numTotSuffixChars; i++)
                {
                    numberCombo = (prefix + listCurNumbers[listIndex].suffixCharsTotal[i].suffix);
                    if (numberCombo.Length == 7)
                    {
                        outputList.Add(numberCombo.Substring(0, 3) + " " + numberCombo.Substring(3, 4));
                    }
                    else  // 10 digit number
                    {
                        outputList.Add(numberCombo.Substring(0, 3) + " " + numberCombo.Substring(3, 3) + " " + numberCombo.Substring(6, 4));
                    }
                }
            }
        }

        public static List<SuffixChar> GetSuffixChars(int keyNum)
        {
            List<SuffixChar> returnList = new List<SuffixChar>();
            SuffixChar curChar = new SuffixChar();

            //All keys will have at least 1 suffix char
            curChar.suffix = keyList[keyNum, 0];
            returnList.Add(curChar);

            if (keyNum > 1)
            {
                //keys > 1 have at least 3 suffix chars
                curChar = new SuffixChar();
                curChar.suffix = keyList[keyNum, 1];
                returnList.Add(curChar);

                curChar = new SuffixChar();
                curChar.suffix = keyList[keyNum, 2];
                returnList.Add(curChar);
            }

            if (keyNum == 7 || keyNum == 9)
            {
                //4th suffix char added for keys 7 and 9
                curChar = new SuffixChar();
                curChar.suffix = keyList[keyNum, 3];
                returnList.Add(curChar);
            }

            return returnList;
        }
    }


    internal class CurNumbers
    {
        //Note: not all class members used in calculations - but are useful for debugging
        public int numPosition { get; set; }
        public string prefix { get; set; }
        public string chrKeyedIn { get; set; }
        public int numKeyedIn { get; set; }
        public int numSuffixChars { get; set; }
        public int numTotSuffixChars { get; set; }
        public List<SuffixChar> suffixChars { get; set; }
        public List<SuffixChar> suffixCharsTotal { get; set; }

        public CurNumbers()
        {
            suffixCharsTotal = new List<SuffixChar>();
        }
    }

    public class SuffixChar
    {
        public string suffix { get; set; }
    }
}