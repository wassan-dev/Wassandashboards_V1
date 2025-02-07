using AutoMapper;
using Newtonsoft.Json;
using System.Text;
using Wassandashboard.Data;
using Wassandashboard.Data.Entities;
using Wassandashboard.Data.Services;
using static Wassandashboard.Data.Constants.Permissions;

namespace Wassandashboard.Services
{
    public class OdkDataPushService
    {
        private static SubmissionsService _service;
        private static DashboardDbContext _context;
        private static IMapper _mapper;

        // Initialize the SubmissionsService instance
        public OdkDataPushService(SubmissionsService service,
                                        DashboardDbContext context,
                                        IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }
    }
}
