using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles.Core.DTO.UserDto
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

}
