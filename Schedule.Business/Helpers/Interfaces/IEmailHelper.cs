using FluentEmail.Core.Models;
using Schedule.Core.DTO.Account;
using System.Threading.Tasks;

namespace Schedule.Business.Helpers.Interfaces
{
    public interface IEmailHelper
    {
        Task<SendResponse> SendRegistrationEmailAsync(UserDto user);
        Task<SendResponse> SendPasswordChangeEmailAsync(UserDto user);
    }
}
