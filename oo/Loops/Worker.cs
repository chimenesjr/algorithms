using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms.oo.Loops
{
    class Worker
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters.Where(x => x.IsAvailable)
                .WithMinimum(x => x.EstimateCompensation(sqMeters));
                
            return 
                painters
                    .Where(x => x.IsAvailable)
                    .OrderBy(x => x.EstimateCompensation(sqMeters))
                    .FirstOrDefault();

            /*
            double bestPrice = 0;
            IPainter cheapest = default(IPainter);

            foreach (var painter in painters)
            {
                if (!painter.IsAvailable)
                    continue;
                
                var price = painter.EstimateCompensation(sqMeters);
                if (cheapest == null || price < bestPrice)
                    cheapest = painter;
            }

            return cheapest;
            */
        }
    }

    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> => 
                sequence
                    .Select(obj => Tuple.Create(obj, criterion(obj)))
                    .Aggregate((Tuple<T, TKey>)null,
                    (best, current) =>
                        best == null || current.Item2.CompareTo(best.Item2) < 0 ? current : best).
                    Item1;

    }
}
