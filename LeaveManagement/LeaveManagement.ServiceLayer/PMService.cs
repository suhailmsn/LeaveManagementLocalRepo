using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using LeaveManagement.ViewModels;
using LeaveManagement.DataModels;
using LeaveManagement.Repositories;
using LeaveManagement.Repository.Interfaces;
using LeaveManagement.ServiceLayer.Interfaces;

namespace LeaveManagement.ServiceLayer
{

    public class PMService : IPMService
    {
        private readonly PMRepository _pmrepository;
        public PMService(PMRepository pmrepository)
        {
            _pmrepository = pmrepository;
        }

        public void LeaveApproval(LeaveViewModel lvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveViewModel,LeaveData>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveData l = mapper.Map<LeaveViewModel, LeaveData>(lvm);
            _pmrepository.LeaveApproval(l);
        }
        public LeaveViewModel ViewLeaveByLeaveID(int lid, string eid)
        {
            LeaveData l = _pmrepository.ViewLeaveByLeaveID(lid, eid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveData,LeaveViewModel> (); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveViewModel lvm = mapper.Map<LeaveData, LeaveViewModel>(l);
            return lvm;
        }
        public List<LeaveViewModel> ViewAllLeave(string eid)
        {
            List<LeaveData> l = _pmrepository.ViewAllLeave(eid);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveData, LeaveViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LeaveViewModel> lvm = mapper.Map<List<LeaveData>, List<LeaveViewModel>>(l);
            return lvm;

        }
    }
}