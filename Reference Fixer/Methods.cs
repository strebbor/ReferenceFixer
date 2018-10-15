using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference_Fixer
{
    public class Methods
    {
        private string[] GetAllReferences(string selectedText)
        {
            return selectedText.Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public string GenerateExampleInlineString(string selectedText)
        {
            string inlineExample = GenerateInlineCitation(selectedText);
            return GetReplacedString(selectedText, inlineExample);
        }

        public string GenerateExampleEndString(string selectedText)
        {
            string endExample = GenerateEndCitation(selectedText);
            return GetReplacedString(selectedText, endExample);
        }

        public string GenerateInlineCitation(string selectedText)
        {
            string[] allReferences = GetAllReferences(selectedText);
            if (allReferences.Length == 0)
            {
                return null;
            }

            string finalReference = "";
            int workingWithReferenceNumber = 0;
            foreach (string reference in allReferences)
            {
                workingWithReferenceNumber++;

                ReferenceObject referenceParts = GetReferenceParts(reference);
                if (referenceParts == null) { continue; }
                if (referenceParts.authors.Length == 0) { continue; }

                if (referenceParts.useEtAl)
                {
                    finalReference += referenceParts.authors[0] + " et al.";
                }
                else
                {
                    foreach (string author in referenceParts.authors)
                    {
                        finalReference += author + " and ";
                    }

                    finalReference = finalReference.Substring(0, finalReference.Length - 5); //chop of the last and
                }

                if ((allReferences.Length - 1) == workingWithReferenceNumber)
                {
                    finalReference += " (" + referenceParts.date + ") and ";
                }
                else
                {
                    finalReference += " (" + referenceParts.date + "), ";
                }

            }

            finalReference = finalReference.Trim();

            if (!string.IsNullOrWhiteSpace(finalReference))
            {
                finalReference = finalReference.Substring(0, finalReference.Length - 1); //chop off last ,
            }

            return finalReference;
        }

        public string GenerateEndCitation(string selectedText)
        {
            string[] allReferences = GetAllReferences(selectedText);
            if (allReferences.Length == 0)
            {
                return null;
            }

            string finalReference = "";
            foreach (string reference in allReferences)
            {
                ReferenceObject referenceParts = GetReferenceParts(reference);
                if (referenceParts == null) { continue; }
                if (referenceParts.authors.Length == 0) { continue; }

                if (referenceParts.useEtAl)
                {
                    finalReference += referenceParts.authors[0] + " et al.";
                }
                else
                {
                    foreach (string author in referenceParts.authors)
                    {
                        finalReference += author + "&";
                    }

                    finalReference = finalReference.Substring(0, finalReference.Length - 1); //chop of the last &
                }

                //add the date
                finalReference += ", " + referenceParts.date + "; ";
            }

            if (!string.IsNullOrWhiteSpace(finalReference))
            {
                finalReference = finalReference.Trim();
                finalReference = finalReference.Substring(0, finalReference.Length - 1);
                finalReference = "(" + finalReference + ")";
            }

            return finalReference;
        }

        private string GetReferenceText(string selectedText)
        {
            int indexOfFirstBracket = selectedText.IndexOf("(");
            int indexOfLastBracket = selectedText.LastIndexOf(")");

            if (indexOfFirstBracket == -1 && indexOfLastBracket == -1)
            {
                return "";
            }

            string referenceText = selectedText;
            if (indexOfFirstBracket != -1)
            {
                referenceText = referenceText.Substring(indexOfFirstBracket + 1);
            }

            indexOfLastBracket = referenceText.LastIndexOf(")");
            if (indexOfLastBracket != -1)
            {
                referenceText = referenceText.Substring(0, indexOfLastBracket);
            }

            return referenceText;
        }

        private ReferenceObject GetReferenceParts(string selectedText)
        {
            string referenceText = GetReferenceText(selectedText);

            ReferenceObject referenceParts = new ReferenceObject();
            if (string.IsNullOrWhiteSpace(referenceText))
            {
                return null;
            }

            //find the date
            var indexOfLastComma = referenceText.LastIndexOf(",");
            string possibleDateString = referenceText.Substring(indexOfLastComma + 1);
            int result = -1;
            int.TryParse(possibleDateString, out result);
            if (result > -1)
            {
                if (result.ToString().Length == 4)
                {
                    referenceParts.date = result.ToString();
                }
            }

            //chop off the date
            referenceText = referenceText.Replace(possibleDateString, "");
            referenceParts.referenceText = referenceText;

            //split the authors           
            referenceParts.authors = referenceText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (referenceParts.authors.Length > 1)
            {
                referenceParts.useEtAl = true;
            }

            return referenceParts;
        }

        public string GetReplacedString(string selectedText, string newText)
        {
            int indexOfFirstBracket = selectedText.IndexOf("(");
            int indexOfLastBracket = selectedText.LastIndexOf(")");
            string oldReference = "";
            if (indexOfFirstBracket < 0 || indexOfLastBracket < 0)
            {
                return selectedText; ;
            }
            else
            {
                int lengthOfOldReference = (indexOfLastBracket - indexOfFirstBracket) + 1;
                oldReference = selectedText.Substring(indexOfFirstBracket, lengthOfOldReference);
                return selectedText.Replace(oldReference, newText);
            }
        }
    }

    public class ReferenceObject
    {
        public string originalReferenceText { get; set; }
        public string referenceText { get; set; }
        public string date { get; set; }
        public bool useEtAl { get; set; }
        public string[] authors { get; set; }
    }
}
