using System;
using System.Collections.Generic;
using System.Text;

namespace DebugInterface
{
    class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box(float lengthInches, float widthInches)
        {
            this.lengthInches = lengthInches;
            this.widthInches = widthInches;
        }

        // Explicitly implement the members of IEnglishDimensions:
        float IEnglishDimensions.Length() => lengthInches;

        float IEnglishDimensions.Width() => widthInches;

        // Explicitly implement the members of IMetricDimensions:
        float IMetricDimensions.Length() => lengthInches * 2.54f;

        float IMetricDimensions.Width() => widthInches * 2.54f;

  
    }
    public interface IEnglishDimensions
    {
        float Length();
        float Width();
    }

    // Declare the metric units interface:
    public interface IMetricDimensions
    {
        float Length();
        float Width();
    }
}
