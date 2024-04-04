using Microsoft.EntityFrameworkCore;
using Neerogilksample.Data.Base;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data.Services
{
    public class NotificationService : EntityBaseRepository<Notification>, INotificationService
    {
        public NotificationService(AppDbContext context) : base(context) { }
    }
}







