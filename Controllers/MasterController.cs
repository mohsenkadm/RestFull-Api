using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull_Api.Models.IRepository;
using RestFull_Api.Models.Repository;

namespace RestFull_Api.Controllers
{
   
    abstract public class MasterController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public MasterController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
    }
}
