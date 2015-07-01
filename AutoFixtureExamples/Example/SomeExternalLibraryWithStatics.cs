using System;

namespace AutoFixtureExamples.Example
{
    public class SomeExternalLibraryWithStatics
    {
        public static bool IsValidForTable(string userInput)
        {
            // assume this calls out to some dependency that is expensive to use at run time and hard
            // to arrange, ie reads a static config or somesuch

            throw new Exception("you called me during a unit test and I really don't like that !!!");
            return true;
        }
    }
}