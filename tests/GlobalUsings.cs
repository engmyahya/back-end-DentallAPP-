global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Microsoft.Bot.Schema;
global using Telerik.JustMock;
global using System.Security.Claims;

global using DentallApp.Features.AvailabilityHours;
global using DentallApp.Features.AvailabilityHours.DTOs;
global using DentallApp.Features.Chatbot.Factories;
global using DentallApp.Features.WeekDays;
global using DentallApp.Features.AppointmentCancellation;
global using DentallApp.Features.AppointmentCancellation.DTOs;
global using DentallApp.Helpers.InstantMessaging;
global using DentallApp.Helpers.DateTimeHelpers;
global using DentallApp.Features.SecurityToken;
global using DentallApp.Features.Roles;
global using DentallApp.Features.Appointments;
global using DentallApp.Features.EmployeeSchedules;
global using DentallApp.Features.EmployeeSchedules.DTOs;
global using DentallApp.Features.GeneralTreatments;
global using DentallApp.Features.GeneralTreatments.DTOs;
global using DentallApp.Features.PublicHolidays.Offices;
global using DentallApp.Entities;
global using DentallApp.Configuration;

global using DentallApp.DataAccess.Repositories;
global using static DentallApp.Constants.ResponseMessages;