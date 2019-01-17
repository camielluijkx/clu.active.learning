using System;

namespace clu.active.learning
{
    /*
    
    Exception Class             Namespace                       Description
    Exception                   System                          Represents any exception that is 
                                                                raised during the execution of an 
                                                                application.
    SystemException             System                          Represents all exceptions raide by 
                                                                the CLR. The SystemException class 
                                                                is the base class for all the 
                                                                exception classes in the System 
                                                                namespace.
    ApplicationException        System                          Represents all non-fatal exceptions 
                                                                raised by applications and not the 
                                                                CLR.
    NullReferenceException      System                          Represents an exception that is 
                                                                caused when trying to use an object 
                                                                that is null.
    FileNotFoundException       System.IO                       Represents an exception caused when 
                                                                a file does not exist.
    SerializationException      System.Runtime.Serialization    Represents an exception that occurs 
                                                                during the serialization or 
                                                                deserialization process.
    
    */
    public static class Exceptions
    {
        #region Public Methods

        public static void UsingExceptions() // SEH = Structured Exception Handling
        {
            Console.WriteLine("* Using Exceptions");
            {
                Console.WriteLine("** Specific");
                {
                    try
                    {

                    }
                    catch (NullReferenceException ex) // specific
                    {
                        // Catch all NullReferenceExceptions.
                    }
                    catch (Exception ex)
                    {
                        // Catch all other exceptions.
                    }
                }

                Console.WriteLine("** Finally");
                {
                    try
                    {
                    }
                    // Catch is optional.
                    finally
                    {
                        // Code that always runs.
                    }

                    try
                    {
                    }
                    catch // Exception is optional.
                    {
                    }
                    finally
                    {
                        // Code that always runs.
                    }
                }

                Console.WriteLine("** Rethrow");
                {
                    try
                    {
                        var ex = new ArgumentNullException("The 'Name' parameter is null.");
                    }
                    catch
                    {
                        // Attempt to handle the exception.

                        // If this catch handler cannot resolve the exception, throw it to the 
                        // calling code.
                        throw;
                    }
                }
            }
        }

        #endregion
    }
}
