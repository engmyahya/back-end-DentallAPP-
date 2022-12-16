﻿namespace DentallApp.Features.PersonalInformation;

public class PersonService : IPersonService
{
	private readonly IPersonRepository _personRepository;

	public PersonService(IPersonRepository personRepository)
	{
		_personRepository = personRepository;
	}

	public async Task<Response> CreatePersonAsync(PersonInsertDto personInsertDto)
	{
		_personRepository.Insert(personInsertDto.MapToPerson());
		await _personRepository.SaveAsync();

		return new Response
		{
			Success = true,
			Message = CreateResourceMessage
		};
	}
}
