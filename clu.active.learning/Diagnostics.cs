using System;
using System.Diagnostics;
using System.IO;

namespace clu.active.learning
{
    /*
    
    The Debug and Trace classes include methods to write format strings to the Output window in Visual Studio, as well 
    as to any other listeners that you configure. You can also write to the Output window only when certain conditions 
    are met, and you can adjust the indentation of your trace messages.
    
    If the condition evaluates to false, the Assert method interrupts the execution of the program and displays a 
    dialog box with the message you specify. 
    
    Debug statements are only active if you build your solution in Debug mode. Trace statements are active in both 
    Debug and Release mode builds.
    
    */
    public static class Diagnostics
    {
        #region Public Methods

        public static void UsingEventLog()
        {
            Console.WriteLine("* Using EventLog");
            {
                string eventLog = "Application";
                string eventSource = "Logging Demo";
                string eventMessage = "Hello from the Logging Demo application";

                if (!EventLog.SourceExists(eventSource))
                {
                    // Create the event source if it does not already exist.
                    EventLog.CreateEventSource(eventSource, eventLog);

                    // Log the message.
                    EventLog.WriteEntry(eventSource, eventMessage);
                }
            }
        }

        public static void UsingDebugging()
        {
            Console.WriteLine("* Using Debugging");
            {
                string sProdName = "Widget";
                int iUnitQty = 100;
                double dUnitCost = 1.03;

                Debug.WriteLine("Debug Information-Product Starting ");
                Debug.Indent();
                Debug.WriteLine("The product name is " + sProdName);
                Debug.WriteLine("The available units on hand are" + iUnitQty.ToString());
                Debug.WriteLine("The per unit cost is " + dUnitCost.ToString());

                System.Xml.XmlDocument oxml = new System.Xml.XmlDocument();
                Debug.WriteLine(oxml);

                Debug.WriteLine("The product name is " + sProdName, "Field");
                Debug.WriteLine("The units on hand are" + iUnitQty, "Field");
                Debug.WriteLine("The per unit cost is" + dUnitCost.ToString(), "Field");
                Debug.WriteLine("Total Cost is  " + (iUnitQty * dUnitCost), "Calc");

                Debug.WriteLineIf(iUnitQty > 50, "This message WILL appear");
                Debug.WriteLineIf(iUnitQty < 50, "This message will NOT appear");

                Debug.Assert(dUnitCost > 1, "Message will NOT appear");
                //Debug.Assert(dUnitCost < 1, "Message will appear since dUnitcost  < 1 is false");

                TextWriterTraceListener tr1 = new TextWriterTraceListener(Console.Out);
                Debug.Listeners.Add(tr1);

                TextWriterTraceListener tr2 = new TextWriterTraceListener(File.CreateText("Output.txt"));
                Debug.Listeners.Add(tr2);

                Debug.WriteLine("The product name is " + sProdName);
                Debug.WriteLine("The available units on hand are" + iUnitQty);
                Debug.WriteLine("The per unit cost is " + dUnitCost);
                Debug.Unindent();
                Debug.WriteLine("Debug Information-Product Ending");
                Debug.Flush();
            }
        }

        public static void UsingTracing()
        {
            Console.WriteLine("* Using Tracing");
            {
                string sProdName = "Widget";
                int iUnitQty = 100;
                double dUnitCost = 1.03;

                Trace.WriteLine("Trace Information-Product Starting ");
                Trace.Indent();

                Trace.WriteLine("The product name is " + sProdName);
                Trace.WriteLine("The product name is" + sProdName, "Field");
                Trace.WriteLineIf(iUnitQty > 50, "This message WILL appear");

                Trace.Assert(dUnitCost > 1, "Message will NOT appear");

                Trace.Unindent();
                Trace.WriteLine("Trace Information-Product Ending");

                Trace.Flush();
            }
        }

        #endregion
    }
}
