using System;

namespace AutoFixtureExamples.Example
{
    public class AllEncompassingLogger
    {
        public static void LogThis(string userInput, string badUserInput)
        {
            // assume this logs records in some manner that even though it might not be expensive,
            // would it not be nice to (a) write tests first that help us establish what logging we have and
            // (b) have tests for our logging that enable to surive merges and the hands of other devs !
            throw new Exception("ouch, the unit test does not have a valid logging config file, so I'll just blow up");
        }
    }
}