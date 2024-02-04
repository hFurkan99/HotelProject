using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelProject.Core.DTOs;

namespace HotelProject.Service.Validations
{
    public class SingleRoomDtoValidator : AbstractValidator<RoomDTO>
    {
        public SingleRoomDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.BedCount)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.Description).NotNull().WithMessage("{PropertyName} is required");
        }
    }

    public class RoomDtoValidator : AbstractValidator<List<RoomDTO>>
    {
        public RoomDtoValidator()
        {
            RuleForEach(x => x).SetValidator(new SingleRoomDtoValidator());
        }
    }
}
