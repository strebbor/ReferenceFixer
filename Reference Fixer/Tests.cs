using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using System.Collections;

namespace Reference_Fixer
{
    public static class TestData
    {
        public static string Input_SingleAuthor_OneReference = "(Bhati, 2012)";
        public static string Input_SingleAuthor_TwoReferences = "(Bhati, 2012) (Gouws, 2003)";
        public static string Input_SingleAuthor_ThreeReferences = "(Bhati, 2012) (Gouws, 2003) (Swart, 2004)";
        public static string Input_TwoAuthors_OneReference = "(Bhati & Dixit, 2012)";
        public static string Input_TwoAuthors_TwoReferences = "(Bhati & Dixit, 2012) (Gouws & Pienaar, 2003)";
        public static string Input_TwoAuthors_ThreeReferences = "(Bhati & Dixit, 2012) (Gouws & Pienaar, 2003) (Swart & Willers, 2004)";
        public static string Input_ThreeAuthors_OneReferences = "(Bhati, Dixit et al., 2012)";
        public static string Input_ThreeAuthors_TwoReferences = "(Bhati, Dixit et al., 2012) (Gouws, Swart et al., 2003)";
        public static string Input_ThreeAuthors_ThreeReferences = "(Bhati, Dixit et al., 2012) (Gouws, Swart et al., 2003) (Swart, Momberg et al., 2007)";
    }

    [TestFixture]
    public class Tests_SingleAuthor
    {
        private string _expectedStart;
        private string _expectedEnd;

        public Tests_SingleAuthor() { }
        public Tests_SingleAuthor(string expectedStart, string expectedEnd)
        {
            _expectedStart = expectedStart;
            _expectedEnd = expectedEnd;
        }

        public string SetupExpected(string expectedValue)
        {
            if (string.IsNullOrWhiteSpace(_expectedStart) && string.IsNullOrWhiteSpace(_expectedEnd))
            {
                return expectedValue;
            }

            string newExpectedValue = "";
            if (_expectedStart != null)
            {
                newExpectedValue = _expectedStart + expectedValue;
            }
            if (_expectedEnd != null)
            {
                newExpectedValue += _expectedEnd;
            }

            return newExpectedValue;
        }

