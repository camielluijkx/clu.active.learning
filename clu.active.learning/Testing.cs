using System;

namespace clu.active.learning
{
    /*
     
    A unit test method is divided into three conceptual phases:

        • Arrange. In this phase, you create the conditions for the test. 
          You instantiate the class you want to test, and you configure any input values 
          that the test requires. 
        • Act. In this phase, you perform the action that you want to test. 
        • Assert. In this phase, you verify the results of the action. If the results were 
          not as expected, the test fails. 

    */
    public static class Testing
    {
        // Class under test.
        public class Customer
        {
            public DateTime DateOfBirth { get; set; }

            public int GetAge()
            {
                TimeSpan difference = DateTime.Now.Subtract(DateOfBirth);
                int ageInYears = (int)(difference.Days / 365.25);
                // Note: converting a double to an int rounds down to the nearest whole number.
                return ageInYears;
            }
        }

        /*

        [TestMethod]
        public void TestGetAge()
        {
            // Arrange.
            DateTime dob = DateTime.Today;
            dob.AddDays(7);
            dob.AddYears(-24);
            Customer testCust = new Customer();
            testCust.DateOfBirth = dob;
            // The customer's 24th birthday is seven days away, so the age in years should be 23.
            int expectedAge = 23;

            // Act.
            int actualAge = testCust.GetAge();
            // Assert.
            // Fail the test if the actual age and the expected age are different.
            Assert.IsTrue((actualAge == expectedAge), "Age not calculated correctly");
        }

        */
    }
}
