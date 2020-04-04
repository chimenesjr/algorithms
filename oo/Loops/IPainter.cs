using System;

namespace algorithms.oo.Loops
{
    public interface IPainter
    {
        bool IsAvailable { get;}
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCompensation(double sqMeters);
    }
}