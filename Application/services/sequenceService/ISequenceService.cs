using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.services.sequenceService
{
    public interface ISequenceService
    {
        List<int> GetComplementaryBases(List<int> mappedSequence);
        List<string> GetAcids(List<int> mappedSequence);
        List<string> GetAcids(List<int> mappedSequence, bool IsRNA);
    }
}