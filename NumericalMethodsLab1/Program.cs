int n = 3;
double[,] a = new double[n + 1, n+2];
for (int i = 1; i <= n; ++i)
{
    for (int j = 1; j <= n + 1; ++j)
    {
        string? input = Console.ReadLine();
        if(input is not null)
        {
            a[i, j] = double.Parse(input);
        } 
    }       
}
double k = a[1, 1];
for (int j = 1; j <= n + 1; ++j) a[1, j] = a[1, j] / k;
k = a[2, 1];
for (int j = 1; j <= n + 1; ++j) a[2, j] = a[1, j] * k - a[2, j];
k = a[3, 1];
for (int j = 1; j <= n + 1; ++j) a[3, j] = a[1, j] * k - a[3, j];
k = a[2, 2];
for (int j = 1; j <= n + 1; ++j) a[2, j] = a[2, j] / k;
k = a[3, 2];
for (int j = 1; j <= n + 1; ++j) a[3, j] = a[2, j] * k - a[3, j];
k = a[3, 3];
for (int j = 1; j <= n + 1; ++j) a[3, j] = a[3, j] / k;

double x3 = a[3, 4];
double x2 = a[2, 4] - x3 * a[2, 3];
double x1 = a[1, 4] - x3 * a[1, 3] - x2 * a[1, 2];
Console.WriteLine("x1 = " + x1 + "\nx2 = " + x2 + "\nx3 = " + x3);
