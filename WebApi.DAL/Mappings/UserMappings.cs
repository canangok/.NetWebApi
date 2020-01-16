using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DAL.Mappings
{
  
    public class UserMappings : EntityTypeConfiguration<User>
    {
        public UserMappings()
        {
            ToTable("Users", "wepApi");
        }
    }
}
