using Microsoft.Extensions.Logging;
using OnlineBooking.BLL.Repository;
using OnlineBooking.Models;
using OnlineBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Services
{
    public class RoomService : IRoomService
    {
        private UnitOfWork _unitOfWork;
        ILogger<RoomService> _iLogger;

        public RoomService(UnitOfWork unitOfWork, ILogger<RoomService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _iLogger = iLogger;
        }

        public void DeleteRoom(int id)
        {
            var room = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(room);
            _unitOfWork.Save();
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();

            try
            {
                var rooms = _unitOfWork.GenericRepository<Room>()
                .GetAll(includeProperties: "RoomType")
                .ToList();

                // Convert the Room model list to RoomViewModel list
                vmList = ConvertModelToViewModelList(rooms);

                //int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                //var rooms = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties: "RoomType")
                //    .Skip(ExcludeRecords).Take(pageSize).ToList();
                //totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count();
                //vmList = ConvertModelToViewModelList(rooms);

            }
            catch (Exception)
            {
                throw;
            }

            //var result = new List<RoomViewModel>
            //{
            //    Data = vmList,
            //    TotalItems = totalCount,
            //    PageNumber = pageNumber,
            //    PageSize = pageSize

            //};

            return vmList;
        }

        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> room)
        {
            return room.Select(x => new RoomViewModel(x)).ToList();
        }

        public RoomViewModel GetRoom(int Id)
        {
            var room = _unitOfWork.GenericRepository<Room>().GetById(Id);
            var vm = new RoomViewModel(room);
            return vm;
        }

        public void InsertRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertModel(room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConvertModel(room);
            _unitOfWork.GenericRepository<Room>().Update(model);
            _unitOfWork.Save();
        }
    }
}
