using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelProject.Core.DTOs;

namespace HotelProject.Service.Validations
{
    public class RoomDtoValidator : AbstractValidator<RoomDTO>
    {
        public RoomDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.BedCount)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
