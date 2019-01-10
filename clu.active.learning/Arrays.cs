using System;

namespace clu.active.learning
{
    public static class Arrays
    {
        #region Public Methods

        public static void UsingArrays()
        {
            Console.WriteLine("* Using Arrays");
            {
                Console.WriteLine("** Singledimensional arrays");
                {
                    int[] arrayName = new int[10];
                }

                Console.WriteLine("** Multidimensional arrays");
                {
                    int[,,] arrayName = new int[10, 10, 10]; // rank = 3 (number of dimensions)
                }

                Console.WriteLine("** Jagged arrays"); // array of arrays
                {
                    int[][] jaggedArray = new int[10][]; // size of first array must be specified
                    jaggedArray[0] = new int[5]; // size of array may vary 
                    jaggedArray[1] = new int[7];
                }

                Console.WriteLine("** Accessing Data by Index");
                {
                    int[] oldNumbers = { 1, 2, 3, 4, 5 };
                    int number = oldNumbers[2]; // = 3
                }

                Console.WriteLine("** Iterating Over an Array");
                {
                    int[] oldNumbers = { 1, 2, 3, 4, 5 };
                    for (int i = 0; i < oldNumbers.Length; i++)
                    {
                        int number = oldNumbers[i]; // zero-indexed, length = 5
                    }
                }
            }
        }

        #endregion
    }
}