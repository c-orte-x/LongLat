using System;

namespace AssignmentV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] arrCells = {{  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S" },
                {"","","","","","","","","","","","","","","","","","","" } };
            double[,] arrLongLat = { { -0.03098,-0.02554,-0.02448,-0.02415,-0.02277,-0.02204,-0.02201,-0.02185,-0.02234,-0.02206,-0.02052,-0.02025,-0.01921,-0.01725,-0.01561,-0.01273,-0.01272,-0.01216,-0.01078},
                            { 51.53657,51.53833,51.53721,51.5445,51.54439,51.54735,51.54739,51.54525,51.53328,51.53948,51.54653,51.54472,51.54262,51.53934,51.53862,51.54337,51.54202,51.5407,51.54023} };
            double[,] arrDis = new double[19, 19];

            double dLong, dLat, long1, long2, lat1, lat2, a, c, d, maxD, minD, maxF, minF;
            int closestDPos;
            double r = 6373; //Radius of the earth in Km

            maxD = 0;
            minD = 9999;
            minF = 110;
            maxF = 115;
            closestDPos = 0;

            for (int j = 0; j < 19; j++)
            {
                Console.WriteLine("Index:" + j);
                for (int k = 0; k < 19; k++)
                {
                    long1 = Convert.ToDouble(arrLongLat[0, j]);
                    long2 = Convert.ToDouble(arrLongLat[0, k]);
                    lat1 = Convert.ToDouble(arrLongLat[1, j]);
                    lat2 = Convert.ToDouble(arrLongLat[1, k]);

                    dLong = long2 - long1;
                    dLat = lat2 - lat1;

                    a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dLong / 2), 2);
                    c = 2 * (Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));
                    d = r * c;

                    arrDis[j, k] = d;

                    if (arrDis[j, k] > maxD)
                    {
                        maxD = arrDis[j, k];
                    }
                    else if (arrDis[j, k] < minD && arrDis[j, k] != 0)
                    {
                        minD = arrDis[j, k];
                        closestDPos = k;
                    }

                    Console.WriteLine("Distance between " + arrCells[0, j] + "  &  " + arrCells[0, k] + " :  " + arrDis[j, k]);

                    arrCells[1, j] = Convert.ToString(minF);
                    arrCells[1, closestDPos] = Convert.ToString(maxF);
                    if (Convert.ToDouble(arrCells[1,j]) == Convert.ToDouble(arrCells[1,closestDPos]))
                    {
                        arrCells[1, j] = Convert.ToString(minF + 1);
                        arrCells[1, closestDPos] = Convert.ToString(maxF - 1);
                        if(Convert.ToDouble(arrCells[1, j]) > 115)
                        {
                            arrCells[1, j] = Convert.ToString(minF - 1);
                        }
                        if (Convert.ToDouble(arrCells[1, closestDPos]) < 110)
                        {
                            arrCells[1, closestDPos] = Convert.ToString(maxF + 1);
                        }
                    }
                    minF++;
                    maxF--;
                    if(minF == 116)
                    {
                        minF = 110;
                    }
                    if(maxF == 109)
                    {
                        maxF = 115;
                    }
                }

                Console.WriteLine(arrCells[0, j] + "  " + arrCells[1, j] + " ; Closest value " + arrCells[0, closestDPos] + "  frequency = " + arrCells[1, closestDPos]);
                Console.WriteLine("\n");
            }

            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine(arrCells[0, i] + "  " + arrCells[1, i]);
            }
        }
    }
}