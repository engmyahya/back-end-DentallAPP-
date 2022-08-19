﻿namespace DentallApp.Features.SpecificTreatments;

public interface ISpecificTreatmentService
{
    Task<IEnumerable<SpecificTreatmentGetDto>> GetSpecificTreatmentsByGeneralTreatmentIdAsync(int generalTreatmentId);
}
