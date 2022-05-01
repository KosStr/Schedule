using FluentEmail.Core;
using FluentEmail.Core.Models;
using Schedule.Business.Helpers.Interfaces;
using Schedule.Business.Services.Base;
using Schedule.Core.Configurations;
using Schedule.Core.DTO.Account;
using Schedule.Core.DTO.Email;
using Schedule.Core.Entities.Account;
using Schedule.Core.Helpers;
using Schedule.Database.Repository.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Schedule.Business.Helpers.Implementations
{
    internal class EmailHelper : ServiceBase, IEmailHelper
    {
        #region Properties

        private readonly IFluentEmail _fluentEmail;
        private readonly EmailSettings _emailSettings;

        #endregion

        #region Constructor

        public EmailHelper(IUnitOfWork unitOfWork, IFluentEmail fluentEmail, EmailSettings emailSettings) : base(unitOfWork)
        {
            _fluentEmail = fluentEmail;
            _emailSettings = emailSettings;
        }

        #endregion

        #region Interface Members

        public async Task<SendResponse> SendRegistrationEmailAsync(UserDto user)
        {
            var confirmationString = Guid.NewGuid().ToString();
            var letter = new ConfirmationMail(user.FirstName, user.LastName, confirmationString);

            var userEntity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Email == user.Email, i => i);
            userEntity.SetEmailToken(confirmationString, 24);

            await UnitOfWork.Repository<User>().UpdateAsync(userEntity);
            await UnitOfWork.SaveChangesAsync();

            return await _fluentEmail
                .To(user.Email)
                .Subject("Registration confirm")
                .UsingTemplateFromEmbedded(Constants.EmailTemplates.RegistrationMailPath, letter, Assembly.GetEntryAssembly())
                .SendAsync();
        }

        public async Task<SendResponse> SendPasswordChangeEmailAsync(UserDto user)
        {
            var userEntity = await UnitOfWork.Repository<User>().GetFirstAsync(i => i.Email == user.Email, i => i);
            if (userEntity.ActivatedDate == null)
            {
                // add Exception;
                return null;
            }
            else
            {
                var forgotLetter = new ConfirmationMail(user.FirstName, user.LastName, userEntity.EmailToken);
                userEntity.SetEmailToken(userEntity.EmailToken, 1);
                return await _fluentEmail
                .To(user.Email)
                .Subject("Passord change")
                .UsingTemplateFromEmbedded(Constants.EmailTemplates.ChangePasswordMailPath, forgotLetter, Assembly.GetEntryAssembly())
                .SendAsync();
            }
        }

        #endregion
    }
}
