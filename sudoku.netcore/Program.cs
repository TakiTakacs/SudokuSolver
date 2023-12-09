using System;

namespace SudokuSolverInProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[9, 9];
            char[][,] boxes = new char[9][,]
            {
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3],
                new char[3, 3]
            };

            initEmptyGrid(grid);
            //initRandomGrid(grid);
            showGrid(grid, boxes);
            initManualGrid(grid, boxes);
            Console.Clear();
            solve(grid, boxes);
            showGrid(grid, boxes);

            Console.ReadKey();
        }
        static bool isInBox(char number, int index, char[][,] boxes)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boxes[index][i, j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void initEmptyGrid(char[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //num = Console.ReadKey().KeyChar;
                    grid[i, j] = '0';
                }
            }
        }
        static void showGrid(char[,] grid, char[][,] boxes)
        {
            updateBoxes(grid, boxes);
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grid[k, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void updateBoxes(char[,] grid, char[][,] boxes)
        {
            int dobozszam = 0;
            for (dobozszam = 0; dobozszam < 9; dobozszam++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        boxes[dobozszam][j, k] = grid[j + setsOffset(dobozszam), k + setoOffset(dobozszam)];
                    }
                }

            }

        }
        static int setoOffset(int dobozszam)
        {
            int oOffset = 0;

            switch (dobozszam)
            {
                case 0:
                case 3:
                case 6:
                    oOffset = 0; break;
                case 1:
                case 4:
                case 7:
                    oOffset = 3; break;
                case 2:
                case 5:
                case 8:
                    oOffset = 6; break;
            }
            return oOffset;
        }
        static int setsOffset(int dobozszam)
        {

            int sOffset = 0;
            switch (dobozszam)
            {
                case 0:
                case 1:
                case 2:
                    sOffset = 0;
                    break;
                case 3:
                case 4:
                case 5:
                    sOffset = 3; break;

                case 6:
                case 7:
                case 8:
                    sOffset = 6; break;
            }

            return sOffset;
        }
        static void initManualGrid(char[,] grid, char[][,] boxes)
        {
            char bemenet = 'a';
            bool siker = false;
            char szambe; 
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Clear();
                    grid[i, j] = '.';
                    showGrid(grid, boxes);
                    Console.WriteLine("\nkérem a kovetkezo erteket:");
                    siker = false;

                    while (!siker)
                    {
                        try
                        {
                            szambe = Console.ReadKey().KeyChar;
                            if (szambe =='0' || szambe =='1' ||szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' ||szambe =='9')
                            {
                                bemenet = szambe;
                                siker = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nSZÁMOT írj be");
                                siker = false;
                            }
                           
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }


                    while ((isInSor(grid, i, bemenet) || isInOszlop(grid, j, bemenet) || isInBox(bemenet, holVagyok(grid, i, j), boxes)) && bemenet != '0')
                    {
                        if (isInSor(grid, i, bemenet) && isInOszlop(grid, j, bemenet) && isInBox(bemenet, holVagyok(grid, i, j), boxes))
                        {
                           // Console.Clear() ;
                            Console.WriteLine("\nilyen szám már van a sorban ÉS az oszlopban ÉS a dobozban is!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        else if (isInSor(grid, i, bemenet) && isInOszlop(grid, j, bemenet))
                        {
                            //Console.Clear() ;
                            Console.WriteLine("\nilyen szám már van a sorban ÉS az oszlopban is!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        else if (isInSor(grid, i, bemenet) && isInBox(bemenet, holVagyok(grid, i, j), boxes))
                        {
                            //Console.Clear() ;
                            Console.WriteLine("\nilyen szám már van a sorban ÉS a dobozban is!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                    while (!siker)
                    {
                        try
                        {
                            szambe = Console.ReadKey().KeyChar;
                            if (szambe =='0' || szambe =='1' ||szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' ||szambe =='9')
                            {
                                bemenet = szambe;
                                siker = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nSZÁMOT írj be");
                                siker = false;
                            }
                           
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                        }
                        else if (isInOszlop(grid, j, bemenet) && isInBox(bemenet, holVagyok(grid, i, j), boxes))
                        {
                            //Console.Clear() ;
                            Console.WriteLine("\nilyen szám már van az oszlopban ÉS a dobozban is!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        else if (isInSor(grid, i, bemenet))
                        {
                            //Console.Clear();
                            Console.WriteLine("\nilyen szám már van a sorban!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        else if (isInOszlop(grid, j, bemenet))
                        {
                            //Console.Clear();
                            Console.WriteLine("\nilyen szám már van az oszlopban!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                        else if (isInBox(bemenet, holVagyok(grid, i, j), boxes))
                        {
                            //Console.Clear() ;
                            Console.WriteLine("\nilyen szám már van a dobozban!!!");
                            Console.WriteLine("Irj be másikat:");
                            siker = false;
                            while (!siker)
                            {
                                try
                                {
                                    szambe = Console.ReadKey().KeyChar;
                                    if (szambe == '0' || szambe == '1' || szambe == '2' || szambe == '3' || szambe == '4' || szambe == '5' || szambe == '6' || szambe == '7' || szambe == '8' || szambe == '9')
                                    {
                                        bemenet = szambe;
                                        siker = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSZÁMOT írj be");
                                        siker = false;
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                    grid[i, j] = bemenet;
                }

            }
            Console.Clear();
            showGrid(grid, boxes);
        }
        static void initRandomGrid(char[,] grid)
        {
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = Convert.ToChar(Convert.ToString(rnd.Next(0, 10)));
                }
            }
        }
        static bool isInSor(char[,] grid, int sorindex, char number)
        {
            bool bennevan = false;
            for (int i = 0; i < 9; i++)
            {
                if (grid[sorindex, i] == number)
                {
                    bennevan = true;
                    break;
                }
            }
            return bennevan;
        }
        static bool isInOszlop(char[,] grid, int oszlopindex, char number)
        {
            bool bennevan = false;
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, oszlopindex] == number)
                {
                    bennevan = true;
                    break;
                }
            }
            return bennevan;
        }
        static int holVagyok(char[,] grid, int sor, int oszlop)
        {
            int dobozindex = 99;
            if ((sor >= 0 && sor < 3) && oszlop < 3)
            {
                dobozindex = 0;
            }
            else if ((sor >= 0 && sor < 3) && (oszlop >= 3 && oszlop <= 5))
            {
                dobozindex = 1;
            }
            else if ((sor >= 0 && sor < 3) && (oszlop >= 6 && oszlop <= 8))
            {
                dobozindex = 2;
            }
            else if ((sor >= 3 && sor < 6) && oszlop < 3)
            {
                dobozindex = 3;
            }
            else if ((sor >= 3 && sor < 6) && (oszlop >= 3 && oszlop <= 5))
            {
                dobozindex = 4;
            }
            else if ((sor >= 3 && sor < 6) && (oszlop >= 6 && oszlop <= 8))
            {
                dobozindex = 5;
            }
            else if ((sor >= 6 && sor < 9) && oszlop < 3)
            {
                dobozindex = 6;
            }
            else if ((sor >= 6 && sor < 9) && (oszlop >= 3 && oszlop <= 5))
            {
                dobozindex = 7;
            }
            else if ((sor >= 6 && sor < 9) && (oszlop >= 6 && oszlop <= 8))
            {
                dobozindex = 8;
            }
            return dobozindex;
        }
        static bool isValid(char[,] grid, char[][,] boxes, int i, int j, char number)
        {
            if (!isInBox(number, holVagyok(grid, i, j), boxes) && !isInOszlop(grid, j, number) && !isInSor(grid, i, number))
            {
                return true;
            }
            else { return false; }
        }
        static bool solve(char[,] board, char[][,] boxes)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == '0')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(board, boxes, i, j, c))
                            {
                                board[i, j] = c;
                                updateBoxes(board, boxes);

                                if (solve(board, boxes))
                                    return true;
                                else
                                    board[i, j] = '0';
                                updateBoxes(board, boxes);
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}