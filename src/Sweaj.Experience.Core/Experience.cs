using Microsoft.Extensions.Logging;

namespace Sweaj.Experience.Bcl
{
    // All the code in this file is included in all platforms.


    /// <summary>
    /// Creating a self learning MAUI App.
    ///
    /// Create using ideas for predicting the best choice based on information you give it by designing
    /// the very self learning part itself. Create your own basic self learning app using machine learning
    /// from how I understand it works.
    ///
    /// Create a weighting system,
    ///
    /// Try again at writing to Dr. Jordan B. Peterson but with a new attitude, mention that I just created
    /// a machine learning technique algorithm from scratch using my understanding of how they work. I decided to write it
    /// as an API, meaning other developers could leverage it. Also to test if my understanding of it is right, then it
    /// should produce more and more accurate results.
    ///
    /// See doc
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Experience : ITrainable, ITestable
    {
        public Experience()
        {
                
        }


    }

    public interface ITrainable
    {
        void Train();
    }

    public interface ITestable
    {
        void Test();
    }

    public interface IDescribable
    {
        public object Self { get; set; }

        public EventId SourceClass { get; }

        public EventId SourceMethod { get; }

        public EventId Source { get; }

        public ActionableType Action { get; }
        public EventId ClassName { get; }

    }

    public enum ActionableType
    {
        Default,
        FromLastTrain,
        FromAllTime,
        Prediction,

    }
}