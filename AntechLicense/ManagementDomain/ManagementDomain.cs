
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.ManagementDomain
{
    public interface IEntityBase
    {
        int Id { get; set; }
    }
    public interface IDeleteEntity : IEntityBase
    {
        bool IsDeleted { get; set; }
    }
    public interface IAuditEntity : IDeleteEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