        Methods m = new Methods();
        [Test]
        public void Inline_SingleAuthor_OneReference()
        {
            var data = TestData.Input_SingleAuthor_OneReference;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati (2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_SingleAuthor_TwoReferences()
        {
            var data = TestData.Input_SingleAuthor_TwoReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati (2012) and Gouws (2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_SingleAuthor_ThreeReferences()
        {
            var data = TestData.Input_SingleAuthor_ThreeReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati (2012), Gouws (2003) and Swart (2004)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_SingleAuthor_OneReference()
        {
            var data = TestData.Input_SingleAuthor_OneReference;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati, 2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_SingleAuthor_TwoReferences()
        {
            var data = TestData.Input_SingleAuthor_TwoReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati, 2012; Gouws, 2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_SingleAuthor_ThreeReferences()
        {
            var data = TestData.Input_SingleAuthor_ThreeReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati, 2012; Gouws, 2003; Swart, 2004)";

            Assert.AreEqual(actual, expected);
        }
    }

    public class Tests_TwoAuthors
    {
        Methods m = new Methods();
        [Test]
        public void Inline_TwoAuthors_OneReference()
        {
            var data = TestData.Input_TwoAuthors_OneReference;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati & Dixit (2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_TwoAuthors_TwoReferences()
        {
            var data = TestData.Input_TwoAuthors_TwoReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati & Dixit (2012) and Gouws & Pienaar (2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_TwoAuthors_ThreeReferences()
        {
            var data = TestData.Input_TwoAuthors_ThreeReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati & Dixit (2012), Gouws & Pienaar (2003) and Swart & Willers (2004)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_TwoAuthors_OneReference()
        {
            var data = TestData.Input_TwoAuthors_OneReference;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati & Dixit, 2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_TwoAuthors_TwoReferences()
        {
            var data = TestData.Input_TwoAuthors_TwoReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati & Dixit, 2012; Gouws & Pienaar, 2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_TwoAuthors_ThreeReferences()
        {
            var data = TestData.Input_TwoAuthors_ThreeReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati & Dixit, 2012; Gouws & Pienaar, 2003; Swart & Willers, 2004)";

            Assert.AreEqual(actual, expected);
        }
    }

    public class Tests_ThreeAuthors
    {
        Methods m = new Methods();
        [Test]
        public void Inline_ThreeAuthors_OneReference()
        {
            var data = TestData.Input_ThreeAuthors_OneReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati et al. (2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_ThreeAuthors_TwoReferences()
        {
            var data = TestData.Input_ThreeAuthors_TwoReferences;
            var actual = m.GenerateInlineCitation(data);
            var expected = "Bhati et al. (2012) and Gouws et al. (2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_ThreeAuthors_OneReference()
        {
            var data = TestData.Input_ThreeAuthors_OneReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati et al., 2012)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_ThreeAuthors_TwoReferences()
        {
            var data = TestData.Input_ThreeAuthors_TwoReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati et al., 2012; Gouws et al., 2003)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_ThreeAuthors_ThreeReferences()
        {
            var data = TestData.Input_ThreeAuthors_ThreeReferences;
            var actual = m.GenerateEndCitation(data);
            var expected = "(Bhati et al., 2012; Gouws et al., 2003; Swart et al., 2007)";

            Assert.AreEqual(actual, expected);
        }
    }

    public class Tests_General
    {
        Methods m = new Methods();

        [Test]
        public void Inline_NoText()
        {
            var data = "";
            var actual = m.GenerateInlineCitation(data);
            string expected = null;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_NoText()
        {
            var data = "";
            var actual = m.GenerateEndCitation(data);
            string expected = null;

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_NoReferenceInText()
        {
            var data = "this is a no referenc text";
            var actual = m.GenerateInlineCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_NoReferenceInText()
        {
            var data = "this is a no referenc text";
            var actual = m.GenerateEndCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_Invalid_Text_At_End()
        {
            var data = " 2011). The factors";
            var actual = m.GenerateEndCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);           
        }

        [Test]
        public void Inline_Invalid_Text_At_End()
        {
            var data = " 2011). The factors";
            var actual = m.GenerateInlineCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_Invalid_Text_At_Start()
        {
            var data = " (2011. The factors";
            var actual = m.GenerateEndCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_Invalid_Text_At_Start()
        {
            var data = " (2011. The factors";
            var actual = m.GenerateInlineCitation(data);
            string expected = "";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_More_Than_One_Ref_Selected()
        {
            var data = " (Gouws, 2011). The factors as specified by (Piet, 2004) is broken";
            var actual = m.GenerateEndCitation(data);
            string expected = "(Gouws, 2011; Piet, 2004)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_More_Than_One_Ref_Selected()
        {
            var data = " (Gouws, 2011). The factors as specified by (Piet, 2004) is broken";
            var actual = m.GenerateInlineCitation(data);
            string expected = "Gouws (2011) and Piet (2004)";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_No_References_In_Text()
        {
            var data = "sdfsdfsdf";
            var actual = m.GenerateExampleInlineString(data);
            string expected = "sdfsdfsdf";

            Assert.AreEqual(actual, expected);
        }
        [Test]
        public void End_No_References_In_Text()
        {
            var data = "sdfsdfsdf";
            var actual = m.GenerateExampleEndString(data);
            string expected = "sdfsdfsdf";

            Assert.AreEqual(actual, expected);
        }
    }

    public class Tests_StartAndEndText
    {
        Methods m = new Methods();
        [Test]
        public void Tests_References_With_StartingText()
        {
            //setup the new test data set
            Type type = typeof(TestData); // MyClass is static class with static properties
            foreach (var p in type.GetFields())
            {
                string newText = "This si my. New starting text " + p.GetValue(null);
                p.SetValue(null, newText);
            }
            Tests_SingleAuthor singleAuthorsTests = new Tests_SingleAuthor();
            singleAuthorsTests.Inline_SingleAuthor_OneReference();
            singleAuthorsTests.Inline_SingleAuthor_TwoReferences();
            singleAuthorsTests.Inline_SingleAuthor_ThreeReferences();

            Tests_TwoAuthors twoAuthorsTests = new Tests_TwoAuthors();
            twoAuthorsTests.Inline_TwoAuthors_OneReference();
            twoAuthorsTests.Inline_TwoAuthors_TwoReferences();
            twoAuthorsTests.Inline_TwoAuthors_ThreeReferences();

            Tests_ThreeAuthors threeAuthorsTests = new Tests_ThreeAuthors();
            threeAuthorsTests.Inline_ThreeAuthors_OneReference();
            threeAuthorsTests.Inline_ThreeAuthors_TwoReferences();
        }

        [Test]
        public void Tests_References_With_EndText()
        {
            //setup the new test data set
            Type type = typeof(TestData); // MyClass is static class with static properties
            foreach (var p in type.GetFields())
            {
                string newText = p.GetValue(null) + ". This is the new ending text";
                p.SetValue(null, newText);
            }
            Tests_SingleAuthor singleAuthorsTests = new Tests_SingleAuthor();
            singleAuthorsTests.End_SingleAuthor_OneReference();
            singleAuthorsTests.End_SingleAuthor_TwoReferences();
            singleAuthorsTests.End_SingleAuthor_ThreeReferences();

            Tests_TwoAuthors twoAuthorsTests = new Tests_TwoAuthors();
            twoAuthorsTests.End_TwoAuthors_OneReference();
            twoAuthorsTests.End_TwoAuthors_TwoReferences();
            twoAuthorsTests.End_TwoAuthors_ThreeReferences();

            Tests_ThreeAuthors threeAuthorsTests = new Tests_ThreeAuthors();
            threeAuthorsTests.End_ThreeAuthors_OneReference();
            threeAuthorsTests.End_ThreeAuthors_TwoReferences();
            threeAuthorsTests.End_ThreeAuthors_ThreeReferences();
        }

        [Test]
        public void Inline_Original_Replaced_Successfully()
        {
            var data = "This is the reference (Cohen, 2012) that I used";
            var actual = m.GenerateExampleInlineString(data);
            var expected = "This is the reference Cohen (2012) that I used";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Inline_Original_Replaced_Successfully_TwoReferences()
        {
            var data = "This is the reference (Cohen, 2012) (Malberge, 2003) that I used";
            var actual = m.GenerateExampleInlineString(data);
            var expected = "This is the reference Cohen (2012) and Malberge (2003) that I used";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void End_Original_Replaced_Successfully()
        {
            var data = "Written stuff (Bhati, Dixit et al., 2012) (Gouws & Swart, 2003) (Pienaar, Momberg et al., 2007). End";
            var actual = m.GenerateExampleEndString(data);
            var expected = "Written stuff (Bhati et al., 2012; Gouws & Swart, 2003; Pienaar et al., 2007). End";

            Assert.AreEqual(actual, expected);
        }
    }

    public class Tests_WrappedText
    {
        [Test]
        public void Inline_Wrapped_Text()
        {
            //setup the new test data set
            Type type = typeof(TestData); // MyClass is static class with static properties
            foreach (var p in type.GetFields())
            {
                string newText = "This is inline " + p.GetValue(null) + " text that is wrapped";
                p.SetValue(null, newText);
            }

            Tests_SingleAuthor singleAuthorsTests = new Tests_SingleAuthor();            
            singleAuthorsTests.Inline_SingleAuthor_OneReference();
            singleAuthorsTests.Inline_SingleAuthor_TwoReferences();
            singleAuthorsTests.Inline_SingleAuthor_ThreeReferences();

            Tests_TwoAuthors twoAuthorsTests = new Tests_TwoAuthors();
            twoAuthorsTests.Inline_TwoAuthors_OneReference();
            twoAuthorsTests.Inline_TwoAuthors_TwoReferences();
            twoAuthorsTests.Inline_TwoAuthors_ThreeReferences();

            Tests_ThreeAuthors threeAuthorsTests = new Tests_ThreeAuthors();
            threeAuthorsTests.Inline_ThreeAuthors_OneReference();
            threeAuthorsTests.Inline_ThreeAuthors_TwoReferences();          
        }
    }
}
