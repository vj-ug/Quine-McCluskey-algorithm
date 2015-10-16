bool CombineAndGroup(List<List<string>> ImplicantsByOne)
{ 
            TermsByOne = new List<List<string>>();
            int combined = 0; 
            for (int i = 0; i < ImplicantsByOne.Count - 1; i++)
            { 
                List<string> termsGrouped = new List<string>();
                for (int j = 0; j < ImplicantsByOne[i].Count; j++)
                { 
                    int combination = 0;
                    int num1 = Convert.ToInt32((ImplicantsByOne[i][j]).Replace('-','0'), 2); 
                        for (int k = 0; k < ImplicantsByOne[i + 1].Count; k++)
                        { 
                            int num2 = Convert.ToInt32((ImplicantsByOne[i + 1][k]).Replace('-', '0'), 2);
                            int num3 = num2 - num1;
                            double num4 = Math.Log((double)num3, (double)2); 
                            if (((num4 % 1) == 0) && (num3 > 0) && (Esum(ImplicantsByOne[i][j]) == Esum(ImplicantsByOne[i + 1][k])))
                            {  
                                string combinedMinterm = CompareString(ImplicantsByOne[i][j], ImplicantsByOne[i + 1][k]); 
                                if (!termsGrouped.Contains(combinedMinterm))
                                {
                                    termsGrouped.Add(combinedMinterm); 
                                }  

                            }
                        }   
                }
                if (termsGrouped.Count > 0)
                {
                    combined += termsGrouped.Count;
                } 
                TermsByOne.Add(termsGrouped);
            }

            return (combined > 0) ? true : false;
        } 

 private int Esum(String binCode)
        {
            binCode = binCode.Replace('1','0');
            binCode = binCode.Replace('-', '1');
            int esum = Convert.ToInt32(binCode, 2);
            return esum;
        }
//Purpose of CompareString is to compare two string and change the unique char to '-'
//like 000 and 001 = 00-
  private string CompareString(string str1, string str2)
        { 
            if (str1 == str2)
            { 
                CountCompareStringLoops++;
                return str1;
            }
            else 
            { 
                if (str1.Length == 1)
                { 
                    return "-";
                }
                int halflength = str1.Length / 2; 
                return CompareString(str1.Substring(0, halflength), str2.Substring(0, halflength)) + CompareString(str1.Substring(halflength), str2.Substring(halflength)); 
            }
        }
