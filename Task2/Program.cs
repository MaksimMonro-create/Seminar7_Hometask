// В двумерном массиве целых чисел. 
// Удалить строку и столбец, на пересечении которых расположен наименьший элемент.

// Создание матрицы
int[,] GetMatrix(int raw, int col, int min, int max)
{
    int[,] matrix = new int[raw, col];
    for (int i=0; i < matrix.GetLength(0); i++)
    {
        for (int j=0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = new Random().Next(min, max);
        }

    }
    return matrix;
}


// Печать матрицы
void PrintArray(int [,] array)
{
    for (int i=0; i < array.GetLength(0); i++)
    {
        for (int j=0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]}");
        }
        Console.WriteLine();
    }
}


// Поиск минимального элемента массива, а также строки и столбца с этим элементом

int[] FindMinNumberWithRawColumn(int [,] array)
{
    int[] number = new int [] {0,0};
    int minNumber = array[0,0];
    for(int i=0; i < array.GetLength(0); i++)
    {
        for(int j=0; j < array.GetLength(1); j++)
        {
            if (array[i,j] < minNumber)
            {
                number[0] = i;
                number[1] = j;
            }
        }
    }
    return number;
}

// Удаление строки и столбца из массива

int[,] DeleteRawColumn(int[,] matrix, int[] array)
{
    int[,] matrix2 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
    for (int i = 0; i < matrix2.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            if (i < array[0]) matrix2[i, j] = matrix[i, j];
            else matrix2[i, j] = matrix[i + 1, j];
        }
    }
    int[,] resultMatrix = new int[matrix2.GetLength(0), matrix2.GetLength(1) - 1]; 
    {
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                if (j < array[1]) resultMatrix[i, j] = matrix2[i, j];
                else resultMatrix[i, j] = matrix2[i, j + 1];
            }
        }
    }
    return resultMatrix;
}


int raw = 7;
int col = 7;
int min = 1;
int max = 10;

int[,] matrix = GetMatrix(raw, col, min, max);
PrintArray(matrix);
Console.WriteLine("---------------------");
int[] minPosition = FindMinNumberWithRawColumn(matrix);
int[,] matrixWithoutRawCol = DeleteRawColumn(matrix, minPosition);
PrintArray(matrixWithoutRawCol);


