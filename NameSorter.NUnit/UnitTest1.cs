using NUnit.Framework;
using NameSorter;

namespace NameSorter.NUnit
{  
    public class Tests
    {
        private const string Value = "Parsons Janet";
        private NameSorter.Program _mainProgram;
        
         [SetUp]
        public void Setup()
        {
            _mainProgram = new Program();

        }

        [Test]
        public void TestGetLastWordToFirst()
        {
            string Result=NameSorter.Program.GetLastWordToFirst("Janet Parsons");
            if (Result.Equals(Value)) {

                Assert.Pass("TestGetLastWordToFirst Pass");
            }
            
            
        }
    }
}