using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
	public class RoleAssignVM
	{
		//O anki kullanıcı bilgileri tutulacak.
		public int RoleId { get; set; }

		public string RoleName { get; set; }

		public bool HasAssign { get; set; } //o anki rolün kullanıcıya atanıp atanmadığının bilgisini tutar.
	}
}
