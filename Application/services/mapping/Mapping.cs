using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.services.mapping
{
    // Default implementation of the IMapping interface
    public class Mapping : IMapping
    {
        // Formats a List<string> of acids to a 
        // user-readable string
        public string FormatAcids(List<string> aminoAcids)
        {
            // Create the string to store amino acids
            string formatted = string.Empty;

            // Loop through the List<string> aminoAcids
            // and append each item to the formatted string
            foreach (string aminoAcid in aminoAcids)
            {
                formatted += $"{aminoAcid}\t";
            }

            // Return the formatted sequence
            return formatted;
        }

        // Maps a base sequence to a library-friendly integer
        public List<int> MapBaseSequence(string sequence)
        {
            // Create an empty int[] that will be populated and returned
            // when the method exits
            List<int> mappedSequence = new List<int>();

            // Check if the length of the sequence is less than three
            if (sequence is null) return mappedSequence;

            // Loop through each character in the sequence and add to the 
            // mappedSequence
            foreach (char nucleotideBase in sequence)
            {
                // Check for character type and add proper index to sequence
                if (nucleotideBase == 'U' || nucleotideBase == 'u' || 
                    nucleotideBase == 'T' || nucleotideBase == 't') mappedSequence.Add(0);
                else if (nucleotideBase == 'C' || nucleotideBase == 'c') mappedSequence.Add(1);
                else if (nucleotideBase == 'A' || nucleotideBase == 'a') mappedSequence.Add(2);
                else if (nucleotideBase == 'G' || nucleotideBase == 'g') mappedSequence.Add(3);

                // Return an empty list if there is an invalid character
                else return Enumerable.Empty<int>().ToList();
            }

            // Return the mappedSequence
            return mappedSequence;
        }

        // Converts a mapped sequence and reverts it to 
        // user-friendly DNA base string
        public string RevertToDNA(List<int> mappedSequence)
        {
            // Create base string to be returned
            string bases = string.Empty;

            // Loop through the mappedSequence and translate
            // bases from numeric to text
            foreach (int nucleotideBase in mappedSequence)
            {
                if (nucleotideBase == 0) bases += "T";
                else if (nucleotideBase == 1) bases += "C";
                else if (nucleotideBase == 2) bases += "A";
                else if (nucleotideBase == 3) bases += "G";
            }

            // Return the string
            return bases;
        }

        // Converts a mapped sequence and reverts it to 
        // user-friendly RNA base string
        public string RevertToRNA(List<int> mappedSequence)
        {
            // Create base string to be returned
            string bases = string.Empty;

            // Loop through the mappedSequence and translate
            // bases from numeric to text
            foreach (int nucleotideBase in mappedSequence)
            {
                if (nucleotideBase == 0) bases += "U";
                else if (nucleotideBase == 1) bases += "C";
                else if (nucleotideBase == 2) bases += "A";
                else if (nucleotideBase == 3) bases += "G";
            }

            // Return the string
            return bases;
        }
    }
}