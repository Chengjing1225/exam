using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

using System.Collections.Generic;
using System.Linq;
using testTwo;


class Program
{
   

    static void Main(string[] args)
    {
        string line;
        while((line = Console.ReadLine())!=null)
        {
            int select = int.Parse(line);
            switch(select)
            {
                case 1:
                    {
                        //string str = "abaaabbbbbbskfkkkkkkkkkkkkkkkkrrttttttt       @@@@@@@@@eeeeeee   eeeeeererhjfhjhjhjsbfjehjrhkzldklfklskkkkuuuuuu";
                        string str = "abaaabbbkkkkkkkkrrtttbbbskfkkkkkkkktttt       @@@eererhjfhjheeee   eeeeejhjsbfjehjr@@@@@@eehkzldklfklskkkkuuuuuu          yyuhhjhhjhjgyyhjhjvvvvvdddrwmslxjjjjjjjjjj";
                        process_str(str);
                    }
                    break;
                case 2:
                    {
                        getMorePoints();
                    }
                    break;
                case 3:
                    getMin();
                    break;
            }
            
            Console.Read();
        }
        
        
    }

    static void process_str(string str)
    {
        string[] strInfo;
        strInfo = Regex.Split(str, "\\s+");
        string result = ' '.ToString();
        char last = ' ';
        int count = 1;

        for (int i = 0; i < strInfo.Length; i++)
        {
            for (int j = 0; j < strInfo[i].Length; j++)
            {
                char s = strInfo[i][j];
                if (j == 0)
                {
                    last = s;
                    continue;
                }
                if (s == last)
                {
                    count++;
                    if (j != strInfo[i].Length - 1)
                        continue;
                }
                if (result == ' '.ToString())
                    result = count.ToString();
                else
                    result += count;
                result += last;
                last = s;
                count = 1;
            }
            if (i != strInfo.Length - 1)
                result += ' ';
        }
        Console.WriteLine(result);

    }


    static void getMorePoints()
    {
        try
        {
            StreamReader sr = new StreamReader(@"..\..\data\testData-2.txt", Encoding.Default);
            string line;
            List<Vector3> vectors = new List<Vector3>();
            Dictionary<vecLineInfo, HashSet<int>> allInfo = new Dictionary<vecLineInfo, HashSet<int>>();
            
            while ((line = sr.ReadLine()) != null)
            {
                List<float> vecList = Regex.Split(line, "\\s+").ToList().Select(t => float.Parse(t)).ToList();
                Vector3 vec = new Vector3(vecList[0], vecList[1], vecList[2]);
                vectors.Add(vec);
            }
            //vectors = vectors.OrderBy(t => t.x).ThenBy(t => t.y).ThenBy(t => t.z).ToList();
            for(int i = 0; i < vectors.Count; i++)
            {
                for(int j = i + 1; j < vectors.Count; j++)
                {
                    Vector3 vector = new Vector3();
                    if(vectors[j].x > vectors[i].x)
                        vector = new Vector3(vectors[j].x - vectors[i].x, vectors[j].y - vectors[i].y, vectors[j].z - vectors[i].z).normalize();
                    else
                        vector = new Vector3(vectors[i].x - vectors[j].x, vectors[i].y - vectors[j].y, vectors[i].z - vectors[j].z).normalize();
                    bool hasExist = false;
                    if (allInfo.Count != 0)
                    {                        
                        foreach(var info in allInfo)
                        {
                            float u = info.Key.k.x - vector.x;
                            if (info.Key.k.x != vector.x || info.Key.k.x != vector.x || info.Key.k.x != vector.x)
                                continue;
                            if (info.Key.startPoint == vectors[i])
                            {
                                info.Value.Add(j);
                                hasExist = true;
                                break;
                            }
                            if (info.Value.FirstOrDefault(t => t == i) != 0)
                            {
                                if (info.Value.FirstOrDefault(t => t == j) != 0)
                                {
                                    hasExist = true;
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                                continue;
                        }
                        if (hasExist)
                            continue;

                    }
                    if (hasExist)
                        continue;
                    vecLineInfo vecLine = new vecLineInfo(vector, vectors[i]);
                    HashSet<int> commonLineIndexs = new HashSet<int>();
                    commonLineIndexs.Add(i);
                    commonLineIndexs.Add(j);
                    allInfo.Add(vecLine, commonLineIndexs);

                }
            }
            List<vecLineInfo> maxIndexs = new List<vecLineInfo>();
            int maxCount = 0;
            foreach(var info in allInfo)
            {
                if(maxCount < info.Value.Count)
                {
                    maxCount = info.Value.Count;
                    maxIndexs.Clear();
                    maxIndexs.Add(info.Key);
                    //maxIndex = info.Key;
                }
                else if(maxCount == info.Value.Count)
                    maxIndexs.Add(info.Key);
            }

            Console.WriteLine("共线的点共有" + allInfo[maxIndexs[0]].Count + "个");
            for(int i = 0; i < maxIndexs.Count; i++)
            {
                foreach (var result in allInfo[maxIndexs[i]])
                {
                    Console.WriteLine(vectors[result].x.ToString() + ' ' + vectors[result].y.ToString() + ' ' + vectors[result].z.ToString());
                }
                if(i != maxIndexs.Count - 1)
                    Console.WriteLine("或");
            }
                
        }
        catch(IOException e)
        {
            Console.WriteLine(e.ToString());
        }
        
    }


    static void getMin()
    {
        int[] stackData = new int[] {2,40,5,8,9,50,4,19,25,34,44,1,1,5,6,18,47,60,555,22,33,88,44,25 };
        test3 stack = new test3();
        for(int i = 0; i < stackData.Length; i++)
        {
            stack.push(stackData[i]);
        }
        int num = stack.GetMin();
        Console.WriteLine(num);
    }
}
