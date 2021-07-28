using System;

namespace Prime.Services
{
    public class PrimeService
    {
        private readonly PositiveService _positiveService;

        public PrimeService(PositiveService positiveService)
        {
            _positiveService = positiveService;
        }

        public bool IsPrime(int candidate)
        {
            if (!_positiveService.IsPositive(candidate)) throw new Exception("Invalid input.");

            if (candidate <= 1) return false;
            else if (candidate % 2 == 0) return candidate == 2;

            long N = (int)(Math.Sqrt(candidate) + 0.5);

            for (int i = 3; i <= N; i += 2)
            {
                if (candidate % i == 0) return false;
            }

            return true;
        }

        public bool HasPrimeId(Person person)
        {
            return IsPrime(person.Id);
        }
    }
}
