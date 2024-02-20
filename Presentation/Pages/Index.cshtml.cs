using Application.services.mapping;
using Application.services.sequenceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.models;

namespace Presentation.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMapping _mapping;
    private readonly ISequenceService _sequenceService;

    public IndexModel(ILogger<IndexModel> logger, IMapping mapping, ISequenceService sequenceService)
    {
        _logger = logger;
        _mapping = mapping;
        _sequenceService = sequenceService;
    }

    // Stores the information for the front-end form
    [BindProperty]
    public NucleicAcid NucleicAcid { get; set; } = new NucleicAcid();
    // Stores the information to display on the front end
    // from the OnPost method
    [BindProperty]
    public string AminoAcids { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public void OnPost()
    {
        List<int> mappedAcids = _mapping.MapBaseSequence(NucleicAcid.Bases);
        List<string> aminoAcids = _sequenceService.GetAcids(mappedAcids, NucleicAcid.IsRNA);
        AminoAcids = _mapping.FormatAcids(aminoAcids);
    }
}
