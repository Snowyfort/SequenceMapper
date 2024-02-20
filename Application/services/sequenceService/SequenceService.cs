using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.common;

namespace Application.services.sequenceService
{
    // Default implementation of the ISequenceService interface
    public class SequenceService : ISequenceService
    {
        private readonly Maps _maps = new Maps();

        // Gets the amino acids from the static string[,,] Map
        public List<string> GetAcids(List<int> mappedSequence)
        {
            // Create an empty List<string> to store amino acids
            List<string> aminoAcids = new List<string>();

            // Format the mappedSequence to it's complementary 
            // RNA bases if IsRNA is specified is false
            mappedSequence = GetComplementaryBases(mappedSequence);

            // Loop through the mappedSequence codons and find the
            // corresponding amino acids
            for (var i = 0; i < mappedSequence.Count; i++)
            {
                // Pass through the bases until get to end of codon
                if ((i + 1) % 3 == 0)
                {
                    // Get the amino acid string from the static Map
                    string acid = _maps.Default[mappedSequence[i - 2], mappedSequence[i - 1], mappedSequence[i]].ToString();
                    
                    // Add the amino acid to the end of the list
                    aminoAcids.Add(acid);
                }
            }

            // Return the populated aminoAcid List
            return aminoAcids;
        }

        // GetAcids overload method for RNA sequences
        // Does not require obtaining complementary sequence
        // as it is provided with the input
        public List<string> GetAcids(List<int> mappedSequence, bool IsRNA)
        {
            // Create an empty List<string> to store amino acids
            List<string> aminoAcids = new List<string>();

            // Format the mappedSequence to it's complementary 
            // RNA bases if IsRNA is specified is false
            if (!IsRNA) mappedSequence = GetComplementaryBases(mappedSequence);

            // Loop through the mappedSequence codons and find the
            // corresponding amino acids
            for (var i = 0; i < mappedSequence.Count; i++)
            {
                // Pass through the bases until get to end of codon
                if ((i + 1) % 3 == 0)
                {
                    // Get the amino acid string from the static Map
                    string acid = _maps.Default[mappedSequence[i - 2], mappedSequence[i - 1], mappedSequence[i]].ToString();
                    
                    // Add the amino acid to the end of the list
                    aminoAcids.Add(acid);
                }
            }

            // Return the populated aminoAcid List
            return aminoAcids;
        }

        public List<int> GetComplementaryBases(List<int> mappedSequence)
        {
            // Create an empty List<int> to store complementary bases
            List<int> complementaryBases = new List<int>();

            // Loop through the list and convert the bases
            foreach (int nucleotideBase in mappedSequence)
            {
                // Get complementary number
                if (nucleotideBase == 0) complementaryBases.Add(2);
                else if (nucleotideBase == 2) complementaryBases.Add(0);
                else if (nucleotideBase == 1) complementaryBases.Add(3);
                else if (nucleotideBase == 3) complementaryBases.Add(1);
            }

            // Return the populated complementaryBases list
            return complementaryBases;
        }
    }
}