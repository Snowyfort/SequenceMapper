using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.services.mapping
{
    public interface IMapping
    {
        List<int> MapBaseSequence(string sequence);
        string RevertToDNA(List<int> mappedSequence);
        string RevertToRNA(List<int> mappedSequence);
        string FormatAcids(List<string> aminoAcids);
    }
}