using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS
{
    public class Constants
    {
        public const string JWT_COOKIE = "JWT";

        public static class Authorization
        {
            public const int ITERATION_COUNT = 10_000;
            public const int BYTES_REQUESTED = 64;
            public const KeyDerivationPrf PRF = KeyDerivationPrf.HMACSHA512;
        }
    }
}
