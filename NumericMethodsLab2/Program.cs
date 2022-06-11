double m;
string input = Console.ReadLine();
m = double.Parse(input);

int n = 4;
double e = 0.005;
double[] v = new double[] { 0.7 * m, 1, 2, 0.5 };
double[] new_vector = new double[] { 0, 0, 0, 0 };
double[,] a = new double[,]{
        { 5, 1, -1, 1, 3 * m},
        { 1, -4, 1, -1, m - 6},
        { -1, 1, 4, 1, 15 - m},
        { 1, 2, 1, -5, m + 2}
    };

for (int i = 0; i < n; i++)
{
    double sum = 0;
    for (int j = 0; j < n; j++)
    {
        sum = sum + Math.Abs(a[i, j]);
    }

    if (Math.Abs(a[i, i]) <= sum - Math.Abs(a[i, i]))
    {
        Console.WriteLine("Fail");
        throw new Exception();
    }
}

int iteration = 0;

while (true)
{
    iteration++;
    double max = 0;
    for (int i = 0; i < n; i++)
    {

        double sum1 = 0, sum2 = 0;

        for (int j = 0; j <= i - 1; j++)
        {
            sum1 += a[i, j] * v[j];
        }

        for (int j = i + 1; j < n; j++)
        {
            sum2 += a[i, j] * v[j];
        }

        double value = (a[i, n] - sum1 - sum2) / a[i, i];
        double x = Math.Abs(value - v[i]);

        if (max < x)
        {
            max = x;
        }
        new_vector[i] = value;
    }

    for (int i = 0; i < n; ++i)
        v[i] = new_vector[i];


    if (max < e)
    {
        Console.WriteLine("x(" + iteration + ")={");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(v[i] + "; ");
        }
        Console.WriteLine("}\n");
        break;
    }
}
