using System;

namespace SoftTest.Shared.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Truncate(this decimal value, int digits)
        {
            return Math.Truncate(100 * value) / 100;
        }
    }
}
