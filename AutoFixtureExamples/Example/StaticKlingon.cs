using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFixtureExamples.Example
{
    public class StaticKlingon
    {
        private readonly string _context;

        public StaticKlingon(string context)
        {
            _context = context;
        }

        public void InsertInput()
        {
            OperationContext.Start("InsertInput", _context);

            string userInput = Console.ReadLine();

            if (SomeExternalLibraryWithStatics.IsValidForTable(userInput))
            {
                var rowsInserted = Repository.InsertToTableFoo(userInput);
            }
            else
            {
                AllEncompassingLogger.LogThis("Bad user input", _context);
            }
        }
    }
}
