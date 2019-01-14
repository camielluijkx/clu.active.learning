using System;

namespace clu.active.learning
{
    /*
    
    Delegates:
        • Delegates are references to methods.
        • They can be saved as fields and passed as parameters.
        • They allow one to execute code that is provided from extrenal sources.
        • Delegates can be executed exactly like methods.

    Events:
        • An event wraps a delegate like a property wraps a field.
        • Events allow the class to notify other consumers of actions performed within it.
        • An event may only be raised by it's containing class.
    
    */
    public static class Events
    {
        public class ThresholdReachedEventArgs : EventArgs
        {
            public int Threshold { get; set; }

            public DateTime TimeReached { get; set; }
        }

        public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);

        public class Counter
        {
            public event ThresholdReachedEventHandler ThresholdReached;

            protected void OnThresholdReached(ThresholdReachedEventArgs e)
            {
                ThresholdReached?.Invoke(this, e);
            }

            public void Add(int number)
            {
                if (number == 5)
                {
                    ThresholdReachedEventArgs args = new ThresholdReachedEventArgs
                    {
                        Threshold = number,
                        TimeReached = DateTime.Now
                    };

                    ThresholdReached(this, args);
                }
            }
        }

        private static void thresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold was reached: {0}.", e.Threshold);
        }

        #region Public Methods

        public static void UsingEventHandlers()
        {
            Console.WriteLine("* Using Event Handlers");
            {
                Counter c = new Counter();

                Console.WriteLine("** Subscribe");
                {
                    c.ThresholdReached += thresholdReached;
                }

                Console.WriteLine("** Raise");
                {
                    c.Add(4);
                    c.Add(5); // raise
                    c.Add(6);
                }

                Console.WriteLine("** Unsubscribe");
                {
                    c.ThresholdReached -= thresholdReached;
                }
            }
        }

        #endregion
    }
}
