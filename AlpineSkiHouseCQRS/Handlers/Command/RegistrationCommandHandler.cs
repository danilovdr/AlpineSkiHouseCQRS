using AlpineSkiHouseCQRS.Commands;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using AlpineSkiHouseCQRS.Infrastructure;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Handlers.Command
{
    public class RegistrationCommandHandler : ICommandHandler<RegistrationCommand>
    {
        IRepository<UserModel> _userRepository;
        IUnitOfWork _unitOfWork;
        ArrayPool<byte> _pool;
        public RegistrationCommandHandler(IUnitOfWork unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
            _unitOfWork = unitOfWork;
            _pool = ArrayPool<byte>.Shared;
        }
        public async Task Handle(RegistrationCommand parametrs)
        {
            if (await IsUserExist(parametrs)) throw new UserAlreadyExistsException();

            var user = CreateUserModel(parametrs);


            try
            {
                _userRepository.Create(user);
                await _unitOfWork.Save();
            }
            catch (DbUpdateException ex)
            {
            }
        }

        private async Task<bool> IsUserExist(RegistrationCommand model)
        {
            return GetUser(model) != null;
        }

        private UserModel CreateUserModel(RegistrationCommand command)
        {
            var model = new UserModel();
            model.Email = command.Email;
            model.BirthDate = command.BirthDate;
            model.FirstName = command.FirstName;
            model.SecondName = command.SecondName;
            model.MiddleName = command.MiddleName;
            model.Salt = CreateSalt();
            model.Password = CreateHashedPassword(model.Salt, command.Password);
            return model;

        }
        private UserModel GetUser(RegistrationCommand command)
        {
            return _userRepository.Find(x => x.Email.Equals(command.Email)).FirstOrDefault();
        }

        private byte[] CreateSalt()
        {
            var arr = _pool.Rent(Constants.Authorization.BYTES_REQUESTED);
            RandomNumberGenerator.Create().GetBytes(arr);
            _pool.Return(arr);
            return arr;
        }

        private byte[] CreateHashedPassword(byte[] salt, string password)
        {
            return
                KeyDerivation.Pbkdf2(password, salt, Constants.Authorization.PRF, Constants.Authorization.ITERATION_COUNT, Constants.Authorization.BYTES_REQUESTED);
        }
    }
}
