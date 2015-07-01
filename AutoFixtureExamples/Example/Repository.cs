using System;

namespace AutoFixtureExamples.Example
{
    public class Repository
    {
        public static int InsertToTableFoo(string userInput)
        {
            // assume this attempts to insert a record into a database
            throw new Exception("what database, this is a unit test, kablam !!");
        }
    }
}