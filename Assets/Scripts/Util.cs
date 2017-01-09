using System;
using System.Collections.Generic;


class Util
{
    public static int Mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }
}
