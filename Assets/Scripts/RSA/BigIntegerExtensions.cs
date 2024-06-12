using System.Numerics;

public static class BigIntegerExtensions
{
    // Extension method to calculate the modular inverse of a number
    public static BigInteger ModInverse(this BigInteger a, BigInteger m)
    {
        BigInteger m0 = m, t, q;
        BigInteger x0 = 0, x1 = 1;

        if (m == 1)
            return 0;

        // Apply extended Euclid Algorithm
        while (a > 1)
        {
            // q is quotient
            q = a / m;
            t = m;

            // m is remainder now, process same as
            // Euclid's algo
            m = a % m;
            a = t;

            t = x0;
            x0 = x1 - q * x0;
            x1 = t;
        }

        // Make x1 positive
        if (x1 < 0)
            x1 += m0;

        return x1;
    }
}