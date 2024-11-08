List<int> Oper(int left, int right) 
{
    List<int> res = [];
    res.Add(left + right);
    res.Add(left - right);
    res.Add(left * right);
    return res;
}
List<int> re(List<int> arr) 
{
    List<int> res = [];
    if (arr.Count() == 2) 
    {
        res.AddRange(Oper(arr[0], arr[1]));
        return res;
    }
    if (arr.Count() == 3)
    {
        List<int> res1 = new List<int> { arr[0], arr[1] }; res1 = re(res1);
        List<int> res2 = new List<int> { arr[1], arr[2] }; res2 = re(res2);
        for (int i = 0; i < res1.Count(); i++)
        {
            res.AddRange(Oper(res1[i], arr[2]));
        }
        for (int i = 0; i < res2.Count(); i++)
        {
            res.AddRange(Oper(arr[0], res2[i]));
        }
        return res;
    }
    else
    {
        List<int> left = new List<int> { arr[0], arr[1] }; left = re(left);
        List<int> mid = new List<int> { arr[1], arr[2] }; mid = re(mid);
        List<int> right = new List<int> { arr[2], arr[3] }; right = re(right);
        List<int> thirdLeft = new List<int> { arr[0], arr[1], arr[2] }; thirdLeft = re(thirdLeft);
        List<int> thirdRight = new List<int> { arr[1], arr[2], arr[3] }; thirdRight = re(thirdRight);
        for (int i = 0; i < left.Count(); i++) 
        {
            for (int j = 0; j < right.Count(); j++) 
            {
                res.AddRange(Oper(left[i], right[j]));
            }
        }
        for (int i = 0; i < mid.Count(); i++) 
        {
            List<int> num = new List<int> { arr[0], mid[i] }; num = re(num);
            List<int> num2 = new List<int> { mid[i], arr[3] }; num2 = re(num2);
            for (int j = 0; j < num.Count(); j++) 
            {
                res.AddRange(Oper(num[j], arr[3]));
            }
            for (int f = 0; f < num2.Count(); f++) 
            {
                res.AddRange(Oper(arr[0], num2[f]));
            }
        }
        for (int i = 0; i < thirdLeft.Count(); i++) 
        {
            res.AddRange(Oper(thirdLeft[i], arr[3]));
        }
        for (int i = 0; i < thirdRight.Count(); i++) 
        {
            res.AddRange(Oper(arr[0], thirdRight[i]));
        }
        return res;
    }
}

string pathToRead = "C:\\Users\\prdb\\Desktop\\SomeProject321\\INPUT.txt";
StreamReader Reader = new StreamReader(pathToRead);

string pathToWrite = "C:\\Users\\prdb\\Desktop\\SomeProject321\\OUTPUT.txt";
StreamWriter Writer = new StreamWriter(pathToWrite,false);

string[] someNum = Reader.ReadLine().Split(" ");
List<int> Numbers = [];
for (int i = 0; i < someNum.Length; i++) Numbers.Add(Convert.ToInt32(someNum[i]));

List<int> Answer = re(Numbers);

if (Answer.Exists(p => p == 24)) Writer.WriteLine("YES");
else Writer.WriteLine("NO");
Writer.Flush();

if (Answer.Exists(p => p == 24)) Console.WriteLine("YES");
else Console.WriteLine("NO");
