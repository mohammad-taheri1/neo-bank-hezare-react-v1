﻿using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDTO Execute(RequestEdituserDto request);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Execute(RequestEdituserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.FullName = request.Fullname;
            _context.SaveChanges();

            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }


    public class RequestEdituserDto
    {
        public long UserId { get; set; }
        public string Fullname { get; set; }
    }
}