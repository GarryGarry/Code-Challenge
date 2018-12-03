using System;
using Xunit;
using dotnet_code_challenge;
using dotnet_code_challenge.Model;
using System.Collections.Generic;
using System.Collections;

namespace dotnet_code_challenge.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_That_OrderBy_Ascending_PrintFunction()
        {
            List<RaceViewModel> model = new List<RaceViewModel>();
            var n1 = new RaceViewModel
            {
                Name = "sean",
                Price = "11"
            };
            var n2 = new RaceViewModel
            {
                Name = "john",
                Price = "12"
            };
            var n3 = new RaceViewModel
            {
                Name = "garry",
                Price = "13"
            };
            model.Add(n1);
            model.Add(n2);
            model.Add(n3);

            PrintNames p = new PrintNames();
            ArrayList actual = p.Print(model);
            ArrayList expected = new ArrayList { "sean", "john", "garry" };
            Assert.Equal(actual, expected);
         
        }
        [Fact]
        public void Test_That_Model_IsNull_PrintFunction()
        {
            bool thrown = false;

            List<RaceViewModel> model = new List<RaceViewModel>();
            PrintNames p = new PrintNames();
            try
            {
                ArrayList actual = p.Print(null);
                thrown = false;
            }
            catch (Exception e)
            {
                thrown = true;
             
            }
           Assert.True(thrown);        

        }

    }
}
